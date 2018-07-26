
using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Configuration
{
    class GES_OpportuniteConfiguration : EntityTypeConfiguration<GES_Opportunite>
    {
        public GES_OpportuniteConfiguration()
        {
            ToTable("GES_Opportunite");
            HasKey(x => x.OpportuniteId);


            /***********************************/

            //virtual public GEN_Dossiers OpportuniteDossier { get; set; }
            //virtual public GEN_Tiers OpportuniteFichetier { get; set; }
            //virtual public Devise OpportuniteDevise { get; set; }


            HasOptional<GEN_Dossiers>(a => a.OpportuniteDossier)
                                  .WithMany(d => d.GES_Opportunite)
                                  .HasForeignKey<long?>(a => a.OpportuniteDossierd);

            HasOptional<GEN_Tiers>(a => a.OpportuniteFichetier)
                                  .WithMany(d => d.GES_Opportunite)
                                  .HasForeignKey<long?>(a => a.OpportuniteIdtiers);
            HasOptional<GEN_Tiers>(a => a.OpportuniteFichetier)
                                .WithMany(d => d.GES_Opportunite)
                                .HasForeignKey<long?>(a => a.OpportuniteIdcommercial);

            HasOptional<GEN_Devises>(a => a.OpportuniteDevise)
                               .WithMany(d => d.GES_Opportunite)
                               .HasForeignKey<long?>(a => a.OpportuniteIdDevise);

        }
    }
}
