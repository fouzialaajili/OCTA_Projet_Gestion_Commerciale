using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Service.Interface
{
 public interface ICompte_GService
    {
        
            IEnumerable<CompteGPivot> GetCPT_CompteGsByActifandIDDossierandValeur(string valeur);
       }
}
