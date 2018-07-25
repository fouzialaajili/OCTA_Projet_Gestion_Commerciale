
using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Configuration
{
    public class GES_MotifConfiguration : EntityTypeConfiguration<GES_Motif>
    {
        public GES_MotifConfiguration()
        {
            ToTable("Motif");
            HasKey(x => x.MotifId);


            /***********************************/

            //  virtual public GES_Opportunite MotifOpportunite { get; set; }

            //  virtual public GEN_Dossiers MotifSociete { get; set; }


            HasOptional<GES_Opportunite>(a => a.MotifOpportunite)
                    .WithMany(d => d.OpportuniteMotif)
                    .HasForeignKey<long?>(a => a.OpportuniteId);

            HasOptional<GEN_Dossiers>(a => a.MotifSociete)
                    .WithMany(d => d.GES_Motif)
                    .HasForeignKey<long?>(a => a.MotifdossierId);

        }
    }
}
