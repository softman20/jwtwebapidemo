﻿using Core.Authentication.LocalJwtBearer;
using Core.Helpers;
using Data.EF;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities
{
    public class GetLoginToken
    {

        public static TokenValidationParameters GetOptions(IConfigurationSection section)
        {
            LocalJwtBearerOptions jwtBearerOptions = new LocalJwtBearerOptions();
            section.Bind(jwtBearerOptions);

            RsaSecurityKey rsaKey = null;
            using (RSA rsa = RSA.Create())
            {
                rsa.FromXml(jwtBearerOptions.TokenValidationParameters.IssuerSigningKeyXml);
                rsaKey = new RsaSecurityKey(rsa);
            }

            return  new TokenValidationParameters
            {
                IssuerSigningKey = rsaKey,
                ValidateIssuerSigningKey = jwtBearerOptions.TokenValidationParameters.ValidateIssuerSigningKey,
                ValidAudience = jwtBearerOptions.Audience,
                ValidIssuer = jwtBearerOptions.TokenValidationParameters.ValidIssuer,
                ClockSkew = TimeSpan.Zero
            };

            //return new TokenValidationParameters
            //{
            //    Path = Configuration.Config.GetSection("TokenAuthentication:TokenPath").Value,
            //    Audience = Configuration.Config.GetSection("TokenAuthentication:Audience").Value,
            //    Issuer = Configuration.Config.GetSection("TokenAuthentication:Issuer").Value,
            //    Expiration = TimeSpan.FromMinutes(Convert.ToInt32(Configuration.Config.GetSection("TokenAuthentication:ExpirationMinutes").Value)),
            //    SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
            //};
        }

        public static string Execute(ApplicationUser user,  RefreshToken refreshToken = null)
        {
            //var options = GetOptions();
            //var now = DateTime.UtcNow;

            //var claims = new List<Claim>()
            //{
            //    new Claim(JwtRegisteredClaimNames.NameId, user.Id.ToString()),
            //    new Claim(JwtRegisteredClaimNames.Jti, user.Id.ToString()),
            //    new Claim(JwtRegisteredClaimNames.Iat, new DateTimeOffset(now).ToUniversalTime().ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64),
            //    new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
            //};

            //var userClaims = db.UserClaims.Where(i => i.UserId == user.Id);
            //foreach (var userClaim in userClaims)
            //{
            //    claims.Add(new Claim(userClaim.ClaimType, userClaim.ClaimValue));
            //}
            //var userRoles = db.UserRoles.Where(i => i.UserId == user.Id);
            //foreach (var userRole in userRoles)
            //{
            //    var role = db.Roles.Single(i => i.Id == userRole.RoleId);
            //    claims.Add(new Claim(Extensions.RoleClaimType, role.Name));
            //}

            //if (refreshToken == null)
            //{
            //    refreshToken = new RefreshToken()
            //    {
            //        UserId = user.Id,
            //        Token = Guid.NewGuid().ToString("N"),
            //    };
            //    db.InsertNew(refreshToken);
            //}

            //refreshToken.IssuedUtc = now;
            //refreshToken.ExpiresUtc = now.Add(options.Expiration);
            //db.SaveChanges();

            //var jwt = new JwtSecurityToken(
            //    issuer: options.Issuer,
            //    audience: options.Audience,
            //    claims: claims.ToArray(),
            //    notBefore: now,
            //    expires: now.Add(options.Expiration),
            //    signingCredentials: options.SigningCredentials);
            //var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            //var response = new LoginResponseData
            //{
            //    access_token = encodedJwt,
            //    refresh_token = refreshToken.Token,
            //    expires_in = (int)options.Expiration.TotalSeconds,
            //    userName = user.UserName,
            //    firstName = user.FirstName,
            //    lastName = user.LastName,
            //    isAdmin = claims.Any(i => i.Type == Extensions.RoleClaimType && i.Value == Extensions.AdminRole)
            //};
            return null;
        }
    }
}
