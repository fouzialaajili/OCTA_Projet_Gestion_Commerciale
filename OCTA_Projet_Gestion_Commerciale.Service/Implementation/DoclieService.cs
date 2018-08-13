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
    public class DoclieService : IDoclieService
    {
        private readonly IDoclieRepository doclieRepository;
        private readonly IUnitOfWork unitOfWork;
        public DoclieService(IDoclieRepository doclieRepository, IUnitOfWork unitOfWork)
        {
            this.doclieRepository = doclieRepository;
            this.unitOfWork = unitOfWork;

        }
public void CreateDocliePivot(DocliePivot doclie)
        {
            GES_Doclie doclies = Mapper.Map<DocliePivot, GES_Doclie>(doclie);
            doclieRepository.Add(doclies);
        }

        public void DeleteDocliePivot(DocliePivot doclie)
        {
          //  doclieRepository.Delete(Mapper.Map<DocliePivot, GES_Doclie>(doclie));
        }

        public IEnumerable<DocliePivot> GetALL()
        {
            IEnumerable<GES_Doclie> doclieartPivots = doclieRepository.GetAll().ToList();
            IEnumerable<DocliePivot> docliePivot = Mapper.Map<IEnumerable<GES_Doclie>, IEnumerable<DocliePivot>>(doclieartPivots);
            return docliePivot;
        }

        public DocliePivot GetDocliePivot(long id)
        {
            var doclie = doclieRepository.GetById((int)id);
            DocliePivot docliePivot = Mapper.Map<GES_Doclie, DocliePivot>(doclie);
            return docliePivot;
        }

        public IEnumerable<DocliePivot> GetDocliePivotByCode(string DoclieartNomdoc)
        {
            throw new NotImplementedException();
        }

        public void SaveDocliePivot()
        {
            unitOfWork.Commit();
        }

        public void UpdateDocliePivot(DocliePivot doclie)
        {
            doclieRepository.Update(Mapper.Map<DocliePivot, GES_Doclie>(doclie));
        }
    }
}
