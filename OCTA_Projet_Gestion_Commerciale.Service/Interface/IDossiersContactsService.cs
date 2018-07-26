
using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Service.Interface
{
   public interface IDossiersContactsService
    {
        IEnumerable<DossiersContactsPivot> GetALL();
        DossiersContactsPivot GetDossiersContactsPivot(long id);
        IEnumerable<DossiersContactsPivot> GetDossiersContactsPivotByCodeDossier(string CodeDossier);
        void DeleteDossiersContactsPivot(DossiersContactsPivot dossiersContacts);
        void UpdateDossiersContactsPivot(DossiersContactsPivot dossiersContacts);
        void CreateDossiersContactsPivot(DossiersContactsPivot dossiersContacts);
        void SaveDossiersContacts();
    }
}
