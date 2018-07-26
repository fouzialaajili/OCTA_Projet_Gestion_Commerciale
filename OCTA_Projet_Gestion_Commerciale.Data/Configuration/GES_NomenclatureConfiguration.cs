
using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Configuration
{
    public class GES_NomenclatureConfiguration : EntityTypeConfiguration<GES_Nomenclature>
    {
        public GES_NomenclatureConfiguration()
        {
            ToTable("GES_Nomenclature");
            HasKey(x => x.NomenclatureId);


            /***********************************/

         // virtual public Articles NomenclatureArticle { get; set; }



        HasOptional<GES_Article>(a => a.NomenclatureArticle)
                  .WithMany(d => d.ArticleNomenclature)
                  .HasForeignKey<long?>(a => a.NomenclatureIdarticle);
            }
    }
}
