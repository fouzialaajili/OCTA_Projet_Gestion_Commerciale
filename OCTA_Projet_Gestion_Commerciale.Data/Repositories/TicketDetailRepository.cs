
using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Repositories
{
  public  class TicketDetailRepository : RepositoryBase<GES_TicketDetail>, ITicketDetailRepository
    {
        public TicketDetailRepository(IDbFactory dbFactory)
            : base(dbFactory) { }


        public GES_TicketDetail GetTicketDetailById(long id)
        {
            var objetifs = this.DbContext.TicketDetails.Where(c => c.TicketDetailId == id).SingleOrDefault();

            return objetifs;
        }

        public IEnumerable<GES_TicketDetail> GetItemsByModelLibelle(string identifged)
        {
            var objetifs = this.DbContext.TicketDetails.Where(c => c.TicketDetailDescription == identifged);

            return objetifs;
        }
    }

    public interface ITicketDetailRepository : IRepository<GES_TicketDetail>
    {
     
        GES_TicketDetail GetTicketDetailById(long id);
        IEnumerable<GES_TicketDetail> GetItemsByModelLibelle(string identifged);
    }
}
