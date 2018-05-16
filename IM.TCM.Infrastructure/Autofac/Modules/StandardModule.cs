using Autofac;
using IM.TCM.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace IM.TCM.Infrastructure.Autofac.Modules
{
   public class StandardModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(AssemblyExtension.GetExecutingAssemblies("IM.TCM.Api"))
                .Where(e => !(e == typeof(GenericRepository<>)))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
