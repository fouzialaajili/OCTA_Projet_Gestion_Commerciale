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

        public void Delete(object idSource, GES_Affaire entity)
        {
            throw new NotImplementedException();
        }

        public GES_Affaire GetById(long id)
        {
            throw new NotImplementedException();
        }

        public void Update(object idSource, GES_Affaire entity)
        {
            throw new NotImplementedException();
        }
    }

}

