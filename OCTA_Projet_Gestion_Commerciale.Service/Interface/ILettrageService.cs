using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Service.Interface
{
   public interface ILettrageService
    {
        IEnumerable<LettragePivot> GetALL();
        LettragePivot GetLettrage(long? id);
        void DeletLettragePivot(LettragePivot Lettrage);
        void UpdateLettragePivot(LettragePivot Lettrage);
        void CreateLettragePivot(LettragePivot Lettrage);
        void SaveLettragePivot();
    }
}
