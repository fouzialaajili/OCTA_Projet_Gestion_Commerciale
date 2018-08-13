using OCTA_Projet_Gestion_Commerciale.Model;


using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Configuration
{
    public class GEN_TiersConfiguration : EntityTypeConfiguration<GEN_Tiers>
    {
        public GEN_TiersConfiguration()
        {
            ToTable("GEN_Tiers");
            HasKey(x => x.Id);
            HasOptional<GEN_TypePaiement>(a => a.GEN_TypePaiement)
                .WithMany(d => d.GEN_Tiers)
                .HasForeignKey<long?>(a => a.IdEcheancement);

            HasOptional<GEN_Dossiers>(a => a.GEN_Dossiers)
                        .WithMany(d => d.GEN_Tiers)
                        .HasForeignKey<long?>(a => a.IdDossier);


            HasOptional<GEN_Devises>(a => a.GEN_Devises)
                        .WithMany(d => d.GEN_Tiers)
                        .HasForeignKey<long?>(a => a.IdDeviseDefault);


            HasOptional<CPT_CompteG>(a => a.CPT_CompteG_CompteCollectifClient)
                        .WithMany(d => d.GEN_Tiers_CompteCollectifClient)
                        .HasForeignKey<long?>(a => a.IdCompteCollectifClient);


            HasOptional<CPT_CompteG>(a => a.CPT_CompteG_CompteCollectifFournisseur)
                        .WithMany(d => d.GEN_Tiers_CompteCollectifFournisseur)
                        .HasForeignKey<long?>(a => a.IdCompteCollectifFournisseur);



        }
    }
}
