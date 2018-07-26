
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Service.Pivot
{
    public class NumerationPivot
    {
        public long Id { get; set; }

        public string Objet { get; set; }

        public long? idDossier { get; set; }

        public string Sys_user { get; set; }

        public DateTime? Sys_dateUpdate { get; set; }

        public DateTime? Sys_dateCreation { get; set; }

        public DossiersPivot GEN_Dossiers { get; set; }
    }
}
