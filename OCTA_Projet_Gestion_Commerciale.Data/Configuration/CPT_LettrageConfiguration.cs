using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Configuration
{
    public class CPT_LettrageConfiguration : EntityTypeConfiguration<CPT_Lettrage>
    {
        public CPT_LettrageConfiguration()
        {
            ToTable("CPT_Lettrage");
            HasKey(x => x.Id);
            HasOptional<CPT_Echeances>(a => a.CPT_Echeances)
      .WithMany(d => d.CPT_Lettrage)
       .HasForeignKey<long?>(a => a.IdEcheance);
            

    }
    }
}
