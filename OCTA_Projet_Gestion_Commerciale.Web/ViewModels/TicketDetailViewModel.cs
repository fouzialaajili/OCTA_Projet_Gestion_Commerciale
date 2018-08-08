using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCTA_Projet_Gestion_Commerciale.Web.ViewModels
{
    public class TicketDetailViewModel
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

    }
}