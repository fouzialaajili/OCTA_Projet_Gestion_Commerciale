using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Repositories
{
    class NomenclatureRepository : RepositoryBase<GES_Nomenclature>, INomenclatureRepository
    {
        public NomenclatureRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

       

        public GES_Nomenclature GetNomenclatureById(long id)
        {
            var nomenclatures = this.DbContext.Nomenclatures.Where(c => c.NomenclatureId== id).SingleOrDefault();

            return nomenclatures;
        }

        public IEnumerable<GES_Nomenclature> GetItemsByModelLibelle(string identifged)
        {
            var nomenclatures = this.DbContext.Nomenclatures.Where(c => c.NomenclatureLib == identifged);

            return nomenclatures;
        }
    }

    public interface INomenclatureRepository : IRepository<GES_Nomenclature>
    {
     
        GES_Nomenclature GetNomenclatureById(long id);
        IEnumerable<GES_Nomenclature> GetItemsByModelLibelle(string identifged);

    }
}
