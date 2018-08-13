
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using OCTA_Projet_Gestion_Commerciale.Service.Interface;
using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using OCTA_Projet_Gestion_Commerciale.Model;
using OCTA_Projet_Gestion_Commerciale.Data.Repositories;

namespace Store.Service.Implementation
{
    class ObjectifService : IObjectifService
    {
        private readonly IObjectifRepository objectifSRepository;


        private readonly IUnitOfWork unitOfWork;

        public ObjectifService(IObjectifRepository objectifSRepository, IUnitOfWork unitOfWork)
        {
            this.objectifSRepository = objectifSRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateObjectif(ObjectifPivot objectif)
        {
            GES_Objectif item = Mapper.Map<ObjectifPivot, GES_Objectif>(objectif);
            objectifSRepository.Add(item);
        }

        public void DeleteObjectif(ObjectifPivot objectif)
        {
        //    objectifSRepository.Delete(Mapper.Map<ObjectifPivot, GES_Objectif>(objectif));
        }

        public IEnumerable<ObjectifPivot> GetALL()
        {
            IEnumerable<GES_Objectif> objectif = objectifSRepository.GetAll().ToList();
            IEnumerable<ObjectifPivot> objectifPivots = Mapper.Map<IEnumerable<GES_Objectif>, IEnumerable<ObjectifPivot>>(objectif);
            return objectifPivots;
        }

        public ObjectifPivot GetObjectif(long id)
        {
            var item = objectifSRepository.GetById((int)id);
            ObjectifPivot objectifPivot = Mapper.Map<GES_Objectif,ObjectifPivot>(item);
            return objectifPivot;
        }

      
        public void SaveObjectif()
        {
            unitOfWork.Commit();
        }

        public void UpdateObjectif(ObjectifPivot objectif)
        {
            objectifSRepository.Update(Mapper.Map<ObjectifPivot, GES_Objectif>(objectif));
        }
    }
}
