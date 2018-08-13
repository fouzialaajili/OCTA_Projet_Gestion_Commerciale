using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Configuration
{
   public  class CPT_RelevesBancairesDetailConfiguration  : EntityTypeConfiguration<CPT_RelevesBancairesDetail>
    {
        public CPT_RelevesBancairesDetailConfiguration()
        {
            ToTable("CPT_RelevesBancairesDetail");
            HasKey(x => x.Id);
            HasOptional<GEN_TypePaiement>(a => a.GEN_TypePaiement)
                                                 .WithMany(d => d.CPT_RelevesBancairesDetail)
                                                 .HasForeignKey<long?>(a => a.IdTypePaiement);

            HasOptional<CPT_CompteG>(a => a.CPT_CompteG)
                                                 .WithMany(d => d.CPT_RelevesBancairesDetail)
                                                 .HasForeignKey<long?>(a => a.IdNatureOperation1);
            HasOptional<CPT_RelevesBancaires>(a => a.CPT_RelevesBancaires)
                                                 .WithMany(d => d.CPT_RelevesBancairesDetail)
                                                 .HasForeignKey<long?>(a => a.IdReleveBancaire);


            HasOptional<GEN_Tiers>(a => a.GEN_Tiers)
                                                .WithMany(d => d.CPT_RelevesBancairesDetail)
                                                .HasForeignKey<long?>(a => a.IdTier);

            HasOptional<GEN_Items>(a => a.GEN_Items)
                                                .WithMany(d => d.CPT_RelevesBancairesDetail)
                                                .HasForeignKey<long?>(a => a.IdTier);

            
}
    }
}
