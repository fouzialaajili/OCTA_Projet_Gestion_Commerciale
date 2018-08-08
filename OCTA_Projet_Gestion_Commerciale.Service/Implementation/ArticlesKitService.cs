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
  public  class ArticlesKitService : IArticlesKitService
    {

        IArticlesKitRepository articlesKitRepository;
        IUnitOfWork unitOfWork;
        public ArticlesKitService(IArticlesKitRepository articlesKitRepository, IUnitOfWork unitOfWork)
        {
            this.articlesKitRepository = articlesKitRepository;
            this.unitOfWork = unitOfWork;
        }

       public void CreateArticlesKitPivot(ArticlesKitPivot articlesKitPivot)
        {
           GES_ArticlesKit  articlesKit = Mapper.Map<ArticlesKitPivot, GES_ArticlesKit>(articlesKitPivot);

           articlesKitRepository.Add(articlesKit);
           
        }

        public void DeleteArticlesKitPivot(ArticlesKitPivot articlesKit)
        {
            articlesKitRepository.Delete(articlesKit.ArticlesKitId, Mapper.Map<ArticlesKitPivot, GES_ArticlesKit>(articlesKit));
        }

        public IEnumerable<ArticlesKitPivot> GetALL()
        {
     
            IEnumerable<GES_ArticlesKit> articlesKits = articlesKitRepository.GetAll().ToList();
            IEnumerable<ArticlesKitPivot> articlesKitsPivot = Mapper.Map<IEnumerable<GES_ArticlesKit>, IEnumerable<ArticlesKitPivot>>(articlesKits);
            return articlesKitsPivot;
        }

        public ArticlesKitPivot GetArticlesKit(long id)
        {
            var articleKits = articlesKitRepository.GetById((int)id);
            ArticlesKitPivot itemPivot = Mapper.Map<GES_ArticlesKit, ArticlesKitPivot>(articleKits);
            return itemPivot;
        }

     

        public void SaveArticlesKitPivot()
        {
            unitOfWork.Commit();
        }

        public void UpdateArticlesKitPivot(ArticlesKitPivot articlesKit)
        {
            articlesKitRepository.Update(Mapper.Map<ArticlesKitPivot, GES_ArticlesKit>(articlesKit));

        }


       

    }
}
