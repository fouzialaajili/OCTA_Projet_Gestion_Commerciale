namespace Store.Model
{
    using System;
    using System.Collections.Generic;
  

    public partial class CPT_Pieces
    {
        

        public long Id { get; set; }
     
        public long? TypePiece { get; set; }
 
        public string OriginePiece { get; set; }
     
        public DateTime? DatePiece { get; set; }

        public DateTime? DateReference { get; set; }
   
        public DateTime? DateFacture { get; set; }
 
        public string RefPiece { get; set; }
  
        public long? IdTiers { get; set; }

        public long? IdJournal { get; set; }

   
        public string NumPiece { get; set; }

        public string Libelle { get; set; }

        public double? CourChange { get; set; }

        public long? IdDeviseTC { get; set; }

  
        public long? IdDeviseTR { get; set; }

     
        public long? IdDossier { get; set; }

        public long? IdDossierSite { get; set; }

  
        public int? Brouillon { get; set; }

        public string sys_user { get; set; }

        public DateTime? sys_dateUpdate { get; set; }

        public DateTime? sys_dateCreation { get; set; }
        public virtual CPT_Journaux CPT_Journaux { get; set; }

        public virtual GEN_Devises GEN_DevisesTC { get; set; }

        public virtual GEN_Devises GEN_DevisesTR { get; set; }

        public virtual GEN_Dossiers GEN_Dossiers { get; set; }

        public virtual GEN_DossiersSites GEN_DossiersSites { get; set; }

        public virtual GEN_Tiers GEN_Tiers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CPT_Ecritures> CPT_Ecritures { get; set; }

      
    }
}
