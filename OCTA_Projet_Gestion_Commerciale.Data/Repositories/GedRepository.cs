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
public class GedRepository : RepositoryBase<GES_Ged>, IGedRepository
    {
        public GedRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

      

        public IEnumerable<GES_Ged> GetItemsByModelLibelle(string identifged)
        {
            var geds = this.DbContext.Geds.Where(c => c.GedEntiteName == identifged);

            return geds;
        }

        public GES_Ged GeGedtById(long id)
        {
            var geds = this.DbContext.Geds.Where(c => c.GedId== id).SingleOrDefault();

            return geds;
        }

        public void Update(object idSource, GES_Ged entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(object idSource, GES_Ged entity)
        {
            throw new NotImplementedException();
        }

        public GES_Ged GetById(long id)
        {
            throw new NotImplementedException();
        }
    }

    public interface IGedRepository : IRepository<GES_Ged>
    {
        
         GES_Ged GeGedtById(long id);
        IEnumerable<GES_Ged> GetItemsByModelLibelle(string identifged);


    }
}
