
using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Service.Interface
{
    interface IImpressionService
    {
        IEnumerable<ImpressionPivot> GetALL();
        ImpressionPivot GetImpression(long id);
        IEnumerable<ImpressionPivot> Impressions(string identifged);
        void DeleteImpression(ImpressionPivot ged);
        void UpdateImpression(ImpressionPivot ged);
        void CreateImpression(ImpressionPivot ged);
        void SaveImpression();
    }
}
