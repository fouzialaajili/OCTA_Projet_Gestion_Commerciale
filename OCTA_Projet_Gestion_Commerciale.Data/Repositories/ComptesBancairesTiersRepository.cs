using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Repositories
{
 public   class ComptesBancairesTiersRepository : RepositoryBase<CPT_ComptesBancairesTiers>, IComptesBancairesTiersRepository
    {
        public ComptesBancairesTiersRepository(IDbFactory dbFactory) : base(dbFactory) { }
    }



    public interface IComptesBancairesTiersRepository : IRepository<CPT_ComptesBancairesTiers>
    {



    }
}

