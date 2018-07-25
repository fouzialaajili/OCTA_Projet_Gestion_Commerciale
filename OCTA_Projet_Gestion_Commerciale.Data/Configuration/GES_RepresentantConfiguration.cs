
using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Configuration
{
    class GES_RepresentantConfiguration : EntityTypeConfiguration<GES_Representant>
    {
        public GES_RepresentantConfiguration()
        {
            ToTable("Representant");
            HasKey(x => x.RepresentantId);


            /***********************************/
      
        //virtual public GEN_Dossiers RepresentantDossier { get; set; }



        HasOptional<GEN_Dossiers>(a => a.RepresentantDossier)
                    .WithMany(d => d.GES_Representant)
                    .HasForeignKey<long?>(a => a.RepresentantDossierId);



        }
    }
}
