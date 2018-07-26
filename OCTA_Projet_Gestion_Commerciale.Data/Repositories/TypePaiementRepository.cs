
using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Repositories
{
  public  class TypePaiementRepository : RepositoryBase<GEN_TypePaiement>, ITypePaiementRepositoy
    {
        public TypePaiementRepository(IDbFactory dbFactory) : base(dbFactory) { }

        public GEN_TypePaiement GetById(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GEN_TypePaiement> GetItemsByModelLibelle(string identifged)
        {
            throw new NotImplementedException();
        }
    }



    public interface ITypePaiementRepositoy : IRepository<GEN_TypePaiement>
    {
      GEN_TypePaiement GetById(long id);
        IEnumerable<GEN_TypePaiement> GetItemsByModelLibelle(string identifged);


    }


}