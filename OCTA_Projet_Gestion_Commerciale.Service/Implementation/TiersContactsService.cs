
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
    public class TiersContactsService : ITiersContactsService
    {
        private readonly ITiersContactsRepository tiersContactsRepository;


        private readonly IUnitOfWork unitOfWork;

        public TiersContactsService(ITiersContactsRepository tiersContactsRepository, IUnitOfWork unitOfWork)
         {
             this.tiersContactsRepository = tiersContactsRepository;
             this.unitOfWork = unitOfWork;
         }

        public void CreateTiersContacts(TiersContactsPivot TiersContact)
        {
            GEN_TiersContacts item = Mapper.Map<TiersContactsPivot, GEN_TiersContacts>(TiersContact);
            tiersContactsRepository.Add(item);
        }

        public void DeleteTiersContacts(TiersContactsPivot TiersContact)
        {

           // tiersContactsRepository.Delete(Mapper.Map<TiersContactsPivot, GEN_TiersContacts>(TiersContact));
        }

        public IEnumerable<TiersContactsPivot> GetALL()
        {
            IEnumerable<GEN_TiersContacts> tiersContacts = tiersContactsRepository.GetAll().ToList();
            IEnumerable<TiersContactsPivot> tiersContactsPivots = Mapper.Map<IEnumerable<GEN_TiersContacts>, IEnumerable<TiersContactsPivot>>(tiersContacts);
            return tiersContactsPivots;
        }

        public TiersContactsPivot GetTiersContacts(long id)
        {
            var item = tiersContactsRepository.GetById((int)id);
            TiersContactsPivot tiersContactsPivot = Mapper.Map<GEN_TiersContacts, TiersContactsPivot>(item);
            return tiersContactsPivot;
        }

        public void SaveTiersContacts()
        {
            unitOfWork.Commit();
        }

        public IEnumerable<TiersContactsPivot> GetTiersContactByName(string identifged)
        {
            IEnumerable<GEN_TiersContacts> tiersContacts = tiersContactsRepository.GetTiersContactsByModelLibelle(identifged).ToList();
            IEnumerable<TiersContactsPivot> tiersContactsPivots = Mapper.Map<IEnumerable<GEN_TiersContacts>, IEnumerable<TiersContactsPivot>>(tiersContacts);
            return tiersContactsPivots;
        }

        public void UpdateTiersContacts(TiersContactsPivot TiersContact)
        {
            tiersContactsRepository.Update(Mapper.Map<TiersContactsPivot, GEN_TiersContacts>(TiersContact));
        }

        public IEnumerable<TiersContactsPivot> GetTiersContactsByIdTiersAndActif(long id)
        {
            IEnumerable<GEN_TiersContacts> tiersContacts = tiersContactsRepository.GetTiersContactsByIdTiersAndActif(id).ToList();
            IEnumerable<TiersContactsPivot> tiersContactsPivots = Mapper.Map<IEnumerable<GEN_TiersContacts>, IEnumerable<TiersContactsPivot>>(tiersContacts);
            return tiersContactsPivots;
        }
    }
}
