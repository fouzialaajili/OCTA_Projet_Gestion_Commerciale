
using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Configuration
{
    public class GES_DoclieConfiguration : EntityTypeConfiguration<GES_Doclie>
    {
        public GES_DoclieConfiguration()
        {
            ToTable("Doclie");
            HasKey(a => a.DoclieId);
            HasOptional<GEN_Dossiers>(a => a.DoclieSociete)
         .WithMany(d => d.SocieteDoclie)
         .HasForeignKey<long?>(a => a.DoclieSocieteId);
        }
    }
}
