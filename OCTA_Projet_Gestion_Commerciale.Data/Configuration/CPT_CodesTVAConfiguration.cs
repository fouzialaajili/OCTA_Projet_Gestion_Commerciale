using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Configuration
{
    public class CPT_CodesTVAConfiguration : EntityTypeConfiguration<CPT_CodesTVA>
    {
        public CPT_CodesTVAConfiguration()
        {
            ToTable("CPT_CodesTVA");
            HasKey(a => a.Id);
            HasOptional<CPT_CompteG>(a => a.CPT_CompteG)
       .WithMany(d => d.CPT_CodesTVA)
     .HasForeignKey<long?>(a => a.IdCompteTVA);
   HasOptional<GEN_Dossiers>(a => a.GEN_Dossiers)
          .WithMany(d => d.CPT_CodesTVA)
        .HasForeignKey<long?>(a => a.IdDossier);
     //HasOptional<GEN_Items>(a => a.GEN_Items_RebriqueDeclaration)
     //           .WithMany(d => d.CPT_CodesTVA)
     //           .HasForeignKey<long?>(a => a.IdRubriqueDeclaration);
     //HasOptional<GEN_Items>(a => a.GEN_Items_TypeTVA)
     //           .WithMany(d => d.CPT_CodesTVA1)
     //           .HasForeignKey<long?>(a => a.TypeTVA);

            


    }
}
}
