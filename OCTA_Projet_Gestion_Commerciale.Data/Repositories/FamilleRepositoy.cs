
using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Repositories
{
   

    public interface IFamilleRepositoy : IRepository<GES_Famille>
    {

    }


    public class FamilleRepositoy : RepositoryBase<GES_Famille>, IFamilleRepositoy
    {
        public FamilleRepositoy(IDbFactory dbFactory) : base(dbFactory) { }

        public void Delete(object idSource, GES_Famille entity)
        {
            throw new NotImplementedException();
        }

        public GES_Famille GetById(long id)
        {
            throw new NotImplementedException();
        }

        public void Update(object idSource, GES_Famille entity)
        {
            throw new NotImplementedException();
        }
    }
}
