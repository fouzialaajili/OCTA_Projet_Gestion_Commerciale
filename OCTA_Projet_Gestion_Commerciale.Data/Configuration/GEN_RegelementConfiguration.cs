using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Configuration
{
    class GEN_RegelementConfiguration : EntityTypeConfiguration<GEN_Regelement>
    {
        public GEN_RegelementConfiguration()
        {
            ToTable("GEN_Regelement");
            HasKey(x => x.Id);


        //     public virtual CPT_Journaux CPT_Journaux { get; set; }

        //public virtual GEN_TypePaiement GEN_TypePaiement { get; set; }

        /***********************************/


        HasOptional<CPT_Journaux>(a => a.CPT_Journaux)
                                                  .WithMany(d => d.GEN_Regelement)
                                                  .HasForeignKey<long?>(a => a.IdJournal);


            HasOptional<GEN_TypePaiement>(a => a.GEN_TypePaiement)
                                                  .WithMany(d => d.GEN_Regelement)
                                                  .HasForeignKey<long?>(a => a.IdModePaiement);

        }
    }
}
