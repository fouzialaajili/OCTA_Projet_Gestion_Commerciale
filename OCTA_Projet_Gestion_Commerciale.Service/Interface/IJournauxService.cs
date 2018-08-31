using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Service.Interface
{
 public   interface IJournauxService
    {
        IEnumerable<JournauxPivot> GetALL();
        JournauxPivot GetJournaux(long? id);
        void DeletJournauxPivot(JournauxPivot Journaux);
        void UpdateJournauxPivot(JournauxPivot Journaux);
        void CreateJournauxPivot(JournauxPivot Journaux);
        void SaveJournauxPivot();

    }
}
