namespace OCTA_Projet_Gestion_Commerciale.Service.Pivot
{
    using OCTA_Projet_Gestion_Commerciale.Model;
    using System;
    using System.Collections.Generic;
 

    public partial class TiersPivot
    {


        public long Id { get; set; }
        public string code { get; set; }
        public string TypeTierCode { get; set; }
        public long? TypeTiers { get; set; }

        public string RaisonSociale { get; set; }

        public string activite { get; set; }

        public long? FormeJuridique { get; set; }

        public string Adresse { get; set; }

        public string adresseLivraison { get; set; }


        public string Tel { get; set; }


        public string Fax { get; set; }

        public string Email { get; set; }

        public string Ville { get; set; }

        public string SiteWeb { get; set; }

        public string CapitalSocial { get; set; }

        public string Pays { get; set; }


        public string IdentifiantFiscale { get; set; }

        public string IdentifiantTVA { get; set; }

        public string ice { get; set; }

        public string Patente { get; set; }

        public long? IdDeviseDefault { get; set; }

        public bool Actif { get; set; }

        public long? IdCompteCollectifClient { get; set; }

        public long? IdCompteCollectifFournisseur { get; set; }

        public long? IdEcheancement { get; set; }

        public long? IdGroupeRemise { get; set; }

        public long? IdGroupeStatistiques { get; set; }

        public long? IdCategorieFiscale { get; set; }

        public long? IdDossier { get; set; }

        public string sys_user { get; set; }

        public DateTime? sys_dateUpdate { get; set; }

        public DateTime? sys_dateCreation { get; set; }

        public CPT_CompteG CPT_CompteG_CompteCollectifClient { get; set; }

        public CPT_CompteG CPT_CompteG_CompteCollectifFournisseur { get; set; }
        public  GEN_Devises GEN_Devises { get; set; }

        public  GEN_Dossiers GEN_Dossiers { get; set; }

       public GEN_Items GEN_Items_CategorieFiscale { get; set; }

        public GEN_Items GEN_Items_FormeJuridique { get; set; }

      public GEN_Items GEN_Items_TypeTiers { get; set; }

        public GEN_TypePaiement GEN_TypePaiement { get; set; }


        public  ICollection<GEN_TiersContacts> GEN_TiersContacts { get; set; }


        public  ICollection<CPT_ComptesBancairesTiers> CPT_ComptesBancairesTiers { get; set; }

        public  ICollection<CPT_Ecritures> CPT_Ecritures { get; set; }


        public  ICollection<CPT_Pieces> CPT_Pieces { get; set; }
          

        public ICollection<CPT_RelevesBancairesDetail> CPT_RelevesBancairesDetail { get; set; }


        public  ICollection<GES_FournisseurArticle> GES_FournisseurArticle { get; set; }
        public  ICollection<GES_Opportunite> GES_Opportunite { get; set; }
        public  ICollection<GES_OpportuniteDetail> GES_OpportuniteDetail { get; set; }
        public  ICollection<GES_Reglement> GES_Reglement { get; set; }
        public  ICollection<GES_Ticket> GES_Ticket { get; set; }
        public  ICollection<GES_TicketDetail> GES_TicketDetail { get; set; }
 

    }
}
