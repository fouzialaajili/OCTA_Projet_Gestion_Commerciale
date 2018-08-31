using OCTA_Projet_Gestion_Commerciale.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Data.Repositories;
using OCTA_Projet_Gestion_Commerciale.Model;
using AutoMapper;

namespace OCTA_Projet_Gestion_Commerciale.Service.Implementations
{
    public class PreferencesService : IPreferencesService
    {

        private readonly IPreferencesRepository preferencesRepository;
        private readonly IUnitOfWork unitOfWork;

        public PreferencesService(IPreferencesRepository preferencesRepository, IUnitOfWork unitOfWork)
        {
            this.preferencesRepository = preferencesRepository;
            this.unitOfWork = unitOfWork;
        }




        public void CreatePreferencesPivot(PreferencesPivot Preferences)
        {
            GEN_Preferences clas = Mapper.Map<PreferencesPivot, GEN_Preferences>(Preferences);
            preferencesRepository.Add(clas);
        }

        public void DeletPreferencesPivot(PreferencesPivot Preferences)
        {
            preferencesRepository.Delete(Preferences.Id, Mapper.Map<PreferencesPivot, GEN_Preferences>(Preferences));
        }

        public IEnumerable<PreferencesPivot> GetALL()
        {
            IEnumerable<GEN_Preferences> preferences = preferencesRepository.GetAll().ToList();
            IEnumerable<PreferencesPivot> preferencesPivots = Mapper.Map<IEnumerable<GEN_Preferences>, IEnumerable<PreferencesPivot>>(preferences);
            return preferencesPivots;
        }

        public PreferencesPivot GetPreferences(long? id)
        {
            var preferences = preferencesRepository.GetById((int)id);
            PreferencesPivot preferencesPivot = Mapper.Map<GEN_Preferences, PreferencesPivot>(preferences);
            return preferencesPivot;
        }

        public void SavePreferencesPivot()
        {
            unitOfWork.Commit();
        }

        public void UpdatePreferencesPivot(PreferencesPivot Preferences)
        {

            preferencesRepository.Update(Preferences.Id, Mapper.Map<PreferencesPivot, GEN_Preferences>(Preferences));
        }
    }
}
