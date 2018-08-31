using OCTA_Projet_Gestion_Commerciale.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Data.Repositories;
using AutoMapper;
using OCTA_Projet_Gestion_Commerciale.Model;

namespace OCTA_Projet_Gestion_Commerciale.Service.Implementation
{
  public  class TVALettrageService: ITVALettrageService
    {
        private readonly ITVALettrageRepository LettrageRepository;
        private readonly IUnitOfWork unitOfWork;


        public TVALettrageService(ITVALettrageRepository LettrageRepository, IUnitOfWork unitOfWork)
        {
            this.LettrageRepository = LettrageRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateTVALettragePivot(TVALettragePivot TVALettrage)
        {
            CPT_TVALettrage clas = Mapper.Map<TVALettragePivot, CPT_TVALettrage>(TVALettrage);
            LettrageRepository.Add(clas);
        }

        public void DeletTVALettragePivot(TVALettragePivot TVALettrage)
        {
            LettrageRepository.Delete(TVALettrage.Id, Mapper.Map<TVALettragePivot, CPT_TVALettrage>(TVALettrage));
        }

        public IEnumerable<TVALettragePivot> GetALL()
        {
            IEnumerable<CPT_TVALettrage> comptes = LettrageRepository.GetAll().ToList();
            IEnumerable<TVALettragePivot> comptesPivots = Mapper.Map<IEnumerable<CPT_TVALettrage>, IEnumerable<TVALettragePivot>>(comptes);
            return comptesPivots;
        }

        public TVALettragePivot GetTVALettrage(long? id)
        {

            var compteg = LettrageRepository.GetById((int)id);
            TVALettragePivot comptegPivot = Mapper.Map<CPT_TVALettrage, TVALettragePivot>(compteg);
            return comptegPivot;
        }

        public void SaveTVALettragePivot()
        {
            unitOfWork.Commit();
        }

        public void UpdateTVALettragePivot(TVALettragePivot TVALettrage)
        {
            LettrageRepository.Update(TVALettrage.Id, Mapper.Map<TVALettragePivot, CPT_TVALettrage>(TVALettrage));
        }
    }
}
