
using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Service.Interface
{
    interface INumerotationService
    {
        IEnumerable<NumerotationPivot> GetALL();
        NumerotationPivot GetNumerotation(long id);
        IEnumerable<NumerotationPivot> GetNumerotationsByName(string identifged);
        void DeleteNumerotation(NumerotationPivot numerotation);
        void UpdateNumerotation(NumerotationPivot numerotation);
        void CreateNumerotation(NumerotationPivot numerotation);
        void SaveMotif();
    }
}
