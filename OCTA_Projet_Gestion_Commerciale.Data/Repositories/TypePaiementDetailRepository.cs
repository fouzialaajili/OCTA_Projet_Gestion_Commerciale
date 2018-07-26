
using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Repositories
{
    class TypePaiementDetailRepository : RepositoryBase<GEN_TypePaiementDetail>, ITypePaiementDetailRepositoy
    {
        public TypePaiementDetailRepository(IDbFactory dbFactory) : base(dbFactory) { }

        public GEN_TypePaiementDetail GetById(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GEN_TypePaiementDetail> GetItemsByModelLibelle(string identifged)
        {
            throw new NotImplementedException();
        }
    }



    public interface ITypePaiementDetailRepositoy : IRepository<GEN_TypePaiementDetail>
    {
        GEN_TypePaiementDetail GetById(long id);
        IEnumerable<GEN_TypePaiementDetail> GetItemsByModelLibelle(string identifged);

       

    }


}