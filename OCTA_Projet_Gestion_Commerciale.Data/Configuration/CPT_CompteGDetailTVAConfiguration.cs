using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Configuration
{
   public  class CPT_CompteGDetailTVAConfiguration : EntityTypeConfiguration<CPT_CompteGDetailTVA>
    {
        public CPT_CompteGDetailTVAConfiguration()
        {
            ToTable(" CPT_CompteGDetailTVA");
            HasKey(a => a.Id);
            HasOptional<CPT_CodesTVA>(a => a.CPT_CodesTVA)
         .WithMany(d => d.CPT_CompteGDetailTVA)
       .HasForeignKey<long?>(a => a.IdCodeTVA);
         
    }



    }
}
