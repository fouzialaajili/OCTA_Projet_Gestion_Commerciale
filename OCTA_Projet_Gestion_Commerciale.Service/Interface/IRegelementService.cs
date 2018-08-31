using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Service.Interface
{
  public  interface IRegelementService
    {
        IEnumerable<RegelementPivot> GetALL();
        RegelementPivot GetRegelement(long? id);
        void DeletRegelementPivot(RegelementPivot Regelement);
        void UpdateRegelementPivot(RegelementPivot Regelement);
        void CreateRegelementPivot(RegelementPivot Regelement);
        void SaveRegelementPivot();


    }
}
