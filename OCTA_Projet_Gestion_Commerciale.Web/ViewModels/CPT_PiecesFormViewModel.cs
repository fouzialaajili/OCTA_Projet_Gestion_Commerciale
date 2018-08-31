using OCTA_Projet_Gestion_Commerciale.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCTA_Projet_Gestion_Commerciale.Web.ViewModels
{
    public class CPT_PiecesFormViewModel
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
      
        public CPT_JournauxFormViewModel CPT_Journaux { get; set; }

        public DevisesFormViewModel GEN_DevisesTC { get; set; }

        public DevisesFormViewModel GEN_DevisesTR { get; set; }

        public GEN_Dossiers_Form_ViewModel GEN_Dossiers { get; set; }

        public DossiersSitesFromViewModel GEN_DossiersSites { get; set; }

        public TiersFormViewModel GEN_Tiers { get; set; }


        public ICollection<CPT_EcrituresFormViewModel> CPT_Ecritures { get; set; }
    }
}