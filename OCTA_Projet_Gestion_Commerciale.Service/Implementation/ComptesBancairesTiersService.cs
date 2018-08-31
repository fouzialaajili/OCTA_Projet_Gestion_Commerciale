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
    class ComptesBancairesTiersService : IComptesBancairesTiersService
    {
        private readonly IComptesBancairesTiersRepository comptebancairesRepository;
        private readonly IUnitOfWork unitOfWork;

        public ComptesBancairesTiersService(IComptesBancairesTiersRepository comptebancairesRepository, IUnitOfWork unitOfWork)
        {
            this.comptebancairesRepository = comptebancairesRepository;
            this.unitOfWork = unitOfWork;
        }




        public void CreateComptesBancairesTiersPivot(ComptesBancairesTiersPivot ComptesBancairesTiers)
        {
            CPT_ComptesBancairesTiers clas = Mapper.Map<ComptesBancairesTiersPivot, CPT_ComptesBancairesTiers>(ComptesBancairesTiers);
            comptebancairesRepository.Add(clas);
        }

        public void DeletComptesBancairesTiersPivot(ComptesBancairesTiersPivot ComptesBancairesTiers)
        {
            comptebancairesRepository.Delete(ComptesBancairesTiers.Id, Mapper.Map<ComptesBancairesTiersPivot, CPT_ComptesBancairesTiers>(ComptesBancairesTiers));
        }

        public IEnumerable<ComptesBancairesTiersPivot> GetALL()
        {
            IEnumerable<CPT_ComptesBancairesTiers> comptes = comptebancairesRepository.GetAll().ToList();
            IEnumerable<ComptesBancairesTiersPivot> comptesPivots = Mapper.Map<IEnumerable<CPT_ComptesBancairesTiers>, IEnumerable<ComptesBancairesTiersPivot>>(comptes);
            return comptesPivots;
        }

        public ComptesBancairesTiersPivot GetComptesBancairesTiers(long? id)
        {
            var compteg = comptebancairesRepository.GetById((int)id);
            ComptesBancairesTiersPivot comptegPivot = Mapper.Map<CPT_ComptesBancairesTiers, ComptesBancairesTiersPivot>(compteg);
            return comptegPivot;
        }

        public void SaveComptesBancairesTiersPivot()
        {
            unitOfWork.Commit();
        }

        public void UpdateComptesBancairesTiersPivot(ComptesBancairesTiersPivot ComptesBancairesTiers)
        {
            comptebancairesRepository.Update(ComptesBancairesTiers.Id, Mapper.Map<ComptesBancairesTiersPivot, CPT_ComptesBancairesTiers>(ComptesBancairesTiers));
        }
    }
}
