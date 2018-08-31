using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Service.Interface
{
 public   interface ICompteGService
    {
        IEnumerable<CompteGPivot> GetALL();
        CompteGPivot GetCompteG(long? id);
        void DeletCompteGPivot(CompteGPivot CompteG);
        void UpdateCompteGPivot(CompteGPivot CompteG);
        void CreateCompteGPivot(CompteGPivot CompteG);
        void SaveCompteGPivot();
    }
}
