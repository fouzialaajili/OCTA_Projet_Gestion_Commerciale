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
    .HasForeignKey<long?>(a => a.IdDossier);
            HasOptional<CPT_Classe>(a => a.CPT_Classe)
                     .WithMany(d => d.CPT_CompteG)
                   .HasForeignKey<long?>(a => a.IdClasse);

            //HasOptional<GEN_Items>(a => a.GEN_Items_NatureCompte)
            //                     .WithMany(d => d.CPT_CompteG)
            //                   .HasForeignKey<long?>(a => a.IdNatureCompte);
            //HasOptional<GEN_Items>(a => a.GEN_Items_ReportANouveau)
            //         .WithMany(d => d.CPT_CompteG1)
            //       .HasForeignKey<long?>(a => a.ReportANouveau);
            //HasOptional<GEN_Items>(a => a.GEN_Items_Sens)
            //         .WithMany(d => d.CPT_CompteG2)
            //       .HasForeignKey<long?>(a => a.Sens);
            //  HasOptional<GEN_Items>(a => a.GEN_Items_SuiviCompteTVA)
            //         .WithMany(d => d.CPT_CompteG3)
            //       .HasForeignKey<long?>(a => a.SuiviCompteTVA);
            // HasOptional<GEN_Items>(a => a.GEN_Items_TypeCompte)
            //         .WithMany(d => d.CPT_CompteG4)
            //       .HasForeignKey<long?>(a => a.IdTypeCompte);
















        }
    }
}
