using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Configuration
{
    public class CPT_PiecesConfiguration : EntityTypeConfiguration<CPT_Pieces>
    {
        public CPT_PiecesConfiguration()
        {
            ToTable("CPT_Pieces");
            HasKey(x => x.Id);
            HasOptional<CPT_Journaux>(a => a.CPT_Journaux)
                                                   .WithMany(d => d.CPT_Pieces)
                                                   .HasForeignKey<long?>(a => a.IdJournal);
            HasOptional<GEN_Tiers>(a => a.GEN_Tiers)
                                                   .WithMany(d => d.CPT_Pieces)
                                                   .HasForeignKey<long?>(a => a.IdTiers);
            HasOptional<GEN_Devises>(a => a.GEN_DevisesTR)
                                       .WithMany(d => d.CPT_Pieces_TR)
                                       .HasForeignKey<long?>(a => a.IdDeviseTR);
            HasOptional<GEN_Devises>(a => a.GEN_DevisesTC)
                                      .WithMany(d => d.CPT_Pieces_TC)
                                      .HasForeignKey<long?>(a => a.IdDeviseTC);
            HasOptional<GEN_DossiersSites>(a => a.GEN_DossiersSites)
                                     .WithMany(d => d.CPT_Pieces)
                                     .HasForeignKey<long?>(a => a.IdDossierSite);
            HasOptional<GEN_Dossiers>(a => a.GEN_Dossiers)
                          .WithMany(d => d.CPT_Pieces)
                          .HasForeignKey<long?>(a => a.IdDossier);



        }
    }
}
