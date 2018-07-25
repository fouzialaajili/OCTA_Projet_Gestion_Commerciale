using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Model
{
    public class GES_Objectif
    {
        public long ObjectifId { get; set; }
   /***/public long ObjectifRepresentantId { get; set; }
        public DateTime? ObjectifAnnee { get; set;}
        public int ObjectifPeriode { get; set; }
        public DateTime? ObjectifDatedebut { get; set; }
        public DateTime? ObjectifDatefin { get; set; }
        public int ObjectifObjectif { get; set; }
        public decimal ObjectifCommission { get; set; }
        public long ObjectifSysuser { get; set; }
        public DateTime? ObjectifSysDateCreation { get; set; }
        public DateTime? ObjectifSysDateUpdate { get; set; }

     /***/   public long ObjectifDossierId { get; set; }
        virtual public GEN_Dossiers ObjectifDossier{ get; set; }
        virtual public GES_Representant ObjectifRepresentant { get; set; }

    }
}
