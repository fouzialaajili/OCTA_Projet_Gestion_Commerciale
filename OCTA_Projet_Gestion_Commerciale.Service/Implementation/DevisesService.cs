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
    public class DevisesService : IDevisesService
    {
        private readonly IDevisesRepository devisesRepository;

        private readonly IUnitOfWork unitOfWork;

        public DevisesService(IDevisesRepository devisesRepository, IUnitOfWork unitOfWork)
        {
            this.devisesRepository = devisesRepository;
            this.unitOfWork = unitOfWork;

        }
        public void CreateDevisesPivot(DevisesPivot devises)
        {
            GEN_Devises _Devises = Mapper.Map<DevisesPivot, GEN_Devises>(devises);
            devisesRepository.Add(_Devises);
        }

        public void DeleteDevisesPivot(DevisesPivot devises)
        {
            devisesRepository.Delete(Mapper.Map<DevisesPivot, GEN_Devises>(devises));
        }
        public DevisesPivot GetDevisesPivot(long id)
        {
            var item = devisesRepository.GetById((int)id);
            DevisesPivot devisesPivot = Mapper.Map<GEN_Devises, DevisesPivot>(item);
            return devisesPivot;
        }

        public void SaveDevisesPivot()
        {
            unitOfWork.Commit();
        }


        public void UpdateDevisesPivot(DevisesPivot devises)
        {
            devisesRepository.Update(Mapper.Map<DevisesPivot, GEN_Devises>(devises));
        }

        IEnumerable<DevisesPivot> IDevisesService.GetALL()
        {
            IEnumerable<GEN_Devises> devises = devisesRepository.GetAll().ToList();
            IEnumerable<DevisesPivot> devisesPivot = Mapper.Map<IEnumerable<GEN_Devises>, IEnumerable<DevisesPivot>>(devises);
            return devisesPivot;
        }
    }
}
