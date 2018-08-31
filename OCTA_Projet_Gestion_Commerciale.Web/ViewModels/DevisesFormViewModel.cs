using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCTA_Projet_Gestion_Commerciale.Web.ViewModels
{
    public class DevisesFormViewModel
    {
        public long DevisesId { get; set; }
        public string DevisesCode { get; set; }
        public string DevisesCodeIso { get; set; }
        public string DevisesSymbole { get; set; }
        public string DevisesDescription { get; set; }

        public double? DevisesCoursDevise { get; set; }

        public int? DevisesTenueDeCompte { get; set; }

        public bool DevisesActif { get; set; }

        public long? DevisesIdDossier { get; set; }

        public string Devisessys_user { get; set; }

        public DateTime? Devisessys_dateUpdate { get; set; }

        public DateTime? Devisessys_dateCreation { get; set; }

        //public DossierViewModel GEN_Dossiers { get; set; }

        //public ICollection<CPT_ComptesBancairesFormViewModel> CPT_ComptesBancaires { get; set; }

        //public ICollection<CPT_ComptesBancairesTiersFormViewModel> CPT_ComptesBancairesTiers { get; set; }

        //public ICollection<CPT_EcrituresFormViewModel> CPT_Ecritures_TC { get; set; }

        //public ICollection<CPT_EcrituresFormViewModel> CPT_Ecritures_TR { get; set; }

        //public ICollection<CPT_JournauxFormViewModel> CPT_Journaux { get; set; }

        //public ICollection<CPT_PiecesFormViewModel> CPT_Pieces_TC { get; set; }

        //public ICollection<CPT_PiecesFormViewModel> CPT_Pieces_TR { get; set; }
        //public ICollection<CPT_RelevesBancairesFormViewModel> CPT_RelevesBancaires { get; set; }
        ////public ICollection<TiersViewModel> GEN_Tiers { get; set; }
        //public ICollection<OpportuniteFormViewModel> GES_Opportunite { get; set; }
    }
}