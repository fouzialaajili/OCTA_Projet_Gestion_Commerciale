using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Repositories
{
  public  class NatureOperationRepository : RepositoryBase<CPT_NatureOperation>, INatureOperationRepository
    {
        public NatureOperationRepository(IDbFactory dbFactory) : base(dbFactory) { }
    }



    public interface INatureOperationRepository : IRepository<CPT_NatureOperation>
    {



    }
}

