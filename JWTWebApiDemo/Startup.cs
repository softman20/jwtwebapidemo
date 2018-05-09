using System.IO;
using Exceptionless;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Microsoft.EntityFrameworkCore;
using Data.EF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Newtonsoft.Json.Serialization;
using Autofac.Extensions.DependencyInjection;
using Autofac;
using Infrastructure.Autofac.Modules;
using System;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Core.Authentication.SaintGobain;
using Core.Authentication.LocalJwtBearer;
using AutoMapper;
using Core.Extensions;
using Microsoft.AspNetCore.Http;


namespace JWTWebApiDemo
{
    public class Startup
    {
        /// <summary>
        /// AppSettings
        /// </summary>
        public IConfigurationRoot AppSettings { get; }
        public IContainer ApplicationContainer { get; private set; }
        public Startup(IHostingEnvironment env)
        {
           

            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);
          

            //serilog
            var logFile = Path.Combine(env.ContentRootPath+"/log/", $"log.{env.EnvironmentName}_.txt");
            Log.Logger = new LoggerConfiguration().MinimumLevel.Warning().WriteTo.File(logFile, rollingInterval: RollingInterval.Day).CreateLogger();

            AppSettings = builder.Build();

        }
         

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            //Add AppSettings root
            services.AddSingleton(AppSettings);

           
            services.AddDbContext<JWTDemoContext>(options =>
                  options.UseSqlServer(AppSettings["ConnectionStrings:JWTWebApiDemoContext"]));

            services.AddIdentity<ApplicationUser, ApplicationRole>()
              .AddEntityFrameworkStores<JWTDemoContext>()
              .AddDefaultTokenProviders();


            //string secretKey = "HilelHilelHilelHilelHilelHilelHilelHilelHilelHilel";
            //var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            //{
            //    options.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuer = true,
            //        ValidateAudience = true,
            //        ValidateIssuerSigningKey = true,
            //        ValidIssuer = "hilel.com",
            //        ValidAudience = "hilel.com",
            //        IssuerSigningKey = key

            //    };
            //});

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
             .AddSaintGobain(AppSettings.GetSection("OAuth"))
             .AddLocalJwtBearer(AppSettings.GetSection("JwtBearer"));

            //.AddJwtBearer(options =>
            //{
            //    options.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuer = true,
            //        ValidateAudience = true,
            //        ValidateIssuerSigningKey = true,
            //        ValidIssuer = "hilel.com",
            //        ValidAudience = "hilel.com",
            //        IssuerSigningKey = key

            //    };
            //})
            ;

            services.AddLogging();
            //services.AddScoped<IUserService, UserService>()
            //        .AddScoped<IUserRepository,UserRepository>();
            
            services.AddMvc()
                .AddControllersAsServices()
                .AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add(new CorsAuthorizationFilterFactory("AllowSpecificOrigin"));
            });


            services.CreateMapping();
            services.AddAutoMapper();
            // Add MemoryCache
            services.AddMemoryCache();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder.WithOrigins(AppSettings["WebApplicationUrl"])
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                  );
            });

            var iocBuilder = new Autofac.ContainerBuilder();
            iocBuilder.Populate(services);
            iocBuilder.RegisterModule<EFModule>();
            iocBuilder.RegisterModule<RepositoryModule>();
            iocBuilder.RegisterModule<StandardModule>();
            iocBuilder.RegisterModule<ServiceModule>();
            ApplicationContainer = iocBuilder.Build();
         
            return new AutofacServiceProvider(ApplicationContainer);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory
            , IApplicationLifetime appLifetime)
        {

           loggerFactory.AddConsole(AppSettings.GetSection("Logging"));

            loggerFactory.AddDebug();

            loggerFactory.AddSerilog();
            string a = AppSettings.GetSection("ExceptionLessParams").GetValue<string>("ExceptionLessApiKey");

            app.UseExceptionless(AppSettings.GetSection("ExceptionLessParams").GetValue<string>("ExceptionLessApiKey"));


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();
         //   app.UseIdentity();

            app.UseMvc();
            app.UseCors("AllowSpecificOrigin");

            appLifetime.ApplicationStopped.Register(() => ApplicationContainer.Dispose());
        }
    }
}
