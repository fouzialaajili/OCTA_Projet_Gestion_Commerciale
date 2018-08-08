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
    public class CategorieService : ICategorieService
    {
        private readonly ICategorieRepository categorieRepository;

        private readonly IUnitOfWork unitOfWork;
       public CategorieService(ICategorieRepository categorieRepository, IUnitOfWork unitOfWork)
        {
            this.categorieRepository = categorieRepository;
            this.unitOfWork = unitOfWork;

        }
      
        public void CreateCategoriePivot(CategoriePivot categoriePivot)
        {
            GES_Categorie categorie = Mapper.Map<CategoriePivot, GES_Categorie>(categoriePivot);
            categorieRepository.Add(categorie);
        }

        public void DeleteCategoriePivot(CategoriePivot categorie)
        {
            categorieRepository.Delete(categorie.CategorieId,Mapper.Map<CategoriePivot, GES_Categorie>(categorie));
        }

        public IEnumerable<CategoriePivot> GetALL()
        {
            IEnumerable<GES_Categorie> categories =categorieRepository.GetAll().ToList();
            IEnumerable<CategoriePivot> categoriePivot = Mapper.Map<IEnumerable<GES_Categorie>, IEnumerable<CategoriePivot>>(categories);
            return categoriePivot;
        }

        public CategoriePivot GetCategoriePivot(long id)
        {
            var item = categorieRepository.GetById((int)id);
            CategoriePivot categoriesPivot = Mapper.Map<GES_Categorie, CategoriePivot>(item);
            return categoriesPivot;
        }

        public IEnumerable<CategoriePivot> GetCategoriePivotByDescription(string Description)
        {
            throw new NotImplementedException();
        }

        public void SaveCategoriePivot()
        {
            unitOfWork.Commit();
        }

            public void UpdateCategoriePivot(CategoriePivot categorie)
        {
            categorieRepository.Update(Mapper.Map<CategoriePivot, GES_Categorie>(categorie));
        }
    }
}
