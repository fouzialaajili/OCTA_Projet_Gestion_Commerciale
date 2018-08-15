using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Repositories
{
    public class DossiersContactsRepository : RepositoryBase<GEN_DossiersContacts>, IDossiersContactsRepository
    {
        public DossiersContactsRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

      
    }

    public interface IDossiersContactsRepository : IRepository<GEN_DossiersContacts>
    {

    }


    //public  class DossiersContactsRepository : RepositoryBase<GEN_DossiersContacts>, IDossiersContactsRepository
    //  {
    //      public DossiersContactsRepository(IDbFactory dbFactory)
    //          : base(dbFactory) { }

    //      public void Delete(object idSource, GEN_DossiersContacts entity)
    //      {
    //          throw new NotImplementedException();
    //      }

    //      public GEN_DossiersContacts GetById(long id)
    //      {
    //          throw new NotImplementedException();
    //      }

    //      public void Update(object idSource, GEN_DossiersContacts entity)
    //      {
    //          throw new NotImplementedException();
    //      }
    //  }

    //  public interface IDossiersContactsRepository : IRepository<GEN_DossiersContacts>
    //  {

    //  }
}
