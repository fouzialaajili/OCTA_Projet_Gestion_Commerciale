using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using OCTA_Projet_Gestion_Commerciale.Model;

namespace OCTA_Projet_Gestion_Commerciale.Data.Configuration
{
    class GES_UniteConfiguration : EntityTypeConfiguration<GES_Unite>
    {
        public GES_UniteConfiguration()
        {
            ToTable("GES_Unite");
            HasKey(a => a.Id);
            HasOptional<GEN_Dossiers>(a => a.UniteSociete)
                .WithMany(d => d.SocieteUnite)
                .HasForeignKey<long?>(a => a.UniteSocieteId);
        }
    }
}
