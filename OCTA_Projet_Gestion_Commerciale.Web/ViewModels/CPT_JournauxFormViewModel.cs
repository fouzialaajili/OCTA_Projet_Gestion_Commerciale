using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCTA_Projet_Gestion_Commerciale.Web.ViewModels
{
    public class CPT_JournauxFormViewModel
    {
        public long Id { get; set; }


        public string CodeJournal { get; set; }


        public string Libelle { get; set; }

        public long? TypeJournal { get; set; }


        public long? IdCompteContrepartie { get; set; }

        public long? IdDossier { get; set; }


        public long? IdDevise { get; set; }

        public bool Actif { get; set; }

        public string sys_user { get; set; }

        public DateTime? sys_DateUpdate { get; set; }

        public DateTime? sys_DateCreation { get; set; }
        public CPT_CompteGFormViewModel CPT_CompteG { get; set; }

        public DevisesFormViewModel GEN_Devises { get; set; }

        public GEN_Dossiers_Form_ViewModel GEN_Dossiers { get; set; }

        public ItemsFormViewModel GEN_Items { get; set; }

        public ICollection<CPT_ParametrageComptableFormViewModel> CPT_ParametrageComptable { get; set; }


        public ICollection<CPT_PiecesFormViewModel> CPT_Pieces { get; set; }


        public ICollection<GEN_Regelement_Form_ViewModel> GEN_Regelement { get; set; }
    }
}