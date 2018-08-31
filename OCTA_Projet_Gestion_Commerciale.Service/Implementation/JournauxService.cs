using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Data.Repositories;
using OCTA_Projet_Gestion_Commerciale.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using OCTA_Projet_Gestion_Commerciale.Model;
using AutoMapper;

namespace OCTA_Projet_Gestion_Commerciale.Service.Implementation
{
public  class JournauxService: IJournauxService
    {
        private readonly IJournauxSRepository JournauxRepository;
        private readonly IUnitOfWork unitOfWork;

        public JournauxService(IJournauxSRepository JournauxRepository, IUnitOfWork unitOfWork)
        {
            this.JournauxRepository = JournauxRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateJournauxPivot(JournauxPivot Journaux)
        {
            CPT_Journaux clas = Mapper.Map<JournauxPivot, CPT_Journaux>(Journaux);
            JournauxRepository.Add(clas);
        }

        public void DeletJournauxPivot(JournauxPivot Journaux)
        {
            JournauxRepository.Delete(Journaux.Id, Mapper.Map<JournauxPivot, CPT_Journaux>(Journaux));
        }

        public IEnumerable<JournauxPivot> GetALL()
        {
            IEnumerable<CPT_Journaux> Journaux = JournauxRepository.GetAll().ToList();
            IEnumerable<JournauxPivot> JournauxPivots = Mapper.Map<IEnumerable<CPT_Journaux>, IEnumerable<JournauxPivot>>(Journaux);
            return JournauxPivots;
        }

        public JournauxPivot GetJournaux(long? id)
        {
            var Journaux = JournauxRepository.GetById((int)id);
            JournauxPivot JournauxPivot = Mapper.Map<CPT_Journaux, JournauxPivot>(Journaux);
            return JournauxPivot;
        }

        public void SaveJournauxPivot()
        {
            unitOfWork.Commit();
        }

        public void UpdateJournauxPivot(JournauxPivot Journaux)
        {
            JournauxRepository.Update(Journaux.Id, Mapper.Map<JournauxPivot, CPT_Journaux>(Journaux));
        }
    }
}
