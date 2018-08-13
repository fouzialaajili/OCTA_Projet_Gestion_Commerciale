
using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Configuration
{
    public class GEN_DevisesConfiguration : EntityTypeConfiguration<GEN_Devises>
    {
        public GEN_DevisesConfiguration()
        {
            ToTable("GEN_Devise");
            HasKey(a => a.DevisesId);


            HasOptional<GEN_Dossiers>(a => a.GEN_Dossiers)
         .WithMany(d => d.GEN_Devises)
       .HasForeignKey<long?>(a => a.DevisesIdDossier);
        }
    }
}
