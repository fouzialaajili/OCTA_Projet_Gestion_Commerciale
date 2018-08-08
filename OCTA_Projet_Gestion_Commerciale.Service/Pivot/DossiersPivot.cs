namespace OCTA_Projet_Gestion_Commerciale.Service.Pivot
{
   
    using System;
    using System.Collections.Generic;


    public partial class DossiersPivot
    {


        public long DossierId { get; set; }
        public string CodeDossier { get; set; }
        public string DossierRaisonSociale { get; set; }
        public int? IdTypeDossier { get; set; }
        public string DossierAdresse { get; set; }
        public string DossierTel { get; set; }
        public string DossierFax { get; set; }
        public string DossierEmail { get; set; }
        public string DossierVille { get; set; }
        public string DossierPays { get; set; }
        public string DossierSiteWeb { get; set; }
        public string DossierCapitalSocial { get; set; }
        public int? IdDeviseTenueCompte { get; set; }
        public string DossierIdentifiantFiscale { get; set; }
        public string DossierIdentifiantTVA { get; set; }
        public string DossierPatente { get; set; }

        public string DossierRegistreCommerce { get; set; }

        public string DossierNumeroCNSS { get; set; }

        public string DossierICE { get; set; }

        public int? DossierComptaActif { get; set; }

        public int? DossierGescomAtif { get; set; }

        public int? DossierPaieActif { get; set; }

        public bool DossierActif { get; set; }

        public string DossierCleSecuriteCompta { get; set; }

        public string DossierCleSecuritePaie { get; set; }

        public string DossierCleSecuriteGescom { get; set; }

        public string DossierCleSecurite { get; set; }

        public string Dossiersys_user { get; set; }

        public DateTime? Dossiersys_dateUpdate { get; set; }

        public DateTime? Dossiersys_dateCreation { get; set; }

        // public virtual GEN_Societes GEN_Societes { get; set; }



        /*****************/


   //    public  ICollection<DevisesPivot> GEN_Devises { get; set; }

        //public ICollection<ClassePivot> CPT_Classe { get; set; }
        //public ICollection<ModelPivot> GEN_Model { get; set; }
        //public ICollection<CodesTVAPivot> CPT_CodesTVA { get; set; }
        //public ICollection<CompteGPivot> CPT_CompteG { get; set; }
        //public ICollection<ComptesBancairesPivot> CPT_ComptesBancaires { get; set; }
        //public ICollection<JournauxPivot> CPT_Journaux { get; set; }
        //public ICollection<ParametrageComptablePivot> CPT_ParametrageComptable { get; set; }
        //public ICollection<PiecesPivot> CPT_Pieces { get; set; }
        //public ICollection<DocumentsPivot> GEN_Documents { get; set; }
        //public ICollection<DossiersContactsPivot> GEN_DossiersContacts { get; set; }
        //public ICollection<DossiersSitesPivot> GEN_DossiersSites { get; set; }
        //public ICollection<ExercicesPivot> GEN_Exercices { get; set; }
        //public ICollection<NumerationPivot> GEN_Numeration { get; set; }
        //public ICollection<NumerotationPivot> GES_Numerotation { get; set; }
        //public ICollection<PreferencesPivot> GEN_Preferences { get; set; }
        //public ICollection<TiersPivot> GEN_Tiers { get; set; }
        //public ICollection<TypePaiementPivot> GEN_TypePaiement { get; set; }
        //public ICollection<MotifPivot> GES_Motif { get; set; }
        //public ICollection<MotifTicketPivot> GES_MotifTicket { get; set; }
        //public ICollection<MouvementStockPivot> GES_MouvementStock { get; set; }
        //public ICollection<ObjectifPivot> GES_Objectif { get; set; }
        //public ICollection<OpportunitePivot> GES_Opportunite { get; set; }
        //public ICollection<ArticlePivot> SocieteArticle { get; set; }
        //public ICollection<AffairePivot> SocieteAffaire { get; set; }
        //public ICollection<CategoriePivot> SocieteCategorie { get; set; }
        //public ICollection<DepotPivot> SocieteDepot { get; set; }

        //public ICollection<DocliePivot> SocieteDoclie { get; set; }
        //public ICollection<DoclieartPivot> SocieteDoclieart { get; set; }
        //public ICollection<DocumentCommercialPivot> SocieteDocumentCommercial { get; set; }
        //public ICollection<DocumentCommercialDetailSeriePivot> SocieteDocumentCommercialDetailSerie { get; set; }
        //public ICollection<FamillePivot> SocieteFamille { get; set; }
        //public ICollection<ImpressionPivot> SocieteImpression { get; set; }
        //public ICollection<MarquePivot> SocieteMarque { get; set; }
        //public ICollection<TolerancePivot> SocieteTolerance { get; set; }
        //public ICollection<UnitePivot> SocieteUnite { get; set; }
        //public ICollection<PeriodePivot> GES_Periode { get; set; }
        //public ICollection<ReglementPivot> GES_Reglement { get; set; }
        //public ICollection<RepresentantPivot> GES_Representant { get; set; }
        //public ICollection<TicketPivot> GES_Ticket { get; set; }
        //public ICollection<CodesTVAPivot> SocieteTVA { get; set; }






    }
}
