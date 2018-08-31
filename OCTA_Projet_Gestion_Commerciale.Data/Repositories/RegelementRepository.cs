using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Data.Repositories;
using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Repositories
{
    public class RegelementRepository : RepositoryBase<GEN_Regelement>, IRegelementRepository
    {
        public RegelementRepository(IDbFactory dbFactory)  : base(dbFactory) { }

    }
    public interface IRegelementRepository : IRepository<GEN_Regelement>
    {

    }
}