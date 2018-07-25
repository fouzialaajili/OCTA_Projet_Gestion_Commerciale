
using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Configuration
{
    public class GES_AffaireConfiguration : EntityTypeConfiguration<GES_Affaire>
    {
        public GES_AffaireConfiguration()
        {
            ToTable("Affaire");
            HasKey(a => a.AffaireId);
            HasOptional<GEN_Dossiers>(a => a.AffaireSociete)
            .WithMany(d => d.SocieteAffaire)
             .HasForeignKey<long?>(a => a.AffaireSocieteId);
        }
    }
}
