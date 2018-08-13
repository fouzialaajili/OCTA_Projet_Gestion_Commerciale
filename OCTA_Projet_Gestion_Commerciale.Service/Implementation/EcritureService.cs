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
 
      public  IEnumerable<EcrituresPivot> GetEcrituresByIdDossiersAndByIdTiers(TiersPivot tiersPivot)
        {
           GEN_Tiers gen_tiers = Mapper.Map<TiersPivot, GEN_Tiers>(tiersPivot);

            IEnumerable<CPT_Ecritures> ecritures = ecritureRepository.GetEcrituresByIdDossiersAndByIdTiers(gen_tiers);

            IEnumerable<EcrituresPivot> ecrituresPivots= Mapper.Map<IEnumerable<CPT_Ecritures>, IEnumerable<EcrituresPivot>>(ecritures);
            return ecrituresPivots;
        }

    }
}
