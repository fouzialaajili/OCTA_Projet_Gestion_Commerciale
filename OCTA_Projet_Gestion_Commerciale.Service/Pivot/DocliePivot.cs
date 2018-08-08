using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Service.Pivot
{
    public class DocliePivot
    {
        public long DoclieId { get; set; }
        public string DoclieNomdoc { get; set; }
        public string DoclieLien { get; set; }
        public int DoclieSysuser { get; set; }
        public DateTime DoclieSysDateCreation { get; set; }
        public DateTime DoclieSysDateUpdate { get; set; }
        public long? DoclieSocieteId { get; set; }
        public DossiersPivot DoclieSociete { get; set; }
    }
}
