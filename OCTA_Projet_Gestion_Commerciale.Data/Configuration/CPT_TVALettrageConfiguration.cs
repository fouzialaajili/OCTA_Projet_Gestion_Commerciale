using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Configuration
{
    public class CPT_TVALettrageConfiguration : EntityTypeConfiguration<CPT_TVALettrage>
    {
        public CPT_TVALettrageConfiguration()
        {
            ToTable("CPT_TVALettrage");
            HasKey(x => x.Id);

            HasOptional<CPT_Lettrage>(a => a.CPT_Lettrage)
                                         .WithMany(d => d.CPT_TVALettrage)
                                         .HasForeignKey<long?>(a => a.LettrageId);

        

    }



    }
}
