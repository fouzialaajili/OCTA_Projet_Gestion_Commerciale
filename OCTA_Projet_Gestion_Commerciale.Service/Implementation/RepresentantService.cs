
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

namespace OCTA_Projet_Gestion_Commerciale.Service.Implementation
{
    class RepresentantService : IRepresentantService
    {

        private readonly IRepresentantRepository representantRepository;


        private readonly IUnitOfWork unitOfWork;

        public RepresentantService(IRepresentantRepository representantRepository, IUnitOfWork unitOfWork)
        {
            this.representantRepository = representantRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateRepresentant(RepresentantPivot Representant)
        {

            GES_Representant item = Mapper.Map<RepresentantPivot, GES_Representant>(Representant);
            representantRepository.Add(item);
        }

        public void DeleteRepresentant(RepresentantPivot Representant)
        {
            //representantRepository.Delete(Mapper.Map<RepresentantPivot, GES_Representant>(Representant));
        }

        public IEnumerable<RepresentantPivot> GetALL()
        {
            IEnumerable<GES_Representant> Representant = representantRepository.GetAll().ToList();
            IEnumerable<RepresentantPivot> representantPivots = Mapper.Map<IEnumerable<GES_Representant>, IEnumerable<RepresentantPivot>>(Representant);
            return representantPivots;
        }

        public RepresentantPivot GetRepresentant(long id)
        {
            var item = representantRepository.GetById((int)id);
            RepresentantPivot representantPivots = Mapper.Map<GES_Representant, RepresentantPivot>(item);
            return representantPivots;
        }

        public IEnumerable<RepresentantPivot> GetRepresentantsByName(string identifged)
        {
            IEnumerable<GES_Representant> representant = representantRepository.GetItemsByModelLibelle(identifged).ToList();
            IEnumerable<RepresentantPivot> representantPivots = Mapper.Map<IEnumerable<GES_Representant>, IEnumerable<RepresentantPivot>>(representant);
            return representantPivots;
        }

        public void SaveRepresentant()
        {
            unitOfWork.Commit();
        }

        public void UpdateRepresentant(RepresentantPivot Representant)
        {
            representantRepository.Update(Mapper.Map<RepresentantPivot, GES_Representant>(Representant));
        }
    }
}
