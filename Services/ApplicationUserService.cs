using AutoMapper;
using Core.Authentication.LocalJwtBearer;
using Core.Authentication.SaintGobain;
using Core.Helpers;
using Data.Repositories.Interfaces;
using Domain.Dtos;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Services
{
    public class ApplicationUserService : BaseService<ApplicationUser>, IApplicationUserService
    {
        private readonly LocalJwtBearerOptions _localJwtBearerOptions;
        private readonly IApplicationUserRepository _applicationUserRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IConfigurationRoot _appSettings;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserBusinessUnitRepository _userBusinessUnitRepository;

        public ApplicationUserService(IConfigurationRoot AppSettings, IHttpContextAccessor httpContextAccessor,
            IMapper mapper, UserManager<ApplicationUser> userManager, IApplicationUserRepository applicationUserRepository,
            IUserBusinessUnitRepository userBusinessUnitRepository, IOptions<LocalJwtBearerOptions> localJwtBearerOptions)
            : base(applicationUserRepository)
        {
            _localJwtBearerOptions = localJwtBearerOptions.Value;
            _applicationUserRepository = applicationUserRepository;
            this._mapper = mapper;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _appSettings = AppSettings;
            _userBusinessUnitRepository = userBusinessUnitRepository;
        }

        public IEnumerable<UserDto> GetAllUsers()
        {
            var allUsers = this._applicationUserRepository.GetQuery().Include(p => p.UserRoles).ThenInclude(p => p.Role)
                                        .Include(p => p.UserBusinessUnits).ThenInclude(p => p.BusinessUnit);

            return _mapper.Map<IEnumerable<ApplicationUser>, IEnumerable<UserDto>>(allUsers);
        }

        public UserDto GetUser(string sgId)
        {
            ApplicationUser IdentityUser = this._applicationUserRepository.Find(where: e => e.SgId == sgId, include: ps => ps.Include(p => p.UserRoles).ThenInclude(p => p.Role)
                                            .Include(p => p.UserBusinessUnits).ThenInclude(p => p.BusinessUnit)).FirstOrDefault();

            return _mapper.Map<ApplicationUser, UserDto>(IdentityUser);
        }

        public async Task<UserDto> AddUserAsync(UserDto user)
        {
            try
            {
                ApplicationUser newUser = _mapper.Map<UserDto, ApplicationUser>(user);

                newUser.CreatedDate = DateTime.Now;
                newUser.UserName = user.SgId.ToUpper();
                newUser.CreatedBy = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                newUser.IsActive = true;

                //Create user
                await _userManager.CreateAsync(newUser);
                //add roles
                await _userManager.AddToRolesAsync(newUser, user.Roles);

                //add BUs
                _userBusinessUnitRepository.AddBusinessUnitToUser(newUser.Id, user.BusinessUnitsId);

                UserLoginInfo userLoginInfo = new UserLoginInfo(SaintGobainDefaults.LoginProvider, newUser.SgId, SaintGobainDefaults.DisplayName);
                //Create User Login
                await _userManager.AddLoginAsync(newUser, userLoginInfo);


                return _mapper.Map<ApplicationUser, UserDto>(newUser);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

       public IEnumerable<UserBusinessUnit> ListBusinessUnits(ApplicationUser user)
        {
            return _userBusinessUnitRepository.Find(where: ubu => ubu.UserId == user.Id);
        }

        public async Task UpdateUserAsync(UserDto user)
        {
            ApplicationUser theUser = await _userManager.FindByLoginAsync(SaintGobainDefaults.LoginProvider, user.SgId);
            if (theUser != null)
            {
                theUser.FirstName = user.FirstName;
                theUser.LastName = user.LastName;
                theUser.Email = user.Email;

                IdentityResult result = await _userManager.UpdateAsync(theUser);

                if (user.Roles.Count() > 0)
                {
                    //delete old roles
                    var userRoles = await _userManager.GetRolesAsync(theUser);
                    await _userManager.RemoveFromRolesAsync(theUser, userRoles);
                    //update roles
                    await _userManager.AddToRolesAsync(theUser, user.Roles);
                }

                //remove BU add param
                //add BUs
                if (user.BusinessUnitsId.Count() > 0)
                    _userBusinessUnitRepository.AddBusinessUnitToUser(theUser.Id, user.BusinessUnitsId, true);



            }
        }

        public async Task DeleteUserAsync(string sgId)
        {
            ApplicationUser user = await _userManager.FindByLoginAsync(SaintGobainDefaults.LoginProvider, sgId);
            if (user != null)
            {
                await _userManager.DeleteAsync(user);
            }
        }

        public string RefreshToken(string currentToken)
        {
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            try
            {
                if (handler.CanReadToken(currentToken))
                {
                    TokenValidationParameters tokenValidationParameters = JWTBearerHelper.GetTokenValidationParameters(_appSettings.GetSection("JwtBearer"));

                    ClaimsPrincipal principal = handler.ValidateToken(currentToken, tokenValidationParameters, out SecurityToken securityToken);

                    //if we came here the current token is valid
                    return currentToken;
                }
            }
            catch (SecurityTokenExpiredException)
            {
                //here the token is valid but expired
                var decodedToken = handler.ReadToken(currentToken) as JwtSecurityToken;
                return this.CreateJwt(decodedToken.Claims.Where(e => e.Type.StartsWith("http")));
            }
            catch (Exception)
            {
                return string.Empty;
            }
            return string.Empty;
        }



        public string CreateJwt(IEnumerable<Claim> claims)
        {
            RsaSecurityKey rsaPrivateKey = null;
            using (RSA rsa = RSA.Create())
            {
                rsa.FromXml(_localJwtBearerOptions.TokenValidationParameters.SigningCredentialsXml);
                rsaPrivateKey = new RsaSecurityKey(rsa);
            }

            var signinCredentials = new SigningCredentials(rsaPrivateKey, SecurityAlgorithms.RsaSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _localJwtBearerOptions.TokenValidationParameters.ValidIssuer,
                audience: _localJwtBearerOptions.Audience,
                expires: DateTime.Now.AddSeconds(3600),
                claims: claims,
                signingCredentials: signinCredentials
            );

            if (jwtSecurityToken == null)
            {
                throw new Exception("ApplicationUserService - CreateJwt - Can't generate security token");
            }

            var handler = new JwtSecurityTokenHandler();
            return handler.WriteToken(jwtSecurityToken);
        }
    }
}
