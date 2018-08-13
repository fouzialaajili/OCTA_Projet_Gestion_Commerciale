using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCTA_Projet_Gestion_Commerciale.Web.ViewModels
{
    public class CPT_CompteGDetailTVAViewModel
    {
        public long Id { get; set; }

        public long? IdCodeTVA { get; set; }

        public long? IdCompteGenerale { get; set; }

        public double? TauxTva { get; set; }

        public int? Percue { get; set; }

        public int? Exonere { get; set; }

        public long? IdCompteG { get; set; }

        public string sys_user { get; set; }

        public DateTime? sys_dateUpdate { get; set; }

        public DateTime? sys_dateCreation { get; set; }
    }
}