namespace Store.Model
{
    using System;
    using System.Collections.Generic;
 

    public partial class GEN_Tiers
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

        public string sys_user { get; set; }

        public DateTime? sys_dateUpdate { get; set; }

        public DateTime? sys_dateCreation { get; set; }

        public virtual CPT_CompteG CPT_CompteG_CompteCollectifClient { get; set; }

        public virtual CPT_CompteG CPT_CompteG_CompteCollectifFournisseur { get; set; }
        public virtual GEN_Devises GEN_Devises { get; set; }

        public virtual GEN_Dossiers GEN_Dossiers { get; set; }

        public virtual GEN_Items GEN_Items_CategorieFiscale { get; set; }

        public virtual GEN_Items GEN_Items_FormeJuridique { get; set; }

        public virtual GEN_Items GEN_Items_TypeTiers { get; set; }

        public virtual GEN_TypePaiement GEN_TypePaiement { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GEN_TiersContacts> GEN_TiersContacts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CPT_ComptesBancairesTiers> CPT_ComptesBancairesTiers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CPT_Ecritures> CPT_Ecritures { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CPT_Pieces> CPT_Pieces { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CPT_RelevesBancairesDetail> CPT_RelevesBancairesDetail { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GES_FournisseurArticle> GES_FournisseurArticle { get; set; }
        public virtual ICollection<GES_Opportunite> GES_Opportunite { get; set; }
        public virtual ICollection<GES_OpportuniteDetail> GES_OpportuniteDetail { get; set; }
        public virtual ICollection<GES_Reglement> GES_Reglement { get; set; }
        public virtual ICollection<GEN_TiersContact> GES_Ticket { get; set; }
        public virtual ICollection<GES_TicketDetail> GES_TicketDetail { get; set; }
            public long TvaSocieteId { get; set; }
        public virtual CPT_CodesTVA TvaSociete { get; set; }
    }
}
