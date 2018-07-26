
using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Service.Interface
{
    public interface IDocumentCommercialDetailService
    {
        IEnumerable<DocumentCommercialDetailPivot> GetALL();
        DocumentCommercialDetailPivot GetDocumentCommercialDetailPivot(long id);

        void DeleteDocumentCommercialDetailPivot(DocumentCommercialDetailPivot documentCommercialDetail);
        void UpdateDocumentCommercialDetailPivot(DocumentCommercialDetailPivot documentCommercialDetail);
        void CreateDocumentCommercialDetailPivot(DocumentCommercialDetailPivot documentCommercialDetail);
        void SaveDocumentCommercialDetail();
    }
}
