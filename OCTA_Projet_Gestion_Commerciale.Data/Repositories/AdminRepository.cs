using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;



namespace OCTA_Projet_Gestion_Commerciale.Data.Repositories
{
    public interface IAdminRepository:IRepository<GES_Admin>
    {

    }



   public class AdminRepository : RepositoryBase<GES_Admin>, IAdminRepository
    {
        public AdminRepository(IDbFactory dbFactory):base(dbFactory) { }

        public void Delete(object idSource, GES_Admin entity)
        {
            throw new NotImplementedException();
        }

        public GES_Admin GetById(long id)
        {
            throw new NotImplementedException();
        }

        public void Update(object idSource, GES_Admin entity)
        {
            throw new NotImplementedException();
        }
    }

  
   
}
