
using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Configuration
{
    class GES_ToleranceConfiguration : EntityTypeConfiguration<GES_Tolerance>
    {
        public GES_ToleranceConfiguration()
        {
            ToTable("GES_Tolerance");
            HasKey(a => a.Id);

            HasOptional<GEN_Dossiers>(a => a.ToleranceSociete)
              .WithMany(d => d.SocieteTolerance)
              .HasForeignKey<long?>(a => a.ToleranceSocieteId);
        }

    }
}
