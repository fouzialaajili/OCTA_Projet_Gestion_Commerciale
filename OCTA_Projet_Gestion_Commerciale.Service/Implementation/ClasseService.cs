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
  public  class ClasseService : IClasseService
    {
        private readonly IClasseRepository classeRepository;
        private readonly IUnitOfWork unitOfWork;

        public ClasseService(IClasseRepository classeRepository, IUnitOfWork unitOfWork)
        {
            this.classeRepository = classeRepository;
            this.unitOfWork = unitOfWork;
        }



        public void CreateClassePivot(ClassePivot classe)
        {
           CPT_Classe clas= Mapper.Map<ClassePivot, CPT_Classe>(classe);
            classeRepository.Add(clas);
        }

        public void DeleteClassePivot(ClassePivot classe)
        {
            classeRepository.Delete(classe.Id, Mapper.Map<ClassePivot, CPT_Classe>(classe));
        }

        public IEnumerable<ClassePivot> GetALL()
        {
            IEnumerable<CPT_Classe> classes = classeRepository.GetAll().ToList();
            IEnumerable<ClassePivot> classesPivots = Mapper.Map<IEnumerable<CPT_Classe>, IEnumerable<ClassePivot>>(classes);
            return classesPivots;
        }

        public ClassePivot GetClasse(long? id)
        {
            var classe = classeRepository.GetById((int)id);
            ClassePivot calssePivot = Mapper.Map<CPT_Classe ,ClassePivot>(classe);
            return calssePivot;
        }

        public void SaveClassePivot()
        {
            unitOfWork.Commit();
        }

        public void UpdateClassePivot(ClassePivot classe)
        {
            classeRepository.Update(Mapper.Map<ClassePivot, CPT_Classe>(classe));
        }
    }
}
