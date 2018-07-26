using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Configuration
{
    public class CPT_CompteGConfiguration : EntityTypeConfiguration<CPT_CompteG>
    {
        public CPT_CompteGConfiguration()
        {
            ToTable("CPT_CompteG");
            HasKey(a => a.Id);
            HasOptional<CPT_CodesTVA>(a => a.CPT_CodesTVA_CodeTVADefault)
     .WithMany(d => d.CPT_CompteG_CodeTVADefault)
   .HasForeignKey<long?>(a => a.IdCodeTvaDefault);

            HasOptional<GEN_Dossiers>(a => a.GEN_Dossiers)
      .WithMany(d => d.CPT_CompteG)
    .HasForeignKey<long?>(a => a.IdCodeTvaDefault);
HasOptional<CPT_Classe>(a => a.CPT_Classe)
         .WithMany(d => d.CPT_CompteG)
       .HasForeignKey<long?>(a => a.IdClasse);


}
    }
}
