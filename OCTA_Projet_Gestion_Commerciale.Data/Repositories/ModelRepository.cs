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
    public class ModelRepository : RepositoryBase<GEN_Model>, IModelRepository
    {
        public ModelRepository(IDbFactory dbFactory) : base(dbFactory) { }
        public GEN_Model GetById(long id)
        {
            var model = this.DbContext.Models.Where(c => c.Id == id).SingleOrDefault();
            return model;

        }

       public IEnumerable<GEN_Model> GetModelByIDdossier()
        {
            var IdModel = this.DbContext.Models.Where(e => e.IdDossier ==Constantes.IdentifiantDossier);
            //.OrderByDescending(e => e.Model).Select(x => new  { ID = x.Id, VALUE = x.Model }).ToList();
            //.AsEnumerable<Models>()
            //.OrderByDescending(e => e.Model).Select(x => new { ID = x.Id, VALUE = x.Model }).AsEnumerable()
            // return model.AsEnumerable();
            //  return IdModel;
            //  DevisesPivot devisesPivot = Mapper.Map<GEN_Devises, DevisesPivot>(item);

            return IdModel;

        }

        public IEnumerable<GEN_Model> GetModelByIDDossier(long id)
        {
            var models = this.DbContext.Models.Where(c => c.IdDossier == id);

            return models;
        }

        public IEnumerable<GEN_Model> GetModelDossier()
        {
            var models = this.DbContext.Models.Where(c => c.IdDossier ==Constantes.IdentifiantDossier);

            return models;
        }
    }
    public interface IModelRepository : IRepository<GEN_Model>
    {

        GEN_Model GetById(long id);
        IEnumerable<GEN_Model> GetModelByIDDossier(long id);
        IEnumerable<GEN_Model> GetModelDossier();
        IEnumerable<GEN_Model> GetModelByIDdossier();//IEnumerable<GEN_Model>
    }

}
