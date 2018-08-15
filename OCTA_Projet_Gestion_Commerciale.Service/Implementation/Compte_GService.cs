using AutoMapper;
using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Data.Repositories;
using OCTA_Projet_Gestion_Commerciale.Model;
using OCTA_Projet_Gestion_Commerciale.Service.Interface;
using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Service.Implementation
{
   public class Compte_GService : ICompte_GService
    {
        private readonly ICompte_GRepository compte_GRepository;
        private readonly IUnitOfWork unitOfWork;
        public Compte_GService(ICompte_GRepository compte_GRepository, IUnitOfWork unitOfWork)
        {
            this.compte_GRepository = compte_GRepository;
            this.unitOfWork = unitOfWork;
        }
        public IEnumerable<CompteGPivot> GetCPT_CompteGsByActifandIDDossierandValeur(string valeur)
        {
            var compteGs = compte_GRepository.GetCPT_CompteGsByActifandIDDossierandValeur(valeur);//.ToList();
            IEnumerable<CompteGPivot> compteGsPivot = Mapper.Map<IEnumerable<CPT_CompteG>, IEnumerable<CompteGPivot>>(compteGs);
            return compteGsPivot;
        }
    }
}
