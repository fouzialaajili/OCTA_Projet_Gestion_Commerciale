using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Service.Interface
{
    interface ICodeTVAService
    {
        IEnumerable<CodesTVAPivot> GetALL();
        CodesTVAPivot GetCodesTVA(long? id);
        void DeleteCodesTVAPivot(CodesTVAPivot Codes);
        void UpdateCodesTVAPivot(CodesTVAPivot Codes);
        void CreateCodesTVAPivot(CodesTVAPivot Codes);
        void SaveCodesTVAPivot();
    }
}
