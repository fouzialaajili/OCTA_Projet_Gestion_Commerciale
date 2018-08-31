using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Service.Interface
{
    public interface IDocumentsService{
        IEnumerable<DocumentsPivot> GetALL();
        DocumentsPivot GetDocuments(long? id);
        void DeletDocumentsPivot(DocumentsPivot Documents);
        void UpdateDocumentsPivot(DocumentsPivot Documents);
        void CreateDocumentsPivot(DocumentsPivot Documents);
        void SaveDocumentsPivot();
    }
}
