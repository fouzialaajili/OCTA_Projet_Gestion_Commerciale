using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Service.Interface
{
  public  interface IDossiersSitesService
    {
        IEnumerable<DossiersSitesPivot> GetAllDossierSite();
        DossiersSitesPivot GetDossiersSitePivot(long? id);
       
        void DeleteDossiersSitePivot(DossiersSitesPivot dossiersSite);
        void UpdateDossierSitePivot(DossiersSitesPivot dossiersSite);
        void CreateDossiersSitePivot(DossiersSitesPivot dossiersSite);
        IEnumerable<DossiersSitesPivot> GetActifDossierSite();
        void SaveDossiersSite();
    }
}
