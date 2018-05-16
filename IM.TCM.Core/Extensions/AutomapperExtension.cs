using AutoMapper;
using IM.TCM.Core.Utilities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace IM.TCM.Core.Extensions
{
    public static class AutomapperExtension
    {
        /// <summary>
        /// Create Mapping
        /// </summary>
        /// <param name="services"></param>
        public static void CreateMapping(this IServiceCollection services)
        {
            // Add AutoMapper
            var config = new MapperConfiguration(c =>
            {
                c.AddProfile(new ApplicationProfile());
                

            });
            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
