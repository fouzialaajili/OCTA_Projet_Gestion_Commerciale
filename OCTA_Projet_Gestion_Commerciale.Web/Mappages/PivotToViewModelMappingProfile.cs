using AutoMapper;

using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using OCTA_Projet_Gestion_Commerciale.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCTA_Projet_Gestion_Commerciale.Web.Mappages
{
    public class PivotToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        public PivotToViewModelMappingProfile()
        {
            CreateMap<AdminPivot, AdminViewModel>()
               .ReverseMap()
               .IgnoreAllPropertiesWithAnInaccessibleSetter();


            CreateMap< ClassePivot, CPT_ClasseViewModel>()
                .ReverseMap()
                .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap< CodesTVAPivot, CPT_CodesTVAViewModel>()
                .ReverseMap()
                .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap< CompteGPivot, CPT_CompteGViewModel> ()
                .ReverseMap()
                .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<CompteGDetailTVAPivot, CPT_CompteGDetailTVAViewModel >()
                .ReverseMap()
                .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap< ComptesBancairesPivot, CPT_ComptesBancairesViewModel>()
                .ReverseMap()
                .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap< ComptesBancairesTiersPivot, CPT_ComptesBancairesTiersViewModel>()
                .ReverseMap()
                .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<EcheancesPivot, CPT_EcheancesViewModel>()
                .ReverseMap()
                .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<EcrituresPivot, CPT_EcrituresViewModel>()
                .ReverseMap()
                .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap< JournauxPivot, CPT_JournauxViewModel>()
                .ReverseMap()
                .IgnoreAllPropertiesWithAnInaccessibleSetter();

            CreateMap< LettragePivot, CPT_LettrageViewModel>()
                .ReverseMap()
                .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap< NatureOperationPivot, CPT_NatureOperationViewModel>()
                            .ReverseMap()
                            .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap< ParametrageComptablePivot, CPT_ParametrageComptableViewModel>()
                            .ReverseMap()
                            .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<PiecesPivot, CPT_PiecesViewModel>()
                            .ReverseMap()
                            .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap< PlanAnalytiquePivot, CPT_PlanAnalytiqueViewModel>()
                            .ReverseMap()
                            .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap< RelevesBancairesPivot, CPT_RelevesBancairesViewModel>()
                            .ReverseMap()
                            .IgnoreAllPropertiesWithAnInaccessibleSetter();

            CreateMap< RelevesBancairesDetailPivot, CPT_RelevesBancairesDetailViewModel>()
                .ReverseMap()
                .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap< TVALettragePivot, CPT_TVALettrageViewModel>()
                            .ReverseMap()
                            .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap< DevisesPivot, DevisesViewModel>()
                            .ReverseMap()
                            .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap< DocumentsPivot, DocumentsViewModel>()
                            .ReverseMap()
                            .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap< DossiersPivot,DossierViewModel>()
                            .ReverseMap()
                            .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap< DossiersContactsPivot, DossierContactsViewModel>()
                            .ReverseMap()
                            .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap< DossiersSitesPivot, DossiersSitesViewModel>()
                            .ReverseMap()
                            .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap< ExercicesPivot, ExercicesViewModel>()
                            .ReverseMap()
                            .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<ItemsPivot, ItemsViewModel>()
                            .ReverseMap()
                            .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap< ModelPivot, ModelViewModel>()
                            .ReverseMap()
                            .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap< NumerationPivot, NumerationsViewModel>()
                            .ReverseMap()
                            .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap< PeriodesPivot, PeriodesViewModel>()
                            .ReverseMap()
                            .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap< RegelementPivot, ReglementViewModel>()
                            .ReverseMap()
                            .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap< TiersPivot, TiersViewModel>()
                            .ReverseMap()
                            .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<TiersContactsPivot, TiersContactsViewModel>()
                            .ReverseMap()
                            .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<TypePaiementPivot, TypePaiementViewModel>()
                            .ReverseMap()
                            .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap< TypePaiementDetailPivot, TypePaiementDetailViewModel>()
                           .ReverseMap()
                           .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap< AffairePivot, AffaireViewModel>()
                            .ReverseMap()
                            .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<ArticlePivot, ArticlesViewModel>()
                           .ReverseMap()
                           .IgnoreAllPropertiesWithAnInaccessibleSetter();

            CreateMap< ArticlesKitPivot, ArticlesKitsViewModel>()
                                       .ReverseMap()
                                       .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap< ArticlesPrixPivot, ArticePrixViewModel>()
                           .ReverseMap()
                           .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap< CategoriePivot, CategorieViewModel >()
                           .ReverseMap()
                           .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap< DepotPivot, DepotViewModel>()
                           .ReverseMap()
                           .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap< DocliePivot, DoclieViewModel>()
                           .ReverseMap()
                           .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap< DoclieartPivot, DoclieartViewModel>()
                          .ReverseMap()
                          .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap< DocumentCommercialPivot, DocumentCommercialViewModel>()
                          .ReverseMap()
                          .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap< DocumentCommercialDetailPivot, DocummentCommercialDetailViewModel>()
                          .ReverseMap()
                          .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap< DocumentCommercialDetailSeriePivot, DocumentCommercialDetailSerieViewModel>()
                      .ReverseMap()
                      .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap< FamillePivot, FamilleViewModel>()
                          .ReverseMap()
                          .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap< FournisseurArticlePivot, FournisseurArticleViewModel>()
                          .ReverseMap()
                          .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<GedPivot, GedViewModel>()
                          .ReverseMap()
                          .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap< ImpressionPivot, ImpressionViewModel>()
                          .ReverseMap()
                          .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<LicencePivot, LicenceViewModel>()
                          .ReverseMap()
                          .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap< MarquePivot, MarqueViewModel>()
                          .ReverseMap()
                          .IgnoreAllPropertiesWithAnInaccessibleSetter();

            CreateMap< MotifPivot, MotifViewModel>()
                      .ReverseMap()
                      .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap< MotifTicketPivot, MotifTicketsViewModel>()
                      .ReverseMap()
                      .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap< MouvementStockPivot, MouvementStockViewModel>()
                      .ReverseMap()
                      .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap< NomenclaturePivot, NomenclatureViewModel>()
                      .ReverseMap()
                      .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap< NumerotationPivot, NumerotationViewModel>()
                      .ReverseMap()
                      .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<ObjectifPivot, ObjectifViewModel>()
                      .ReverseMap()
                      .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap< OpportunitePivot,OpportuniteViewModel>()
                      .ReverseMap()
                      .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap< OpportuniteDetailPivot, OpportuniteDetailViewModel>()
                      .ReverseMap()
                      .IgnoreAllPropertiesWithAnInaccessibleSetter();

            CreateMap< PeriodePivot, GES_PeriodeViewModel>()
                   .ReverseMap()
                   .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap< ReglementPivot, ReglementViewModel>()
                   .ReverseMap()
                   .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<ReglementFacturePivot, ReglementFactureViewModel>()
                   .ReverseMap()
                   .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap< RepresentantPivot, RepresentantViewModel>()
                   .ReverseMap()
                   .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<TicketPivot, TicketViewModel>()
                   .ReverseMap()
                   .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap< TicketDetailPivot, TicketDetailViewModel>()
                   .ReverseMap()
                   .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap< TolerancePivot, ToleranceViewModel>()
                   .ReverseMap()
                   .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap< UnitePivot, UniteViewModel>()
                .ReverseMap()
                .IgnoreAllPropertiesWithAnInaccessibleSetter();





        }
    }
}