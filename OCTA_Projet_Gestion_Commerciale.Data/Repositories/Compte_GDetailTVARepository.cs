using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Repositories
{
 public   class Compte_GDetailTVARepository : RepositoryBase<CPT_CompteGDetailTVA>, ICompte_GDetailTVARepository
    {
        public Compte_GDetailTVARepository(IDbFactory dbFactory) : base(dbFactory) { }
    }


    public interface ICompte_GDetailTVARepository : IRepository<CPT_CompteGDetailTVA>
    {



    }

    

}
