using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCTA_Projet_Gestion_Commerciale.Web.ViewModels
{
    public class GEN_Tiers_ViewModel
    {
        public long Id { get; set; }
        public string code { get; set; }
        public string Ville { get; set; }
        public string Tel { get; set; }
        public string RaisonSociale { get; set; }
        public string Pays { get; set; }

    }
}