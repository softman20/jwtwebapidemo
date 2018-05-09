using Core.Utilities;
using Data.Repositories;
using Data.Repositories.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Authentication
{
    public class RefreshTokenProviderMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly JsonSerializerSettings _serializerSettings;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IRefreshTokenRepository _refreshTokenRepository;

        public RefreshTokenProviderMiddleware(
                    RequestDelegate next, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
                    IRefreshTokenRepository refreshTokenRepository)
        {
            _next = next;
         
            _serializerSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };

            _signInManager = signInManager;
            _userManager = userManager;
            _refreshTokenRepository = refreshTokenRepository;
        }

        public Task Invoke(HttpContext context)
        {
            // If the request path doesn't match, skip
            if (!context.Request.Path.Equals("api/refresh", StringComparison.Ordinal))
            {
                return _next(context);
            }

            // Request must be POST with Content-Type: application/x-www-form-urlencoded
            if (!context.Request.Method.Equals("POST")
               || !context.Request.HasFormContentType)
            {
                context.Response.StatusCode = 400;
                return context.Response.WriteAsync("Bad request.");
            }

            return GenerateToken(context);
        }

        private async Task GenerateToken(HttpContext context)
        {
            var refreshToken = context.Request.Form["refreshToken"].ToString();
            if (string.IsNullOrWhiteSpace(refreshToken))
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("User must relogin.");
                return;
            }

            //var db = context.RequestServices.GetService();
            // var signInManager = context.RequestServices.GetService & lt; SignInManager & lt; ApplicationUser &gt; => ();
            // var userManager = context.RequestServices.GetService & lt; UserManager & lt; ApplicationUser &gt; => ();

            var refreshTokenModel = _refreshTokenRepository.GetToken(refreshToken);
               
            if (refreshTokenModel == null)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("User must relogin.");
                return;
            }

            if (!await _signInManager.CanSignInAsync(refreshTokenModel.User))
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("User is unable to login.");
                return;
            }

            if (_userManager.SupportsUserLockout && await _userManager.IsLockedOutAsync(refreshTokenModel.User))
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("User is locked out.");
                return;
            }

            var user = refreshTokenModel.User;
            var token =  GetLoginToken.Execute(user, refreshTokenModel);
            context.Response.ContentType = "application / json " ;
            await context.Response.WriteAsync(JsonConvert.SerializeObject(token, _serializerSettings));
        }

    }
}
