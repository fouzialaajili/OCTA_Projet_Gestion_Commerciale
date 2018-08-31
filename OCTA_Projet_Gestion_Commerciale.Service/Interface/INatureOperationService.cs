using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Service.Interface
{
  public  interface INatureOperationService
    {
        IEnumerable<NatureOperationPivot> GetALL();
        NatureOperationPivot GetNatureOperation(long? id);
        void DeletNatureOperationPivot(NatureOperationPivot NatureOperation);
        void UpdateNatureOperationPivot(NatureOperationPivot NatureOperation);
        void CreateNatureOperationPivot(NatureOperationPivot NatureOperation);
        void SaveNatureOperationPivot();

    }
}
