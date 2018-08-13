
using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Repositories
{
 public   class MotifRepository : RepositoryBase<GES_Motif>, IMotifRepository
    {
        public MotifRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

      

        public GES_Motif GetMotifById(long id)
        {
            var motifs = this.DbContext.Motifs.Where(c => c.MotifId == id).SingleOrDefault();

            return motifs;
        }

        public IEnumerable<GES_Motif> GetItemsByModelLibelle(string identifged)
        {
            var motifs = this.DbContext.Motifs.Where(c => c.MotifDescription == identifged);

            return motifs;
        }
    }

    public interface IMotifRepository : IRepository<GES_Motif>
    {
   
        GES_Motif GetMotifById(long id);
        IEnumerable<GES_Motif> GetItemsByModelLibelle(string identifged);

    }
}

