
using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Service.Interface
{
    public interface IDoclieartService
    {
        IEnumerable<DoclieartPivot> GetALL();
        DoclieartPivot  GetDevisesPivot(long id);
        IEnumerable<DoclieartPivot> GetDoclieartPivotByCode(string DoclieartNomdoc);
        void DeleteDoclieartPivot(DoclieartPivot doclieart);
        void UpdateDoclieartPivot(DoclieartPivot doclieart);
        void CreateDoclieartPivot(DoclieartPivot doclieart);
        void SaveDoclieartPivot();
    }
}
