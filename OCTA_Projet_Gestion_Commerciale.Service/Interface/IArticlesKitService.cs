
using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Service.Interface
{
   public  interface IArticlesKitService
    {
        IEnumerable<ArticlesKitPivot> GetALL();
        ArticlesKitPivot GetArticlesKit(long id);
    
        void DeleteArticlesKitPivot(ArticlesKitPivot articlesKit);
        void UpdateArticlesKitPivot(ArticlesKitPivot articlesKit);
        void CreateArticlesKitPivot(ArticlesKitPivot articlesKit);
        void SaveArticlesKitPivot();
    }
}
