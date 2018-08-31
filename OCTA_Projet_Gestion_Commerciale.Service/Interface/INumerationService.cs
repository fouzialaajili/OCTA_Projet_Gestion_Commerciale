using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Service.Interface
{
   public interface INumerationService
    {
        IEnumerable<NumerationPivot> GetALL();
        NumerationPivot GetNumeration(long? id);
        void DeletNumerationPivot(NumerationPivot Numeration);
        void UpdateNumerationPivot(NumerationPivot Numeration);
        void CreateNumerationPivot(NumerationPivot Numeration);
        void SaveNumerationPivot();
    }
}
