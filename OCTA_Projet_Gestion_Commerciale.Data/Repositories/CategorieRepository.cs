
using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Repositories
{
    public interface ICategorieRepository : IRepository<GES_Categorie>
    {

    }


    public class CategorieRepository : RepositoryBase<GES_Categorie>, ICategorieRepository
    {
        public CategorieRepository(IDbFactory dbFactory) : base(dbFactory) { }

      
    }
}
