
using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Service.Interface
{
    interface IOpportuniteService
    {
        IEnumerable<OpportunitePivot> GetALL();
        OpportunitePivot Getopportunite(long id);
        IEnumerable<OpportunitePivot> GetopportunitesByName(string identifged);
        void DeleteOpportunite(OpportunitePivot opportunite);
        void UpdateOpportunite(OpportunitePivot opportunite);
        void CreateOpportunite(OpportunitePivot opportunite);
        void SaveOpportunite();
    }
}
