using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCTA_Projet_Gestion_Commerciale.Web.ViewModels
{
    public class DepotFormViewModel
    {
        public long DepotId { get; set; }

        public string DepotVille { get; set; }
        public string DepotPays { get; set; }
        public string DepotAdresse { get; set; }
        public string DepotDepot { get; set; }
        public string DepotCode { get; set; }
        public string DepotDescription  { get; set; }
        public int DepotSysuser { get; set; }
        public DateTime DepotSysDateCreation { get; set; }
        public DateTime DepotSysDateUpdate { get; set; }
        public bool DepotActif { get; set; }
        public long? DepotSocieteId { get; set; }
    }
}