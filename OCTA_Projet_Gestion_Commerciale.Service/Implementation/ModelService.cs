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
  public  class ModelService : IModelService
    {
        private readonly IModelRepository iModelRepository;
        private readonly IUnitOfWork unitOfWork;

        public ModelService(IModelRepository iModelRepository, IUnitOfWork unitOfWork)
        {
            this.iModelRepository = iModelRepository;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<ModelPivot> GetModelByIdDossier(long id)
        {
            IEnumerable<GEN_Model> item = iModelRepository.GetModelByIDDossier(id);
            IEnumerable<ModelPivot> tiersPivots = Mapper.Map<IEnumerable<GEN_Model>, IEnumerable<ModelPivot>>(item);
            return tiersPivots;

        }

        public IEnumerable<ModelPivot> GetModelIdDossier()
        {
            IEnumerable<GEN_Model> item = iModelRepository.GetModelDossier().ToList();
            IEnumerable<ModelPivot> ModelPivots = Mapper.Map<IEnumerable<GEN_Model>, IEnumerable<ModelPivot>>(item);
            return ModelPivots;
        }

        public IEnumerable<ModelPivot> GetModels()
        {
           var modelss=  iModelRepository.GetModelByIDdossier().ToList();
            IEnumerable<ModelPivot> dossierpivot = Mapper.Map<IEnumerable<GEN_Model>, IEnumerable<ModelPivot>>(modelss);

            return dossierpivot;

        }
    }
}

