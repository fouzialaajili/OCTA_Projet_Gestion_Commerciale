
using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Service.Interface
{
    public interface ITiersContactsService
    {
        IEnumerable<TiersContactsPivot> GetALL();
        TiersContactsPivot GetTiersContacts(long id);
        IEnumerable<TiersContactsPivot>GetTiersContactByName(string identifged);
        void DeleteTiersContacts(TiersContactsPivot TiersContact);
        void UpdateTiersContacts(TiersContactsPivot TiersContact);
        void CreateTiersContacts(TiersContactsPivot TiersContact);
        IEnumerable<TiersContactsPivot> GetTiersContactsByIdTiersAndActif(long id);
    
            void SaveTiersContacts();
    }
}
