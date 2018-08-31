
using OCTA_Projet_Gestion_Commerciale.Model;
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
        IEnumerable<DossiersPivot> GetAllDossier();
        DossiersPivot GetDossiersPivot(long? id);
        IEnumerable<DossiersPivot> GetDossierByCond();
        // IEnumerable<DossiersPivot> GetDossiersPivotByNom(string Nom);
        IEnumerable<DossiersSitesPivot> GetingDossierSites();
        IEnumerable<DossiersContactsPivot> GetingDossierContact();
        void DeleteDossiersPivot(DossiersPivot dossiers);
        void UpdateDossierPivot(DossiersPivot dossiers);
        void CreateDossiersPivot(DossiersPivot dossiers);
        IEnumerable<DossiersPivot> GetActifDossier();
        IEnumerable<DossiersSitesPivot> GentingSite(long id);
        IEnumerable<DossiersContactsPivot> GentingContact(long id);
        DossiersPivot GetDossiersAndInclude(long? id);
        IEnumerable<ItemsPivot> GetingModelItem(string valeur);
        IEnumerable<PiecesPivot> GetCPT_Piece(long? id);
        // DossiersPivot getSingleActif();
        DossiersPivot getingDossierActif();
        void Validation_Db(DossiersPivot objet);
        IEnumerable<DossiersPivot> GetDossier();
        void SaveDossiers();

        /****/
        IEnumerable<DossiersPivot> GetDossiersByDossiersIdAndActif();
        IEnumerable<DossiersPivot> GetDossiersByActif(bool actif);
        IEnumerable<DossiersPivot> GetDossiersByDossiersId();



    }
}
