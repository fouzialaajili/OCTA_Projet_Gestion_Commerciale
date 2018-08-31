using OCTA_Projet_Gestion_Commerciale.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCTA_Projet_Gestion_Commerciale.Web.ViewModels
{
    public class CPT_ComptesBancairesViewModel
    {
        public long Id { get; set; }

        public long? IdBanque { get; set; }

        public string NomAgence { get; set; }

        public string Adresse { get; set; }

        public string Contact { get; set; }


        public string Tel { get; set; }


        //[IsRIBUnique]      
        public string RIB { get; set; }

        public long? IdDevise { get; set; }

        public bool Actif { get; set; }

        public bool ParDefault { get; set; }

        public long? IdDossier { get; set; }

        public string sys_user { get; set; }

        public DateTime? sys_dateUpdate { get; set; }

        public DateTime? sys_dateCreation { get; set; }

        public long? IdCompteG { get; set; }
        public CPT_CompteGViewModel CPT_CompteG { get; set; }

        public DevisesViewModel GEN_Devises { get; set; }

        public DossierViewModel GEN_Dossiers { get; set; }

        public ItemsViewModel GEN_Items { get; set; }

        public ICollection<CPT_RelevesBancairesViewModel> CPT_RelevesBancaires { get; set; }
    }
}