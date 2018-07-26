
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
    class ReglementService : IReglementService
    {

        private readonly IReglementRepository reglementRepository;


        private readonly IUnitOfWork unitOfWork;

        public ReglementService(IReglementRepository reglementRepository, IUnitOfWork unitOfWork)
        {
            this.reglementRepository = reglementRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateReglement(ReglementPivot Reglement)
        {

            GES_Reglement item = Mapper.Map<ReglementPivot, GES_Reglement>(Reglement);
            reglementRepository.Add(item);
        }

        public void DeleteReglement(ReglementPivot Reglement)
        {
            reglementRepository.Delete(Mapper.Map<ReglementPivot, GES_Reglement>(Reglement));
        }

        public IEnumerable<ReglementPivot> GetALL()
        {
            IEnumerable<GES_Reglement> reglement= reglementRepository.GetAll().ToList();
            IEnumerable<ReglementPivot> reglementPivots = Mapper.Map<IEnumerable<GES_Reglement>, IEnumerable<ReglementPivot>>(reglement);
            return reglementPivots;
        }

        public ReglementPivot GetReglement(long id)
        {
            var item = reglementRepository.GetById((int)id);
            ReglementPivot reglementFacturePivots = Mapper.Map<GES_Reglement, ReglementPivot>(item);
            return reglementFacturePivots;
        }

        public IEnumerable<ReglementPivot> GetReglementsByName(string identifged)
        {
            IEnumerable<GES_Reglement> reglement = reglementRepository.GetItemsByModelLibelle(identifged).ToList();
            IEnumerable<ReglementPivot> reglementFacturePivots = Mapper.Map<IEnumerable<GES_Reglement>, IEnumerable<ReglementPivot>>(reglement);
            return reglementFacturePivots;
        }

        public void SaveReglement()
        {
            unitOfWork.Commit();
        }

        public void UpdateReglement(ReglementPivot Reglement)
        {
            reglementRepository.Update(Mapper.Map<ReglementPivot, GES_Reglement>(Reglement));
        }
    }
}
