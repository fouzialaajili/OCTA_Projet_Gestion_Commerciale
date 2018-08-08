
using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Repositories
{
 public   class TicketRepository : RepositoryBase<GES_Ticket>, ITicketRepository
    {
        public TicketRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

      

        public GES_Ticket GetById(long id)
        {
            var objetifs = this.DbContext.Tickets.Where(c => c.TicketId== id).SingleOrDefault();

            return objetifs;
        }

        public IEnumerable<GES_Ticket> GetItemsByModelLibelle(string identifged)
        {
            var objetifs = this.DbContext.Tickets.Where(c => c.TicketStatut == identifged);

            return objetifs;
        }
    }

    public interface ITicketRepository : IRepository<GES_Ticket>
    {

        GES_Ticket GetById(long id);
        IEnumerable<GES_Ticket> GetItemsByModelLibelle(string identifged);
    }
}
