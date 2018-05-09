using Autofac;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Autofac.Modules
{
  public  class ServiceModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(AssemblyExtension.GetExecutingAssemblies("Services"))
                .Where(a => a.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            //register identity services
            builder.RegisterType<UserManager<ApplicationUser>>().SingleInstance().InstancePerLifetimeScope();
            builder.RegisterType<SignInManager<ApplicationUser>>().SingleInstance().InstancePerLifetimeScope();
            builder.RegisterType<RoleManager<ApplicationRole>>().SingleInstance().InstancePerLifetimeScope();
        }
    }
}
