using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Service.Interface
{
 public   interface IPlanAnalytiqueService
    {
        IEnumerable<PlanAnalytiquePivot> GetALL();
        PlanAnalytiquePivot GetPlanAnalytique(long? id);
        void DeletPlanAnalytiquePivot(PlanAnalytiquePivot PlanAnalytique);
        void UpdatePlanAnalytiquePivot(PlanAnalytiquePivot PlanAnalytique);
        void CreatePlanAnalytiquePivot(PlanAnalytiquePivot PlanAnalytique);
        void SavePlanAnalytiquePivot();
    }
}
