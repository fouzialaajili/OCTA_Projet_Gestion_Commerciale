using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Service.Interface
{
  public  interface IPreferencesService
    {

        IEnumerable<PreferencesPivot> GetALL();
        PreferencesPivot GetPreferences(long? id);
        void DeletPreferencesPivot(PreferencesPivot Preferences);
        void UpdatePreferencesPivot(PreferencesPivot Preferences);
        void CreatePreferencesPivot(PreferencesPivot Preferences);
        void SavePreferencesPivot();
    }
}
