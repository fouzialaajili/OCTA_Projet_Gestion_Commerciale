using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Repositories
{
  public  class MouvementStockRepository : RepositoryBase<GES_MouvementStock>, IMouvementStockRepository
    {
        public MouvementStockRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

    

        public GES_MouvementStock GetMouvementStockById(long id)
        {
            var mouvementstocks = this.DbContext.MouvementStocks.Where(c => c.MouvementStockId== id).SingleOrDefault();

            return mouvementstocks;
        }

        public IEnumerable<GES_MouvementStock> GetItemsByModelLibelle(string identifged)
        {
            var mouvementstocks = this.DbContext.MouvementStocks.Where(c => c.MouvementStockCode == identifged);

            return mouvementstocks;
        }

        public void Update(object idSource, GES_MouvementStock entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(object idSource, GES_MouvementStock entity)
        {
            throw new NotImplementedException();
        }

        public GES_MouvementStock GetById(long id)
        {
            throw new NotImplementedException();
        }
    }

    public interface IMouvementStockRepository : IRepository<GES_MouvementStock>
    {
     
        GES_MouvementStock GetMouvementStockById(long id);
        IEnumerable<GES_MouvementStock> GetItemsByModelLibelle(string identifged);

    }
}
