
using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Configuration
{
    public class GES_DocumentCommercialDetailConfiguration : EntityTypeConfiguration<GES_DocumentCommercialDetail>
    {
        public GES_DocumentCommercialDetailConfiguration()
        {
            ToTable("GES_DocumentCommercialDetail");
            HasKey(a => a.DocumentCommercialDetailId);
            HasOptional<GES_Article>(a => a.DocumentCommercialDetailArticle)
      .WithMany(d => d.ArticleDocumentCommercialDetail)
      .HasForeignKey<long?>(a => a.DocumentCommercialDetailArticleId);
            HasOptional<GES_DocumentCommercial>(a => a.DocumentCommercialDetailDocumentCommercial)
             .WithMany(d => d.DocumentCommercialDocumentCommercialDetail)
             .HasForeignKey<long?>(a => a.DocumentCommercialIdDocumentCommercial);

     


    }
}
}
