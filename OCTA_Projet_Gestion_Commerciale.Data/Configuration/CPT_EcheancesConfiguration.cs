using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Configuration
{
   public  class CPT_EcheancesConfiguration : EntityTypeConfiguration<CPT_Echeances>
    {
        public CPT_EcheancesConfiguration()
        {
            ToTable("CPT_Classe");
            HasKey(x => x.Id);
            HasOptional<CPT_Ecritures>(a => a.CPT_Ecritures)
        .WithMany(d => d.CPT_Echeances)
         .HasForeignKey<long?>(a => a.IdEcriture);

      //      HasOptional<GEN_Items>(a => a.GEN_Items_ModePaiement)
      //.WithMany(d => d.CPT_Echeances)
      // .HasForeignKey<long?>(a => a.IdModePaiement);


    }
    }
}
