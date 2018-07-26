
using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Service.Interface
{
   public interface IAffaireService
    {
        IEnumerable<AffairePivot> GetALL();
        AffairePivot  GetAffaire(long id);
        
        void DeleteAffairePivot(AffairePivot affaire);
        void UpdateAffairePivot(AffairePivot affaire);
        void CreateAffairePivot(AffairePivot affaire);
        void SaveAffairePivot();
    }
}
