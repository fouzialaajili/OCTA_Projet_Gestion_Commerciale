
using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Configuration
{
    class GES_ObjectifConfiguration : EntityTypeConfiguration<GES_Objectif>
    {
        public GES_ObjectifConfiguration()
        {
            ToTable("Objectif");
            HasKey(x => x.ObjectifId);


            /***********************************/
        // virtual public GEN_Dossiers ObjectifDossier { get; set; }
        //virtual public GES_Representant ObjectifRepresentant { get; set; }




        HasOptional<GEN_Dossiers>(a => a.ObjectifDossier)
                      .WithMany(d => d.GES_Objectif)
                      .HasForeignKey<long?>(a => a.ObjectifDossierId);

            HasOptional<GES_Representant>(a => a.ObjectifRepresentant)
                          .WithMany(d => d.RepresentantObject)
                          .HasForeignKey<long?>(a => a.ObjectifRepresentantId);
        }
    }
}
