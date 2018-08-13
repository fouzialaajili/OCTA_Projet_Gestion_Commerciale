
using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Repositories
{
  public  class CPT_ParametrageComptableRepository : RepositoryBase<CPT_ParametrageComptable>, ICPT_ParametrageComptableRepository
    {
        public CPT_ParametrageComptableRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public void Delete(object idSource, CPT_ParametrageComptable entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CPT_ParametrageComptable> GetALL()
        {
            return this.DbContext.ParametrageComptables.ToList();
        }

        public CPT_ParametrageComptable GetById(long id)
        {
            var _ParametrageComptable = this.DbContext.ParametrageComptables.Where(c => c.Id == id).SingleOrDefault();

            return _ParametrageComptable;
        }

        public CPT_ParametrageComptable GetCPT_ParametrageComptableById(long id)
        {
            throw new NotImplementedException();
        }

        // public CPT_ParametrageComptable GetParametrageComptablById(long id)

        /* public CPT_ParametrageComptable GetById(long id)
         {

         }*/

        public IEnumerable<CPT_ParametrageComptable> GetItemsByModelLibelle(string identifged)
        {

            var _CPT_ParametrageComptable = this.DbContext.ParametrageComptables.Where(c => c.LibelleEcritureANouveau == identifged);

            return _CPT_ParametrageComptable;

           
        }

        public CPT_ParametrageComptable GetParametrageComptablById(long id)
        {
            var _ParametrageComptable = this.DbContext.ParametrageComptables.Where(c => c.Id == id).SingleOrDefault();

            return _ParametrageComptable;
        }

        public void Update(object idSource, CPT_ParametrageComptable entity)
        {
            throw new NotImplementedException();
        }
    }

    public interface ICPT_ParametrageComptableRepository : IRepository<CPT_ParametrageComptable>
    {
        IEnumerable<CPT_ParametrageComptable> GetALL();
        CPT_ParametrageComptable GetParametrageComptablById(long id);
       
        CPT_ParametrageComptable GetCPT_ParametrageComptableById(long id);
        IEnumerable<CPT_ParametrageComptable> GetItemsByModelLibelle(string identifged);
    }
}
