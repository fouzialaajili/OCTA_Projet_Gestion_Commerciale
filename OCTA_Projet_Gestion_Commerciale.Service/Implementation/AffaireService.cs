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
  public  class AffaireService : IAffaireService
    {
        private readonly IAffaireRepository affaireRepository;
        private readonly IUnitOfWork unitOfWork;
        public AffaireService(IAffaireRepository affaireRepository, IUnitOfWork unitOfWork)
        {
            this.affaireRepository = affaireRepository;
            this.unitOfWork = unitOfWork;
        }
        public void CreateAffairePivot(AffairePivot affairePivot)
        {
            GES_Affaire admin = Mapper.Map<AffairePivot, GES_Affaire>(affairePivot);
            affaireRepository.Add(admin);
           
        }

        public void DeleteAffairePivot(AffairePivot affaire)
        {
         affaireRepository.Delete(affaire.AffaireId,Mapper.Map<AffairePivot, GES_Affaire>(affaire));
        }

        public AffairePivot GetAffaire(long id)
        {
            var affaire = affaireRepository.GetById((int)id);
            AffairePivot itemPivot = Mapper.Map<GES_Affaire, AffairePivot>(affaire);
            return itemPivot;
        }

        public IEnumerable<AffairePivot> GetAffairePivotByCode(string Code)
        {
            
            throw new NotImplementedException();

        }

        public IEnumerable<AffairePivot> GetALL()
        {
            IEnumerable<GES_Affaire> affaires = affaireRepository.GetAll().ToList();
            IEnumerable<AffairePivot> affairePivot = Mapper.Map<IEnumerable<GES_Affaire>, IEnumerable<AffairePivot>>(affaires);
            return affairePivot;
        }

        public void SaveAffairePivot()
        {
            unitOfWork.Commit();
        }

        public void UpdateAffairePivot(AffairePivot affaire)
        {
            affaireRepository.Update(Mapper.Map<AffairePivot, GES_Affaire>(affaire));

        }
    }

}
