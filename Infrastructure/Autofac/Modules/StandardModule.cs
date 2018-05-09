using Autofac;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Autofac.Modules
{
   public class StandardModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(AssemblyExtension.GetExecutingAssemblies("JWTWebApiDemo"))
                .Where(e => !(e == typeof(GenericRepository<>)))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
