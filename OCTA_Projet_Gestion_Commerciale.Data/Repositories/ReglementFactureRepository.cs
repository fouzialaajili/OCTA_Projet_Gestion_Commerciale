
using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Repositories
{
    class ReglementFactureRepository : RepositoryBase<GES_ReglementFacture>, IReglementFactureRepository
    {
        public ReglementFactureRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

   

        public GES_ReglementFacture GetById(long id)
        {
            var impressions = this.DbContext.ReglementFactures.Where(c => c.ReglementFactureId == id).SingleOrDefault();

            return impressions;
        }

        public IEnumerable<GES_ReglementFacture> GetItemsByModelLibelle(string identifged)
        {
            throw new NotImplementedException();
        }
    }

    public interface IReglementFactureRepository : IRepository<GES_ReglementFacture>
    {
       
        GES_ReglementFacture GetById(long id);
        IEnumerable<GES_ReglementFacture> GetItemsByModelLibelle(string identifged);
    }
}
