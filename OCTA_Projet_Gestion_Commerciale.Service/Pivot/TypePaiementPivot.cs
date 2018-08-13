namespace OCTA_Projet_Gestion_Commerciale.Service.Pivot
{
    using OCTA_Projet_Gestion_Commerciale.Model;
    using System;
    using System.Collections.Generic;
  

    public  partial class TypePaiementPivot
    {
        public long TypePaiementId { get; set; }

        public string Libelle { get; set; }

        public bool Actif { get; set; }
        public long? IdDossier { get; set; }




        public  GEN_Dossiers GEN_Dossiers { get; set; }


        public  ICollection<CPT_RelevesBancairesDetail> CPT_RelevesBancairesDetail { get; set; }


        public  ICollection<GEN_Regelement> GEN_Regelement { get; set; }


        public ICollection<GEN_Tiers> GEN_Tiers { get; set; }

        public  DossiersPivot GEN_Dossiers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public  ICollection<RelevesBancairesDetailPivot> CPT_RelevesBancairesDetail { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public  ICollection<RegelementPivot> GEN_Regelement { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public  ICollection<TiersPivot> GEN_Tiers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public  ICollection<TypePaiementDetailPivot> GEN_TypePaiementDetail { get; set; }
    }
}
