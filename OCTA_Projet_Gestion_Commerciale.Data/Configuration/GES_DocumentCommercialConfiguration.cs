using OCTA_Projet_Gestion_Commerciale.Model;

using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Configuration
{
    public class GES_DocumentCommercialConfiguration : EntityTypeConfiguration<GES_DocumentCommercial>
    {
        public GES_DocumentCommercialConfiguration()
        {
            ToTable("DocumentCommercial");
            HasKey(a => a.DocumentCommercialId);
HasOptional<GEN_Dossiers>(a => a.DocumentCommercialSociete)
      .WithMany(d => d.SocieteDocumentCommercial)
      .HasForeignKey<long?>(a => a.DocumentCommercialSocieteId);
 
        }
    }
}
