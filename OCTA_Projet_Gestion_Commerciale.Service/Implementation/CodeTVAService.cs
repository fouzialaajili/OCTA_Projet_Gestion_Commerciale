using OCTA_Projet_Gestion_Commerciale.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using OCTA_Projet_Gestion_Commerciale.Data.Repositories;
using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Model;
using AutoMapper;

namespace OCTA_Projet_Gestion_Commerciale.Service.Implementation
{
    class CodeTVAService : ICodeTVAService
    {

        private readonly ICodesTVARepository codesRepository;
        private readonly IUnitOfWork unitOfWork;

        public CodeTVAService(ICodesTVARepository codesRepository, IUnitOfWork unitOfWork)
        {
            this.codesRepository = codesRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateCodesTVAPivot(CodesTVAPivot Codes)
        {
            CPT_CodesTVA clas = Mapper.Map<CodesTVAPivot, CPT_CodesTVA>(Codes);
            codesRepository.Add(clas);
        }

        public void DeleteCodesTVAPivot(CodesTVAPivot Codes)
        {
            codesRepository.Delete(Codes.Id, Mapper.Map<CodesTVAPivot, CPT_CodesTVA>(Codes));
        }

        public IEnumerable<CodesTVAPivot> GetALL()
        {
            IEnumerable<CPT_CodesTVA> codes= codesRepository.GetAll().ToList();
            IEnumerable<CodesTVAPivot> codesPivots = Mapper.Map<IEnumerable<CPT_CodesTVA>, IEnumerable<CodesTVAPivot>>(codes);
            return codesPivots;
        }

        public CodesTVAPivot GetCodesTVA(long? id)
        {
            var codes = codesRepository.GetById((int)id);
            CodesTVAPivot codesPivot = Mapper.Map<CPT_CodesTVA, CodesTVAPivot>(codes);
            return codesPivot;
        }

        public void SaveCodesTVAPivot()
        {
            unitOfWork.Commit();
        }

        public void UpdateCodesTVAPivot(CodesTVAPivot Codes)
        {
            codesRepository.Update(Mapper.Map<CodesTVAPivot, CPT_CodesTVA>(Codes));
        }
    }
}
