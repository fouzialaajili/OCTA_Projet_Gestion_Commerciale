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

namespace OCTA_Projet_Gestion_Commerciale.Service.Implementation
{
    public class LettrageService : ILettrageService
    {

        private readonly ILettrageRepository LettrageRepository;
        private readonly IUnitOfWork unitOfWork;

        public LettrageService(ILettrageRepository LettrageRepository, IUnitOfWork unitOfWork)
        {
            this.LettrageRepository = LettrageRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateLettragePivot(LettragePivot Lettrage)
        {
            CPT_Lettrage clas = Mapper.Map<LettragePivot, CPT_Lettrage>(Lettrage);
            LettrageRepository.Add(clas);
        }

        public void DeletLettragePivot(LettragePivot Lettrage)
        {
           LettrageRepository.Delete(Lettrage.Id, Mapper.Map<LettragePivot, CPT_Lettrage>(Lettrage));
        }

        public IEnumerable<LettragePivot> GetALL()
        {
            IEnumerable<CPT_Lettrage> CPT_Lettrage = LettrageRepository.GetAll().ToList();
            IEnumerable<LettragePivot> CPT_LettragePivots = Mapper.Map<IEnumerable<CPT_Lettrage>, IEnumerable<LettragePivot>>(CPT_Lettrage);
            return CPT_LettragePivots;
        }

        public LettragePivot GetLettrage(long? id)
        {
            var Lettrage = LettrageRepository.GetById((int)id);
            LettragePivot LettragePivot = Mapper.Map<CPT_Lettrage, LettragePivot>(Lettrage);
            return LettragePivot;
        }

        public void SaveLettragePivot()
        {
            unitOfWork.Commit();
        }

        public void UpdateLettragePivot(LettragePivot Lettrage)
        {
            LettrageRepository.Update(Lettrage.Id, Mapper.Map<LettragePivot, CPT_Lettrage>(Lettrage));
        }
    }
}
