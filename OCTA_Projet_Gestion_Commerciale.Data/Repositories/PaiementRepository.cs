using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Repositories
{
  public  class PaiementRepository : RepositoryBase<GEN_TypePaiement>, IPaiementRepository
    {
        public PaiementRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public void Delete(object idSource, GEN_TypePaiement entity)
        {
            throw new NotImplementedException();
        }

        public GEN_TypePaiement GetById(long id)
        {
            throw new NotImplementedException();
        }

        public void Update(object idSource, GEN_TypePaiement entity)
        {
            throw new NotImplementedException();
        }
    }

    public interface IPaiementRepository : IRepository<GEN_TypePaiement>
    {

    }
}
