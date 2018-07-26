
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
    class ReglementFactureService : IReglementFactureService
    {
        private readonly IReglementFactureRepository reglementFactureRepository;


        private readonly IUnitOfWork unitOfWork;

        public ReglementFactureService(IReglementFactureRepository reglementFactureRepository, IUnitOfWork unitOfWork)
        {
            this.reglementFactureRepository = reglementFactureRepository;
            this.unitOfWork = unitOfWork;
        }


        public void CreateReglementFacture(ReglementFacturePivot ReglementFacture)
        {
            GES_ReglementFacture item = Mapper.Map<ReglementFacturePivot, GES_ReglementFacture>(ReglementFacture);
            reglementFactureRepository.Add(item);
        }

        public void DeleteReglementFacture(ReglementFacturePivot ReglementFacture)
        {
            reglementFactureRepository.Delete(Mapper.Map<ReglementFacturePivot, GES_ReglementFacture>(ReglementFacture));
        }

        public IEnumerable<ReglementFacturePivot> GetALL()
        {
            IEnumerable<GES_ReglementFacture> reglementFactur = reglementFactureRepository.GetAll().ToList();
            IEnumerable<ReglementFacturePivot> reglementFacturePivots = Mapper.Map<IEnumerable<GES_ReglementFacture>, IEnumerable<ReglementFacturePivot>>(reglementFactur);
            return reglementFacturePivots;
        }

        public ReglementFacturePivot GetReglementFacture(long id)
        {
            var item = reglementFactureRepository.GetById((int)id);
            ReglementFacturePivot reglementFacturePivots = Mapper.Map<GES_ReglementFacture, ReglementFacturePivot>(item);
            return reglementFacturePivots;
        }

        public IEnumerable<ReglementFacturePivot> GetReglementFacturesByName(string identifged)
        {
            IEnumerable<GES_ReglementFacture> reglement= reglementFactureRepository.GetItemsByModelLibelle(identifged).ToList();
            IEnumerable<ReglementFacturePivot> reglementFacturePivots = Mapper.Map<IEnumerable<GES_ReglementFacture>, IEnumerable<ReglementFacturePivot>>(reglement);
            return reglementFacturePivots;
        }

        public void SaveReglementFacture()
        {
            unitOfWork.Commit();
        }

        public void UpdateReglementFacture(ReglementFacturePivot ReglementFacture)
        {

            reglementFactureRepository.Update(Mapper.Map<ReglementFacturePivot, GES_ReglementFacture>(ReglementFacture));
        }
    }
}
