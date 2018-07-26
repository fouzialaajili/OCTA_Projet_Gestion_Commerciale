
using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Service.Interface
{
    public interface IDocumentCommercialDetailSerieService
    {
        IEnumerable<DocumentCommercialDetailSeriePivot> GetALL();
        DocumentCommercialDetailSeriePivot GetDocumentCommercialDetailSeriePivot(long id);
    
        void DeleteDocumentCommercialDetailSeriePivot(DocumentCommercialDetailSeriePivot documentCommercialDetailSerie);
        void UpdateDocumentCommercialDetailSeriePivot(DocumentCommercialDetailSeriePivot documentCommercialDetailSerie);
        void CreateDocumentCommercialDetailSeriePivot(DocumentCommercialDetailSeriePivot documentCommercialDetailSerie);
        void SaveDocumentCommercialDetailSerie();
    }
}
