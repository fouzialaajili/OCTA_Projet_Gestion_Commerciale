using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Configuration
{
    public class CPT_ComptesBancairesTiersConfiguration : EntityTypeConfiguration<CPT_ComptesBancairesTiers>
    {public CPT_ComptesBancairesTiersConfiguration()
        {
            ToTable("CPT_ComptesBancairesTiers");
            HasKey(x => x.Id);
            HasOptional<GEN_Devises>(a => a.GEN_Devises)
        .WithMany(d => d.CPT_ComptesBancairesTiers)
         .HasForeignKey<long?>(a => a.IdDevise);
            HasOptional<GEN_Tiers>(a => a.GEN_Tiers)
        .WithMany(d => d.CPT_ComptesBancairesTiers)
         .HasForeignKey<long?>(a => a.IdTiers);

            

    }
    }
}
