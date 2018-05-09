using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Core.Authentication.SaintGobain
{
    public class SaintGobainOptions : OAuthOptions
    {
        /// <summary>
        /// Initializes a new <see cref="SaintGobainOptions"/>.
        /// </summary>
        public SaintGobainOptions()
        {
            CallbackPath = new PathString("/signin-saintgobain");
            AuthorizationEndpoint = SaintGobainDefaults.AuthorizationEndpoint;
            TokenEndpoint = SaintGobainDefaults.TokenEndpoint;
            UserInformationEndpoint = SaintGobainDefaults.UserInformationEndpoint;
            Scope.Add("mail");
            Scope.Add("sn");
            Scope.Add("stGoSGI");
            Scope.Add("givenName");

            ClaimActions.MapJsonKey(ClaimTypes.Email, "mail");
            ClaimActions.MapJsonKey(ClaimTypes.Name, "sn");
            ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "stGoSGI");
            ClaimActions.MapJsonKey(ClaimTypes.GivenName, "givenName");
            ClaimActions.MapJsonKey(ClaimTypes.Expiration, "expires_in");
        }
    }
}
