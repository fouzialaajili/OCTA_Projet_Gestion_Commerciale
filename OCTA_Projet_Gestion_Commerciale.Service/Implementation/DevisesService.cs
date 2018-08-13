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
        public void CreateDevise(DevisesPivot devises)
        {
            GEN_Devises _Devises = Mapper.Map<DevisesPivot, GEN_Devises>(devises);
            devisesRepository.Add(_Devises);
        }

        public void DeleteDevise(DevisesPivot devises)
        {
            //devisesRepository.Delete(Mapper.Map<DevisesPivot, GEN_Devises>(devises));
        }

        public IQueryable<GEN_Devises> GetAllDevises()
        {
            var devises = devisesRepository.GetAll();//.ToList();
            //IEnumerable<DevisesPivot> devisesPivot = Mapper.Map<IEnumerable<GEN_Devises>, IEnumerable<DevisesPivot>>(devises);
            return devises.AsQueryable();
        }

        public DevisesPivot GetDevise(long id)
        {
            var item = devisesRepository.GetById((int)id);
            DevisesPivot devisesPivot = Mapper.Map<GEN_Devises, DevisesPivot>(item);
            return devisesPivot;
        }

        public IEnumerable<DevisesPivot> GetDevisesByIDDossierAndActif()
        {
            IEnumerable<GEN_Devises> devises = devisesRepository.GetDevisesByIDDossierAndActif().ToList();
            IEnumerable<DevisesPivot> devisesPivot = Mapper.Map<IEnumerable<GEN_Devises>, IEnumerable<DevisesPivot>>(devises);
            return devisesPivot;
        }

        public void SaveDevise()
        {
            unitOfWork.Commit();
        }


        public void UpdateDevise(DevisesPivot devises)
        {
            devisesRepository.Update(Mapper.Map<DevisesPivot, GEN_Devises>(devises));
        }

        

        //IEnumerable<DevisesPivot> GetDevises()
        //{
        //    IEnumerable<GEN_Devises> devises = devisesRepository.GetAll().ToList();
        //    IEnumerable<DevisesPivot> devisesPivot = Mapper.Map<IEnumerable<GEN_Devises>, IEnumerable<DevisesPivot>>(devises);
        //    return devisesPivot;
        //}
    }
}
