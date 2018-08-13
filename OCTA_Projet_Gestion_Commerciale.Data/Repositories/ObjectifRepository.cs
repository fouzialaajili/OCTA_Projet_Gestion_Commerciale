using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Repositories
{
    class ObjectifRepository : RepositoryBase<GES_Objectif>, IObjectifRepository
    {
        public ObjectifRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

      
        public GES_Objectif GetObjectifById(long id)
        {
            var objetifs = this.DbContext.Objectifs.Where(c => c.ObjectifId== id).SingleOrDefault();

            return objetifs;
        }

    
    }

    public interface IObjectifRepository : IRepository<GES_Objectif>
    {
    
        GES_Objectif GetObjectifById(long id);
 

    }
}
