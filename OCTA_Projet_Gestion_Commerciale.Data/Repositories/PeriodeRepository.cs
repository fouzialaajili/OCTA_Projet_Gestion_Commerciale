
using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Repositoriess
{
  public  class PeriodeRepository : RepositoryBase<GES_Periode>, IPeriodeRepository
    {
        public PeriodeRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

      
        public GES_Periode GetById(long id)
        {
            var peroides = this.DbContext.Periodes.Where(c => c.PeriodeId == id).SingleOrDefault();

            return peroides;
        }

        public IEnumerable<GES_Periode> GetItemsByModelLibelle(string identifged)
        {
            var Periodes = this.DbContext.Periodes.Where(c => c.PeriodeLibelle == identifged);

            return Periodes;
        }
    }

    public interface IPeriodeRepository : IRepository<GES_Periode>
    {
    

        GES_Periode GetById(long id);
      IEnumerable<GES_Periode> GetItemsByModelLibelle(string identifged);
    }
}
