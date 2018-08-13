using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Repositories
{
  
    public interface ILicenceRepository : IRepository<GES_Licence>
    {
       
        GES_Licence GetLicenceById(long id);
        IEnumerable<GES_Licence> GetItemsByModelLibelle(string identifged);
    }


    public class LicenceRepositoy : RepositoryBase<GES_Licence>, ILicenceRepository
    {
        public LicenceRepositoy(IDbFactory dbFactory) : base(dbFactory) { }

      

        public GES_Licence GetLicenceById(long id)
        {

            var licences = this.DbContext.Licences.Where(c => c.Id == id).SingleOrDefault();

            return licences;
        }

        public IEnumerable<GES_Licence> GetItemsByModelLibelle(string identifged)
        {
            var licences = this.DbContext.Licences.Where(c => c.LicenceRaisonSociale == identifged);

            return licences;
        }
    }
}
