using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Service.Interface
{
    public interface IArticlesService
    {
        IEnumerable<ArticlePivot> GetALL();
        ArticlePivot GetArticlePivot(long id);

        void DeleteArticlePivot(ArticlePivot articlesPrix);
        void UpdateArticlePivot(ArticlePivot articlesPrix);
        void CreateArticlePivot(ArticlePivot  articlesPrix);
        void SaveArticlePivot();
    }
}
