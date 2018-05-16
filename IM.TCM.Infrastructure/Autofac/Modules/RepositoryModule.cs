using Autofac;
using IM.TCM.Data.Repositories;
using IM.TCM.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IM.TCM.Infrastructure.Autofac.Modules
{
    public class RepositoryModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(GenericRepository<>))
                .As(typeof(IGenericRepository<>))
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(AssemblyExtension.GetExecutingAssemblies("IM.TCM.Data"))
                .Where(a => a.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
