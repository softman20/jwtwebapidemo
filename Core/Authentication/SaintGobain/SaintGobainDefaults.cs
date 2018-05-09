using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Authentication.SaintGobain
{
    public static class SaintGobainDefaults
    {
        public const string AuthenticationScheme = "SaintGobain";
        public static readonly string DisplayName = "Saint-Gobain";
        public static readonly string LoginProvider = "Saint-Gobain";
        public static readonly string AuthorizationEndpoint = "https://cloudsso.saint-gobain.com/openam/oauth2/authorize";
        public static readonly string TokenEndpoint = "https://cloudsso.saint-gobain.com/openam/oauth2/access_token";
        public static readonly string UserInformationEndpoint = "https://cloudsso.saint-gobain.com/openam/oauth2/tokeninfo";
    }
}
