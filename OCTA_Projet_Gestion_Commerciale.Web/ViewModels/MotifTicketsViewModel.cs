using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCTA_Projet_Gestion_Commerciale.Web.ViewModels
{
    public class MotifTicketsViewModel
    {
        public long MotifTicketId { get; set; }
        /**/
        public long? MotifIdticket { get; set; }
        public string MotifTicketEtat { get; set; }
        public string MotifTicketMotif { get; set; }
        public string MotifTicketDescription { get; set; }
        public int MotifTicketSysuser { get; set; }
        public DateTime? MotifTicketSysDateCreation { get; set; }
        public DateTime? MotifTicketSysDateUpdate { get; set; }
        public long? MotifTicketTiersContactId { get; set; }
        public long? MotifTicketSocieteId { get; set; }
    }
}