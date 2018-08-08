using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCTA_Projet_Gestion_Commerciale.Web.ViewModels
{
    public class CPT_CompteGFormViewModel
    {
        public long Id { get; set; }

        public string Code { get; set; }


        public string Libelle { get; set; }

        public long? IdClasse { get; set; }

        public long? IdTypeCompte { get; set; }

        public long? IdNatureCompte { get; set; }

        public long? IdCodeTvaDefault { get; set; }

        public bool Ana { get; set; }

        public bool Rappro { get; set; }

        public bool Lettrage { get; set; }

        public bool Pointage { get; set; }

        public long? Sens { get; set; }

        public bool Actif { get; set; }

        public long? SuiviCompteTVA { get; set; }

        public long? ReportANouveau { get; set; }

        public long? IdDossier { get; set; }

        public string sys_user { get; set; }

        public DateTime? sys_dateUpdate { get; set; }

        public DateTime? sys_dateCreation { get; set; }
    }
}