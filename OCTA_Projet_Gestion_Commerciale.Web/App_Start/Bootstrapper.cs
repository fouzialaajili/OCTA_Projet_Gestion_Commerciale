using Autofac;
using Autofac.Integration.Mvc;
using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Data.Repositories;
using OCTA_Projet_Gestion_Commerciale.Data.Repositoriess;
using OCTA_Projet_Gestion_Commerciale.Service.Implementation;
using OCTA_Projet_Gestion_Commerciale.Service.Mappages;
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

            builder.RegisterAssemblyTypes(typeof(AffaireRepository).Assembly)
          .Where(t => t.Name.EndsWith("Repository"))
          .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(ArticleRepository).Assembly)
             .Where(t => t.Name.EndsWith("Repository"))
             .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(ArticlesKitRepository).Assembly)
          .Where(t => t.Name.EndsWith("Repository"))
          .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(ArticlesPrixRepository).Assembly)
          .Where(t => t.Name.EndsWith("Repository"))
          .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(CategorieRepository).Assembly)
          .Where(t => t.Name.EndsWith("Repository"))
          .AsImplementedInterfaces().InstancePerRequest();


            builder.RegisterAssemblyTypes(typeof(CodesTVARepository).Assembly)
          .Where(t => t.Name.EndsWith("Repository"))
          .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(CPT_ParametrageComptableRepository).Assembly)
          .Where(t => t.Name.EndsWith("Repository"))
          .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(DepotRepository).Assembly)
          .Where(t => t.Name.EndsWith("Repository"))
          .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(DoclieartRepository).Assembly)
             .Where(t => t.Name.EndsWith("Repository"))
             .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(DoclieRepository).Assembly)
          .Where(t => t.Name.EndsWith("Repository"))
          .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(DocumentCommercialDetailRepository).Assembly)
          .Where(t => t.Name.EndsWith("Repository"))
          .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(DocumentCommercialDetailSerieRepository).Assembly)
          .Where(t => t.Name.EndsWith("Repository"))
          .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(DocumentCommercialRepository).Assembly)
          .Where(t => t.Name.EndsWith("Repository"))
          .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(DossiersContactsRepository).Assembly)
          .Where(t => t.Name.EndsWith("Repository"))
          .AsImplementedInterfaces().InstancePerRequest();


            builder.RegisterAssemblyTypes(typeof(DossiersSitesRepository).Assembly)
          .Where(t => t.Name.EndsWith("Repository"))
          .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(DossiersRepository).Assembly)
          .Where(t => t.Name.EndsWith("Repository"))
          .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(FamilleRepositoy).Assembly)
          .Where(t => t.Name.EndsWith("Repository"))
          .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(FournisseurArticleRepository).Assembly)
     .Where(t => t.Name.EndsWith("Repository"))
     .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(GedRepository).Assembly)
     .Where(t => t.Name.EndsWith("Repository"))
     .AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(ImpressionRepository).Assembly)
     .Where(t => t.Name.EndsWith("Repository"))
     .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(MarqueRepository).Assembly)
     .Where(t => t.Name.EndsWith("Repository"))
     .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(MotifRepository).Assembly)
     .Where(t => t.Name.EndsWith("Repository"))
     .AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(MotifTicketRepository).Assembly)
     .Where(t => t.Name.EndsWith("Repository"))
     .AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(MouvementStockRepository).Assembly)
     .Where(t => t.Name.EndsWith("Repository"))
     .AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(NomenclatureRepository).Assembly)
     .Where(t => t.Name.EndsWith("Repository"))
     .AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(NumerotationRepository).Assembly)
     .Where(t => t.Name.EndsWith("Repository"))
     .AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(ObjectifRepository).Assembly)
     .Where(t => t.Name.EndsWith("Repository"))
     .AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(OpportuniteDetailRepository).Assembly)
     .Where(t => t.Name.EndsWith("Repository"))
     .AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(OpportuniteRepository).Assembly)
     .Where(t => t.Name.EndsWith("Repository"))
     .AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(PaiementRepository).Assembly)
     .Where(t => t.Name.EndsWith("Repository"))
     .AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(PeriodeRepository).Assembly)
     .Where(t => t.Name.EndsWith("Repository"))
     .AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(ReglementFactureRepository).Assembly)
     .Where(t => t.Name.EndsWith("Repository"))
     .AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(ReglementRepository).Assembly)
     .Where(t => t.Name.EndsWith("Repository"))
     .AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(RepresentantRepository).Assembly)
     .Where(t => t.Name.EndsWith("Repository"))
     .AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(TicketDetailRepository).Assembly)
     .Where(t => t.Name.EndsWith("Repository"))
     .AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(TicketRepository).Assembly)
     .Where(t => t.Name.EndsWith("Repository"))
     .AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(TiersContactRepository).Assembly)
     .Where(t => t.Name.EndsWith("Repository"))
     .AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(TiersRepository).Assembly)
     .Where(t => t.Name.EndsWith("Repository"))
     .AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(ToleranceRepositoy).Assembly)
     .Where(t => t.Name.EndsWith("Repository"))
     .AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(TypePaiementDetailRepository).Assembly)
     .Where(t => t.Name.EndsWith("Repository"))
     .AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(TypePaiementRepository).Assembly)
     .Where(t => t.Name.EndsWith("Repository"))
     .AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(UniteRepository).Assembly)
     .Where(t => t.Name.EndsWith("Repository"))
     .AsImplementedInterfaces().InstancePerRequest();



            builder.RegisterAssemblyTypes(typeof(ItemsRepository).Assembly)
  .Where(t => t.Name.EndsWith("Repository"))
  .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(ModelRepository).Assembly)
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

            builder.RegisterAssemblyTypes(typeof(DossiersSitesService).Assembly)
              .Where(t => t.Name.EndsWith("Service"))
              .AsImplementedInterfaces().InstancePerRequest();




            builder.RegisterAssemblyTypes(typeof(AffaireService).Assembly)
          .Where(t => t.Name.EndsWith("Service"))
          .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(ArticlesService).Assembly)
             .Where(t => t.Name.EndsWith("Service"))
             .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(ArticlesKitService).Assembly)
          .Where(t => t.Name.EndsWith("Service"))
          .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(ArticlesPrixService).Assembly)
          .Where(t => t.Name.EndsWith("Service"))
          .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(CategorieService).Assembly)
          .Where(t => t.Name.EndsWith("Service"))
          .AsImplementedInterfaces().InstancePerRequest();


            builder.RegisterAssemblyTypes(typeof(CodesTVAService).Assembly)
          .Where(t => t.Name.EndsWith("Service"))
          .AsImplementedInterfaces().InstancePerRequest();

           /* builder.RegisterAssemblyTypes(typeof(CPT_ParametrageComptableService).Assembly)
          .Where(t => t.Name.EndsWith("Service"))
          .AsImplementedInterfaces().InstancePerRequest();*/

            builder.RegisterAssemblyTypes(typeof(DepotService).Assembly)
          .Where(t => t.Name.EndsWith("Service"))
          .AsImplementedInterfaces().InstancePerRequest();


            builder.RegisterAssemblyTypes(typeof(DoclieartService).Assembly)
             .Where(t => t.Name.EndsWith("Service"))
             .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(DoclieService).Assembly)
          .Where(t => t.Name.EndsWith("Service"))
          .AsImplementedInterfaces().InstancePerRequest();

          //  builder.RegisterAssemblyTypes(typeof(DocumentCommercialDetailService).Assembly)
          //.Where(t => t.Name.EndsWith("Service"))
          //.AsImplementedInterfaces().InstancePerRequest();

          //  builder.RegisterAssemblyTypes(typeof(DocumentCommercialDetailSerieService).Assembly)
          //.Where(t => t.Name.EndsWith("Service"))
          //.AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(DocumentCommercialService).Assembly)
          .Where(t => t.Name.EndsWith("Service"))
          .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(DossiersContactsService).Assembly)
          .Where(t => t.Name.EndsWith("Service"))
          .AsImplementedInterfaces().InstancePerRequest();



            builder.RegisterAssemblyTypes(typeof(DossiersService).Assembly)
          .Where(t => t.Name.EndsWith("Service"))
          .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(FamilleService).Assembly)
          .Where(t => t.Name.EndsWith("Service"))
          .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(FournisseurArticleService).Assembly)
     .Where(t => t.Name.EndsWith("Service"))
     .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(GedService).Assembly)
     .Where(t => t.Name.EndsWith("Service"))
     .AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(ImpressionService).Assembly)
     .Where(t => t.Name.EndsWith("Service"))
     .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(MarqueService).Assembly)
     .Where(t => t.Name.EndsWith("Service"))
     .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(MotifService).Assembly)
     .Where(t => t.Name.EndsWith("Service"))
     .AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(MotifTicketService).Assembly)
     .Where(t => t.Name.EndsWith("Service"))
     .AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(MouvementStockService).Assembly)
     .Where(t => t.Name.EndsWith("Service"))
     .AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(NomenclatureService).Assembly)
     .Where(t => t.Name.EndsWith("Service"))
     .AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(NumerotationService).Assembly)
     .Where(t => t.Name.EndsWith("Service"))
     .AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(ObjectifService).Assembly)
     .Where(t => t.Name.EndsWith("Service"))
     .AsImplementedInterfaces().InstancePerRequest();
           /* builder.RegisterAssemblyTypes(typeof(OpportuniteDetailService).Assembly)
     .Where(t => t.Name.EndsWith("Service"))
     .AsImplementedInterfaces().InstancePerRequest();*/
            builder.RegisterAssemblyTypes(typeof(OpportuniteService).Assembly)
     .Where(t => t.Name.EndsWith("Service"))
     .AsImplementedInterfaces().InstancePerRequest();
          /*  builder.RegisterAssemblyTypes(typeof(PaiementService).Assembly)
     .Where(t => t.Name.EndsWith("Service"))
     .AsImplementedInterfaces().InstancePerRequest();*/
            builder.RegisterAssemblyTypes(typeof(PeriodeService).Assembly)
     .Where(t => t.Name.EndsWith("Service"))
     .AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(ReglementFactureService).Assembly)
     .Where(t => t.Name.EndsWith("Service"))
     .AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(ReglementService).Assembly)
     .Where(t => t.Name.EndsWith("Service"))
     .AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(RepresentantService).Assembly)
     .Where(t => t.Name.EndsWith("Service"))
     .AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(TicketDetailService).Assembly)
     .Where(t => t.Name.EndsWith("Service"))
     .AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(TicketService).Assembly)
     .Where(t => t.Name.EndsWith("Service"))
     .AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(TiersContactsService).Assembly)
     .Where(t => t.Name.EndsWith("Service"))
     .AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(TiersService).Assembly)
     .Where(t => t.Name.EndsWith("Service"))
     .AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(ToleranceService).Assembly)
     .Where(t => t.Name.EndsWith("Service"))
     .AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(TypePaiementDetailService).Assembly)
     .Where(t => t.Name.EndsWith("Service"))
     .AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(TypePaiementService).Assembly)
     .Where(t => t.Name.EndsWith("Service"))
     .AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(UniteService).Assembly)
     .Where(t => t.Name.EndsWith("Service"))
     .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(ModelService).Assembly)
     .Where(t => t.Name.EndsWith("Service"))
     .AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(ItemsService).Assembly)
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