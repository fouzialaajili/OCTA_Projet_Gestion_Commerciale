using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Service.Interface
{
public    interface IEcheancesService
    {
        IEnumerable<EcheancesPivot> GetALL();
        EcheancesPivot GetEcheance(long? id);
        void DeletEcheancesPivot(EcheancesPivot Echeances);
        void UpdateEcheancesPivot(EcheancesPivot Echeances);
        void CreateEcheancesPivot(EcheancesPivot Echeances);
        void SaveEcheancesPivot();
    }
}
