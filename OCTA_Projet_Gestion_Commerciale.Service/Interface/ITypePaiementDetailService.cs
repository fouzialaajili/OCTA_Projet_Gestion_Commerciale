
using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Service.Interface
{
   public interface ITypePaiementDetailService
    {
        IEnumerable<TypePaiementDetailPivot> GetALL();
        TypePaiementDetailPivot GetTypePaiementDetails(long id);
        IEnumerable<TypePaiementDetailPivot> GetTypePaiementDetailsByName(string identifged);
        void DeleteTypePaiementDetail(TypePaiementDetailPivot TypePaiementDetail);
        void UpdateTypePaiementDetail(TypePaiementDetailPivot TypePaiementDetail);
        void CreateTypePaiementDetail(TypePaiementDetailPivot TypePaiementDetail);
        IEnumerable<TypePaiementDetailPivot> GetTypePaiementDetailByTypePaiementId(long id);
        void SaveTypePaiementDetail();
    }
}
