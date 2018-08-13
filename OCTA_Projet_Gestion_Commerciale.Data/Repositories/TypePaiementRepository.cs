
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

    public class TypePaiementRepository : RepositoryBase<GEN_TypePaiement>, ITypePaiementRepositoy
    {
        public TypePaiementRepository(IDbFactory dbFactory) : base(dbFactory) { }

        public GEN_TypePaiement GetTypePaiementById(long id)
        {
            var typePaiement = this.DbContext.TypePaiement.Where(c => c.TypePaiementId == id).SingleOrDefault();
            return typePaiement;
        }

        public IEnumerable<GEN_TypePaiement> GetItemsByModelLibelle(string identifged)
        {
            throw new NotImplementedException();
        }

        public GEN_TypePaiement GetTypePaiements()
        {
            var typePaiement = this.DbContext.TypePaiement.Where(x => x.Actif == false && x.Libelle == "").FirstOrDefault();

            return typePaiement;

        }

        public IEnumerable<GEN_TypePaiement> GetTypePaiementByIDDossier()
        {

            var typePaiements = this.DbContext.TypePaiement.Where(c => c.IdDossier == Constantes.CurrentPreferenceIdDossier && c.Actif);

            return typePaiements;
        }

        public IEnumerable<GEN_TypePaiement> GetTypePaiemenByIDDossierAndActif()
        {
            var typePaiements = this.DbContext.TypePaiement.Where(e => e.IdDossier == Constantes.CurrentPreferenceIdDossier && e.Actif);
            return typePaiements;


        }

        public IEnumerable<GEN_TypePaiement> GetTypePaiementByIDDossier(long id)
        {
            throw new NotImplementedException();
        }

      
    }

    public interface ITypePaiementRepositoy : IRepository<GEN_TypePaiement>
    {
      GEN_TypePaiement GetTypePaiementById(long id);
     IEnumerable<GEN_TypePaiement> GetItemsByModelLibelle(string identifged);
        //ajouter par moi-méme
     IEnumerable<GEN_TypePaiement> GetTypePaiementByIDDossier(long id);
        GEN_TypePaiement GetTypePaiements();
            IEnumerable<GEN_TypePaiement> GetTypePaiemenByIDDossierAndActif();
    }


}