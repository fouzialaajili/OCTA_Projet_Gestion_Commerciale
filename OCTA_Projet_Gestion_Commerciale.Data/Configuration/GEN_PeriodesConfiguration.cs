using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Configuration
{
    class GEN_PeriodesConfiguration : EntityTypeConfiguration<GEN_Periodes>
    {
        public GEN_PeriodesConfiguration()
        {
            ToTable(" GEN_Periode");
            HasKey(x => x.Id);


            /***********************************/
            //   public virtual GEN_Exercices GEN_Exercices { get; set; }

            HasOptional<GEN_Exercices>(a => a.GEN_Exercices)
                                              .WithMany(d => d.GEN_Periodes)
                                              .HasForeignKey<long?>(a => a.IdExercice);

             
        }
    }
}
