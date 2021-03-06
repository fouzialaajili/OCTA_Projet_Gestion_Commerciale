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
  public  class OpportuniteDetailRepository : RepositoryBase<GES_OpportuniteDetail>, IOpportuniteDetailRepository
    {
        public OpportuniteDetailRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public void Delete(object idSource, GES_OpportuniteDetail entity)
        {
            throw new NotImplementedException();
        }

        public GES_OpportuniteDetail GetById(long id)
        {
            throw new NotImplementedException();
        }

        public void Update(object idSource, GES_OpportuniteDetail entity)
        {
            throw new NotImplementedException();
        }
    }

    public interface IOpportuniteDetailRepository : IRepository<GES_OpportuniteDetail>
    {

    }
}
