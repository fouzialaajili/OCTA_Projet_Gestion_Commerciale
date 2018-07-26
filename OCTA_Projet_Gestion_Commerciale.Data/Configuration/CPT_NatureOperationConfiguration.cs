using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Configuration
{
    public class CPT_NatureOperationConfiguration : EntityTypeConfiguration<CPT_NatureOperation>
    {
        public CPT_NatureOperationConfiguration()
        {
            ToTable("CPT_NatureOperation");
            HasKey(x => x.Id);

        }
    }
}
