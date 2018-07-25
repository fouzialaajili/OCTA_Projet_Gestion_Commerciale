using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Configuration
{
    class GEN_DossiersSitesConfiguration:EntityTypeConfiguration<GEN_DossiersSites>
    {


        // public virtual GEN_Dossiers GEN_Dossiers { get; set; }


        public GEN_DossiersSitesConfiguration()
        {
            ToTable("GEN_DossiersSites");
            HasKey(a => a.Id);


            HasOptional<GEN_Dossiers>(a => a.GEN_Dossiers)
         .WithMany(d => d.GEN_DossiersSites)
       .HasForeignKey<long?>(a => a.IdDossier);


           


        }

    }
}
