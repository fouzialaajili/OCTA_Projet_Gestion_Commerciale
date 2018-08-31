using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Service.Interface
{
  public interface IEcritureService
    {
        IEnumerable<EcrituresPivot> GetEcrituresByIdDossiersAndByIdTiers(TiersPivot gEN_Tiers);
        IEnumerable<EcrituresPivot> GetALL();
        EcrituresPivot GetEcritures(long? id);
        void DeletEcrituresPivot(EcrituresPivot Ecritures);
        void UpdatEcrituresPivot(EcrituresPivot Ecritures);
        void CreateEcrituresPivot(EcrituresPivot Ecritures);
        void SaveEcrituresPivot();
    }
}
