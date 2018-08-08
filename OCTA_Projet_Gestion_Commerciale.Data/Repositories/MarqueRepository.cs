
using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Repositories
{
   
    public interface IMarqueRepository : IRepository<GES_Marque>
    {
       
        GES_Marque  GetById(long id);
        IEnumerable<GES_Marque> GetItemsByModelLibelle(string identifged);
    }


    public class MarqueRepository : RepositoryBase<GES_Marque>, IMarqueRepository
    {
        public MarqueRepository(IDbFactory dbFactory) : base(dbFactory) { }

      

        public GES_Marque GetById(long id)
        {
            var marques = this.DbContext.Marques.Where(c => c.Id == id).SingleOrDefault();

            return marques;
        }

        public IEnumerable<GES_Marque> GetItemsByModelLibelle(string identifged)
        {
            var marques = this.DbContext.Marques.Where(c => c.MarqueCode == identifged);

            return marques;
        }
    }
}
