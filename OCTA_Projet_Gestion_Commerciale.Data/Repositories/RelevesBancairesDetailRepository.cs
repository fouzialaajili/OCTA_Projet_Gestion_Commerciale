﻿using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Repositories
{
  public  class RelevesBancairesDetailRepository : RepositoryBase<CPT_RelevesBancairesDetail>, IRelevesBancairesDetailRepository
    {
        public RelevesBancairesDetailRepository(IDbFactory dbFactory) : base(dbFactory) { }
    }



    public interface IRelevesBancairesDetailRepository : IRepository<CPT_RelevesBancairesDetail>
    {



    }
}



