﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Model
{
    public class GES_Ticket
    {
        public long TicketId { get; set; }
        public long TicketNumero { get; set; }
        public DateTime? TicketDate_ouverture { get; set; }
        public long? TicketType { get; set; }
        public string TicketStatut { get; set; }
        public string TicketObjet { get; set; }
        public string TicketDescription { get; set; }
        public string TicketDegre { get; set; }
   
   /***/   public long? TicketIdClient { get; set; }
   /***/   public long? TicketIdRepresentant { get; set; }

   /***/
        public long? TicketIdcontact { get; set; }
        public long? TicketTypeaction { get; set; }
        public long TicketSysuser { get; set; }
        public DateTime? TicketSysDateCreation { get; set; }
        public DateTime? TicketSysDateUpdate { get; set; }
        virtual public GEN_Tiers TicketFichetier { get; set; }
        virtual public GES_Representant TicketRepresentant { get; set; }
        virtual public GEN_TiersContacts TicketFichetiersContact { get; set; }
    
  /***/ public long? TicketDossierId { get; set; }
        virtual  public GEN_Dossiers TicketDossier { get; set; }

        public virtual ICollection<GES_MotifTicket> TicketMotifTicket { get; set; }
        public virtual ICollection<GES_TicketDetail> GES_TicketDetail { get; set; }
    }
}
