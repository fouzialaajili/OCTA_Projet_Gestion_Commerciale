using OCTA_Projet_Gestion_Commerciale.Model;

using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Configuration
{
  public   class CPT_ParametrageComptableConfiguration : EntityTypeConfiguration<CPT_ParametrageComptable>
    {
        public CPT_ParametrageComptableConfiguration()
        {
            ToTable("CPT_ParametrageComptable");
            HasKey(x => x.Id);


        HasOptional<GEN_Dossiers>(a => a.GEN_Dossiers)
                                  .WithMany(d => d.CPT_ParametrageComptable)
                                  .HasForeignKey<long?>(a => a.IdDossier);


            HasOptional<CPT_Journaux>(a => a.CPT_Journaux)
                                      .WithMany(d => d.CPT_ParametrageComptable)
                                      .HasForeignKey<long?>(a => a.IdJournalANouveaux);

            HasOptional<CPT_CompteG>(a => a.CPT_CompteG)
                                      .WithMany(d => d.CPT_ParametrageComptable_CompteBenfice)
                                      .HasForeignKey<long?>(a => a.IdCompteBenefice);

            HasOptional<CPT_CompteG>(a => a.CPT_CompteG_CompteDeficit)
                                      .WithMany(d => d.CPT_ParametrageComptable_CompteDeficit)
                                      .HasForeignKey<long?>(a => a.IdCompteDeficit);
        }
    }
}
