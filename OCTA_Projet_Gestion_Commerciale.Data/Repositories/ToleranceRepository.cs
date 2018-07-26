
using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Repositories
{
   
    public interface IToleranceRepositoy : IRepository<GES_Tolerance>
    {
     
        GES_Tolerance GetById(long id);
        IEnumerable<GES_Tolerance> GetItemsByModelLibelle(string identifged);

    }


    public class ToleranceRepositoy : RepositoryBase<GES_Tolerance>, IToleranceRepositoy
    {
        public ToleranceRepositoy(IDbFactory dbFactory) : base(dbFactory) { }

     

        public GES_Tolerance GetById(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GES_Tolerance> GetItemsByModelLibelle(string identifged)
        {
            throw new NotImplementedException();
        }
    }
}
