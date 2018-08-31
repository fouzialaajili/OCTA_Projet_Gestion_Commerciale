using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Service.Interface
{
  public  interface ITVALettrageService
    {
        IEnumerable<TVALettragePivot> GetALL();
        TVALettragePivot GetTVALettrage(long? id);
        void DeletTVALettragePivot(TVALettragePivot TVALettrage);
        void UpdateTVALettragePivot(TVALettragePivot TVALettrage);
        void CreateTVALettragePivot(TVALettragePivot TVALettrage);
        void SaveTVALettragePivot();
    }
}
