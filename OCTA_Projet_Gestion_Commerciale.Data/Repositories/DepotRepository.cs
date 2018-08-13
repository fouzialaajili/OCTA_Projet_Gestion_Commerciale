using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Repositories
{
   
    public interface IDepotRepository : IRepository<GES_Depot>
    {

    }


    public class DepotRepository : RepositoryBase<GES_Depot>, IDepotRepository
    {
        public DepotRepository(IDbFactory dbFactory) : base(dbFactory) { }

        public void Delete(object idSource, GES_Depot entity)
        {
            throw new NotImplementedException();
        }

        public GES_Depot GetById(long id)
        {
            throw new NotImplementedException();
        }

        public void Update(object idSource, GES_Depot entity)
        {
            throw new NotImplementedException();
        }
    }
}
