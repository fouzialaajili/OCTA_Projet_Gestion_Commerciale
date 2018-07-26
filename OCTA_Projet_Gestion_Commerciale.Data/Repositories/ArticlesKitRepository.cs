using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Repositories
{
  
    public interface IArticlesKitRepository : IRepository<GES_ArticlesKit>
    {

    }


    public class ArticlesKitRepository : RepositoryBase<GES_ArticlesKit>, IArticlesKitRepository
    {
        public ArticlesKitRepository(IDbFactory dbFactory) : base(dbFactory) { }


    }
}
