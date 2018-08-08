using AutoMapper;
using OCTA_Projet_Gestion_Commerciale.Model;
using OCTA_Projet_Gestion_Commerciale.Service.Pivot;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCTA_Projet_Gestion_Commerciale.Service.Mappages
{
    public class ModelToPivotMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }
        public ModelToPivotMappingProfile()
        {
            CreateMap<GES_Admin, AdminPivot>()
                  .ReverseMap()
                  .IgnoreAllPropertiesWithAnInaccessibleSetter();

            CreateMap<CPT_Classe,ClassePivot>()
                .ReverseMap()
                .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<CPT_CodesTVA, CodesTVAPivot>()
                .ReverseMap()
                .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<CPT_CompteG, CompteGPivot>()
                .ReverseMap()
                .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<CPT_CompteGDetailTVA, CompteGDetailTVAPivot>()
                .ReverseMap()
                .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<CPT_ComptesBancaires, ComptesBancairesPivot>()
                .ReverseMap()
                .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<CPT_ComptesBancairesTiers, ComptesBancairesTiersPivot>()
                .ReverseMap()
                .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<CPT_Echeances, EcheancesPivot>()
                .ReverseMap()
                .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<CPT_Ecritures, EcrituresPivot>()
                .ReverseMap()
                .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<CPT_Journaux, JournauxPivot>()
                .ReverseMap()
                .IgnoreAllPropertiesWithAnInaccessibleSetter();

            CreateMap<CPT_Lettrage, LettragePivot>()
                .ReverseMap()
                .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<CPT_NatureOperation, NatureOperationPivot>()
                            .ReverseMap()
                            .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<CPT_ParametrageComptable, ParametrageComptablePivot>()
                            .ReverseMap()
                            .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<CPT_Pieces, PiecesPivot>()
                            .ReverseMap()
                            .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<CPT_PlanAnalytique, PlanAnalytiquePivot>()
                            .ReverseMap()
                            .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<CPT_RelevesBancaires, RelevesBancairesPivot>()
                            .ReverseMap()
                            .IgnoreAllPropertiesWithAnInaccessibleSetter();



            CreateMap<CPT_RelevesBancairesDetail, RelevesBancairesDetailPivot>()
                .ReverseMap()
                .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<CPT_TVALettrage, TVALettragePivot>()
                            .ReverseMap()
                            .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<GEN_Devises, DevisesPivot>()
                            .ReverseMap()
                            .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<GEN_Documents, DocumentsPivot>()
                            .ReverseMap()
                            .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<GEN_Dossiers, DossiersPivot>()
                            .ReverseMap()
                            .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<GEN_DossiersContacts, DossiersContactsPivot>()
                            .ReverseMap()
                            .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<GEN_DossiersSites, DossiersSitesPivot>()
                            .ReverseMap()
                            .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<GEN_Exercices, ExercicesPivot>()
                            .ReverseMap()
                            .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<GEN_Items, ItemsPivot>()
                            .ReverseMap()
                            .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<GEN_Model , ModelPivot>()
                            .ReverseMap()
                            .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<GEN_Numeration, NumerationPivot>()
                            .ReverseMap()
                            .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<GEN_Periodes, PeriodesPivot>()
                            .ReverseMap()
                            .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<GEN_Regelement , RegelementPivot>()
                            .ReverseMap()
                            .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<GEN_Tiers, TiersPivot>()
                            .ReverseMap()
                            .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<GEN_TiersContacts, TiersContactsPivot>()
                            .ReverseMap()
                            .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<GEN_TypePaiement, TypePaiementPivot>()
                            .ReverseMap()
                            .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<GEN_TypePaiementDetail, TypePaiementDetailPivot>()
                           .ReverseMap()
                           .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<GES_Affaire ,AffairePivot>()
                            .ReverseMap()
                            .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<GES_Article, ArticlePivot>()
                           .ReverseMap()
                           .IgnoreAllPropertiesWithAnInaccessibleSetter();

            CreateMap<GES_ArticlesKit, ArticlesKitPivot>()
                                       .ReverseMap()
                                       .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<GES_ArticlesPrix, ArticlesPrixPivot>()
                           .ReverseMap()
                           .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<GES_Categorie, CategoriePivot>()
                           .ReverseMap()
                           .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<GES_Depot, DepotPivot>()
                           .ReverseMap()
                           .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<GES_Doclie, DocliePivot>()
                           .ReverseMap()
                           .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<GES_Doclieart, DoclieartPivot>()
                          .ReverseMap()
                          .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<GES_DocumentCommercial, DocumentCommercialPivot>()
                          .ReverseMap()
                          .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<GES_DocumentCommercialDetail, DocumentCommercialDetailPivot>()
                          .ReverseMap()
                          .IgnoreAllPropertiesWithAnInaccessibleSetter();
                 CreateMap<GES_DocumentCommercialDetailSerie, DocumentCommercialDetailSeriePivot>()
                           .ReverseMap()
                           .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<GES_Famille, FamillePivot>()
                          .ReverseMap()
                          .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<GES_FournisseurArticle, FournisseurArticlePivot>()
                          .ReverseMap()
                          .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<GES_Ged, GedPivot>()
                          .ReverseMap()
                          .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<GES_Impression, ImpressionPivot>()
                          .ReverseMap()
                          .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<GES_Licence, LicencePivot>()
                          .ReverseMap()
                          .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<GES_Marque, MarquePivot>()
                          .ReverseMap()
                          .IgnoreAllPropertiesWithAnInaccessibleSetter();

            CreateMap<GES_Motif, MotifPivot>()
                      .ReverseMap()
                      .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<GES_MotifTicket, MotifTicketPivot>()
                      .ReverseMap()
                      .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<GES_MouvementStock, MouvementStockPivot>()
                      .ReverseMap()
                      .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<GES_Nomenclature, NomenclaturePivot>()
                      .ReverseMap()
                      .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<GES_Numerotation, NumerotationPivot>()
                      .ReverseMap()
                      .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<GES_Objectif, ObjectifPivot>()
                      .ReverseMap()
                      .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<GES_Opportunite, OpportunitePivot>()
                      .ReverseMap()
                      .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<GES_OpportuniteDetail, OpportuniteDetailPivot>()
                      .ReverseMap()
                      .IgnoreAllPropertiesWithAnInaccessibleSetter();

            CreateMap<GES_Periode, PeriodePivot>()
                   .ReverseMap()
                   .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<GES_Reglement,ReglementPivot>()
                   .ReverseMap()
                   .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<GES_ReglementFacture, ReglementFacturePivot>()
                   .ReverseMap()
                   .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<GES_Representant, RepresentantPivot>()
                   .ReverseMap()
                   .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<GES_Ticket, TicketPivot>()
                   .ReverseMap()
                   .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<GES_TicketDetail, TicketDetailPivot>()
                   .ReverseMap()
                   .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<GES_Tolerance , TolerancePivot>()
                   .ReverseMap()
                   .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<GES_Unite, UnitePivot>()
                .ReverseMap()
                .IgnoreAllPropertiesWithAnInaccessibleSetter();

        }
    }
}