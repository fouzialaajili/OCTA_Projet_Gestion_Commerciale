using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Repositories
{
 public   class PlanAnalytiqueRepository : RepositoryBase<CPT_PlanAnalytique>, IPlanAnalytiqueRepository
    {
        public PlanAnalytiqueRepository(IDbFactory dbFactory) : base(dbFactory) { }
    }



    public interface IPlanAnalytiqueRepository : IRepository<CPT_PlanAnalytique>
    {



    }
}



