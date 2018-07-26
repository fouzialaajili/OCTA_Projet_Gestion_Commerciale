
using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Service.Interface
{
    interface IReglementFactureService
    {

        IEnumerable<ReglementFacturePivot> GetALL();
        ReglementFacturePivot GetReglementFacture(long id);
        IEnumerable<ReglementFacturePivot> GetReglementFacturesByName(string identifged);
        void DeleteReglementFacture(ReglementFacturePivot ReglementFacture);
        void UpdateReglementFacture(ReglementFacturePivot ReglementFacture);
        void CreateReglementFacture(ReglementFacturePivot ReglementFacture);
        void SaveReglementFacture();
    }
}
