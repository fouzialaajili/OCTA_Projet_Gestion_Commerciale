
using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Data.Utils;
using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Repositories
{
    public class TiersRepository:RepositoryBase<GEN_Tiers>, ITiersRepository
    {
        public TiersRepository(IDbFactory dbFactory)
            : base(dbFactory) { }


        public GEN_Tiers GetTiersById(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GEN_Tiers> GetItemsByModelLibelle(string identifged)
        {
            throw new NotImplementedException();
        }
       public GEN_Tiers GetTiers()
        {
            var _Tiers= this.DbContext.Tiers.Where(x => x.Actif == false && x.code == "").FirstOrDefault();

            return _Tiers;
        }

        public GEN_Tiers GetTiersByTypeTier()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GEN_Tiers> GetTiersByItems_TypeTiers(string Type)
        {
            var _Tiers = this.DbContext.Tiers.Where(e => e.IdDossier == Constantes.CurrentSocieteId && e.GEN_Items_TypeTiers.Valeur.Contains(Type) && e.Actif);
            return _Tiers;
        }
    }
    public interface ITiersRepository : IRepository<GEN_Tiers>
    {
    
        GEN_Tiers GetTiersById(long id);
         GEN_Tiers GetTiers();
        GEN_Tiers GetTiersByTypeTier();
        IEnumerable<GEN_Tiers> GetItemsByModelLibelle(string identifged);

        IEnumerable<GEN_Tiers> GetTiersByItems_TypeTiers(string Type);
    }
}
