using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using OCTA_Projet_Gestion_Commerciale.Service.Interface;
using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Model;
using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using OCTA_Projet_Gestion_Commerciale.Data.Repositories;

namespace OCTA_Projet_Gestion_Commerciale.Service.Implementation
{
  public class FournisseurArticleService : IFournisseurArticleService
    {
       

        private readonly IFournisseurArticleRepository fournisseurArticleRepository;
       

        private readonly IUnitOfWork unitOfWork;

        public FournisseurArticleService(IFournisseurArticleRepository fournisseurArticleRepository,  IUnitOfWork unitOfWork)
        {
            this.fournisseurArticleRepository = fournisseurArticleRepository;
          
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<FournisseurArticlePivot> GetALL()
        {
            IEnumerable<GES_FournisseurArticle> fournisseurArticles = fournisseurArticleRepository.GetAll().ToList();
            IEnumerable<FournisseurArticlePivot> fournisseurArticlePivots = Mapper.Map<IEnumerable<GES_FournisseurArticle>, IEnumerable<FournisseurArticlePivot>>(fournisseurArticles);
            return fournisseurArticlePivots;
        }

        public FournisseurArticlePivot GetFournisseurArticle(long id)
        {
            var item = fournisseurArticleRepository.GetById((int)id);
            FournisseurArticlePivot fournisseurArticlePivot = Mapper.Map<GES_FournisseurArticle, FournisseurArticlePivot>(item);
            return fournisseurArticlePivot;
        }

        public IEnumerable<FournisseurArticlePivot> GetTiersFournisseurArticle(string tiersArticle)
        {
            IEnumerable<GES_FournisseurArticle> fournisseurArticles = fournisseurArticleRepository.GetItemsByModelLibelle(tiersArticle).ToList();
            IEnumerable<FournisseurArticlePivot> fournisseurArticlePivots = Mapper.Map<IEnumerable<GES_FournisseurArticle>, IEnumerable<FournisseurArticlePivot>>(fournisseurArticles);
            return fournisseurArticlePivots;
        }
        public void CreateFournisseurArticle(FournisseurArticlePivot fournisseurArticle)
        {
            GES_FournisseurArticle item = Mapper.Map<FournisseurArticlePivot, GES_FournisseurArticle>(fournisseurArticle);
            fournisseurArticleRepository.Add(item);
        }

        public void SaveFournisseurArticle()
        {
            unitOfWork.Commit();
        }

        public void DeleteFournisseurArticle(FournisseurArticlePivot fournisseurArticle)
        {
            fournisseurArticleRepository.Delete(fournisseurArticle.FournisseurArticleId,Mapper.Map<FournisseurArticlePivot, GES_FournisseurArticle>(fournisseurArticle));
        }

        public void UpdateFournisseurArticle(FournisseurArticlePivot fournisseurArticle)
        {
            fournisseurArticleRepository.Update(Mapper.Map<FournisseurArticlePivot, GES_FournisseurArticle>(fournisseurArticle));
        }


    }
}