using OCTA_Projet_Gestion_Commerciale.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OCTA_Projet_Gestion_Commerciale.Model;
using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using OCTA_Projet_Gestion_Commerciale.Data.Repositories;
using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using AutoMapper;

namespace OCTA_Projet_Gestion_Commerciale.Service.Implementation
{
    public class LicenceService : ILicenceService
    {
        private readonly ILicenceRepository licenceRepository;
    

        private readonly IUnitOfWork unitOfWork;

        public LicenceService(ILicenceRepository licenceRepository , IUnitOfWork unitOfWork)
        {
            this.licenceRepository = licenceRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateLicence(LicencePivot licence)
        {
            GES_Licence item = Mapper.Map<LicencePivot, GES_Licence>(licence);
            licenceRepository.Add(item);
        }

        public void DeleteLicence(LicencePivot licence)
        {
            licenceRepository.Delete(licence.Id,Mapper.Map<LicencePivot, GES_Licence>(licence));
        }

        public IEnumerable<LicencePivot> GetALL()
        {
            IEnumerable<GES_Licence> licences = licenceRepository.GetAll().ToList();
            IEnumerable<LicencePivot> licencePivots = Mapper.Map<IEnumerable<GES_Licence>, IEnumerable<LicencePivot>>(licences);
            return licencePivots;
        }

        public LicencePivot GetLicence(long id)
        {
            var item = licenceRepository.GetById((int)id);
            LicencePivot licencePivot = Mapper.Map<GES_Licence, LicencePivot>(item);
            return licencePivot;
        }

        public IEnumerable<LicencePivot> Licences(string identifged)
        {
            IEnumerable<GES_Licence> licences = licenceRepository.GetItemsByModelLibelle(identifged).ToList();
            IEnumerable<LicencePivot> licencesPivots = Mapper.Map<IEnumerable<GES_Licence>, IEnumerable<LicencePivot>>(licences);
            return licencesPivots;
        }

        public void SaveLicence()
        {
            unitOfWork.Commit();
        }

        public void UpdateLicence(LicencePivot licence)
        {
            licenceRepository.Update(Mapper.Map<LicencePivot, GES_Licence>(licence));
        }
    }
}
