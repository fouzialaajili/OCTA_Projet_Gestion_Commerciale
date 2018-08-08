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

        public IEnumerable<GEN_Devises> AdeviseByCond()
        {
            var devises= this.DbContext.Devises.Where(e => e.DevisesIdDossier ==Constantes.IdentifiantDossier && e.DevisesActif).ToList();
            return devises;
        }

        public void Disposing()
        {
            this.DbContext.Dispose();
        }

        public IEnumerable<GEN_Devises> GetDevising()
        {
           var fat= from b in this.DbContext.Devises where b.DevisesIdDossier ==Constantes.IdentifiantDossier && b.DevisesTenueDeCompte == 1 select b;
            return fat;
        }

        public GEN_Devises GetingAttribute(GEN_Devises gEN_Devises)
        {
            gEN_Devises.DevisesIdDossier =Constantes.IdentifiantDossier;
            gEN_Devises.Devisessys_dateCreation = DateTime.Now;
            gEN_Devises.Devisessys_dateUpdate = DateTime.Now;
            gEN_Devises.Devisessys_user = Constantes.IdentifiantUser;
            return gEN_Devises;
        }
    }
    public interface IDevisesRepository : IRepository<GEN_Devises>
    {
        void Disposing();
        GEN_Devises GetingAttribute(GEN_Devises devise);
        IEnumerable<GEN_Devises> GetDevising();
        IEnumerable<GEN_Devises> AdeviseByCond();
    }




}
