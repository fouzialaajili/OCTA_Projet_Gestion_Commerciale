using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using OCTA_Projet_Gestion_Commerciale.Service.Interface;

using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Model;
using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using OCTA_Projet_Gestion_Commerciale.Data.Repositories;

namespace OCTA_Projet_Gestion_Commerciale.Service.Implementation
{
   public class TiersService : ITiersService
    { 
        private readonly ITiersRepository iTiersRepository;


        private readonly IUnitOfWork unitOfWork;

        public TiersService(ITiersRepository iTiersRepository, IUnitOfWork unitOfWork)
        {
            this.iTiersRepository = iTiersRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateTiers(TiersPivot Tiers)
        {
            GEN_Tiers item = Mapper.Map<TiersPivot, GEN_Tiers>(Tiers);
            iTiersRepository.Add(item);
            SaveTiers();
        }

        public void DeleteTiers(TiersPivot Tiers)
        {

      iTiersRepository.Delete(Tiers.Id,Mapper.Map<TiersPivot, GEN_Tiers>(Tiers));
            SaveTiers();
        }

        public IEnumerable<TiersPivot> GetALL()
        {
            IEnumerable<GEN_Tiers> tiers = iTiersRepository.GetAll().ToList();
            IEnumerable<TiersPivot> tiersPivots = Mapper.Map<IEnumerable<GEN_Tiers>, IEnumerable<TiersPivot>>(tiers);
            return tiersPivots;
           // return tiers;
        }

        public TiersPivot  GetTier (long? id)
        {
            var item = iTiersRepository.GetById((int)id);
            TiersPivot tiersPivot = Mapper.Map<GEN_Tiers, TiersPivot>(item);
            return tiersPivot;
        }

        public void SaveTiers()
        {
            unitOfWork.Commit();
        }

        public IEnumerable<TiersPivot> GetTiersByName(string identifged)
        {
            IEnumerable<GEN_Tiers> tiers = iTiersRepository.GetItemsByModelLibelle(identifged).ToList();
            IEnumerable<TiersPivot> tiersPivots = Mapper.Map<IEnumerable<GEN_Tiers>, IEnumerable<TiersPivot>>(tiers);
            return tiersPivots;
        }

        public void UpdateTiers(TiersPivot Tiers)
        {
            iTiersRepository.Update(Mapper.Map<TiersPivot, GEN_Tiers>(Tiers));
            SaveTiers();
        }

        public TiersPivot GetTiers()
        {
            var item = iTiersRepository.GetTiers();
            TiersPivot tiersPivot = Mapper.Map<GEN_Tiers, TiersPivot>(item);
            return tiersPivot;
        }

        public IEnumerable<TiersPivot> GetTiersByItems_TypeTiers(string Type)
        {
            IEnumerable<GEN_Tiers> tiers = iTiersRepository.GetTiersByItems_TypeTiers(Type).ToList();
            IEnumerable<TiersPivot> tiersPivots = Mapper.Map<IEnumerable<GEN_Tiers>, IEnumerable<TiersPivot>>(tiers);
            return tiersPivots;
        }
    }
}
