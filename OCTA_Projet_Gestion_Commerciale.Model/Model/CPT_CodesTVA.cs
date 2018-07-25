namespace Store.Model
{
    using System;
    using System.Collections.Generic;

    public partial class CPT_CodesTVA
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

        public string sys_user { get; set; }

        public DateTime? sys_dateUpdate { get; set; }

        public DateTime? sys_dateCreation { get; set; }

        

        public virtual CPT_CompteG CPT_CompteG { get; set; }

        public virtual GEN_Dossiers GEN_Dossiers { get; set; }

        public virtual GEN_Items GEN_Items_RebriqueDeclaration { get; set; }

        public virtual GEN_Items GEN_Items_TypeTVA { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CPT_CompteG> CPT_CompteG_CodeTVADefault { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CPT_CompteGDetailTVA> CPT_CompteGDetailTVA { get; set; }

        public long TvaSocieteId { get; set; }
        public virtual GEN_Dossiers TvaSociete { get; set; }
        public virtual ICollection<GEN_Tiers> TvaFichetier { get; set; }
    }
}
