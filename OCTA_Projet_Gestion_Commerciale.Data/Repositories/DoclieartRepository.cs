using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Repositories
{
   
    public interface IDoclieartRepository : IRepository<GES_Doclieart>
    {

    }


    public class DoclieartRepository : RepositoryBase<GES_Doclieart>, IDoclieartRepository
    {
        public DoclieartRepository(IDbFactory dbFactory) : base(dbFactory) { }

        public void Delete(object idSource, GES_Doclieart entity)
        {
            throw new NotImplementedException();
        }

        public GES_Doclieart GetById(long id)
        {
            throw new NotImplementedException();
        }

        public void Update(object idSource, GES_Doclieart entity)
        {
            throw new NotImplementedException();
        }
    }
}
