using Autofac;
using IM.TCM.Data.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IM.TCM.Infrastructure.Autofac.Modules
{
    public class EFModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new RepositoryModule());
            builder.RegisterType<TCMContext>().AsSelf().As<DbContext>().InstancePerLifetimeScope();
        }
    }
}
