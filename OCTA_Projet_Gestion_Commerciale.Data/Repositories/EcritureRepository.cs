using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Data.Utils;
using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Repositories
{
    public interface IEcritureRepository : IRepository<CPT_Ecritures>
    {
        IEnumerable<CPT_Ecritures> GetEcrituresByIdDossiersAndByIdTiers(GEN_Tiers gEN_Tiers);

    }

    public class EcritureRepository : RepositoryBase<CPT_Ecritures>, IEcritureRepository
    {
        public EcritureRepository(IDbFactory dbFactory) : base(dbFactory) { }

       
        public IEnumerable<CPT_Ecritures> GetEcrituresByIdDossiersAndByIdTiers(GEN_Tiers gEN_Tiers)
        {
            var test = this.DbContext.Ecritures.Where(e => e.IdDossier == Constantes.CurrentPreferenceIdDossier && e.IdTiers == gEN_Tiers.TypeTiers);
            return test;
        }

       
    }
}
