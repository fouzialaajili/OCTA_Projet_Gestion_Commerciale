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
   public class ComptesBancairesService : IComptesBancairesService
    {
        private readonly IComptesBancairesRepository comptebancairesRepository;
        private readonly IUnitOfWork unitOfWork;

        public ComptesBancairesService(IComptesBancairesRepository comptebancairesRepository, IUnitOfWork unitOfWork)
        {
            this.comptebancairesRepository = comptebancairesRepository;
            this.unitOfWork = unitOfWork;
        }
        public void CreateComptesBancairesPivot(ComptesBancairesPivot ComptesBancaires)
        {
            CPT_ComptesBancaires clas = Mapper.Map< ComptesBancairesPivot, CPT_ComptesBancaires>(ComptesBancaires);
            comptebancairesRepository.Add(clas);
        }

        public void DeletComptesBancairesPivot(ComptesBancairesPivot ComptesBancaires)
        {
            comptebancairesRepository.Delete(ComptesBancaires.Id, Mapper.Map<ComptesBancairesPivot, CPT_ComptesBancaires>(ComptesBancaires));
        }

        public IEnumerable<ComptesBancairesPivot> GetALL()
        {
            IEnumerable<CPT_ComptesBancaires> comptes = comptebancairesRepository.GetAll().ToList();
            IEnumerable<ComptesBancairesPivot> comptesPivots = Mapper.Map<IEnumerable<CPT_ComptesBancaires>, IEnumerable<ComptesBancairesPivot>>(comptes);
            return comptesPivots;
        }

        public ComptesBancairesPivot GetComptesBancaires(long? id)
        {
            var compteg = comptebancairesRepository.GetById((int)id);
            ComptesBancairesPivot comptegPivot = Mapper.Map<CPT_ComptesBancaires, ComptesBancairesPivot>(compteg);
            return comptegPivot;
        }

        public void SaveComptesBancairesPivot()
        {
            unitOfWork.Commit();
        }

        public void UpdateComptesBancairesPivot(ComptesBancairesPivot ComptesBancaires)
        {
            comptebancairesRepository.Update(ComptesBancaires.Id, Mapper.Map<ComptesBancairesPivot, CPT_ComptesBancaires>(ComptesBancaires));
        }
    }
}
