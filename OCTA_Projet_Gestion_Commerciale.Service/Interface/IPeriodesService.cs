using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Service.Interface
{
 public   interface IPeriodesService
    {
        IEnumerable<PeriodesPivot> GetALL();
        PeriodesPivot GetPeriodes(long id);
       
        void DeletePeriodes(PeriodesPivot Periodes);
        void UpdatePeriodes(PeriodesPivot Periodes);
        void CreatePeriodes(PeriodesPivot Periodes);
        void SavePeriodes();
    }
}
