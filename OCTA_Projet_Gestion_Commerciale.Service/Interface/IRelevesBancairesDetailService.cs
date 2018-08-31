using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Service.Interface
{
  public  interface IRelevesBancairesDetailService
    {
        IEnumerable<RelevesBancairesDetailPivot> GetALL();
        RelevesBancairesDetailPivot GetRelevesBancaires(long? id);
        void DeletRelevesBancairesPivot(RelevesBancairesDetailPivot RelevesBancaires);
        void UpdateRelevesBancairesPivot(RelevesBancairesDetailPivot RelevesBancaires);
        void CreateRelevesBancairesPivot(RelevesBancairesDetailPivot RelevesBancaires);
        void SaveRelevesBancairesPivot();
    }
}
