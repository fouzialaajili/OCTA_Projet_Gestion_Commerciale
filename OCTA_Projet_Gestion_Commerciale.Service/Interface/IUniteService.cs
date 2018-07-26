
using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Service.Interface
{
    interface IUniteService
    {
        IEnumerable<UnitePivot> GetALL();
        UnitePivot GetUnitePivot(long id);
        IEnumerable<UnitePivot> GetUnitePivotsByName(string UniteName);
        void DeleteUnitePivot(UnitePivot doclieart);
        void UpdateUnitePivot(UnitePivot doclieart);
        void CreateUnitePivot(UnitePivot doclieart);
        void SaveUnitePivot();
    
}
}
