using OCTA_Projet_Gestion_Commerciale.Model;
using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Service.Interface
{
    interface ILicenceService
    {
        IEnumerable<LicencePivot> GetALL();
        LicencePivot GetLicence(long id);
        IEnumerable<LicencePivot> Licences(string identifged);
        void DeleteLicence(LicencePivot licence);
        void UpdateLicence(LicencePivot licence);
        void CreateLicence(LicencePivot licence);
        void SaveLicence();
    }
}
