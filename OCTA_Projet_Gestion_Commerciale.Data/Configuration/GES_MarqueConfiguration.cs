
using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Configuration
{
    public class GES_MarqueConfiguration : EntityTypeConfiguration<GES_Marque>
    {
        public GES_MarqueConfiguration()
        {
            ToTable("Marque");
            HasKey(a => a.MarqueId);
            HasOptional<GEN_Dossiers>(a => a.MarqueSociete)
                .WithMany(d => d.SocieteMarque)
                .HasForeignKey<long?>(a => a.MarqueSocieteId);
        }
    }
    }
