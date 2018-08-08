using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCTA_Projet_Gestion_Commerciale.Web.ViewModels
{
    public class DoclieFormViewModel
    {
        public long DoclieId { get; set; }
        public string DoclieNomdoc { get; set; }
        public string DoclieLien { get; set; }
        public int DoclieSysuser { get; set; }
        public DateTime DoclieSysDateCreation { get; set; }
        public DateTime DoclieSysDateUpdate { get; set; }
        public long? DoclieSocieteId { get; set; }
    }
}