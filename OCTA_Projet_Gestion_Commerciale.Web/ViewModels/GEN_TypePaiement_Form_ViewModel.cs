using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCTA_Projet_Gestion_Commerciale.Web.ViewModels
{
    public class GEN_TypePaiement_Form_ViewModel
    {
            public long TypePaiementId { get; set; }

            public string Libelle { get; set; }

            public bool Actif { get; set; }
            public long? IdDossier { get; set; }




            public GEN_Dossiers_Form_ViewModel GEN_Dossiers { get; set; }


            public ICollection<CPT_RelevesBancairesDetail_Form_ViewModel> CPT_RelevesBancairesDetail { get; set; }


            public ICollection<GEN_Regelement_Form_ViewModel> GEN_Regelement { get; set; }


            public ICollection<GEN_Tiers_Form_ViewModel> GEN_Tiers { get; set; }


            public ICollection<GEN_TypePaiementDetail_Form_ViewModel> GEN_TypePaiementDetail { get; set; }


}
}