using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Configuration
{
    public class CPT_EcrituresConfiguration : EntityTypeConfiguration<CPT_Ecritures>
    {
        public CPT_EcrituresConfiguration()
        {
            ToTable("CPT_Ecritures");
            HasKey(x => x.Id);
            HasOptional<CPT_CompteG>(a => a.CPT_CompteG)
       .WithMany(d => d.CPT_Ecritures)
        .HasForeignKey<long?>(a => a.IdCompteG);
            HasOptional<CPT_Pieces>(a => a.CPT_Pieces)
     .WithMany(d => d.CPT_Ecritures)
      .HasForeignKey<long?>(a => a.IdPiece);
            HasOptional<GEN_Devises>(a => a.GEN_Devises_TC)
.WithMany(d => d.CPT_Ecritures_TC)
.HasForeignKey<long?>(a => a.IdDeviceTC);
            HasOptional<GEN_Devises>(a => a.GEN_Devises_TR)
.WithMany(d => d.CPT_Ecritures_TR)
.HasForeignKey<long?>(a => a.IdDeviceTR);
            HasOptional<GEN_DossiersSites>(a => a.GEN_DossiersSites)
.WithMany(d => d.CPT_Ecritures)
.HasForeignKey<long?>(a => a.IdDossierSite);
            HasOptional<GEN_Tiers>(a => a.GEN_Tiers)
.WithMany(d => d.CPT_Ecritures)
.HasForeignKey<long?>(a => a.IdDossierSite);



        }
    }
}
