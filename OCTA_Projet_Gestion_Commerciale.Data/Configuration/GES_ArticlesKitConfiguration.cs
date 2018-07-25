
using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Configuration
{
    public class GES_ArticlesKitConfiguration : EntityTypeConfiguration<GES_ArticlesKit>
    {
        public GES_ArticlesKitConfiguration(){
            ToTable("ArticlesKit");
            HasKey(a => a.ArticlesKitId);
            HasOptional<GES_Article>(a => a.ArticlesKitArticle)
.WithMany(d => d.ArticleArticlesKit)
.HasForeignKey<long?>(a => a.ArticlesKitArticlesId);
            HasOptional<GES_Article>(a => a.ArticlesKitArticle)
.WithMany(d => d.ArticleArticlesKit1)
.HasForeignKey<long?>(a => a.ArticlesKitArticleId1);
        }
    }
}
