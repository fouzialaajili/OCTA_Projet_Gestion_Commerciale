using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCTA_Projet_Gestion_Commerciale.Web.ViewModels
{
    public class CPT_ComptesBancairesTiersFormViewModel
    {
        public long Id { get; set; }

        public string NomAgence { get; set; }
        public string Adresse { get; set; }

        public string Contact { get; set; }


        public string Tel { get; set; }


        public string RIB { get; set; }

        public long? IdDevise { get; set; }

        public bool? Actif { get; set; }

        public int? ParDefault { get; set; }

        public long? IdTiers { get; set; }

        public string sys_user { get; set; }

        public DateTime? sys_dateUpdate { get; set; }

        public DateTime? sys_dateCreation { get; set; }
        public DevisesFormViewModel GEN_Devises { get; set; }

        public TiersFormViewModel GEN_Tiers { get; set; }
    }
}