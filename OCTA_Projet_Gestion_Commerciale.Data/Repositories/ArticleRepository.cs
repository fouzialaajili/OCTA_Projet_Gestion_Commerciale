using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Repositories
{
    public interface IArticleRepository: IRepository<GES_Article>
    {

    }


    public class ArticleRepository: RepositoryBase<GES_Article>, IArticleRepository
    {
        public ArticleRepository(IDbFactory dbFactory) : base(dbFactory) { }

        public void Delete(object idSource, GES_Article entity)
        {
            throw new NotImplementedException();
        }

        public GES_Article GetById(long id)
        {
            throw new NotImplementedException();
        }

        public void Update(object idSource, GES_Article entity)
        {
            throw new NotImplementedException();
        }
    }


   

    


    
}
