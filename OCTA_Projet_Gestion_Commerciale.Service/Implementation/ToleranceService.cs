
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using OCTA_Projet_Gestion_Commerciale.Service.Interface;

using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Data.Repositories;
using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using OCTA_Projet_Gestion_Commerciale.Model;

namespace SOCTA_Projet_Gestion_Commerciale.Service.Implementation
{
    class ToleranceService : IToleranceService
    {
        private readonly IToleranceRepositoy toleranceRepository;


        private readonly IUnitOfWork unitOfWork;

        public ToleranceService(IToleranceRepositoy toleranceRepository, IUnitOfWork unitOfWork)
        {
            this.toleranceRepository = toleranceRepository;
            this.unitOfWork = unitOfWork;
        }


        public void CreateTolerances(TolerancePivot Tolerances)
        {
            GES_Tolerance item = Mapper.Map<TolerancePivot, GES_Tolerance>(Tolerances);
            toleranceRepository.Add(item);
        }

        public void DeleteTolerances(TolerancePivot Tolerances)
        {
           // toleranceRepository.Delete(Mapper.Map<TolerancePivot, GES_Tolerance>(Tolerances));
        }

        public IEnumerable<TolerancePivot> GetALL()
        {
            IEnumerable<GES_Tolerance> tolerances = toleranceRepository.GetAll().ToList();
            IEnumerable<TolerancePivot> tolerancesPivots = Mapper.Map<IEnumerable<GES_Tolerance>, IEnumerable<TolerancePivot>>(tolerances);
            return tolerancesPivots;
        }

        public TolerancePivot GetTolerances(long id)
        {
            var item =toleranceRepository.GetById((int)id);
            TolerancePivot tolerancesPivot = Mapper.Map<GES_Tolerance, TolerancePivot>(item);
            return tolerancesPivot;
        }

        public void SaveTolerances()
        {
            unitOfWork.Commit();
        }

        public IEnumerable<TolerancePivot> GetTolerancesByName(string identifged)
        {
            IEnumerable<GES_Tolerance> tolerances = toleranceRepository.GetItemsByModelLibelle(identifged).ToList();
            IEnumerable<TolerancePivot> tolerancesPivots = Mapper.Map<IEnumerable<GES_Tolerance>, IEnumerable<TolerancePivot>>(tolerances);
            return tolerancesPivots;
        }

        public void UpdateTolerances(TolerancePivot Tolerances)
        {
            toleranceRepository.Update(Mapper.Map<TolerancePivot, GES_Tolerance>(Tolerances));
        }
    }
}
