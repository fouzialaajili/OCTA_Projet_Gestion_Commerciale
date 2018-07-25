
using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Configuration
{
    public class GES_DocumentCommercialDetailSerieConfiguration : EntityTypeConfiguration<GES_DocumentCommercialDetailSerie>
    {
        public GES_DocumentCommercialDetailSerieConfiguration()
        {
            ToTable("DocumentCommercialDetailSerie");
            HasKey(a => a.DocumentCommercialDetailSerieId);

            HasOptional<GEN_Dossiers>(a => a.DocumentCommercialDetailSerieSociete)
    .WithMany(d => d.SocieteDocumentCommercialDetailSerie)
    .HasForeignKey<long?>(a => a.DocumentCommercialDetailSerieSocieteId);
            HasOptional<GES_DocumentCommercialDetail>(a => a.DocumentCommercialDetailSerieDocumentCommercialDetail)
             .WithMany(d => d.DocumentCommercialDetailDocumentCommercialDetailSerie)
             .HasForeignKey<long?>(a => a.DocumentCommercialDetailSerieDocumentCommercialDetailIdDocumentDetail);
        
    }
    }
}
