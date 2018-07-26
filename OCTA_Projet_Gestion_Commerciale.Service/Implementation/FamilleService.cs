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
{
    class FamilleService : IFamilleService
    {
        private readonly IFamilleRepositoy familleRepository;
        private readonly IUnitOfWork unitOfWork;
        public   FamilleService(IFamilleRepositoy familleRepository, IUnitOfWork unitOfWork)
        {
            this.familleRepository = familleRepository;
            this.unitOfWork = unitOfWork;
        }
       
        public void CreateFamillePivot(FamillePivot familles)
        {
            GES_Famille famille = Mapper.Map<FamillePivot, GES_Famille>(familles);
            familleRepository.Add(famille);
        }

        public void DeleteFamillePivot(FamillePivot dossiers)
        {
            familleRepository.Delete(Mapper.Map<FamillePivot, GES_Famille>(dossiers));

        }

        public IEnumerable<FamillePivot> GetALL()
        {
            IEnumerable<GES_Famille> familles = familleRepository.GetAll().ToList();
            IEnumerable<FamillePivot > famillePivot = Mapper.Map<IEnumerable<GES_Famille>, IEnumerable<FamillePivot>>(familles);
            return famillePivot;
        }

        public FamillePivot GetFamillePivot(long id)
        {
            var dossiers = familleRepository.GetById((int)id);
            FamillePivot famillePivot = Mapper.Map<GES_Famille, FamillePivot>(dossiers);
            return famillePivot;
        }

        public IEnumerable<FamillePivot> GetFamillePivotByFamilleCode(string FamilleCode)
        {
            throw new NotImplementedException();
        }

        public void SaveFamille()
        {
            unitOfWork.Commit();
        }

        public void UpdateFamillePivot(FamillePivot dossiers)
        {
            familleRepository.Update(Mapper.Map<FamillePivot, GES_Famille>(dossiers));

        }
    }
}
