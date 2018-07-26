
using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Service.Interface
{
   public interface IDevisesService
    {
        IEnumerable<DevisesPivot> GetALL();
        DevisesPivot GetDevisesPivot(long id);
     
        void DeleteDevisesPivot(DevisesPivot devises);
        void UpdateDevisesPivot(DevisesPivot devises);
        void CreateDevisesPivot(DevisesPivot devises);
        void SaveDevisesPivot();
    }
}
