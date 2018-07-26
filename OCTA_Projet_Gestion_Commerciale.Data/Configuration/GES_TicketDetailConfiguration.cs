
using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Configuration
{
    class GES_TicketDetailConfiguration : EntityTypeConfiguration<GES_TicketDetail>
    {
        public GES_TicketDetailConfiguration()
        {
            ToTable("GES_TicketDetail");
            HasKey(x => x.TicketDetailId);


            /***********************************/

        //virtual public GEN_Tiers TicketDetailFichetier { get; set; }
        //virtual public GES_Ticket TicketDetailTicket { get; set; }

        HasOptional<GEN_Tiers>(a => a.TicketDetailFichetier)
                              .WithMany(d => d.GES_TicketDetail)
                              .HasForeignKey<long?>(a => a.TicketDetailIdcommercial);

            HasOptional<GEN_TiersContact>(a => a.TicketDetailTicket)
                                  .WithMany(d => d.GES_TicketDetail)
                                  .HasForeignKey<long?>(a => a.TicketDetailIdTicket);

        }
    }
}
