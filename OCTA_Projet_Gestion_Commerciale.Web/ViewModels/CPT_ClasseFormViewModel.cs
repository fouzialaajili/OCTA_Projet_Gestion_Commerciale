using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCTA_Projet_Gestion_Commerciale.Web.ViewModels
{
    public class CPT_ClasseFormViewModel
    {
        public long Id { get; set; }


        public string CodeClasse { get; set; }

        public string Libelle { get; set; }

        public long? IdClasse { get; set; }

        public long? IdDossier { get; set; }

        public string sys_user { get; set; }

        public DateTime? Sys_dateUpdate { get; set; }

        public DateTime? Sys_dateCreation { get; set; }
    }
}