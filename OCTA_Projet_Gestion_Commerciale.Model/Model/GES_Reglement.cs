using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Model
{
    public class GES_Reglement
    {
       public long ReglementId {get;set;}
        public long? ReglementType { get; set; }
        public string ReglementReference { get; set; }
        public string ReglementLibelle { get; set; }
        public DateTime? ReglementDatereglement { get; set; }
        public DateTime? ReglementDateecheance { get; set; }
   /***/     public long ReglementIdtiers { get; set; }
  /***/      public long ReglementIdmoyenpaiement { get; set; }
        public int DevisesId { get; set; }
        public int ReglementMontant { get; set; }
 /***/    public long ReglementBanqueId { get; set; }
        public string ReglementStatut { get; set; }
        public string ReglementEtat { get; set; }
        public DateTime? ReglementDatePaiement { get; set; }
        public bool ReglementPaye { get; set; }
        public long ReglementNumreleve { get; set; }
        public long ReglementSysuser { get; set; }
        public DateTime? ReglementSysDateCreation { get; set; }
        public DateTime? ReglementSysDateUpdate { get; set; }

       /***/ public long ReglementDossierId { get; set; }
        virtual public GEN_Dossiers ReglementDossier { get; set; }
        virtual public GEN_Tiers ReglementFichetier { get; set; }




    }
}
