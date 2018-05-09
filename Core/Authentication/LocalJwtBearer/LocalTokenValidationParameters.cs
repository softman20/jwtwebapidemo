using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Authentication.LocalJwtBearer
{
    public class LocalTokenValidationParameters : TokenValidationParameters
    {
        /// <summary>
        /// Gets or sets the Signing key Xml used for signature validation.
        /// </summary>
        public string IssuerSigningKeyXml { get; set; }

        /// <summary>
        /// Gets or sets the Signing Credentials Xml used for signature creation.
        /// </summary>
        public string SigningCredentialsXml { get; set; }
    }
}
