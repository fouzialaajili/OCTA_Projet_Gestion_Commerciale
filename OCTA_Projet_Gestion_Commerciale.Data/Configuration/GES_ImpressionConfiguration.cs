
using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Configuration
{
    public class GES_ImpressionConfiguration : EntityTypeConfiguration<GES_Impression>
    {
        public GES_ImpressionConfiguration()
        {
            ToTable("Impression");
            HasKey(a => a.ImpressionId);
            HasOptional<GEN_Dossiers>(a => a.ImpressionSociete)
                .WithMany(d => d.SocieteImpression)
                .HasForeignKey<long?>(a => a.ImpressionSocieteId);
        }
    }
}
