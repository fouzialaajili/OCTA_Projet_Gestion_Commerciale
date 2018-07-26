using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Repositories
{
   
    public interface IDoclieRepository : IRepository<GES_Doclie>
    {

    }


    public class DoclieRepository : RepositoryBase<GES_Doclie>, IDoclieRepository
    {
        public DoclieRepository(IDbFactory dbFactory) : base(dbFactory) { }


    }
}
