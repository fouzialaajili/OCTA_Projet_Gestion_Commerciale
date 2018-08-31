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
    class CompteGDetailTVAService : ICompteGDetailTVAService
    {
        private readonly ICompte_GDetailTVARepository compteGRepository;
        private readonly IUnitOfWork unitOfWork;

        public CompteGDetailTVAService(ICompte_GDetailTVARepository compteGRepository, IUnitOfWork unitOfWork)
        {
            this.compteGRepository = compteGRepository;
            this.unitOfWork = unitOfWork;
        }
        public void CreateCompteGDetailTVAPivot(CompteGDetailTVAPivot CompteGDetailTVA)
        {
            CPT_CompteGDetailTVA clas = Mapper.Map<CompteGDetailTVAPivot, CPT_CompteGDetailTVA>(CompteGDetailTVA);
            compteGRepository.Add(clas);
        }

        public void DeletCompteGDetailTVAPivot(CompteGDetailTVAPivot CompteGDetailTVA)
        {
            compteGRepository.Delete(CompteGDetailTVA.Id, Mapper.Map< CompteGDetailTVAPivot, CPT_CompteGDetailTVA > (CompteGDetailTVA));
        }

        public IEnumerable<CompteGDetailTVAPivot> GetALL()
        {
            IEnumerable<CPT_CompteGDetailTVA> comptes = compteGRepository.GetAll().ToList();
            IEnumerable<CompteGDetailTVAPivot> comptesPivots = Mapper.Map<IEnumerable<CPT_CompteGDetailTVA>, IEnumerable<CompteGDetailTVAPivot>>(comptes);
            return comptesPivots;
        }

        public CompteGDetailTVAPivot GetCompteGDetailTVA(long? id)
        {
            var compteg = compteGRepository.GetById((int)id);
            CompteGDetailTVAPivot comptegPivot = Mapper.Map<CPT_CompteGDetailTVA, CompteGDetailTVAPivot>(compteg);
            return comptegPivot;
        }

        public void SaveCompteGDetailTVAPivot()
        {
            unitOfWork.Commit();
        }

        public void UpdateCompteGDetailTVAPivot(CompteGDetailTVAPivot CompteGDetailTVA)
        {
            compteGRepository.Update(CompteGDetailTVA.Id,Mapper.Map<CompteGDetailTVAPivot, CPT_CompteGDetailTVA>(CompteGDetailTVA));
        }
    }
}
