using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCTA_Projet_Gestion_Commerciale.Web.ViewModels
{
    public class MotifFormViewModel
    {
        public long MotifId { get; set; }
        /****/
        public long? OpportuniteId { get; set; }
        public string MotifEtat { get; set; }
        public string MotifMotif { get; set; }
        public string MotifDescription { get; set; }
        public DateTime? MotifSysDateCreation { get; set; }
        public DateTime? MotifSysDateUpdate { get; set; }
        public long? MotifdossierId { get; set; }
    }
}