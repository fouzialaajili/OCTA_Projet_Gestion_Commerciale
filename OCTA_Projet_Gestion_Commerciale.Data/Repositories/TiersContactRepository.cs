
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using OCTA_Projet_Gestion_Commerciale.Model;
using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;

namespace OCTA_Projet_Gestion_Commerciale.Data.Repositories
{
  public  class TiersContactRepository:RepositoryBase<GEN_TiersContacts>, ITiersContactRepository
    {
        public TiersContactRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

      

        public GEN_TiersContacts GetById(long id)
        {
            var objetifs = this.DbContext.TiersContacts.Where(c => c.GEN_TiersContactsId == id).SingleOrDefault();

            return objetifs;
        }

       

        IEnumerable<GEN_TiersContacts> ITiersContactRepository.GetItemsByModelLibelle(string identifged)
        {
            var objetifs = this.DbContext.TiersContacts.Where(c => c.Nom == identifged);

            return objetifs;
        }
    }
 
    public interface ITiersContactRepository : IRepository<GEN_TiersContacts>
    {
    
        GEN_TiersContacts GetById(long id);
        IEnumerable<GEN_TiersContacts> GetItemsByModelLibelle(string identifged);
    }
}
