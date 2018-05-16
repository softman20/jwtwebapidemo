using System;
using System.Collections.Generic;
using System.Text;

namespace IM.TCM.Core.Authentication.LocalJwtBearer
{
    public class LocalJwtBearerOptions
    {
        public bool RequireHttpsMetadata { get; set; } = true;

        /// <summary>
        /// Gets or sets the audience for any received OpenIdConnect token.
        /// </summary>
        public string Audience { get; set; }

        /// <summary>
        /// Gets or sets the parameters used to validate identity tokens.
        /// </summary>
        /// <remarks>Contains the types and definitions required for validating a token.</remarks>
        /// <exception cref="ArgumentNullException">if 'value' is null.</exception>
        public LocalTokenValidationParameters TokenValidationParameters { get; set; } = new LocalTokenValidationParameters();

    }
}
