
using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Repositories
{
  public  class TiersRepository:RepositoryBase<GEN_Tiers>, ITiersRepository
    {
        public TiersRepository(IDbFactory dbFactory)
            : base(dbFactory) { }


        public GEN_Tiers GetById(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GEN_Tiers> GetItemsByModelLibelle(string identifged)
        {
            throw new NotImplementedException();
        }
    }
    public interface ITiersRepository : IRepository<GEN_Tiers>
    {
    
        GEN_Tiers GetById(long id);
        IEnumerable<GEN_Tiers> GetItemsByModelLibelle(string identifged);

    }
}
