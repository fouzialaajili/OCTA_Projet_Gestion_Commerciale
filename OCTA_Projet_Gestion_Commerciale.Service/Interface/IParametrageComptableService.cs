
using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Service.Interface
{
    interface IParametrageComptableService
    {
        IEnumerable<ParametrageComptablePivot> GetALL();
        ParametrageComptablePivot GetParametrageComptable (long id);
        IEnumerable<ParametrageComptablePivot> GetParametrageComptablesByName(string identifged);
        void DeleteParametrageComptable(ParametrageComptablePivot ParametrageComptable);
        void UpdateParametrageComptable(ParametrageComptablePivot ParametrageComptable);
        void CreateParametrageComptable(ParametrageComptablePivot ParametrageComptable);
        void SaveParametrageComptable();
    }
}
