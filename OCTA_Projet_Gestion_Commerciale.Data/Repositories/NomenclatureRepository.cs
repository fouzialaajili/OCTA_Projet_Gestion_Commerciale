using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Repositories
{
  public  class NomenclatureRepository : RepositoryBase<GES_Nomenclature>, INomenclatureRepository
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

        public void Update(object idSource, GES_Nomenclature entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(object idSource, GES_Nomenclature entity)
        {
            throw new NotImplementedException();
        }

        public GES_Nomenclature GetById(long id)
        {
            throw new NotImplementedException();
        }
    }

    public interface INomenclatureRepository : IRepository<GES_Nomenclature>
    {
     
        GES_Nomenclature GetNomenclatureById(long id);
        IEnumerable<GES_Nomenclature> GetItemsByModelLibelle(string identifged);

    }
}
