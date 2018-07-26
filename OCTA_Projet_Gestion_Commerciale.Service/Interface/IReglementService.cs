
using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Service.Interface
{
    interface IReglementService
    {

        IEnumerable<ReglementPivot> GetALL();
        ReglementPivot GetReglement(long id);
        IEnumerable<ReglementPivot> GetReglementsByName(string identifged);
        void DeleteReglement(ReglementPivot Reglement);
        void UpdateReglement(ReglementPivot Reglement);
        void CreateReglement(ReglementPivot Reglement);
        void SaveReglement();
    }
}