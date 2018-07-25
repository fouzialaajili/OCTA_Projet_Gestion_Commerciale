namespace Store.Model
{
    using System;
    using System.Collections.Generic;
   

    public partial class CPT_Echeances
    {
       
        public long Id { get; set; }

        public long? IdEcriture { get; set; }

        public long? IdTypePaiement { get; set; }

        public long? IdModePaiement { get; set; }

        public DateTime? DateEcheance { get; set; }

        public double? Pourcentage { get; set; }

        public double? MontantTC { get; set; }

        public long? IdDeviseTC { get; set; }

        public double? MontantTR { get; set; }

        public long? IdDeviseTR { get; set; }

        public int? Statut { get; set; }

        public long? IdDossier { get; set; }

        public long? IdDossierSite { get; set; }

        public string sys_user { get; set; }

   
        public DateTime? sys_dateUpdate { get; set; }

     
        public DateTime? sys_dateCreation { get; set; }

        public virtual CPT_Ecritures CPT_Ecritures { get; set; }

        public virtual GEN_Items GEN_Items_ModePaiement { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CPT_Lettrage> CPT_Lettrage { get; set; }
    }
}
