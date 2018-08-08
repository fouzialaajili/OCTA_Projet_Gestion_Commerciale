
using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Repositories
{
    
   public interface IImpressionRepositoy : IRepository<GES_Impression>
    {
      
        GES_Impression GetById(long id);
        IEnumerable<GES_Impression> GetItemsByModelLibelle(string identifged);
    }


    public class ImpressionRepository : RepositoryBase<GES_Impression>, IImpressionRepositoy
    {

        public ImpressionRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public GES_Impression GetById(long id)
        {
            var impressions = this.DbContext.Impressions.Where(c => c.Id == id).SingleOrDefault();

            return impressions;
        }

        public IEnumerable<GES_Impression> GetItemsByModelLibelle(string identifged)
        {
            var impressions = this.DbContext.Impressions.Where(c => c.ImpressionChemin == identifged);

            return impressions;
        }
    }
}
