
using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Repositories
{
  
    public interface IDocumentCommercialDetailRepository : IRepository<GES_DocumentCommercialDetail>
    {

    }


    public class DocumentCommercialDetailRepository : RepositoryBase<GES_DocumentCommercialDetail>, IDocumentCommercialDetailRepository
    {
        public DocumentCommercialDetailRepository(IDbFactory dbFactory) : base(dbFactory) { }

        public void Delete(object idSource, GES_DocumentCommercialDetail entity)
        {
            throw new NotImplementedException();
        }

        public GES_DocumentCommercialDetail GetById(long id)
        {
            throw new NotImplementedException();
        }

        public void Update(object idSource, GES_DocumentCommercialDetail entity)
        {
            throw new NotImplementedException();
        }
    }
}
