using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCTA_Projet_Gestion_Commerciale.Web.ViewModels
{
    public class DoclieartFormViewModel
    {
        public long DoclieartId { get; set; }
        public string DoclieartNomdoc { get; set; }
        public string DoclieartLien { get; set; }
        public int DoclieSysuser { get; set; }
        public DateTime DoclieSysDateCreation { get; set; }
        public DateTime DoclieSysDateUpdate { get; set; }
        public long? DoclieartSocieteId { get; set; }
    }
}