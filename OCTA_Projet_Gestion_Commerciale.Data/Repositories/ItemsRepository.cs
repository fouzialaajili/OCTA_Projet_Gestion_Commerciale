using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Repositories
{
   public class ItemsRepository : RepositoryBase<GEN_Items>, IItemsRepository
    {
        public ItemsRepository(IDbFactory dbFactory) : base(dbFactory) { }


    }



    public interface IItemsRepository : IRepository<GEN_Items>
    {

    }

}



