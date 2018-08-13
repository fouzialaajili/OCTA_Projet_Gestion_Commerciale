
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
   public  class TiersContactsRepository:RepositoryBase<GEN_TiersContacts>, ITiersContactsRepository
    {
        public TiersContactsRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public void Delete(object idSource, GEN_TiersContacts entity)
        {
            throw new NotImplementedException();
        }

        public GEN_TiersContacts GetById(long id)
        {
            throw new NotImplementedException();
        }

        public GEN_TiersContacts GetTiersContactsById(long id)
        {
            var TiersContacts = this.DbContext.TiersContacts.Where(c => c.GEN_TiersContactsId == id).SingleOrDefault();

            return TiersContacts;
        }

        public IEnumerable<GEN_TiersContacts> GetTiersContactsByIdTiersAndActif(long id)
        
        {
            var TiersContacts = this.DbContext.TiersContacts.Where(c => c.IdTiers == id && c.Actif);

            return TiersContacts;
        }

        public IEnumerable<GEN_TiersContacts> GetTiersContactsByModelLibelle(string identifged)
        {
            var TiersContacts = this.DbContext.TiersContacts.Where(c => c.Nom == identifged);

            return TiersContacts;
        }

        public void Update(object idSource, GEN_TiersContacts entity)
        {
            throw new NotImplementedException();
        }
    }
 
    public interface ITiersContactsRepository : IRepository<GEN_TiersContacts>
    {
    
        GEN_TiersContacts GetTiersContactsById(long id);
        IEnumerable<GEN_TiersContacts> GetTiersContactsByModelLibelle(string identifged);
        IEnumerable<GEN_TiersContacts> GetTiersContactsByIdTiersAndActif(long id);
        
        }
}
