using OCTA_Projet_Gestion_Commerciale.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Data.Repositories;
using AutoMapper;
using OCTA_Projet_Gestion_Commerciale.Model;

namespace OCTA_Projet_Gestion_Commerciale.Service.Implementation
{
    public class RegelementService : IRegelementService
    {

        private readonly IRegelementRepository regelementRepository;


        private readonly IUnitOfWork unitOfWork;

        public RegelementService(IRegelementRepository regelementRepository, IUnitOfWork unitOfWork)
        {
            this.regelementRepository = regelementRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateRegelementPivot(RegelementPivot Regelement)
        {

            GEN_Regelement item = Mapper.Map<RegelementPivot, GEN_Regelement>(Regelement);
            regelementRepository.Add(item);
        }

        public void DeletRegelementPivot(RegelementPivot Regelement)
        {
            regelementRepository.Delete(Regelement.Id, Mapper.Map<RegelementPivot, GEN_Regelement>(Regelement));
        }

        public IEnumerable<RegelementPivot> GetALL()
        {
            IEnumerable<GEN_Regelement> reglement = regelementRepository.GetAll().ToList();
            IEnumerable<RegelementPivot> reglementPivots = Mapper.Map<IEnumerable<GEN_Regelement>, IEnumerable<RegelementPivot>>(reglement);
            return reglementPivots;
        }

        public RegelementPivot GetRegelement(long? id)
        {
            var item = regelementRepository.GetById((int)id);
            RegelementPivot reglementFacturePivots = Mapper.Map<GEN_Regelement, RegelementPivot>(item);
            return reglementFacturePivots;
        }

        public void SaveRegelementPivot()
        {
            unitOfWork.Commit();
        }

        public void UpdateRegelementPivot(RegelementPivot Regelement)
        {
            regelementRepository.Update(Regelement.Id,Mapper.Map<RegelementPivot, GEN_Regelement>(Regelement));
        }
    }
}
