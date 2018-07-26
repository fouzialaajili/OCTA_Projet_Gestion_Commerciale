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
    public class CodesTVAService : ICodesTVAService
{
        private readonly ICodesTvaRepository codesTvaRepository;

        private readonly IUnitOfWork unitOfWork;
        public CodesTVAService(ICodesTvaRepository codesTvaRepository,IUnitOfWork unitOfWork)
        {
            this.codesTvaRepository = codesTvaRepository;
            this.unitOfWork = unitOfWork;

        }
        public void CreateCodesTVAPivot(CodesTVAPivot codesTVAPivot)
        {
            CPT_CodesTVA codesTVA = Mapper.Map<CodesTVAPivot, CPT_CodesTVA>(codesTVAPivot);
            codesTvaRepository.Add(codesTVA);
        }

        public void DeleteCodesTVAPivot(CodesTVAPivot codesTVAPivot)
        {
            codesTvaRepository.Delete(Mapper.Map<CodesTVAPivot, CPT_CodesTVA>(codesTVAPivot));
        }

        public IEnumerable<CodesTVAPivot> GetALL()
        {
            IEnumerable<CPT_CodesTVA> codesTVAPivots = codesTvaRepository.GetAll().ToList();
            IEnumerable<CodesTVAPivot> codesTVAPivot = Mapper.Map<IEnumerable<CPT_CodesTVA>, IEnumerable<CodesTVAPivot>>(codesTVAPivots);
            return codesTVAPivot;
        }

        public CodesTVAPivot GetCodesTVAPivot(long id)
        {
            var item = codesTvaRepository.GetById((int)id);
            CodesTVAPivot codesTVAPivot = Mapper.Map<CPT_CodesTVA, CodesTVAPivot>(item);
            return codesTVAPivot;
        }

        public IEnumerable<CodesTVAPivot> GetCodesTVAPivotByLibelleTaux(string LibelleTaux)
        {
            throw new NotImplementedException();
        }

        public void SaveCodesTVAPivot()
        {
            unitOfWork.Commit();
        }

        public void UpdateCodesTVAPivot(CodesTVAPivot codesTVAPivot)
        {
            codesTvaRepository.Update(Mapper.Map<CodesTVAPivot, CPT_CodesTVA>(codesTVAPivot));
        }
    }
}
