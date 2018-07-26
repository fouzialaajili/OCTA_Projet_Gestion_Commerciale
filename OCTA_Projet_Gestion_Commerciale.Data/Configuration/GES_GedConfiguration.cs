
using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Configuration
{
    public class GES_GedConfiguration : EntityTypeConfiguration<GES_Ged>
    {
        public GES_GedConfiguration()
        {
            ToTable("GES_Ged");
            HasKey(x => x.GedId);
           
        }
    }
}
