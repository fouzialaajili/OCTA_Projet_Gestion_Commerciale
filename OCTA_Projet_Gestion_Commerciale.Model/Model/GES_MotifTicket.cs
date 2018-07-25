using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Model
{
    public class GES_MotifTicket
    {
        public long MotifTicketId { get; set; }
   /**/     public long MotifIdticket { get; set; }
        public string MotifTicketEtat { get; set; }
        public string MotifTicketMotif { get; set; }
        public string MotifTicketDescription{ get; set; }
        public int MotifTicketSysuser { get; set; }
        public DateTime? MotifTicketSysDateCreation { get; set;}
        public DateTime? MotifTicketSysDateUpdate { get; set;}

    /***/    public long MotifTicketSocieteId { get; set; }
         virtual  public GEN_TiersContact MotifTicketTicket { get; set; }
          virtual public GEN_Dossiers MotifTicketSociete { get; set; }

    }

}
