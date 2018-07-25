using OCTA_Projet_Gestion_Commerciale.Model;

using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Configuration
{
    class GES_NumerotationConfiguration : EntityTypeConfiguration<GES_Numerotation>
    {
        public GES_NumerotationConfiguration()
        {
            ToTable("Numerotation");
            HasKey(x => x.NumerotationId);


            /***********************************/
            //  virtual public GEN_Dossiers NumerotationDossier { get; set; }



            HasOptional<GEN_Dossiers>(a => a.NumerotationDossier)
                      .WithMany(d => d.GES_Numerotation)
                      .HasForeignKey<long?>(a => a.NumerotationDossierId);
        }
    }
}
