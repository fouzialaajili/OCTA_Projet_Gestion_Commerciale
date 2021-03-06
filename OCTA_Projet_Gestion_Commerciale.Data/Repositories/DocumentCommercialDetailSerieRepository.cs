﻿
using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Repositories
{
   
    public interface IDocumentCommercialDetailSerieRepository : IRepository<GES_DocumentCommercialDetailSerie>
    {

    }


    public class DocumentCommercialDetailSerieRepository : RepositoryBase<GES_DocumentCommercialDetailSerie>, IDocumentCommercialDetailSerieRepository
    {
        public DocumentCommercialDetailSerieRepository(IDbFactory dbFactory) : base(dbFactory) { }

        public void Delete(object idSource, GES_DocumentCommercialDetailSerie entity)
        {
            throw new NotImplementedException();
        }

        public GES_DocumentCommercialDetailSerie GetById(long id)
        {
            throw new NotImplementedException();
        }

        public void Update(object idSource, GES_DocumentCommercialDetailSerie entity)
        {
            throw new NotImplementedException();
        }
    }
}
