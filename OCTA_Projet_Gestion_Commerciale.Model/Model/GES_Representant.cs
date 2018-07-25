using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Model
{
    public class GES_Representant
    {
        public long RepresentantId { get; set; }
        public string RepresentantCode { get; set; }
        public string RepresentantCivilite { get; set; }
        public string RepresentantNom { get; set; }
        public string RepresentantAdresse { get; set; }
        public string RepresentantTelephone { get; set; }
        public string RepresentantGsm { get; set; }
        public string RepresentantVille { get; set; }
        public string RepresentantPays { get; set; }
        public string RepresentantEmail { get; set; }
        public string RepresentantFonction { get; set; }
        public bool RepresentantActif { get; set; }
        public bool RepresentantAcheteur { get; set; }
        public bool RepresentantVenseur { get; set; }
        public string RepresentantLogin { get; set; }
        public string RepresentantPasswoord{ get; set; }

        public long RepresentantProfil { get; set; }

        public bool RepresentantBc { get; set; }

        public long RepresentantSysuser { get; set; }
        public DateTime? RepresentantSysDateCreation { get; set; }
        public DateTime? ZenRepresentantSysDateUpdate { get; set; }

      
       /***/ public long RepresentantDossierId { get; set; }
        virtual public GEN_Dossiers RepresentantDossier { get; set; }
        public virtual ICollection<GES_Objectif> RepresentantObject { get; set; }
        public virtual ICollection<GEN_Tiers> RepresentantFichetier { get; set; }
        public virtual ICollection<GEN_TiersContact> RepresentantTicket { get; set; }


    }
}
