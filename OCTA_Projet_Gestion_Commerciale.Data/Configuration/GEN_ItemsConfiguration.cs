using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Configuration
{
    class GEN_ItemsConfiguration : EntityTypeConfiguration<GEN_Items>
    {
        public GEN_ItemsConfiguration()
        {
            ToTable("GEN_Items");
            HasKey(x => x.Id);


           

        }
    }
}
