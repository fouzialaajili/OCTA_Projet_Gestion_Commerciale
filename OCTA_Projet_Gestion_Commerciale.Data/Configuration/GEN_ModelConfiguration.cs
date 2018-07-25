using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Configuration
{
    class GEN_ModelConfiguration : EntityTypeConfiguration<GEN_Model>
    {
        public GEN_ModelConfiguration()
        {
            ToTable("GEN_Model");
            HasKey(x => x.Id);




        }
    }
}
