
using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Repositories
{
  public  class RepresentantRepository : RepositoryBase<GES_Representant>, IRepresentantRepository
    {
        public RepresentantRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

     

        public GES_Representant GetRepresentantById(long id)
        {
            var objetifs = this.DbContext.Representants.Where(c => c.RepresentantId== id).SingleOrDefault();

            return objetifs;
        }

        public IEnumerable<GES_Representant> GetItemsByModelLibelle(string identifged)
        {
            var numerotations = this.DbContext.Representants.Where(c => c.RepresentantNom == identifged);

            return numerotations;
        }

        public void Update(object idSource, GES_Representant entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(object idSource, GES_Representant entity)
        {
            throw new NotImplementedException();
        }

        public GES_Representant GetById(long id)
        {
            throw new NotImplementedException();
        }
    }

    public interface IRepresentantRepository : IRepository<GES_Representant>
    {
    
        GES_Representant GetRepresentantById(long id);
      IEnumerable<GES_Representant> GetItemsByModelLibelle(string identifged);
    }
}
