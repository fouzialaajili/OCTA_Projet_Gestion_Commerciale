
using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Configuration
{
    public class GEN_TiersContactsConfiguration: EntityTypeConfiguration<GEN_TiersContacts>
    {
        public GEN_TiersContactsConfiguration()
        {
            ToTable("tiersContact");
            HasKey(x => x.GEN_TiersContactsId);


            /***********************************/

            //     public virtual GEN_Tiers GEN_Tiers { get; set; }


            HasOptional<GEN_Tiers>(a => a.GEN_Tiers)
                    .WithMany(d => d.GEN_TiersContacts)
                    .HasForeignKey<long?>(a => a.IdTiers);
        }
           

        }
    }
