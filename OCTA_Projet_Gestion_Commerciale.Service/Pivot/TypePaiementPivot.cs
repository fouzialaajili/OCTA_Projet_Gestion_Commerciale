namespace OCTA_Projet_Gestion_Commerciale.Service.Pivot
{
    using System;
    using System.Collections.Generic;
  

    public partial class TypePaiementPivot
    {

        public long TypePaiementId { get; set; }

        public string Libelle { get; set; }

        public bool Actif { get; set; }
        public long? IdDossier { get; set; }






        public DossiersPivot GEN_Dossiers { get; set; }

    
        public  ICollection<RelevesBancairesDetailPivot> CPT_RelevesBancairesDetail { get; set; }

        public  ICollection<RegelementPivot> GEN_Regelement { get; set; }


        public  ICollection<TiersPivot> GEN_Tiers { get; set; }
        
        public  ICollection<TypePaiementDetailPivot> GEN_TypePaiementDetail { get; set; }
    }
}
