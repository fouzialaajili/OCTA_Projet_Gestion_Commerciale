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
    public class ExercicesService : IExercicesService
    {
        private readonly IExercicesRepository exercicesRepository;
        private readonly IUnitOfWork unitOfWork;

        public ExercicesService(IExercicesRepository exercicesRepository, IUnitOfWork unitOfWork)
        {
            this.exercicesRepository = exercicesRepository;
            this.unitOfWork = unitOfWork;
        }




        public void CreateExercicesPivot(ExercicesPivot Exercices)
        {
           GEN_Exercices clas = Mapper.Map<ExercicesPivot, GEN_Exercices>(Exercices);
            exercicesRepository.Add(clas);
        }

        public void DeletExercicesPivot(ExercicesPivot Exercices)
        {
            exercicesRepository.Delete(Exercices.Id, Mapper.Map<ExercicesPivot, GEN_Exercices>(Exercices));
        }

        public IEnumerable<ExercicesPivot> GetALL()
        {
            IEnumerable<GEN_Exercices> execrice = exercicesRepository.GetAll().ToList();
            IEnumerable<ExercicesPivot> execricePivots = Mapper.Map<IEnumerable<GEN_Exercices>, IEnumerable<ExercicesPivot>>(execrice);
            return execricePivots;
        }

        public ExercicesPivot GetExercices(long? id)
        {
            var execrice = exercicesRepository.GetById((int)id);
            ExercicesPivot execricePivot = Mapper.Map<GEN_Exercices, ExercicesPivot>(execrice);
            return execricePivot;
        }

        public void SaveExercicesPivot()
        {
            unitOfWork.Commit();
        }

        public void UpdateExercicesPivot(ExercicesPivot Exercices)
        {
            exercicesRepository.Update(Exercices.Id, Mapper.Map<ExercicesPivot, GEN_Exercices>(Exercices));
        }
    }
}
