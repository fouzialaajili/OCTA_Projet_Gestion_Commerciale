
using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Service.Interface
{
    public interface IDossiersService
    {
        IEnumerable<DossiersPivot> GetALL();
        DossiersPivot GetDossiersPivot(long id);
        IEnumerable<DossiersPivot> GetDossiersPivotByNom(string Nom);
        void DeleteDossiersPivot(DossiersPivot dossiers);
        void UpdateDossiersContactsPivot(DossiersPivot dossiers);
        void CreateDossiersContactsPivot(DossiersPivot dossiers);
        void SaveDossiers();
    }
}
