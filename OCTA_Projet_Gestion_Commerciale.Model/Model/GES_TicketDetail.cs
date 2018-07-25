using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Model
{
    public class GES_TicketDetail
    {
        public long TicketDetailId { get; set; }
    /***/    public long TicketDetailIdTicket { get; set; }
        public long? TicketDetailTypeaction { get; set; }
    /***/    public long TicketDetailIdcommercial { get; set; }

        public DateTime? TicketDetailDateaction { get; set; }
        public DateTime? TicketDetailheureaction { get; set; }
        public string TicketDetailDescription { get; set; }
        public long TicketDetailSysuser { get; set; }
        public DateTime? TicketDetailSysDateCreation { get; set; }
        public DateTime? TicketDetailSysDateUpdate { get; set; }

      

        virtual public GEN_Tiers TicketDetailFichetier { get; set; }
        virtual public GEN_TiersContact TicketDetailTicket { get; set; }
       

    }
}
