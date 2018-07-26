
using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Configuration
{
    class GES_TicketConfiguration : EntityTypeConfiguration<GES_Ticket>
    {
        public GES_TicketConfiguration()
        {
            ToTable("GES_Ticket");
            HasKey(x => x.TicketId);


            /***********************************/
        // virtual public GEN_Tiers TicketFichetier { get; set; }
        //virtual public GES_Representant TicketRepresentant { get; set; }
        //virtual public GEN_TiersContacts TicketFichetiersContact { get; set; }
        //virtual public GEN_Dossiers TicketDossier { get; set; }




        HasOptional<GEN_Dossiers>(a => a.TicketDossier)
                              .WithMany(d => d.GES_Ticket)
                              .HasForeignKey<long?>(a => a.TicketDossierId);

            HasOptional<GEN_Tiers>(a => a.TicketFichetier)
                      .WithMany(d => d.GES_Ticket)
                      .HasForeignKey<long?>(a => a.TicketIdClient);

            HasOptional<GES_Representant>(a => a.TicketRepresentant)
                      .WithMany(d => d.RepresentantTicket)
                      .HasForeignKey<long?>(a => a.TicketIdRepresentant);

            HasOptional<GEN_TiersContacts>(a => a.TicketFichetiersContact)
                      .WithMany(d => d.GES_Ticket)
                      .HasForeignKey<long?>(a => a.TicketIdcontact);

        }
    }
}
