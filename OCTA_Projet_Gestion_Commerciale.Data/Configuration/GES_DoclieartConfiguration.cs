using OCTA_Projet_Gestion_Commerciale.Model;

using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Configuration
{
    public class GES_DoclieartConfiguration : EntityTypeConfiguration<GES_Doclieart>
    {
        public GES_DoclieartConfiguration()
        {
            ToTable("Doclieart");
            HasKey(a => a.DoclieartId);
            HasOptional<GEN_Dossiers>(a => a.DoclieartSociete)
           .WithMany(d => d.SocieteDoclieart)
           .HasForeignKey<long?>(a => a.DoclieartSocieteId);
        }
    }
}
