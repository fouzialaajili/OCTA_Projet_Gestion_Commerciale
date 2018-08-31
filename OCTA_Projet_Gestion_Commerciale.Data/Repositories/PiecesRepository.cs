using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Repositories
{
   public class PiecesRepository : RepositoryBase<CPT_Pieces>, IPiecesRepository
    {
        public PiecesRepository(IDbFactory dbFactory) : base(dbFactory) { }
    }



    public interface IPiecesRepository : IRepository<CPT_Pieces>
    {



    }
}



