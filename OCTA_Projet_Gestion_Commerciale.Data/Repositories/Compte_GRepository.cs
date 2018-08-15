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
   
    public interface ICompte_GRepository : IRepository<CPT_CompteG>
    {

        IEnumerable<CPT_CompteG> GetCPT_CompteGsByActifandIDDossierandValeur(string valeur);

    }



    public class Compte_GRepository : RepositoryBase<CPT_CompteG>, ICompte_GRepository
    {
        public Compte_GRepository(IDbFactory dbFactory) : base(dbFactory) { }
      public IEnumerable<CPT_CompteG> GetCPT_CompteGsByActifandIDDossierandValeur(string valeur)
        {


            var cpt_Coompte_G = this.DbContext.CPT_CompteGs.Where(e => e.IdDossier == Constantes.CurrentSocieteId && e.Actif && e.GEN_Items_TypeCompte.Valeur == valeur && e.GEN_Items_TypeCompte.GEN_Model.Model == "TypeCompte");

               return cpt_Coompte_G.ToList();


                }





    }
}
