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
    class ArticlesService : IArticlesService
    {

       private readonly IArticleRepository articlesRepository;
        
       private readonly IUnitOfWork unitOfWork;
          public ArticlesService(IArticleRepository articleRepository, IUnitOfWork unitOfWork)
        {
            this.articlesRepository=articleRepository;
            this.unitOfWork = unitOfWork;

        }
        public void CreateArticlePivot(ArticlePivot articlePivot)
        {
            GES_Article article = Mapper.Map<ArticlePivot, GES_Article>(articlePivot);
            articlesRepository.Add(article);
        }

        public void DeleteArticlePivot(ArticlePivot article)
        {
            articlesRepository.Delete(Mapper.Map<ArticlePivot, GES_Article>(article));
        }

        public IEnumerable<ArticlePivot> GetALL()
        {
            IEnumerable<GES_Article> articles = articlesRepository.GetAll().ToList();
            IEnumerable<ArticlePivot> articlesPrixesPivots = Mapper.Map<IEnumerable<GES_Article>, IEnumerable<ArticlePivot>>(articles);
            return articlesPrixesPivots;
       }

        public ArticlePivot GetArticlePivot(long id)
        {
            var item = articlesRepository.GetById((int)id);
            ArticlePivot articlesPivot = Mapper.Map<GES_Article, ArticlePivot>(item);
            return articlesPivot;
        }

        public void SaveArticlePivot()
        {
            unitOfWork.Commit();
        }

        public void UpdateArticlePivot(ArticlePivot articlesPivot)
        {
            articlesRepository.Update(Mapper.Map<ArticlePivot, GES_Article>(articlesPivot));
        }
    }
}
