
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
            ToTable("Devise");
            HasKey(a => a.DevisesId);


            HasOptional<GEN_Dossiers>(a => a.DeviseSociete)
         .WithMany(d => d.SocieteDevise)
       .HasForeignKey<long?>(a => a.DevisesIdDossier);
        }
    }
}
