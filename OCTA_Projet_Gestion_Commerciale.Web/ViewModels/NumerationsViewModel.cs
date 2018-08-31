using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCTA_Projet_Gestion_Commerciale.Web.ViewModels
{
    public class NumerationsViewModel
    {
        public long Id { get; set; }

        public string Objet { get; set; }

        public long? idDossier { get; set; }

        public string sys_user { get; set; }

        public DateTime? sys_dateUpdate { get; set; }

        public DateTime? sys_dateCreation { get; set; }
        public GEN_Dossiers_ViewModel GEN_Dossiers { get; set; }
    }
}