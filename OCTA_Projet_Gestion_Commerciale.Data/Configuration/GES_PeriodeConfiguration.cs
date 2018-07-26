
using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Configuration
{
    class GES_PeriodeConfiguration : EntityTypeConfiguration<GES_Periode>
    {
        public GES_PeriodeConfiguration()
        {
            ToTable("GES_Periode");
            HasKey(x => x.PeriodeId);


            /***********************************/
            //        virtual public GEN_Dossiers PeriodeSociete { get; set; }


            HasOptional<GEN_Dossiers>(a => a.PeriodeSociete)
                            .WithMany(d => d.GES_Periode)
                            .HasForeignKey<long?>(a => a.PeriodeSocieteId);


        }
    }
}
