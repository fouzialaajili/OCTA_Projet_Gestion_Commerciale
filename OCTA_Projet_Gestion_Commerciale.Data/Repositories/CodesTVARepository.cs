
using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Repositories
{
    public interface ICodesTVARepository : IRepository<CPT_CodesTVA>
    {

    }


    public class CodesTVARepository : RepositoryBase<CPT_CodesTVA>, ICodesTVARepository
    {
        public CodesTVARepository(IDbFactory dbFactory) : base(dbFactory) { }

        public void Delete(object idSource, CPT_CodesTVA entity)
        {
            throw new NotImplementedException();
        }

        public CPT_CodesTVA GetById(long id)
        {
            throw new NotImplementedException();
        }

        public void Update(object idSource, CPT_CodesTVA entity)
        {
            throw new NotImplementedException();
        }
    }
}
