using OCTA_Projet_Gestion_Commerciale.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using OCTA_Projet_Gestion_Commerciale.Data.Repositories;
using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Model;
using AutoMapper;

namespace OCTA_Projet_Gestion_Commerciale.Service.Implementation
{
    public class DossiersSitesService : IDossiersSitesService
    {

        private readonly IDossiersSitesRepository dossierSiteRepository;
        private readonly IUnitOfWork unitOfWork;

        public DossiersSitesService(IDossiersSitesRepository dossierSiteRepository, IUnitOfWork unitOfWork)
        {
            this.dossierSiteRepository = dossierSiteRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateDossiersSitePivot(DossiersSitesPivot dossiersSite)
        {
            GEN_DossiersSites dossiers = Mapper.Map<DossiersSitesPivot, GEN_DossiersSites>(dossiersSite);
            dossierSiteRepository.Add(dossiers);
        }

        public void DeleteDossiersSitePivot(DossiersSitesPivot dossiersSite)
        {
            dossierSiteRepository.Delete(dossiersSite.Id,Mapper.Map<DossiersSitesPivot, GEN_DossiersSites>(dossiersSite));

        }

        public IEnumerable<DossiersSitesPivot> GetActifDossierSite()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DossiersSitesPivot> GetAllDossierSite()
        {
            IEnumerable<GEN_DossiersSites> dossiers = dossierSiteRepository.GetAll();
            IEnumerable<DossiersSitesPivot> dossiersPivot = Mapper.Map<IEnumerable<GEN_DossiersSites>, IEnumerable<DossiersSitesPivot>>(dossiers);
            return dossiersPivot;
        }

        public DossiersSitesPivot GetDossiersSitePivot(long? id)
        {
            var dossiers = dossierSiteRepository.GetById((int)id);
            DossiersSitesPivot dossiersPivot = Mapper.Map<GEN_DossiersSites, DossiersSitesPivot>(dossiers);
            return dossiersPivot;
        }

        public void SaveDossiersSite()
        {
            unitOfWork.Commit();
        }

        public void UpdateDossierSitePivot(DossiersSitesPivot dossiersSite)
        {
            dossierSiteRepository.Update(dossiersSite.Id,Mapper.Map<DossiersSitesPivot,GEN_DossiersSites>(dossiersSite));
        }
    }
}
