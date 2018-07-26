using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Configuration
{
    public class GES_DepotConfiguration : EntityTypeConfiguration<GES_Depot>
    {
        public GES_DepotConfiguration()
        {
            ToTable("GES_Depot");
            HasKey(a => a.DepotId);
            HasOptional<GEN_Dossiers>(a => a.DepotSociete)
.WithMany(d => d.SocieteDepot)
.HasForeignKey<long?>(a => a.DepotSocieteId);


    }
    }
}
