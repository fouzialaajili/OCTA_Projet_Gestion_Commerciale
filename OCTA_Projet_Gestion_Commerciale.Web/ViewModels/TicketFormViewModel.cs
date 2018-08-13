using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCTA_Projet_Gestion_Commerciale.Web.ViewModels
{
    public class TicketFormViewModel
    {
        public long TicketId { get; set; }
        public long TicketNumero { get; set; }
        public DateTime? TicketDate_ouverture { get; set; }
        public long? TicketType { get; set; }
        public string TicketStatut { get; set; }
        public string TicketObjet { get; set; }
        public string TicketDescription { get; set; }
        public string TicketDegre { get; set; }

        /***/
        public long? TicketIdClient { get; set; }
        /***/
        public long? TicketIdRepresentant { get; set; }

        /***/
        public long? TicketIdcontact { get; set; }
        public long? TicketTypeaction { get; set; }
        public long TicketSysuser { get; set; }
        public DateTime? TicketSysDateCreation { get; set; }
        public DateTime? TicketSysDateUpdate { get; set; }
        public long? TicketDossierId { get; set; }
    }
}