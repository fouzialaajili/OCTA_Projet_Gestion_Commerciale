using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Configuration
{
    public class CPT_JournauxConfiguration : EntityTypeConfiguration<CPT_Journaux>
    {   public CPT_JournauxConfiguration()
        {
            ToTable("CPT_Journaux");
            HasKey(x => x.Id);
            HasOptional<CPT_CompteG>(a => a.CPT_CompteG)
    .WithMany(d => d.CPT_Journaux)
     .HasForeignKey<long?>(a => a.IdCompteContrepartie);
            HasOptional<GEN_Devises>(a => a.GEN_Devises)
      .WithMany(d => d.CPT_Journaux)
       .HasForeignKey<long?>(a => a.IdDevise);
            HasOptional<GEN_Dossiers>(a => a.GEN_Dossiers)
   .WithMany(d => d.CPT_Journaux)
    .HasForeignKey<long?>(a => a.IdDossier);
        


    }
    }
}
