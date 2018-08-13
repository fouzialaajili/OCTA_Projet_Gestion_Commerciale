
using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Repositories
{
    public interface IArticlesPrixRepository : IRepository<GES_ArticlesPrix>
    {

    }


    public class ArticlesPrixRepository : RepositoryBase<GES_ArticlesPrix>, IArticlesPrixRepository
    {
        public ArticlesPrixRepository(IDbFactory dbFactory) : base(dbFactory) { }

        public void Delete(object idSource, GES_ArticlesPrix entity)
        {
            throw new NotImplementedException();
        }

        public GES_ArticlesPrix GetById(long id)
        {
            throw new NotImplementedException();
        }

        public void Update(object idSource, GES_ArticlesPrix entity)
        {
            throw new NotImplementedException();
        }
    }
    
}
