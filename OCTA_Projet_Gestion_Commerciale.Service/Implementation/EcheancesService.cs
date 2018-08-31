using OCTA_Projet_Gestion_Commerciale.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Model;
using OCTA_Projet_Gestion_Commerciale.Data.Repositories;
using AutoMapper;

namespace OCTA_Projet_Gestion_Commerciale.Service.Implementation
{
    public class EcheancesService : IEcheancesService
    {
        private readonly IEcheancesRepository echeancesRepository;
        private readonly IUnitOfWork unitOfWork;

        public EcheancesService(IEcheancesRepository echeancesRepository, IUnitOfWork unitOfWork)
        {
            this.echeancesRepository = echeancesRepository;
            this.unitOfWork = unitOfWork;
        }



        public void CreateEcheancesPivot(EcheancesPivot Echeances)
        {
            CPT_Echeances clas = Mapper.Map<EcheancesPivot, CPT_Echeances>(Echeances);
            echeancesRepository.Add(clas);
        }

        public void DeletEcheancesPivot(EcheancesPivot Echeances)
        {
            echeancesRepository.Delete(Echeances.Id, Mapper.Map<EcheancesPivot, CPT_Echeances>(Echeances));
        }

        public IEnumerable<EcheancesPivot> GetALL()
        {
            IEnumerable<CPT_Echeances> comptes = echeancesRepository.GetAll().ToList();
            IEnumerable<EcheancesPivot> comptesPivots = Mapper.Map<IEnumerable<CPT_Echeances>, IEnumerable<EcheancesPivot>>(comptes);
            return comptesPivots;
        }

        public EcheancesPivot GetEcheance(long? id)
        {
            var compteg = echeancesRepository.GetById((int)id);
            EcheancesPivot comptegPivot = Mapper.Map<CPT_Echeances, EcheancesPivot>(compteg);
            return comptegPivot;
        }

        public void SaveEcheancesPivot()
        {

            unitOfWork.Commit();
        }

        public void UpdateEcheancesPivot(EcheancesPivot Echeances)
        {
            echeancesRepository.Update(Echeances.Id, Mapper.Map<EcheancesPivot, CPT_Echeances>(Echeances));
        }
    }
}
