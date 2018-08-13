
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
       //IEnumerable<DevisesPivot> GetDevises();
        DevisesPivot GetDevise(long? id);
        IEnumerable<DevisesPivot> Getingdevises();
        void DeleteDevise(DevisesPivot devises);
        void UpdateDevise(DevisesPivot devises);
        void CreateDevise(DevisesPivot devises);
        IQueryable<GEN_Devises> GetAllDevises();
        IEnumerable<DevisesPivot> GetDevisesByIDDossierAndActif();
        IEnumerable<DevisesPivot> GetDeviseByCond();
        void DisposeDevise();
        IEnumerable<DevisesPivot> GetAllDevises();
        DevisesPivot GetAttributes(DevisesPivot devisepivot);
        void SaveDevise();
    }
}
