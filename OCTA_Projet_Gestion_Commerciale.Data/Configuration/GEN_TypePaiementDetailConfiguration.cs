
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


            /***********************************/
    //public virtual GEN_Items GEN_Items_ModePaiement { get; set; }

    //    public virtual GEN_Items GEN_Items_DateCalcul { get; set; }

    //    public virtual GEN_Items GEN_Items_Delai { get; set; }

    //    public virtual GEN_TypePaiement GEN_TypePaiement { get; set; }

  
                    HasOptional<GEN_TypePaiement>(a => a.GEN_TypePaiement)
                                          .WithMany(d => d.GEN_TypePaiementDetail)
                                          .HasForeignKey<long?>(a => a.IdTypePaiement);

                  
      
    }
    }
}
