using AutoMapper;
using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Data.Repositories;
using OCTA_Projet_Gestion_Commerciale.Model;
using OCTA_Projet_Gestion_Commerciale.Service.Interface;
using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Service.Implementation
{
    public class ModelService : IModelService
    {
       private readonly IModelRepository iModelRepository;
       private readonly IUnitOfWork unitOfWork;

    public ModelService(IModelRepository iModelRepository, IUnitOfWork unitOfWork)
  {
     this.iModelRepository = iModelRepository;
      this.unitOfWork = unitOfWork;
}
        public IEnumerable<ModelPivot> GetModels()
        {
            var modelss = iModelRepository.GetModelByIDDossiers().ToList();
            IEnumerable<ModelPivot> dossierpivot = Mapper.Map<IEnumerable<GEN_Model>, IEnumerable<ModelPivot>>(modelss);

            return dossierpivot;

        }
        public void CreateModel(ModelPivot Model)
        {
            GEN_Model model = Mapper.Map<ModelPivot, GEN_Model>(Model);
            iModelRepository.Add(model);
            SaveModel();
        }

        public void DeleteModel(ModelPivot Model)
        {

          iModelRepository.Delete(Model.Id, Mapper.Map<ModelPivot, GEN_Model>(Model));
            //iModelRepository.Delete(Model.Id);
            SaveModel();

        }

        public IEnumerable<ModelPivot> GetALL()
        {
            IEnumerable<GEN_Model> models = iModelRepository.GetAll().ToList();
            IEnumerable<ModelPivot> modelPivots = Mapper.Map<IEnumerable<GEN_Model>, IEnumerable<ModelPivot>>(models);
            return modelPivots;
        }

        public ModelPivot GetModel(long? id)
        {
            var item = iModelRepository.GetById((int)id);
            ModelPivot modelPivot = Mapper.Map<GEN_Model, ModelPivot>(item);
            return modelPivot;
        }

        public IEnumerable<ModelPivot> GetModelByIdDossier(long id)
        {
            IEnumerable<GEN_Model> item = iModelRepository.GetModelByIDDossier(id).ToList();
            IEnumerable<ModelPivot> tiersPivots = Mapper.Map<IEnumerable<GEN_Model>, IEnumerable<ModelPivot>>(item);
            return tiersPivots;

        }

        public IEnumerable<ModelPivot> GetMotifsByName(string identifged)
        {
            throw new NotImplementedException();
        }

        public void SaveModel()
        {
            unitOfWork.Commit();
        }

        public void UpdateModel(ModelPivot Model)
        {
            iModelRepository.Update(Mapper.Map<ModelPivot,GEN_Model>(Model));
     
        }
    }
}
