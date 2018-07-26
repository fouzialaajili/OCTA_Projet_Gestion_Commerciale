
using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Repositories
{
    class CPT_ParametrageComptableRepository : RepositoryBase<CPT_ParametrageComptable>, ICPT_ParametrageComptableRepository
    {
        public CPT_ParametrageComptableRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public IEnumerable<CPT_ParametrageComptable> GetALL()
        {
            return DbContext.ParametrageComptables.ToList();
        }

        public CPT_ParametrageComptable GetById(long id)
        {
            var _ParametrageComptable = this.DbContext.ParametrageComptables.Where(c => c.CPT_ParametrageComptableId == id).SingleOrDefault();

            return _ParametrageComptable;
        }

        public IEnumerable<CPT_ParametrageComptable> GetItemsByModelLibelle(string identifged)
        {

            var _CPT_ParametrageComptable = this.DbContext.ParametrageComptables.Where(c => c.LibelleEcritureANouveau == identifged);

            return _CPT_ParametrageComptable;

           
        }
    }

    public interface ICPT_ParametrageComptableRepository : IRepository<CPT_ParametrageComptable>
    {
        IEnumerable<CPT_ParametrageComptable> GetALL();
        CPT_ParametrageComptable GetById(long id);
        IEnumerable<CPT_ParametrageComptable> GetItemsByModelLibelle(string identifged);
    }
}
