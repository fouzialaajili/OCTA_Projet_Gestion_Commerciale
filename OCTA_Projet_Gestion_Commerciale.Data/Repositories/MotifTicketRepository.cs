
using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Repositories
{
 public   class MotifTicketRepository : RepositoryBase<GES_MotifTicket>, IMotifTicketRepository
    {
        public MotifTicketRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

      

        public GES_MotifTicket GetMotifTicketById(long id)
        {
            var motifs = this.DbContext.MotifTickets.Where(c => c.MotifTicketId == id).SingleOrDefault();

            return motifs;
        }

        public IEnumerable<GES_MotifTicket> GetItemsByModelLibelle(string identifged)
        {
            var motifs = this.DbContext.MotifTickets.Where(c => c.MotifTicketDescription == identifged);

            return motifs;
        }

        public void Update(object idSource, GES_MotifTicket entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(object idSource, GES_MotifTicket entity)
        {
            throw new NotImplementedException();
        }

        public GES_MotifTicket GetById(long id)
        {
            throw new NotImplementedException();
        }
    }

    public interface IMotifTicketRepository : IRepository<GES_MotifTicket>
    {
      
        GES_MotifTicket GetMotifTicketById(long id);
        IEnumerable<GES_MotifTicket> GetItemsByModelLibelle(string identifged);

    }
}

