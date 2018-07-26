
using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Configuration
{
    public class GES_ArticleConfiguration : EntityTypeConfiguration<GES_Article>
    {
        public GES_ArticleConfiguration()
        {
ToTable("GES_Article");
HasKey(a => a.ArticleId);
HasOptional<GEN_Dossiers>(a => a.ArticleSociete)
           .WithMany(d => d.SocieteArticle)
            .HasForeignKey<long?>(a => a.ArticleSocieteId);

HasOptional<GES_Depot>(a => a.ArticleDepot)
                      .WithMany(d => d.DepotArticle)
                       .HasForeignKey<long?>(a => a.ArticleDepotId);

 HasOptional<GES_Categorie>(a => a.ArticleCategorie)
.WithMany(d => d.CategorieArticle)
.HasForeignKey<long?>(a => a.ArticleCategorieId);

            HasOptional<GES_Unite>(a => a.ArticleUnite)
    .WithMany(d => d.UniteArticle)
    .HasForeignKey<long?>(a => a.ArticleUniteId);

            HasOptional<GES_Marque>(a => a.ArticleMarque)
.WithMany(d => d.MarqueArticle)
.HasForeignKey<long?>(a => a.ArticleMarqueId);
        

    }
    }
}
