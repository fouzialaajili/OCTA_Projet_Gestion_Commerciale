using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Repositories
{
  public  class DossiersSitesRepository : RepositoryBase<GEN_DossiersSites>, IDossiersSitesRepository
    {
        public DossiersSitesRepository(IDbFactory dbFactory) : base(dbFactory) { }

        public void Delete(object idSource, GEN_DossiersSites entity)
        {
            throw new NotImplementedException();
        }

        public GEN_DossiersSites GetById(long id)
        {
            throw new NotImplementedException();
        }

        public void Update(object idSource, GEN_DossiersSites entity)
        {
            throw new NotImplementedException();
        }
    }
    public interface IDossiersSitesRepository : IRepository<GEN_DossiersSites>
    {

    }



    

}
