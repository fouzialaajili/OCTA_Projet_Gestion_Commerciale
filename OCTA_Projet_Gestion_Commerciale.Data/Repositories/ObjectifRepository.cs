using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Repositories
{
 public   class ObjectifRepository : RepositoryBase<GES_Objectif>, IObjectifRepository
    {
        public ObjectifRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public void Delete(object idSource, GES_Objectif entity)
        {
            throw new NotImplementedException();
        }

        public GES_Objectif GetById(long id)
        {
            throw new NotImplementedException();
        }

        public GES_Objectif GetObjectifById(long id)
        {
            var objetifs = this.DbContext.Objectifs.Where(c => c.ObjectifId== id).SingleOrDefault();

            return objetifs;
        }

        public void Update(object idSource, GES_Objectif entity)
        {
            throw new NotImplementedException();
        }
    }

    public interface IObjectifRepository : IRepository<GES_Objectif>
    {
    
        GES_Objectif GetObjectifById(long id);
 

    }
}
