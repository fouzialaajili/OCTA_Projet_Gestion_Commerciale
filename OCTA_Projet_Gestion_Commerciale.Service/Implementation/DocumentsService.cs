using OCTA_Projet_Gestion_Commerciale.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Data.Repositories;
using OCTA_Projet_Gestion_Commerciale.Model;
using AutoMapper;

namespace OCTA_Projet_Gestion_Commerciale.Service.Implementation
{
    public class DocumentsService : IDocumentsService
    {
        private readonly IDocumentsRepository documentsRepository;
        private readonly IUnitOfWork unitOfWork;

        public DocumentsService(IDocumentsRepository documentsRepository, IUnitOfWork unitOfWork)
        {
            this.documentsRepository = documentsRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateDocumentsPivot(DocumentsPivot Documents)
        {
            GEN_Documents clas = Mapper.Map<DocumentsPivot, GEN_Documents>(Documents);
            documentsRepository.Add(clas);
        }

        public void DeletDocumentsPivot(DocumentsPivot Documents)
        {
            documentsRepository.Delete(Documents.Id, Mapper.Map<DocumentsPivot, GEN_Documents>(Documents));
        }

        public IEnumerable<DocumentsPivot> GetALL()
        {
            IEnumerable<GEN_Documents> documentes = documentsRepository.GetAll().ToList();
            IEnumerable<DocumentsPivot> documentesPivots = Mapper.Map<IEnumerable<GEN_Documents>, IEnumerable<DocumentsPivot>>(documentes);
            return documentesPivots;
        }

        public DocumentsPivot GetDocuments(long? id)
        {
            var compteg = documentsRepository.GetById((int)id);
            DocumentsPivot comptegPivot = Mapper.Map<GEN_Documents, DocumentsPivot>(compteg);
            return comptegPivot;
        }
        public void SaveDocumentsPivot()
        {
            unitOfWork.Commit();
        }

        public void UpdateDocumentsPivot(DocumentsPivot Documents)
        {
            documentsRepository.Update(Documents.Id, Mapper.Map<DocumentsPivot, GEN_Documents>(Documents));
        }
    }
}
