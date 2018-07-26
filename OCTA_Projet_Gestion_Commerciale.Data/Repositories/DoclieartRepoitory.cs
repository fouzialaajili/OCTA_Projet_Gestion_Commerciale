﻿using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Model;
using Store.Data.Infrastructure;
using Store.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Repositories
{
   
    public interface IDoclieartRepository : IRepository<GES_Doclieart>
    {

    }


    public class DoclieartRepository : RepositoryBase<GES_Doclieart>, IDoclieartRepository
    {
        public DoclieartRepository(IDbFactory dbFactory) : base(dbFactory) { }


    }
}
