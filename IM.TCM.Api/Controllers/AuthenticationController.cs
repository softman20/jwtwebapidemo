using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IM.TCM.Core.Authentication.SaintGobain;
using IM.TCM.Core.Extensions;
using IM.TCM.Domain.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using IM.TCM.Services.Interfaces;
using System.Dynamic;

namespace IM.TCM.Api.Controllers
{

    public class AuthenticationController : Controller
    {
        private readonly string _webApplicationUrl;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IApplicationUserService _applicationUserService;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public AuthenticationController(RoleManager<ApplicationRole> roleManager, IConfigurationRoot AppSettings, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IApplicationUserService applicationUserService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _applicationUserService = applicationUserService;
            _webApplicationUrl = AppSettings["WebApplicationUrl"];
        }
        [HttpGet]
        [AllowAnonymous]
        [Route("login")]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            var info = await _signInManager.GetExternalLoginInfoAsync();
            string loginCallbackUrl = Url.RouteUrl("LoginCallback", new { ReturnUrl = returnUrl });

            if (info != null)
            {
                return Redirect(loginCallbackUrl);
            }

            AuthenticationProperties authProperties = _signInManager.ConfigureExternalAuthenticationProperties(SaintGobainDefaults.DisplayName, loginCallbackUrl);
            return new ChallengeResult(SaintGobainDefaults.AuthenticationScheme, authProperties);
        }

        [HttpGet]
        [Route("login-callback", Name = "LoginCallback")]
        public async Task<IActionResult> LoginCallback(string returnUrl = null,string switchSgId=null)
        {
            string sgId=string.Empty;
            ExternalLoginInfo externalLoginInfo = await _signInManager.GetExternalLoginInfoAsync();

            if (string.IsNullOrEmpty(switchSgId))
            {               
                sgId = externalLoginInfo.Principal.FindFirstValue(ClaimTypes.NameIdentifier);

                if (string.IsNullOrEmpty(sgId))
                {
                    return Unauthorized();
                }

                await _signInManager.UpdateExternalAuthenticationTokensAsync(externalLoginInfo);
            }
            else sgId = switchSgId;
            ApplicationUser user = await _userManager.FindByLoginAsync(SaintGobainDefaults.DisplayName, sgId);
            //create roles
            //if (!await _roleManager.RoleExistsAsync("Administrator"))
            //    await _roleManager.CreateAsync(new ApplicationRole() { Name = "Administrator" });
            //if (!await _roleManager.RoleExistsAsync("Provider 1"))
            //    await _roleManager.CreateAsync(new ApplicationRole() { Name = "Provider 1" });
            //if (!await _roleManager.RoleExistsAsync("Provider 2"))
            //    await _roleManager.CreateAsync(new ApplicationRole() { Name = "Provider 2" });
            //if (!await _roleManager.RoleExistsAsync("Validator"))
            //    await _roleManager.CreateAsync(new ApplicationRole() { Name = "Validator" });
            //if (!await _roleManager.RoleExistsAsync("Accountant"))
            //    await _roleManager.CreateAsync(new ApplicationRole() { Name = "Accountant" });
            //if (!await _roleManager.RoleExistsAsync("Viewer"))
            //    await _roleManager.CreateAsync(new ApplicationRole() { Name = "Viewer" });

            if (user == null && string.IsNullOrEmpty(switchSgId))
            {     
                user = new ApplicationUser
                {
                    SgId = sgId,
                    UserName = sgId,
                    FirstName = externalLoginInfo.Principal.FindFirstValue(ClaimTypes.GivenName),
                    LastName = externalLoginInfo.Principal.FindFirstValue(ClaimTypes.Name).IndexOf(",") > 0 ? externalLoginInfo.Principal.FindFirstValue(ClaimTypes.Name).Substring(0, externalLoginInfo.Principal.FindFirstValue(ClaimTypes.Name).IndexOf(",")) : externalLoginInfo.Principal.FindFirstValue(ClaimTypes.Name),
                    Email = externalLoginInfo.Principal.FindFirstValue(ClaimTypes.Email)
                };

                //Create user
                await _userManager.CreateAsync(user);

                //add roles
                  await _userManager.AddToRoleAsync(user, "Administrator" );

                //Create User Login
                await _userManager.AddLoginAsync(user, externalLoginInfo);
            }
           

            ClaimsIdentity externalClaimIdentity = externalLoginInfo!=null && string.IsNullOrEmpty(switchSgId) ? externalLoginInfo.Principal.Identity as ClaimsIdentity:null;
            ClaimsIdentity claimIdentity = await GetClaimIdentity(user, externalClaimIdentity);

            //Create JWT token
            string token = _applicationUserService.CreateJwt(claimIdentity.Claims);

            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized();
            }

            //sign in 
            QueryBuilder query = new QueryBuilder
            {
                { "token", token }
            };
           
            if (!string.IsNullOrEmpty(returnUrl))
            {
                query.Add("returnurl", returnUrl);
            }

            return Redirect(_webApplicationUrl + query.ToQueryString());
        }

        private async Task<ClaimsIdentity> GetClaimIdentity(ApplicationUser user, ClaimsIdentity initClaimIdentity)
        {
            ClaimsIdentity claimIdentity = initClaimIdentity != null ? initClaimIdentity.Clone() : new ClaimsIdentity();

            //if no sso claims, create them from db
            if (initClaimIdentity == null)
            {
                claimIdentity.AddClaim(new Claim(ClaimTypes.Email, user.Email));
                claimIdentity.AddClaim(new Claim(ClaimTypes.Name, user.LastName));
                claimIdentity.AddClaim(new Claim(ClaimTypes.GivenName, user.FirstName));
                claimIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.SgId));
            }
            claimIdentity.AddUpdateClaim("ID",user.Id.ToString());

            //Add roles

            var userRoles = await _userManager.GetRolesAsync(user);
            foreach (string roleName in userRoles)
            {
                claimIdentity.AddClaim(new Claim(ClaimTypes.Role, roleName));
            }
          //  externalLoginInfo.Principal.AddIdentity(claimIdentity);

            //Add business units
            IEnumerable<int> userBus = _applicationUserService.ListBusinessUnits(user);
            foreach (var userBu in userBus)
            {
                Claim claimBu = new Claim("businessUnits", userBu.ToString());
                claimIdentity.AddClaim(claimBu);
            }

            claimIdentity.AddUpdateClaim(ClaimTypes.NameIdentifier, user.SgId);
            claimIdentity.AddUpdateClaim("sgid", user.UserName);
            claimIdentity.AddUpdateClaim("gender", user.Gender);
            claimIdentity.AddUpdateClaim("validAvatar", user.ValidAvatar.ToString());
            claimIdentity.AddUpdateClaim("isSuperAdmin", user.IsSuperAdmin.ToString());
            return claimIdentity;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
            return Ok();
        }

        [HttpGet("{token}")]
        [Route("refreshToken")]
        [AllowAnonymous]
        public async Task<IActionResult> RefreshToken(string token)
        {
            ClaimsPrincipal principal = _applicationUserService.ValidateJwt(token, false);
            if (principal != null)
            {
                string userSgId = principal.FindFirstValue(ClaimTypes.NameIdentifier);
                ClaimsIdentity currentClaimIdentity = principal.Identity as ClaimsIdentity;
                ApplicationUser currentUser = await _userManager.FindByLoginAsync(SaintGobainDefaults.DisplayName, userSgId);
              
                ClaimsIdentity newClaimIdentity = await GetClaimIdentity(currentUser, currentClaimIdentity);
                string refreshToken = _applicationUserService.CreateJwt(newClaimIdentity.Claims);
                //dynamic newToken = new ExpandoObject();
                //newToken.token = refreshToken;
                return Ok(refreshToken);
            }

            return BadRequest();
        }


        [Route("api/GetUserClaims")]
        [HttpGet]
        public User GetUserClaims()
        {
            var identityClaims = (ClaimsIdentity)User.Identities;
            IEnumerable<Claim> claims = identityClaims.Claims;
            User user = new User()
            {
                Name = identityClaims.FindFirst("Username").Value,
                Email = identityClaims.FindFirst("Email").Value
            };
            return user;
        }
    }
}