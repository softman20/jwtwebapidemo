using Autofac;
using Data.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Autofac.Modules
{
    public class EFModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new RepositoryModule());
            builder.RegisterType<JWTDemoContext>().AsSelf().As<DbContext>().InstancePerLifetimeScope();
        }
    }
}
