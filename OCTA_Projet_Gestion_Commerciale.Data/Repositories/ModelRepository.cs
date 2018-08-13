using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Repositories
{
    public class ModelRepository: RepositoryBase<GEN_Model>,IModelRepository
    {
        public ModelRepository(IDbFactory dbFactory) : base(dbFactory) { }

        public void Delete(object idSource, GEN_Model entity)
        {
            throw new NotImplementedException();
        }

        public GEN_Model GetById(long id)
        {
            throw new NotImplementedException();
        }

        public GEN_Model GetModelById(long id)
        {
            var model = this.DbContext.Models.Where(c => c.Id == id).SingleOrDefault();
            return model;

        }

        public IEnumerable<GEN_Model> GetModelByIDDossier(long id)
        {
            var models = this.DbContext.Models.Where(c => c.IdDossier== id);

            return models;
        }
        
        public void Update(object idSource, GEN_Model entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GEN_Model> GetModelByIDDossiers()
        {
            var models = this.DbContext.Models.Where(e => e.IdDossier == Utils.Constantes.CurrentPreferenceIdDossier);
            return models;
        }
        /* public override void Update(GEN_Model gEN_Model)
{
//entity.DateUpdated = DateTime.Now;
base.Update(gEN_Model);
}*/
    }
    public interface IModelRepository : IRepository<GEN_Model>
    {

        GEN_Model GetModelById(long id);
        IEnumerable<GEN_Model> GetModelByIDDossier(long id);
        IEnumerable<GEN_Model> GetModelByIDDossiers();
    }

}
