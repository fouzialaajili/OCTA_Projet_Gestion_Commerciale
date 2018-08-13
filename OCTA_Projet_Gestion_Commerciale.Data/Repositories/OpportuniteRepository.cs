
using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Repositoriess
{
    class OpportuniteRepository : RepositoryBase<GES_Opportunite>, IOpportuniteRepository
    {
        public OpportuniteRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

    

        public GES_Opportunite GetOpportuniteById(long id)
        {
            var opportunites = this.DbContext.Opportunites.Where(c => c.OpportuniteId == id).SingleOrDefault();

            return opportunites;
        }

        public IEnumerable<GES_Opportunite> GetItemsByModelLibelle(string identifged)
        {
            var numerotations = this.DbContext.Opportunites.Where(c => c.OpportuniteLibelle == identifged);

            return numerotations;
        }
    }

    public interface IOpportuniteRepository : IRepository<GES_Opportunite>
    {

   
        GES_Opportunite GetOpportuniteById(long id);
       IEnumerable<GES_Opportunite> GetItemsByModelLibelle(string identifged);
    }
}
