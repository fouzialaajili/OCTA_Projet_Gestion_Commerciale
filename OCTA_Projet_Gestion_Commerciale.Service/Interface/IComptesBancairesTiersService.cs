using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Service.Interface
{
public  interface IComptesBancairesTiersService
    {
        IEnumerable<ComptesBancairesTiersPivot> GetALL();
        ComptesBancairesTiersPivot GetComptesBancairesTiers(long? id);
        void DeletComptesBancairesTiersPivot(ComptesBancairesTiersPivot ComptesBancairesTiers);
        void UpdateComptesBancairesTiersPivot(ComptesBancairesTiersPivot ComptesBancairesTiers);
        void CreateComptesBancairesTiersPivot(ComptesBancairesTiersPivot ComptesBancairesTiers);
        void SaveComptesBancairesTiersPivot();
    }
}
