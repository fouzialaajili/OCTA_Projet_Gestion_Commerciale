
using OCTA_Projet_Gestion_Commerciale.Model;
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
    
        DevisesPivot GetDevise(long? id);
        IEnumerable<DevisesPivot> Getingdevises();
        void DeleteDevise(DevisesPivot devises);
        void UpdateDevise(DevisesPivot devises);
        void CreateDevise(DevisesPivot devises);
        IEnumerable<DevisesPivot> GetDeviseByCond();
        IEnumerable<DevisesPivot> GetDevisesByIDDossierAndActif();
        IEnumerable<DevisesPivot> GetAllDevises();
        DevisesPivot GetAttributes(DevisesPivot devisepivot);
        void SaveDevise();
    }
}
