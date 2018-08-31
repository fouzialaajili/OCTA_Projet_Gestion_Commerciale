using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Service.Interface
{
public  interface IComptesBancairesService
    {
        IEnumerable<ComptesBancairesPivot> GetALL();
        ComptesBancairesPivot GetComptesBancaires(long? id);
        void DeletComptesBancairesPivot(ComptesBancairesPivot ComptesBancaires);
        void UpdateComptesBancairesPivot(ComptesBancairesPivot ComptesBancaires);
        void CreateComptesBancairesPivot(ComptesBancairesPivot ComptesBancaires);
        void SaveComptesBancairesPivot();
    }
}
