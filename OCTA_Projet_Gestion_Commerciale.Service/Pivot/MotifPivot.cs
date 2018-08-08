
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Service.Pivot
{
    public class MotifPivot
    {
        public long MotifId { get; set; }
        /****/
        public long? OpportuniteId { get; set; }
        public string MotifEtat { get; set; }
        public string MotifMotif { get; set; }
        public string MotifDescription { get; set; }
        public DateTime? MotifSysDateCreation { get; set; }
        public DateTime? MotifSysDateUpdate { get; set; }


        public OpportunitePivot MotifOpportunite { get; set; }
        /***/
        public long MotifdossierId { get; set; }
         public DossiersPivot MotifSociete { get; set; }
    }
}
