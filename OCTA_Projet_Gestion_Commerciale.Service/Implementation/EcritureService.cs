using AutoMapper;
using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Data.Repositories;
using OCTA_Projet_Gestion_Commerciale.Model;
using OCTA_Projet_Gestion_Commerciale.Service.Interface;
using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Service.Implementation

{ public class EcritureService:IEcritureService
{
        private readonly IEcritureRepository ecritureRepository;
        private readonly IUnitOfWork unitOfWork;
        public EcritureService(IEcritureRepository ecritureRepository, IUnitOfWork unitOfWork)
        {
            this.ecritureRepository = ecritureRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateEcrituresPivot(EcrituresPivot Ecritures)
        {
            CPT_Ecritures clas = Mapper.Map<EcrituresPivot, CPT_Ecritures>(Ecritures);
            ecritureRepository.Add(clas);
        }

        public void DeletEcrituresPivot(EcrituresPivot Ecritures)
        {
            ecritureRepository.Delete(Ecritures.Id, Mapper.Map<EcrituresPivot, CPT_Ecritures>(Ecritures));
        }

        public IEnumerable<EcrituresPivot> GetALL()
        {
            IEnumerable<CPT_Ecritures> comptes = ecritureRepository.GetAll().ToList();
            IEnumerable<EcrituresPivot> comptesPivots = Mapper.Map<IEnumerable<CPT_Ecritures>, IEnumerable<EcrituresPivot>>(comptes);
            return comptesPivots;
        }

        public EcrituresPivot GetEcritures(long? id)
        {
            var compteg = ecritureRepository.GetById((int)id);
            EcrituresPivot comptegPivot = Mapper.Map<CPT_Ecritures, EcrituresPivot>(compteg);
            return comptegPivot;
        }

        public  IEnumerable<EcrituresPivot> GetEcrituresByIdDossiersAndByIdTiers(TiersPivot tiersPivot)
        {
           GEN_Tiers gen_tiers = Mapper.Map<TiersPivot, GEN_Tiers>(tiersPivot);

            IEnumerable<CPT_Ecritures> ecritures = ecritureRepository.GetEcrituresByIdDossiersAndByIdTiers(gen_tiers);

            IEnumerable<EcrituresPivot> ecrituresPivots= Mapper.Map<IEnumerable<CPT_Ecritures>, IEnumerable<EcrituresPivot>>(ecritures);
            return ecrituresPivots;
        }

        public void SaveEcrituresPivot()
        {
            unitOfWork.Commit();
        }

        public void UpdatEcrituresPivot(EcrituresPivot Ecritures)
        {
            ecritureRepository.Update(Ecritures.Id, Mapper.Map<EcrituresPivot, CPT_Ecritures>(Ecritures));
        }
    }
}
