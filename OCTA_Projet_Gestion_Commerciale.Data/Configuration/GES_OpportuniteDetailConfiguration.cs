
using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Configuration
{
    class GES_OpportuniteDetailConfiguration : EntityTypeConfiguration<GES_OpportuniteDetail>
    {
        public GES_OpportuniteDetailConfiguration()
        {
            ToTable("GES_OpportuniteDetail");
            HasKey(x => x.OpportuniteDetailId);


            /***********************************/

        // virtual public GEN_Tiers OpportuniteDetailFichetier { get; set; }
        //virtual public GES_Opportunite OpportuniteDetailOpportunite { get; set; }

        HasOptional<GEN_Tiers>(a => a.OpportuniteDetailFichetier)
                                  .WithMany(d => d.GES_OpportuniteDetail)
                                  .HasForeignKey<long?>(a => a.OpportuniteDetailIdcommercial);

            HasOptional<GES_Opportunite>(a => a.OpportuniteDetailOpportunite)
                                  .WithMany(d => d.OpportuniteOpportuniteDetail)
                                  .HasForeignKey<long?>(a => a.OpportuniteDetailIdopportunite);

        }
    }
}
