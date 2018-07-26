using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Configuration
{
    public class CPT_RelevesBancairesConfiguration : EntityTypeConfiguration<CPT_RelevesBancaires>
    {
        public CPT_RelevesBancairesConfiguration()
        {
            ToTable("CPT_RelevesBancaires");
            HasKey(x => x.Id);
            HasOptional<CPT_ComptesBancaires>(a => a.CPT_ComptesBancaires)
                                                  .WithMany(d => d.CPT_RelevesBancaires)
                                                  .HasForeignKey<long?>(a => a.IdCompteBancaire);
            HasOptional<GEN_Devises>(a => a.GEN_Devises)
                                                  .WithMany(d => d.CPT_RelevesBancaires)
                                                  .HasForeignKey<long?>(a => a.IdDevise);

            

    }
    }
}
