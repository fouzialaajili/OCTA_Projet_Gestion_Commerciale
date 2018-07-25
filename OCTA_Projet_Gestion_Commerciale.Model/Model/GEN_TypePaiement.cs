namespace OCTA_Projet_Gestion_Commerciale.Model
{
    using System;
    using System.Collections.Generic;
  

    public partial class GEN_TypePaiement
    {
       
        public long TypePaiementId { get; set; }
      
        public string Libelle { get; set; }

        public bool Actif { get; set; }
        public long? IdDossier { get; set; }




        public virtual GEN_Dossiers GEN_Dossiers { get; set; }

        
        public virtual ICollection<CPT_RelevesBancairesDetail> CPT_RelevesBancairesDetail { get; set; }

     
        public virtual ICollection<GEN_Regelement> GEN_Regelement { get; set; }

      
        public virtual ICollection<GEN_Tiers> GEN_Tiers { get; set; }

        
        public virtual ICollection<GEN_TypePaiementDetail> GEN_TypePaiementDetail { get; set; }
    }
}
