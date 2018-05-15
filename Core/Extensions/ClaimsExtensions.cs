using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Core.Extensions
{
    public static class ClaimsExtensions
    {
        public static void AddUpdateClaim(this ClaimsIdentity claimIdentity, string key, string value)
        {
            if (claimIdentity == null)
                return;

            // check for existing claim and remove it
            var existingClaim = claimIdentity.FindFirst(key);
            if (existingClaim != null)
            {
                claimIdentity.RemoveClaim(existingClaim);
            }

            // add new claim
            claimIdentity.AddClaim(new Claim(key, value));
        }

        public static string GetClaimValue(this ClaimsIdentity claimIdentity, string key)
        {
            if (claimIdentity == null)
                return null;

            var claim = claimIdentity.Claims.FirstOrDefault(c => c.Type == key);
            return claim.Value;
        }
    }
}
