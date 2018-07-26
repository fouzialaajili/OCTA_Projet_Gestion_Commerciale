
using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OCTA_Projet_Gestion_Commerciale.Service.Interface
{
   public interface IFournisseurArticleService
    {
        IEnumerable<FournisseurArticlePivot> GetALL();
        FournisseurArticlePivot  GetFournisseurArticle(long id);
        IEnumerable<FournisseurArticlePivot> GetTiersFournisseurArticle(string tiersArticle);
        void DeleteFournisseurArticle(FournisseurArticlePivot fournisseurArticle);
        void UpdateFournisseurArticle(FournisseurArticlePivot fournisseurArticle);
        void CreateFournisseurArticle(FournisseurArticlePivot fournisseurArticle);
        void SaveFournisseurArticle();
    }
}
