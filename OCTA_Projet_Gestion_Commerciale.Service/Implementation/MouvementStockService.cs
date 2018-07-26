
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using OCTA_Projet_Gestion_Commerciale.Service.Interface;
using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;

using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using OCTA_Projet_Gestion_Commerciale.Model;
using OCTA_Projet_Gestion_Commerciale.Data.Repositories;

namespace OCTA_Projet_Gestion_Commerciale.Service.Implementation
{
    class MouvementStockService : IMouvementStockService
    {

        private readonly IMouvementStockRepository mouvementStockRepository;


        private readonly IUnitOfWork unitOfWork;

        public MouvementStockService(IMouvementStockRepository mouvementStockRepository, IUnitOfWork unitOfWork)
        {
            this.mouvementStockRepository = mouvementStockRepository;
            this.unitOfWork = unitOfWork;
        }
        public void CreateMouvementStock(MouvementStockPivot mouvementStock)
        {
            GES_MouvementStock item = Mapper.Map<MouvementStockPivot, GES_MouvementStock>(mouvementStock);
            mouvementStockRepository.Add(item);
        }

        public void DeleteMouvementStock(MouvementStockPivot mouvementStock)
        {
            mouvementStockRepository.Delete(Mapper.Map<MouvementStockPivot, GES_MouvementStock>(mouvementStock));
        }

        public IEnumerable<MouvementStockPivot> GetALL()
        {
            IEnumerable<GES_MouvementStock> mouvementStock = mouvementStockRepository.GetAll().ToList();
            IEnumerable<MouvementStockPivot> mouvementStockPivots = Mapper.Map<IEnumerable<GES_MouvementStock>, IEnumerable<MouvementStockPivot>>(mouvementStock);
            return mouvementStockPivots;
        }

        public MouvementStockPivot GetMouvementStocks(long id)
        {
            var item = mouvementStockRepository.GetById((int)id);
            MouvementStockPivot  motifPivot = Mapper.Map<GES_MouvementStock, MouvementStockPivot>(item);
            return motifPivot;
        }

        public IEnumerable<MouvementStockPivot> GetMouvementStocksByName(string identifged)
        {
            IEnumerable<GES_MouvementStock> motif = mouvementStockRepository.GetItemsByModelLibelle(identifged).ToList();
            IEnumerable<MouvementStockPivot> motifsPivots = Mapper.Map<IEnumerable<GES_MouvementStock>, IEnumerable<MouvementStockPivot>>(motif);
            return motifsPivots;
        }

        public void SaveMotif()
        {

            unitOfWork.Commit();
        }

        public void UpdateMouvementStock(MouvementStockPivot mouvementStock)
        {
            mouvementStockRepository.Update(Mapper.Map<MouvementStockPivot, GES_MouvementStock>(mouvementStock));
        }
    }
}
