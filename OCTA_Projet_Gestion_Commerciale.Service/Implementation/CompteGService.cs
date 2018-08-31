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
  public  class CompteGService : ICompteGService
    {

        private readonly ICompte_GRepository compteGRepository;
        private readonly IUnitOfWork unitOfWork;

        public CompteGService(ICompte_GRepository compteGRepository, IUnitOfWork unitOfWork)
        {
            this.compteGRepository = compteGRepository;
            this.unitOfWork = unitOfWork;
        }
        public void CreateCompteGPivot(CompteGPivot CompteG)
        {
            CPT_CompteG  clas = Mapper.Map<CompteGPivot, CPT_CompteG>(CompteG);
            compteGRepository.Add(clas);
        }

        public void DeletCompteGPivot(CompteGPivot CompteG)
        {
            compteGRepository.Delete(CompteG.Id, Mapper.Map<CompteGPivot, CPT_CompteG>(CompteG));
        }

        public IEnumerable<CompteGPivot> GetALL()
        {
            IEnumerable<CPT_CompteG> comptes = compteGRepository.GetAll().ToList();
            IEnumerable<CompteGPivot> comptesPivots = Mapper.Map<IEnumerable<CPT_CompteG>, IEnumerable<CompteGPivot>>(comptes);
            return comptesPivots;
        }

        public CompteGPivot GetCompteG(long? id)
        {
            var compteg= compteGRepository.GetById((int)id);
            CompteGPivot comptegPivot = Mapper.Map<CPT_CompteG, CompteGPivot>(compteg);
            return comptegPivot;
        }

        public void SaveCompteGPivot()
        {
            unitOfWork.Commit();
        }

        public void UpdateCompteGPivot(CompteGPivot CompteG)
        {
            compteGRepository.Update(CompteG.Id,Mapper.Map<CompteGPivot, CPT_CompteG>(CompteG));
        }
    }
}
