namespace OCTA_Projet_Gestion_Commerciale.Service.Pivot
{
    using System;
    using System.Collections.Generic;
 

    public partial class TiersPivot
    {
       
        public long Id { get; set; }
        public string code { get; set; }
   
        public long? TypeTiers { get; set; }
      
        public string RaisonSociale { get; set; }
       
        public string activite { get; set; }
       
        public long? FormeJuridique { get; set; }
       
        public string Adresse { get; set; }
       
        public string adresseLivraison { get; set; }

     
        public string Tel { get; set; }

   
        public string Fax { get; set; }
     
        public string Email { get; set; }
       
        public long? Ville { get; set; }
      
        public string SiteWeb { get; set; }
   
        public string CapitalSocial { get; set; }
    
        public long? Pays { get; set; }

    
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

        public string Sys_user { get; set; }

        public DateTime? Sys_dateUpdate { get; set; }

        public DateTime? Sys_dateCreation { get; set; }

        public CompteGPivot CPT_CompteG_CompteCollectifClient { get; set; }

        public CompteGPivot CPT_CompteG_CompteCollectifFournisseur { get; set; }
        public  DevisesPivot GEN_Devises { get; set; }

        public DossiersPivot GEN_Dossiers { get; set; }

        public ItemsPivot GEN_Items_CategorieFiscale { get; set; }

        public ItemsPivot GEN_Items_FormeJuridique { get; set; }

        public ItemsPivot GEN_Items_TypeTiers { get; set; }

        public TypePaiementPivot GEN_TypePaiement { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public  ICollection<TiersContactsPivot> GEN_TiersContacts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public  ICollection<ComptesBancairesTiersPivot> CPT_ComptesBancairesTiers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public  ICollection<EcrituresPivot> CPT_Ecritures { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public  ICollection<PiecesPivot> CPT_Pieces { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public  ICollection<RelevesBancairesDetailPivot> CPT_RelevesBancairesDetail { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public  ICollection<FournisseurArticlePivot> GES_FournisseurArticle { get; set; }
        public  ICollection<OpportunitePivot> GES_Opportunite { get; set; }
        public ICollection<OpportuniteDetailPivot> GES_OpportuniteDetail { get; set; }
        public  ICollection<ReglementPivot> GES_Reglement { get; set; }
        public ICollection<TicketPivot> GES_Ticket { get; set; }
        public  ICollection<TicketDetailPivot> GES_TicketDetail { get; set; }
            public long TvaSocieteId { get; set; }
        public  CodesTVAPivot TvaSociete { get; set; }
    }
}
