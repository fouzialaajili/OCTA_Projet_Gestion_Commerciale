using OCTA_Projet_Gestion_Commerciale.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCTA_Projet_Gestion_Commerciale.Web.ViewModels
{
    public class DevisesViewModel
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

        public DossierViewModel GEN_Dossiers { get; set; }

        public ICollection<CPT_ComptesBancairesViewModel> CPT_ComptesBancaires { get; set; }

        public ICollection<CPT_ComptesBancairesTiersViewModel> CPT_ComptesBancairesTiers { get; set; }

        public ICollection<CPT_EcrituresViewModel> CPT_Ecritures_TC { get; set; }

        public ICollection<CPT_EcrituresViewModel> CPT_Ecritures_TR { get; set; }

        public ICollection<CPT_JournauxViewModel> CPT_Journaux { get; set; }

        public ICollection<CPT_PiecesViewModel> CPT_Pieces_TC { get; set; }

        public ICollection<CPT_PiecesViewModel> CPT_Pieces_TR { get; set; }
        public ICollection<CPT_RelevesBancairesViewModel> CPT_RelevesBancaires { get; set; }
        public ICollection<TiersViewModel> GEN_Tiers { get; set; }
        public ICollection<OpportuniteViewModel> GES_Opportunite { get; set; }
    }
}