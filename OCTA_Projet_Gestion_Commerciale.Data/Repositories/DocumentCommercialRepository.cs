using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Repositories
{
    
    public interface IDocumentCommercialRepository : IRepository<GES_DocumentCommercial>
    {

    }


    public class DocumentCommercialRepository : RepositoryBase<GES_DocumentCommercial>, IDocumentCommercialRepository
    {
        public DocumentCommercialRepository(IDbFactory dbFactory) : base(dbFactory) { }


    }

}
