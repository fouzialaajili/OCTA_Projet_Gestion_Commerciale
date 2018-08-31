using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Service.Interface
{
  public  interface IRelevesBancairesService
    {
        IEnumerable<RelevesBancairesPivot> GetALL();
        RelevesBancairesPivot GetRelevesBancaires(long? id);
        void DeletRelevesBancairesPivot(RelevesBancairesPivot RelevesBancaires);
        void UpdateRelevesBancairesPivot(RelevesBancairesPivot RelevesBancaires);
        void CreateRelevesBancairesPivot(RelevesBancairesPivot RelevesBancaires);
        void SaveRelevesBancairesPivot();
    }
}
