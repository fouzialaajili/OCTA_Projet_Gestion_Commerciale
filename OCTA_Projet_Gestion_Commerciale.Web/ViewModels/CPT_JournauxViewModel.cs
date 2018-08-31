using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCTA_Projet_Gestion_Commerciale.Web.ViewModels
{
    public class CPT_JournauxViewModel
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
        public CPT_CompteGViewModel CPT_CompteG { get; set; }

        public DevisesViewModel GEN_Devises { get; set; }

        public GEN_Dossiers_ViewModel GEN_Dossiers { get; set; }

        public ItemsViewModel GEN_Items { get; set; }

        public ICollection<CPT_ParametrageComptableViewModel> CPT_ParametrageComptable { get; set; }


        public ICollection<CPT_PiecesViewModel> CPT_Pieces { get; set; }


        public ICollection<GEN_Regelement_ViewModel> GEN_Regelement { get; set; }
    }
}