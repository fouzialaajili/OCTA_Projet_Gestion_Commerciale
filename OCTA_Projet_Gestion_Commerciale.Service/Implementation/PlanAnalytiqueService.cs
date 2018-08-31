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
    public class PlanAnalytiqueService : IPlanAnalytiqueService
    {

        private readonly IPlanAnalytiqueRepository planAnalytiqueRepository;
        private readonly IUnitOfWork unitOfWork;

        public PlanAnalytiqueService(IPlanAnalytiqueRepository planAnalytiqueRepository, IUnitOfWork unitOfWork)
        {
            this.planAnalytiqueRepository = planAnalytiqueRepository;
            this.unitOfWork = unitOfWork;
        }


        public void CreatePlanAnalytiquePivot(PlanAnalytiquePivot PlanAnalytique)
        {
            CPT_PlanAnalytique clas = Mapper.Map<PlanAnalytiquePivot, CPT_PlanAnalytique>(PlanAnalytique);
            planAnalytiqueRepository.Add(clas);
        }

        public void DeletPlanAnalytiquePivot(PlanAnalytiquePivot PlanAnalytique)
        {
            planAnalytiqueRepository.Delete(PlanAnalytique.Id, Mapper.Map<PlanAnalytiquePivot, CPT_PlanAnalytique>(PlanAnalytique));
        }

        public IEnumerable<PlanAnalytiquePivot> GetALL()
        {

            IEnumerable<CPT_PlanAnalytique> comptes = planAnalytiqueRepository.GetAll().ToList();
            IEnumerable<PlanAnalytiquePivot> comptesPivots = Mapper.Map<IEnumerable<CPT_PlanAnalytique>, IEnumerable<PlanAnalytiquePivot>>(comptes);
            return comptesPivots;
        }

        public PlanAnalytiquePivot GetPlanAnalytique(long? id)
        {
            var compteg = planAnalytiqueRepository.GetById((int)id);
            PlanAnalytiquePivot comptegPivot = Mapper.Map<CPT_PlanAnalytique, PlanAnalytiquePivot>(compteg);
            return comptegPivot;
        }

        public void SavePlanAnalytiquePivot()
        {
            unitOfWork.Commit();
        }

        public void UpdatePlanAnalytiquePivot(PlanAnalytiquePivot PlanAnalytique)
        {
            planAnalytiqueRepository.Update(PlanAnalytique.Id, Mapper.Map<PlanAnalytiquePivot, CPT_PlanAnalytique>(PlanAnalytique));
        }
    }
}
