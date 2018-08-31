using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Service.Interface
{
  public  interface ICompteGDetailTVAService
    {
        IEnumerable<CompteGDetailTVAPivot> GetALL();
        CompteGDetailTVAPivot GetCompteGDetailTVA(long? id);
        void DeletCompteGDetailTVAPivot(CompteGDetailTVAPivot CompteGDetailTVA);
        void UpdateCompteGDetailTVAPivot(CompteGDetailTVAPivot CompteGDetailTVA);
        void CreateCompteGDetailTVAPivot(CompteGDetailTVAPivot CompteGDetailTVA);
        void SaveCompteGDetailTVAPivot();
    }
}
