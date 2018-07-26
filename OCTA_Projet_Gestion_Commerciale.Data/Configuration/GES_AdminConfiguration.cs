using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Configuration
{
    public class GES_AdminConfiguration : EntityTypeConfiguration<GES_Admin>
    {
      public GES_AdminConfiguration() {
           ToTable("GES_Admin");
            HasKey(a => a.AdminId);
           
     
    }
    }
}
