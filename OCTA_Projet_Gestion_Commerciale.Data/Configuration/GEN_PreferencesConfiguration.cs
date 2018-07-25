using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Configuration
{
    class GEN_PreferencesConfiguration : EntityTypeConfiguration<GEN_Preferences>
    {
        public GEN_PreferencesConfiguration()
        {
            ToTable("GEN_Preference");
            HasKey(x => x.Id);


        //     public virtual GEN_Dossiers GEN_Dossiers { get; set; }

        //public virtual GEN_Exercices GEN_Exercices { get; set; }

        /***********************************/


        HasOptional<GEN_Dossiers>(a => a.GEN_Dossiers)
                                              .WithMany(d => d.GEN_Preferences)
                                              .HasForeignKey<long?>(a => a.IdDossier);


            HasOptional<GEN_Exercices>(a => a.GEN_Exercices)
                                                  .WithMany(d => d.GEN_Preferences)
                                                  .HasForeignKey<long?>(a => a.IdExercices);

        }
    }
}
