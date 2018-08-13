using AutoMapper;
using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Data.Repositories;
using OCTA_Projet_Gestion_Commerciale.Model;
using OCTA_Projet_Gestion_Commerciale.Service.Interface;
using OCTA_Projet_Gestion_Commerciale.Service.Pivot;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Service.Implementation
{
    public class DocumentCommercialService : IDocumentCommercialService
    {
        private readonly IDocumentCommercialRepository documentCommercialRepository;
        private readonly IUnitOfWork unitOfWork;
        public DocumentCommercialService(IDocumentCommercialRepository documentCommercialRepository, IUnitOfWork unitOfWork)
        {
            this.documentCommercialRepository = documentCommercialRepository;
            this.unitOfWork = unitOfWork;

        }
        

        public void CreateDocumentCommercialPivot(DocumentCommercialPivot documentCommercial)
        {
            GES_DocumentCommercial doclies = Mapper.Map<DocumentCommercialPivot, GES_DocumentCommercial>(documentCommercial);
            documentCommercialRepository.Add(doclies);
        }

        public void DeleteDocumentCommercialPivot(DocumentCommercialPivot documentCommercial)
        {
           // documentCommercialRepository.Delete(Mapper.Map<DocumentCommercialPivot, GES_DocumentCommercial>(documentCommercial));
        }

        public IEnumerable<DocumentCommercialPivot> GetALL()
        {
            IEnumerable<GES_DocumentCommercial> documentCommercial = documentCommercialRepository.GetAll().ToList();
            IEnumerable<DocumentCommercialPivot> documentCommercialPivot = Mapper.Map<IEnumerable<GES_DocumentCommercial>, IEnumerable<DocumentCommercialPivot>>(documentCommercial);
            return documentCommercialPivot;
        }

        public DocumentCommercialPivot GetDocumentCommercialPivot(long id)
        {
            var documentCommercial = documentCommercialRepository.GetById((int)id);
            DocumentCommercialPivot documentCommercialPivot = Mapper.Map<GES_DocumentCommercial, DocumentCommercialPivot >(documentCommercial);
            return documentCommercialPivot;
        }

        public void SaveDocumentCommercial()
        {
            /// throw new NotImplementedException();
            unitOfWork.Commit();
        }

        public void UpdateDocumentCommercialPivot(DocumentCommercialPivot documentCommercial)
        {
            documentCommercialRepository.Update(Mapper.Map<DocumentCommercialPivot, GES_DocumentCommercial>(documentCommercial));
            
        }
    }
}
