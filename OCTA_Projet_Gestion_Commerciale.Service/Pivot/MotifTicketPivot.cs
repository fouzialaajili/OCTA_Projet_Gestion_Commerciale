﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Service.Pivot
{
    public class MotifTicketPivot
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

        /***/
        public long? MotifTicketTiersContactId { get; set; }
        public TicketPivot MotifTicketTicket { get; set; }
         public DossiersPivot MotifTicketSociete { get; set; }

    }
}
