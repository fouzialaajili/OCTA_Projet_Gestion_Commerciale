namespace Store.Model
{
    using System;
    using System.Collections.Generic;
  
    public partial class CPT_Ecritures
    {
        

        public long Id { get; set; }

   
        public long? IdPiece { get; set; }

       
        public DateTime? DateEcriture { get; set; }

        public long? IdCompteG { get; set; }

     
        public string LibelleEcriture { get; set; }

        public string Reference { get; set; }


        public long? IdTauxTVA { get; set; }

 
        public double? Taux { get; set; }

        
        public long? IdDeviceTC { get; set; }
       
        public double? DebitTC { get; set; }
      
        public double? CreditTC { get; set; }

    
        public long? IdDeviceTR { get; set; }

      
        public double? DebitTR { get; set; }

      
        public double? CreditTR { get; set; }

  
        public long? IdTiers { get; set; }
        public long? IdSectionANA { get; set; }
        public long? IdSectionBUD { get; set; }

   
        public long? IdTypePaiement { get; set; }

        public string CodePointage { get; set; }
        public int? IdentifiantUniqueLettrage { get; set; }
        public long? Rapprochement { get; set; }

     
        public int? NumOrdre { get; set; }
        public long? IdDossier { get; set; }
        public long? IdDossierSite { get; set; }
        public string sys_user { get; set; }
        public DateTime? sys_dateUpdate { get; set; }
        public DateTime? sys_dateCreation { get; set; }

        public virtual CPT_CompteG CPT_CompteG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CPT_Echeances> CPT_Echeances { get; set; }

        public virtual CPT_Pieces CPT_Pieces { get; set; }

        public virtual GEN_Devises GEN_Devises_TC { get; set; }

        public virtual GEN_Devises GEN_Devises_TR { get; set; }

        public virtual GEN_DossiersSites GEN_DossiersSites { get; set; }

        public virtual GEN_Tiers GEN_Tiers { get; set; }
    }
}
