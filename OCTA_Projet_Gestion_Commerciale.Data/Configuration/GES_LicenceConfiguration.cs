using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Configuration
{
    public class GES_LicenceConfiguration : EntityTypeConfiguration<GES_Licence>
    {
        public GES_LicenceConfiguration()
        {
            ToTable("Licence");
            HasKey(a => a.LicenceId);


         }
        }
}
