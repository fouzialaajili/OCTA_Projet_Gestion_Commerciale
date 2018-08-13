
using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Repositories
{
   
    public interface IUniteRepository : IRepository<GES_Unite>
    {
        GES_Unite GetUniteById(long id);
        IEnumerable<GES_Unite> GetItemsByModelLibelle(string identifged);

    }


    public class UniteRepository : RepositoryBase<GES_Unite>, IUniteRepository
    {
        public UniteRepository(IDbFactory dbFactory) : base(dbFactory) { }

        public GES_Unite GetUniteById(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GES_Unite> GetItemsByModelLibelle(string identifged)
        {
            throw new NotImplementedException();
        }
    }
}
