namespace OCTA_Projet_Gestion_Commerciale.Service.Pivot
{
    using System;
    using System.Collections.Generic;

    public partial class CodesTVAPivot
    { 

        public long Id { get; set; }

      
        public string CodeTaux { get; set; }

        public string LibelleTaux { get; set; }


        public long? TypeTVA { get; set; }
   
        public int? Percue { get; set; }

 
        public int? Exonere { get; set; }
      
        public double? TauxTVA { get; set; }

     
        public long? IdCompteTVA { get; set; }

     
        public long? IdRubriqueDeclaration { get; set; }

        public bool Actif { get; set; }

        public long? IdDossier { get; set; }

        public string Sys_user { get; set; }

        public DateTime? Sys_dateUpdate { get; set; }

        public DateTime? Sys_dateCreation { get; set; }

        

        public  CompteGPivot CPT_CompteG { get; set; }

        public DossiersPivot GEN_Dossiers { get; set; }

        public ItemsPivot GEN_Items_RebriqueDeclaration { get; set; }

        public ItemsPivot GEN_Items_TypeTVA { get; set; }


          public  ICollection<CompteGPivot> CPT_CompteG_CodeTVADefault { get; set; }

        
        public  ICollection<CompteGDetailTVAPivot> CPT_CompteGDetailTVA { get; set; }

        public long TvaSocieteId { get; set; }
        public DossiersPivot TvaSociete { get; set; }
        public  ICollection<TiersPivot> TvaFichetier { get; set; }
    }
}