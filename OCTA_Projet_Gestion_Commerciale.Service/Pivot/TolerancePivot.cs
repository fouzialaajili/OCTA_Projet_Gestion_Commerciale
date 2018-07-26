
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Service.Pivot
{
    public class TolerancePivot
    {
        public long ToleranceId { get; set; }
        public int ToleranceEntier { get; set; }

        public long ToleranceSocieteId { get; set; }
        public DossiersPivot ToleranceSociete { get; set; }

    }
}
