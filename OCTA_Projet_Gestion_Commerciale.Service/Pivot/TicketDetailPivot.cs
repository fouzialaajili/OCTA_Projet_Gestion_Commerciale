
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Service.Pivot
{
    public class TicketDetailPivot
    {
        public long TicketDetailId { get; set; }
        /***/
        public long? TicketDetailIdTicket { get; set; }
        public long? TicketDetailTypeaction { get; set; }
        /***/
        public long? TicketDetailIdcommercial { get; set; }

        public DateTime? TicketDetailDateaction { get; set; }
        public DateTime? TicketDetailheureaction { get; set; }
        public string TicketDetailDescription { get; set; }
        public long? TicketDetailSysuser { get; set; }
        public DateTime? TicketDetailSysDateCreation { get; set; }
        public DateTime? TicketDetailSysDateUpdate { get; set; }



        public TiersPivot TicketDetailFichetier { get; set; }
       public TicketPivot TicketDetailTicket { get; set; }

    }
}
