﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Core.Authentication.SaintGobain;
using Domain.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Services.Interfaces;

namespace JWTWebApiDemo.Controllers
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
        public async Task<IActionResult> LoginCallback(string returnUrl = null)
        {
            ExternalLoginInfo externalLoginInfo = await _signInManager.GetExternalLoginInfoAsync();
            string sgId = externalLoginInfo.Principal.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(sgId))
            {
                return Unauthorized();
            }

            await _signInManager.UpdateExternalAuthenticationTokensAsync(externalLoginInfo);

            ApplicationUser user = await _userManager.FindByLoginAsync(SaintGobainDefaults.DisplayName, sgId);
            //create roles
            if (!await _roleManager.RoleExistsAsync("Administrator"))
                await _roleManager.CreateAsync(new ApplicationRole() { Name = "Administrator" });
            if (!await _roleManager.RoleExistsAsync("Provider 1"))
                await _roleManager.CreateAsync(new ApplicationRole() { Name = "Provider 1" });
            if (!await _roleManager.RoleExistsAsync("Provider 2"))
                await _roleManager.CreateAsync(new ApplicationRole() { Name = "Provider 2" });
            if (!await _roleManager.RoleExistsAsync("Validator"))
                await _roleManager.CreateAsync(new ApplicationRole() { Name = "Validator" });
            if (!await _roleManager.RoleExistsAsync("Accountant"))
                await _roleManager.CreateAsync(new ApplicationRole() { Name = "Accountant" });
            if (!await _roleManager.RoleExistsAsync("Viewer"))
                await _roleManager.CreateAsync(new ApplicationRole() { Name = "Viewer" });

            if (user == null)
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

                //Create User Login
                await _userManager.AddLoginAsync(user, externalLoginInfo);
            }
            //Add roles
            ClaimsIdentity claimIdentity = new ClaimsIdentity();
            var userRoles = await _userManager.GetRolesAsync(user);
            foreach (string roleName in userRoles)
            {
                claimIdentity.AddClaim(new Claim(ClaimTypes.Role, roleName));
            }
            externalLoginInfo.Principal.AddIdentity(claimIdentity);

            
            //Create JWT token
            string token = _applicationUserService.CreateJwt(externalLoginInfo.Principal.Claims);

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
        public IActionResult RefreshToken(string token)
        {
            string newToken = _applicationUserService.RefreshToken(token);
            return Ok(newToken);
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