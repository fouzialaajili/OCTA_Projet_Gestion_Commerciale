
using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Service.Interface
{
    interface IToleranceService
    {
        IEnumerable<TolerancePivot> GetALL();
        TolerancePivot GetTolerances(long id);
        IEnumerable<TolerancePivot> GetTolerancesByName(string identifged);
        void DeleteTolerances(TolerancePivot Tolerances);
        void UpdateTolerances(TolerancePivot Tolerances);
        void CreateTolerances(TolerancePivot Tolerances);
        void SaveTolerances();
    }
}
