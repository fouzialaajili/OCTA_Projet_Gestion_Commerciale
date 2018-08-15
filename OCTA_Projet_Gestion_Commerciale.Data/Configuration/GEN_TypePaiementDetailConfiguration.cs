
using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Configuration
{
    public class GEN_TypePaiementDetailConfiguration : EntityTypeConfiguration<GEN_TypePaiementDetail>
    {
        public GEN_TypePaiementDetailConfiguration()
        {
            ToTable("GEN_TypePaiementDetail");
            HasKey(x => x.TypePaiementDetailId);
            

  
     HasOptional<GEN_TypePaiement>(a => a.GEN_TypePaiement)
                                          .WithMany(d => d.GEN_TypePaiementDetail)
                                          .HasForeignKey<long?>(a => a.IdTypePaiement);
     //HasOptional<GEN_Items>(a => a.GEN_Items_ModePaiement)
     //                                     .WithMany(d => d.GEN_TypePaiementDetail)
     //                                     .HasForeignKey<long?>(a => a.IdModePaiement);
     //HasOptional<GEN_Items>(a => a.GEN_Items_DateCalcul)
     //                                     .WithMany(d => d.GEN_TypePaiementDetail1)
     //                                     .HasForeignKey<long?>(a => a.DateCalcul);
                                        
     //       HasOptional<GEN_Items>(a => a.GEN_Items_Delai)
     //                                     .WithMany(d => d.GEN_TypePaiementDetail2)
     //                                     .HasForeignKey<long?>(a => a.Delai);
        



    }
    }
}
