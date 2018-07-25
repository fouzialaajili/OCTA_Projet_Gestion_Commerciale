using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Configuration
{
    class GEN_NumerationConfiguration : EntityTypeConfiguration<GEN_Numeration>
    {
        // public virtual GEN_Dossiers GEN_Dossiers { get; set; }
        public GEN_NumerationConfiguration()
        {
            ToTable("GEN_Numeration");
            HasKey(a => a.Id);


            HasOptional<GEN_Dossiers>(a => a.GEN_Dossiers)
         .WithMany(d => d.GEN_Numeration)
       .HasForeignKey<long?>(a => a.idDossier);
        }

    }
}
