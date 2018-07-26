
using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Repositories
{
    class ReglementRepository : RepositoryBase<GES_Reglement>, IReglementRepository
    {
        public ReglementRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

     

        public GES_Reglement GetById(long id)
        {

            var peroides = this.DbContext.Reglements.Where(c => c.ReglementId == id).SingleOrDefault();

            return peroides;
        }

        public IEnumerable<GES_Reglement> GetItemsByModelLibelle(string identifged)
        {
            var Periodes = this.DbContext.Reglements.Where(c => c.ReglementLibelle== identifged);

            return Periodes;
        }
    }

    public interface IReglementRepository : IRepository<GES_Reglement>
    {
       
        GES_Reglement GetById(long id);
        IEnumerable<GES_Reglement> GetItemsByModelLibelle(string identifged);

    }
}
