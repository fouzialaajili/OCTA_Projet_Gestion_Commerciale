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
    public class NatureOperationService : INatureOperationService
    {

        private readonly INatureOperationRepository NatureOperationRepository;
        private readonly IUnitOfWork unitOfWork;

        public NatureOperationService(INatureOperationRepository NatureOperationRepository, IUnitOfWork unitOfWork)
        {
            this.NatureOperationRepository = NatureOperationRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateNatureOperationPivot(NatureOperationPivot NatureOperation)
        {
            CPT_NatureOperation clas = Mapper.Map<NatureOperationPivot, CPT_NatureOperation>(NatureOperation);
            NatureOperationRepository.Add(clas);
        }

        public void DeletNatureOperationPivot(NatureOperationPivot NatureOperation)
        {
            NatureOperationRepository.Delete(NatureOperation.Id, Mapper.Map<NatureOperationPivot, CPT_NatureOperation>(NatureOperation));
        }

        public IEnumerable<NatureOperationPivot> GetALL()
        {
            IEnumerable<CPT_NatureOperation> NatureOperation = NatureOperationRepository.GetAll().ToList();
            IEnumerable<NatureOperationPivot> NatureOperationPivots = Mapper.Map<IEnumerable<CPT_NatureOperation>, IEnumerable<NatureOperationPivot>>(NatureOperation);
            return NatureOperationPivots;
        }

        public NatureOperationPivot GetNatureOperation(long? id)
        {
            var NatureOperation = NatureOperationRepository.GetById((int)id);
            NatureOperationPivot natureOperationPivot = Mapper.Map< CPT_NatureOperation, NatureOperationPivot>(NatureOperation);
            return natureOperationPivot;
        }

        public void SaveNatureOperationPivot()
        {
            unitOfWork.Commit();
        }

        public void UpdateNatureOperationPivot(NatureOperationPivot NatureOperation)
        {
            NatureOperationRepository.Update(NatureOperation.Id, Mapper.Map<NatureOperationPivot, CPT_NatureOperation>(NatureOperation));
        }
    }
}
