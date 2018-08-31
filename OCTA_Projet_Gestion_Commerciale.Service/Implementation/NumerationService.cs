using OCTA_Projet_Gestion_Commerciale.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using OCTA_Projet_Gestion_Commerciale.Data.Repositories;
using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Model;
using AutoMapper;

namespace OCTA_Projet_Gestion_Commerciale.Service.Implementation
{
    public class NumerationService : INumerationService
    {
        private readonly INumerationRepository numerationRepository;
        private readonly IUnitOfWork unitOfWork;

        public NumerationService(INumerationRepository numerationRepository,IUnitOfWork unitOfWork)
        {
            this.numerationRepository = numerationRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateNumerationPivot(NumerationPivot Numeration)
        {
            GEN_Numeration numeration = Mapper.Map<NumerationPivot, GEN_Numeration>(Numeration);
            numerationRepository.Add(numeration);
        }

        public void DeletNumerationPivot(NumerationPivot Numeration)
        {
            numerationRepository.Delete(Numeration.Id, Mapper.Map<NumerationPivot, GEN_Numeration>(Numeration));
        }

        public IEnumerable<NumerationPivot> GetALL()
        {
            IEnumerable<GEN_Numeration> Numeration = numerationRepository.GetAll().ToList();
            IEnumerable<NumerationPivot> NumerationPivot = Mapper.Map<IEnumerable<GEN_Numeration>, IEnumerable<NumerationPivot>>(Numeration);
            return NumerationPivot;
        }

        public NumerationPivot GetNumeration(long? id)
        {
            var Numeration = numerationRepository.GetById((int)id);
            NumerationPivot NumerationPivot = Mapper.Map<GEN_Numeration, NumerationPivot>(Numeration);
            return NumerationPivot;
        }

        public void SaveNumerationPivot()
        {
            unitOfWork.Commit();
        }

        public void UpdateNumerationPivot(NumerationPivot Numeration)
        {
            numerationRepository.Update(Numeration.Id,Mapper.Map<NumerationPivot, GEN_Numeration>(Numeration));
        }
    }
}
