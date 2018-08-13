using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OCTA_Projet_Gestion_Commerciale.Data.Utils;
namespace OCTA_Projet_Gestion_Commerciale.Data.Repositories
{
    public class DossiersRepository : RepositoryBase<GEN_Dossiers>, IDossiersRepository
    {
        public DossiersRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public IEnumerable<GEN_Dossiers> DossiersByActif(bool actif)
        {

            //this.DbContext.DossierdossParametrageComptables.Where(c => c.LibelleEcritureANouveau == identifged);
           var dossier= this.DbContext.Dossier.Where(e => e.DossierActif ==actif);
               return dossier;
        }

        public IEnumerable<GEN_Dossiers> GetDossiersByDossiersId()
        {
            var dossier = this.DbContext.Dossier.Where(e => e.DossierId==Constantes.CurrentSocieteId);
            return dossier;
        }

        public IEnumerable<GEN_Dossiers> GetDossiersByDossiersIdAndActif()
        {


            var dossier = this.DbContext.Dossier.Where(e => e.DossierId == Constantes.CurrentPreferenceIdDossier && e.DossierActif);
             return dossier;

        }
    }

    public interface IDossiersRepository : IRepository<GEN_Dossiers>
    {
       IEnumerable<GEN_Dossiers> DossiersByActif(bool actif);
        IEnumerable<GEN_Dossiers> GetDossiersByDossiersId();
        IEnumerable<GEN_Dossiers> GetDossiersByDossiersIdAndActif();
    }
}
