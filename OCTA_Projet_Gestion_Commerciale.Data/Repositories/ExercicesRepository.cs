using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Repositories
{
    public interface IExercicesRepository : IRepository<GEN_Exercices>
    {

    }
    

    public class ExercicesRepository : RepositoryBase<GEN_Exercices>, IExercicesRepository
    {
        public ExercicesRepository(IDbFactory dbFactory) : base(dbFactory) { }


    }
}
