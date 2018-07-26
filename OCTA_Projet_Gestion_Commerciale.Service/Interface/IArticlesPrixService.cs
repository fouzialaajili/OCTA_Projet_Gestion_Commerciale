
using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Service.Interface
{
    public interface IArticlesPrixService
    {
        IEnumerable<ArticlesPrixPivot> GetALL();
        ArticlesPrixPivot GetArticlesPrixPivot(long id);
 
        void DeleteArticlesPrixPivot(ArticlesPrixPivot articlesPrix);
        void UpdateArticlesPrixPivot(ArticlesPrixPivot articlesPrix);
        void CreateArticlesPrixPivot(ArticlesPrixPivot articlesPrix);
        void SaveArticlesPrixPivot();
    }
}
