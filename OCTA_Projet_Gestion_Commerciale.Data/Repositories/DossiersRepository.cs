using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Data.Utils;
using OCTA_Projet_Gestion_Commerciale.Model;

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Repositories
{
    public class DossiersRepository : RepositoryBase<GEN_Dossiers>, IDossiersRepository
    {
        public DossiersRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public IEnumerable<GEN_Dossiers> GetAdossierByCond()
        {
            //  var samesdossiers= this.DbContext.Dossiers.Where(e => e.DossierId == Constantes.IdentifiantDossier && e.CodeDossier != "" && e.DossierActif);
            var samesdossiers = this.DbContext.Dossier.Where(e => e.CodeDossier != "" && e.DossierActif);
            return samesdossiers;
        }
        public IEnumerable<GEN_DossiersContacts> GetingAContact(long id)
        {

            return this.DbContext.DossierContacts.Where(x => x.IdDossier == id && x.Actif);
        }

        public IEnumerable<GEN_Dossiers> GetingActif()
        {
            return this.DbContext.Dossier.Where(e => e.DossierActif);
        }

        public IEnumerable<GEN_DossiersSites> GetingASite(long id)
        {
            return this.DbContext.GEN_DossiersSites.Where(x => x.IdDossier == id && x.Actif).ToList();
        }

        public IEnumerable<GEN_Dossiers> GetOnlyDossier()
        {
            return this.DbContext.Dossier;
        }

        public IEnumerable<CPT_Pieces> GetPiece(long? id)
        {
            return from b in this.DbContext.Pieces where b.IdDossier == id select b;
        }

        public void Validate_db(GEN_Dossiers doss)
        {
            using (var dbIgnoreValidation = new StoreEntities())
            {
                dbIgnoreValidation.Configuration.ValidateOnSaveEnabled = false;
                dbIgnoreValidation.Dossier.Add(doss);
                //Add(gEN_Dossiers);
                dbIgnoreValidation.SaveChanges();
            }
        }
        public IEnumerable<GEN_DossiersContacts> GetAdossierContact()
        {
          return this.DbContext.DossierContacts.Where(e => e.IdDossier == Constantes.IdentifiantDossier && e.Actif).ToList();
        }

        public GEN_Dossiers GetAdossierIncluding(long? id)
        {
           return this.DbContext.Dossier.Where(x => x.DossierId== id).Include(x => x.GEN_DossiersContacts).FirstOrDefault();
        }

        public IEnumerable<GEN_DossiersSites> GetAdossierSite()
        {
           return this.DbContext.GEN_DossiersSites.Where(e => e.IdDossier == Constantes.IdentifiantDossier && e.Actif).ToList();
        }

        public IEnumerable<GEN_Items> GetAModelItem(string varr)
        {

            return this.DbContext.Items.Where(e => e.GEN_Model.Model == varr && e.GEN_Model.IdDossier == Constantes.IdentifiantDossier);
        }

        public GEN_Dossiers GetDossierActif()
        {
           var expression= this.DbContext.Dossier.Where(x => x.DossierActif == false && x.CodeDossier =="").FirstOrDefault();
            return expression;
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

        public IEnumerable<GEN_Dossiers> DossiersByActif(bool actif)
        {
            throw new NotImplementedException();
        }

        public void Update(object idSource, GEN_Dossiers entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(object idSource, GEN_Dossiers entity)
        {
            throw new NotImplementedException();
        }

        public GEN_Dossiers GetById(long id)
        {
            throw new NotImplementedException();
        }
    }

       


    public interface IDossiersRepository : IRepository<GEN_Dossiers>
    {
       IEnumerable<GEN_Dossiers> DossiersByActif(bool actif);
        IEnumerable<GEN_Dossiers> GetDossiersByDossiersId();
        IEnumerable<GEN_Dossiers> GetDossiersByDossiersIdAndActif();
        IEnumerable<GEN_Dossiers> GetAdossierByCond();
        IEnumerable<GEN_Dossiers> GetOnlyDossier();
        IEnumerable<GEN_DossiersSites>  GetAdossierSite();
        IEnumerable<GEN_DossiersSites> GetingASite(long id);
        IEnumerable<GEN_DossiersContacts> GetAdossierContact();
        IEnumerable<GEN_DossiersContacts> GetingAContact(long id);
        IEnumerable<GEN_Items> GetAModelItem(string varr);
       GEN_Dossiers GetDossierActif();
       GEN_Dossiers GetAdossierIncluding(long? id);
        IEnumerable<CPT_Pieces> GetPiece(long? id);
        void Validate_db(GEN_Dossiers doss);
        IEnumerable<GEN_Dossiers>  GetingActif();
    }
}
