
using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Repositories
{
    public interface ICodesTvaRepository : IRepository<CPT_CodesTVA>
    {

    }


    public class CodesTvaRepository : RepositoryBase<CPT_CodesTVA>, ICodesTvaRepository
    {
        public CodesTvaRepository(IDbFactory dbFactory) : base(dbFactory) { }


    }
}
