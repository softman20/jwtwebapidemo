using IM.TCM.Core.Authentication.LocalJwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace IM.TCM.Core.Helpers
{
    public static class JWTBearerHelper
    {
        public static TokenValidationParameters GetTokenValidationParameters(IConfiguration JwtBearerConfig)
        {
            LocalJwtBearerOptions jwtBearerOptions = new LocalJwtBearerOptions();
            JwtBearerConfig.Bind(jwtBearerOptions);

            RsaSecurityKey rsaKey = null;
            using (RSA rsa = RSA.Create())
            {
                rsa.FromXml(jwtBearerOptions.TokenValidationParameters.IssuerSigningKeyXml);
                rsaKey = new RsaSecurityKey(rsa);
            }

            var tokenValidationParameters = new TokenValidationParameters
            {
                IssuerSigningKey = rsaKey,
                ValidateIssuerSigningKey = jwtBearerOptions.TokenValidationParameters.ValidateIssuerSigningKey,
                ValidAudience = jwtBearerOptions.Audience,
                ValidIssuer = jwtBearerOptions.TokenValidationParameters.ValidIssuer,
                ClockSkew = TimeSpan.Zero
            };

            return tokenValidationParameters;

        }
    }
}
