using IM.TCM.Core.Helpers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace IM.TCM.Core.Authentication.LocalJwtBearer
{
     public static class LocalJwtBearerExtensions
    {
        public static AuthenticationBuilder AddLocalJwtBearer(this AuthenticationBuilder authenticationBuilder, IConfigurationSection section)
        {
            LocalJwtBearerOptions jwtBearerOptions = new LocalJwtBearerOptions();
            section.Bind(jwtBearerOptions);
            
            TokenValidationParameters tokenValidationParameters = JWTBearerHelper.GetTokenValidationParameters(section);

            authenticationBuilder
                .AddJwtBearer(options => {
                    options.Audience = jwtBearerOptions.Audience;
                    options.RequireHttpsMetadata = jwtBearerOptions.RequireHttpsMetadata;
                    options.TokenValidationParameters = tokenValidationParameters;
                }).Services.Configure<LocalJwtBearerOptions>(section);

            return authenticationBuilder;
        }   
    }
}
