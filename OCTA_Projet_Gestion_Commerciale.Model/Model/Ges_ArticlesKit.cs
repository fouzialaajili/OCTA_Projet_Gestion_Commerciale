using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Model
{
    public class GES_ArticlesKit
    {
        public long  ArticlesKitId { get; set;
        }
        public int ArticlesKitQantite { get; set; }
        public string ArticlesKitDescription { get; set; }
        public int ArticlesKitSysuser { get; set; }
        public DateTime ArticlesKitSysDateCreation { get; set; }
        public DateTime ArticlesKitSysDateUpdate { get; set; }
        public long ArticlesKitArticlesId { get; set; }
        public virtual GES_Article ArticlesKitArticle { get; set; }
        public long ArticlesKitArticleId1 { get; set; }
        public virtual GES_Article ArticlesKitArticle1 { get; set; }

    }
}
