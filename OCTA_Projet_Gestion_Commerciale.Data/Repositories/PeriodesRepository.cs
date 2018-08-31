using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Repositories
{
    public class PeriodesRepository : RepositoryBase<GEN_Periodes>, IPeriodesRepository
    {
        public PeriodesRepository(IDbFactory dbFactory)
            : base(dbFactory) { }


    }
    public interface IPeriodesRepository : IRepository<GEN_Periodes>
    {

    }
}