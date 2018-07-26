using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Repositories
{
    public interface IAffaireRepository : IRepository<GES_Affaire>
    {

    }
    

    public class AffaireRepository : RepositoryBase<GES_Affaire>, IAffaireRepository
    {
        public AffaireRepository(IDbFactory dbFactory) : base(dbFactory) { }


    }

}

