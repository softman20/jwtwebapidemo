using AutoMapper;
using IM.TCM.Core.Authentication.LocalJwtBearer;
using IM.TCM.Core.Authentication.SaintGobain;
using IM.TCM.Core.Helpers;
using IM.TCM.Data.Repositories.Interfaces;
using IM.TCM.Domain.Dtos;
using IM.TCM.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using IM.TCM.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using MoreLinq;

namespace IM.TCM.Services
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
        private readonly IUserAuthorizationRepository _userAuthorizationRepository;
        private readonly IBusinessUnitRepository _businessUnitRepository;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public ApplicationUserService(RoleManager<ApplicationRole> roleManager, IConfigurationRoot AppSettings, IHttpContextAccessor httpContextAccessor,
            IMapper mapper, UserManager<ApplicationUser> userManager, IApplicationUserRepository applicationUserRepository,
            IUserBusinessUnitRepository userBusinessUnitRepository, IUserAuthorizationRepository userAuthorizationRepository,
            IBusinessUnitRepository businessUnitRepository, IOptions<LocalJwtBearerOptions> localJwtBearerOptions)
            : base(applicationUserRepository)
        {
            _localJwtBearerOptions = localJwtBearerOptions.Value;
            _applicationUserRepository = applicationUserRepository;
            this._mapper = mapper;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _appSettings = AppSettings;
            _userBusinessUnitRepository = userBusinessUnitRepository;
            _userAuthorizationRepository = userAuthorizationRepository;
            _businessUnitRepository = businessUnitRepository;
            _roleManager = roleManager;
        }

        public IEnumerable<BusinessUnitDto> GetUserBUWithRolesByIDs(int userId, int[] BUids)
        {
            //var userBus = _userAuthorizationRepository.Find(where: e => e.UserId == userId && (BUids.Contains(e.BUId)||e.BUId==-1), include: e => e.Include(p => p.Role).Include(p => p.BusinessUnit));
            var userBus = _mapper.Map<IEnumerable<BusinessUnit>,IEnumerable<BusinessUnitDto>>( _businessUnitRepository.Find(where: e => BUids.Contains(e.Id)));

            foreach (var bu in userBus)
            {
                //fill roles
              // var a =  _userAuthorizationRepository.Find(include: ua => ua.Include(p => p.Role), where: ua => ua.UserId == userId && (ua.BUId == bu.Id|| ua.BUId==-1)).Select(e => e.Role.Name);
                bu.Roles = _userAuthorizationRepository.Find(include:ua=>ua.Include(p=>p.Role), where: ua => ua.UserId == userId && (ua.BUId == bu.Id || ua.BUId == -1)).Select(e => e.Role.Name);
                //if user has role All bu, add it
                //foreach (var role in _roleManager.Roles)
                //{

                //}
            }
            //return userBus.Select(e => 
            //new BusinessUnitDto { Id = e.Id, Code = e.Code, Name = e.Name, Roles =  && ua.BUId== userBus.Where(b=>b.BUId==e.BUId).Select(r => r.Role.Name).Distinct() });
            return userBus;
        }

        public IEnumerable<UserDto> GetAllUsers()
        {
            var allUsers = this._applicationUserRepository.Find(include: e => e.Include(p => p.Authorizations).ThenInclude(p => p.Role)
                                         .Include(p => p.Authorizations).ThenInclude(p => p.BusinessUnit)
                                         .Include(p => p.Authorizations).ThenInclude(p => p.CompanyCode)
                                         .Include(p => p.Authorizations).ThenInclude(p => p.ProcessType));

            return _mapper.Map<IEnumerable<ApplicationUser>, IEnumerable<UserDto>>(allUsers);
        }

        public UserDto GetUser(string sgId)
        {
            ApplicationUser IdentityUser = this._applicationUserRepository.Find(where: e => e.SgId == sgId, include: e => e.Include(p => p.Authorizations).ThenInclude(p => p.Role)
                                              .Include(p => p.Authorizations).ThenInclude(p => p.BusinessUnit)
                                              .Include(p => p.Authorizations).ThenInclude(p => p.CompanyCode)
                                              .Include(p => p.Authorizations).ThenInclude(p => p.ProcessType)).FirstOrDefault();

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
                newUser.Authorizations = null;
                //Create user
                await _userManager.CreateAsync(newUser);

                UserLoginInfo userLoginInfo = new UserLoginInfo(SaintGobainDefaults.LoginProvider, newUser.SgId, SaintGobainDefaults.DisplayName);
                //Create User Login
                await _userManager.AddLoginAsync(newUser, userLoginInfo);

                // add authorizations
                foreach (var authorization in user.Authorizations)
                {
                    _userAuthorizationRepository.Add(new UserAuthorization
                    {
                        UserId = newUser.Id,
                        BUId = authorization.BusinessUnit.Id,
                        RoleId = authorization.Role.Id,
                        CompanyId = authorization.CompanyCode.Id,
                        ProcessTypeId = authorization.ProcessTypeId
                    });
                }
                _userAuthorizationRepository.SaveChanges();


                return _mapper.Map<ApplicationUser, UserDto>(newUser);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public IEnumerable<int> ListBusinessUnits(ApplicationUser user)
        {
            IEnumerable<int> authorizedBUs = _userAuthorizationRepository.Find(where: ubu => ubu.UserId == user.Id).Select(e => e.BUId);
            if (authorizedBUs.Contains(-1))
                authorizedBUs = _businessUnitRepository.Find(where: e => e.Id != -1).Select(e => e.Id);
            return authorizedBUs.Distinct();
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

                //remove authorizations
                _userAuthorizationRepository.DeleteMulti(where: e => e.UserId == theUser.Id);
                _userAuthorizationRepository.SaveChanges();
                // add authorizations
                foreach (var authorization in user.Authorizations)
                {
                    _userAuthorizationRepository.Add(new UserAuthorization
                    {
                        UserId = theUser.Id,
                        BUId = authorization.BusinessUnit.Id,
                        RoleId = authorization.Role.Id,
                        CompanyId = authorization.CompanyCode.Id,
                        ProcessTypeId = authorization.ProcessTypeId
                    });
                }
                _userAuthorizationRepository.SaveChanges();
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

        public ClaimsPrincipal ValidateJwt(string currentToken, bool requireExpirationTime)
        {
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            if (handler.CanReadToken(currentToken))
            {
                TokenValidationParameters tokenValidationParameters = JWTBearerHelper.GetTokenValidationParameters(_appSettings.GetSection("JwtBearer"));
                tokenValidationParameters.ValidateLifetime = requireExpirationTime;

                return handler.ValidateToken(currentToken, tokenValidationParameters, out SecurityToken securityToken);
            }

            return null;
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
