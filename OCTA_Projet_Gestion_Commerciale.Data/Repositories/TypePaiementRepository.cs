
using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Repositories
{
    class TypePaiementRepository : RepositoryBase<GEN_TypePaiement>, ITypePaiementRepositoy
    {
        public TypePaiementRepository(IDbFactory dbFactory) : base(dbFactory) { }

        

       
    }



    public interface ITypePaiementRepositoy : IRepository<GEN_TypePaiement>
    {
        GEN_TypePaiement GetById(long id);
        IEnumerable<GEN_TypePaiement> GetItemsByModelLibelle(string identifged);


    }


}