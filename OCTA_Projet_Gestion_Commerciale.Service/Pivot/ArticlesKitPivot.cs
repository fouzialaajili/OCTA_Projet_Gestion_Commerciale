using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Service.Pivot
{
    public class ArticlesKitPivot
    {
        public long ArticlesKitId
        { get; set;
        }
        public int ArticlesKitQantite { get; set; }
        public string ArticlesKitDescription { get; set; }
        public int ArticlesKitSysuser { get; set; }
        public DateTime ArticlesKitSysDateCreation { get; set; }
        public DateTime ArticlesKitSysDateUpdate { get; set; }
        public long? ArticlesKitArticlesId { get; set; }
        public ArticlePivot ArticlesKitArticle { get; set; }
        public long?ArticlesKitArticleId1 { get; set; }
        public ArticlePivot ArticlesKitArticle1 { get; set; }

    }
}
