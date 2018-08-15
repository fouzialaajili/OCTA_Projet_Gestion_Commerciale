using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Repositories
{
   
    public interface IClasseRepository : IRepository<CPT_Classe>
    {

    }



    public class ClasseRepository : RepositoryBase<CPT_Classe>, IClasseRepository
    {
        public ClasseRepository(IDbFactory dbFactory) : base(dbFactory) { }


    }






}
