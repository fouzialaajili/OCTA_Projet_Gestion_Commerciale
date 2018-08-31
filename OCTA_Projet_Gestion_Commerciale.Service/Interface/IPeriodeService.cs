
using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Service.Interface
{
    public interface IPeriodeService
    {
        IEnumerable<PeriodePivot> GetALL();
        PeriodePivot GetPeriodes(long id);
        IEnumerable<PeriodePivot> GetPeriodesByName(string identifged);
        void DeletePeriode(PeriodePivot Periodes);
        void UpdatePeriode(PeriodePivot Periodes);
        void CreatePeriodes(PeriodePivot Periodes);
        void SavePeriode();
    }
}
