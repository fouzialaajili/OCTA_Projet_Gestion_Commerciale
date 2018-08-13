using Autofac;
using Autofac.Integration.Mvc;
using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Data.Repositories;
using OCTA_Projet_Gestion_Commerciale.Service.Implementation;
using OCTA_Projet_Gestion_Commerciale.Web.Mappages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace OCTA_Projet_Gestion_Commerciale.Web.App_Start
{
    public class Bootstrapper
    {

        public static void Run()
        {
            SetAutofacContainer();
            AutoMapperConfiguration.Configure();
        }

        private static void SetAutofacContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();

            // Repositories
  builder.RegisterAssemblyTypes(typeof(ModelRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(DossiersRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(AdminRepository).Assembly)
      .Where(t => t.Name.EndsWith("Repository"))
      .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(LicenceRepositoy).Assembly)
               .Where(t => t.Name.EndsWith("Repository"))
               .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(DevisesRepository).Assembly)
              .Where(t => t.Name.EndsWith("Repository"))
              .AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(TiersRepository).Assembly)
     .Where(t => t.Name.EndsWith("Repository"))
    .AsImplementedInterfaces().InstancePerRequest();


            builder.RegisterAssemblyTypes(typeof(TypePaiementRepository).Assembly)
      .Where(t => t.Name.EndsWith("Repository"))
      .AsImplementedInterfaces().InstancePerRequest();


            builder.RegisterAssemblyTypes(typeof(ItemsRepository).Assembly)
 .Where(t => t.Name.EndsWith("Repository"))
 .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(EcritureRepository).Assembly)
        .Where(t => t.Name.EndsWith("Repository"))
        .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(TiersContactsRepository).Assembly)
        .Where(t => t.Name.EndsWith("Repository"))
        .AsImplementedInterfaces().InstancePerRequest();


            // Services
            builder.RegisterAssemblyTypes(typeof(AdminService).Assembly)
                          .Where(t => t.Name.EndsWith("Service"))
                          .AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(ItemsService).Assembly)
.Where(t => t.Name.EndsWith("Service"))
.AsImplementedInterfaces().InstancePerRequest();


            builder.RegisterAssemblyTypes(typeof(EcritureService).Assembly)
        .Where(t => t.Name.EndsWith("Service"))
        .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(TypePaiementService).Assembly)
      .Where(t => t.Name.EndsWith("Service"))
      .AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(LicenceService).Assembly)
               .Where(t => t.Name.EndsWith("Service"))
               .AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(ModelService).Assembly)
                     .Where(t => t.Name.EndsWith("Service"))
                     .AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(DevisesService).Assembly)
               .Where(t => t.Name.EndsWith("Service"))
               .AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(TiersContactsService).Assembly)
        .Where(t => t.Name.EndsWith("Service"))
        .AsImplementedInterfaces().InstancePerRequest();
          
            builder.RegisterAssemblyTypes(typeof(DossiersService).Assembly)
  .Where(t => t.Name.EndsWith("Service"))
  .AsImplementedInterfaces().InstancePerRequest();


            builder.RegisterAssemblyTypes(typeof(TiersService).Assembly)
  .Where(t => t.Name.EndsWith("Service"))
  .AsImplementedInterfaces().InstancePerRequest();
            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}