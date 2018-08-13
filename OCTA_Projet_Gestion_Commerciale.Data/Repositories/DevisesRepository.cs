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
    public class DevisesRepository : RepositoryBase<GEN_Devises>, IDevisesRepository
    {
        public DevisesRepository(IDbFactory dbFactory) : base(dbFactory) { }

        public IEnumerable<GEN_Devises> GetDevisesByIDDossierAndActif()
        {
            var dossier = this.DbContext.Devises.Where(e => e.DevisesIdDossier == Constantes.CurrentPreferenceIdDossier && e.DevisesActif);
            return dossier;
        }
    }
    public interface IDevisesRepository : IRepository<GEN_Devises>
    {
        IEnumerable<GEN_Devises> GetDevisesByIDDossierAndActif();
    }




}
