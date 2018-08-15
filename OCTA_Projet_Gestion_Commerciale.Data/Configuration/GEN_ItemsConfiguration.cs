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
       
     //       ToTable("GEN_Items");
     //       HasKey(x => x.Id);

            //       HasOptional<GEN_Model>(a => a.GEN_Model)
            //  .WithMany(d => d.GEN_Items)
            //.HasForeignKey<long?>(a => a.IdModel);

        public GEN_ItemsConfiguration()
        {
            ToTable("GEN_Items");
            HasKey(x => x.Id);

            HasOptional<GEN_Model>(a => a.GEN_Model)
       .WithMany(d => d.GEN_Items)
     .HasForeignKey<long?>(a => a.IdModel);



        }
    }
}
