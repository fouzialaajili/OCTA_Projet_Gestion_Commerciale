using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Repositories
{
public    class FournisseurArticleRepository : RepositoryBase<GES_FournisseurArticle>, IFournisseurArticleRepository
    {
        public FournisseurArticleRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

      

        public GES_FournisseurArticle GetFournisseurArticleById(long id)
        {
            var fournisseurArticles = this.DbContext.FournisseurArticles.Where(c => c.FournisseurArticleId == id).SingleOrDefault();

            return fournisseurArticles;
        }


        public IEnumerable<GES_FournisseurArticle> GetItemsByModelLibelle(string ReferenceName)
        {
            var fournisseurArticles = this.DbContext.FournisseurArticles.Where(c => c.FournisseurArticleReference == ReferenceName);

            return fournisseurArticles;
        }

      
    }

    public interface IFournisseurArticleRepository : IRepository<GES_FournisseurArticle>
    {
        IEnumerable<GES_FournisseurArticle> GetItemsByModelLibelle(string categoryName);
       
        GES_FournisseurArticle GetFournisseurArticleById(long id);

    }
}
