using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Model
{
    public class GES_Periode
    {
        public long PeriodeId { get; set; }
        public DateTime? PeriodeAnnee { get; set; }
        public long? PeriodeTypePeriode { get; set; }
        public string PeriodeLibelle { get; set; }
        public DateTime? PeriodeDateDebut { get; set; }
        public DateTime? PeriodeDateFin { get; set; }
        public string PeriodeEtatPeriode { get; set; }
        public int PeriodeSysuser { get; set; }
        public DateTime? PeriodeSysDateCreation { get; set; }
        public DateTime? PeriodeSysDateUpdate { get; set; }
        public bool PeriodeAutoriserVente { get; set; }
        public bool PeriodeAutoriserAchat{ get; set; }
        public bool PeriodeAutoriserMvtStock { get; set; }
        public long PeriodeSocieteId { get; set; }
        virtual public GEN_Dossiers PeriodeSociete { get; set; }
    }
}
