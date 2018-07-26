
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Service.Pivot
{
    public class OpportuniteDetailPivot
    {
        public long Id { get; set; }
        /***/
        public long OpportuniteDetailIdopportunite { get; set; }
        public long? OpportuniteDetailType_action { get; set; }
        /***/
        public long OpportuniteDetailIdcommercial { get; set; }
        public DateTime? OpportuniteDetailDateaction { get; set; }
        public DateTime? OpportuniteDetailHeureaction { get; set; }
        public string OpportuniteDetailDescription { get; set; }
        public long OpportuniteDetailSysuser { get; set; }
        public DateTime? OpportuniteDetailSysDateCreation { get; set; }
        public DateTime? OpportuniteDetailSysDateUpdate { get; set; }
         public TiersPivot OpportuniteDetailFichetier { get; set; }
        public OpportunitePivot OpportuniteDetailOpportunite { get; set; }
     


    }
}
