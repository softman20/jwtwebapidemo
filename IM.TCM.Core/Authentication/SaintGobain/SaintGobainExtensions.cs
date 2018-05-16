using System;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace IM.TCM.Core.Authentication.SaintGobain
{
    public static class SaintGobainExtensions
    {

        public static AuthenticationBuilder AddSaintGobain(this AuthenticationBuilder builder)
            => builder.AddSaintGobain(SaintGobainDefaults.AuthenticationScheme, _ => { });

        public static AuthenticationBuilder AddSaintGobain(this AuthenticationBuilder builder, Action<SaintGobainOptions> configureOptions)
            => builder.AddSaintGobain(SaintGobainDefaults.AuthenticationScheme, configureOptions);

        public static AuthenticationBuilder AddSaintGobain(this AuthenticationBuilder builder, string authenticationScheme, Action<SaintGobainOptions> configureOptions)
            => builder.AddSaintGobain(authenticationScheme, SaintGobainDefaults.DisplayName, configureOptions);

        public static AuthenticationBuilder AddSaintGobain(this AuthenticationBuilder builder, string authenticationScheme, string displayName, Action<SaintGobainOptions> configureOptions)
            => builder.AddOAuth<SaintGobainOptions, SaintGobainHandler>(authenticationScheme, displayName, configureOptions);

        public static AuthenticationBuilder AddSaintGobain(this AuthenticationBuilder builder, IConfigurationSection section)
        {
            SaintGobainOptions saintGobainOptions = new SaintGobainOptions();
            section.Bind(saintGobainOptions);

            if (saintGobainOptions != null)
            {

                builder.Services.Configure<SaintGobainOptions>(section);

                return builder.AddSaintGobain(options =>
                {
                    options.ClientId = saintGobainOptions.ClientId;
                    options.ClientSecret = saintGobainOptions.ClientSecret;
                    options.SaveTokens = true;
                });
            }
            else
            {
                return builder.AddSaintGobain();
            }
        }
    }
}
