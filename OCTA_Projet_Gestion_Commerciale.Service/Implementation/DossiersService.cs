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
  public  class DossiersService : IDossiersService
    {
        private readonly IDossiersRepository dossiersRepository;
        private readonly IUnitOfWork unitOfWork;
        public DossiersService(IDossiersRepository dossiersRepository, IUnitOfWork unitOfWork)
        {
            this.dossiersRepository = dossiersRepository;
            this.unitOfWork = unitOfWork;
        }
        /*
        public void CreateDossiersContactsPivot(DossiersPivot dossiersPivot)
        {
            GEN_Dossiers dossiers = Mapper.Map<DossiersPivot, GEN_Dossiers>(dossiersPivot);
            dossiersRepository.Add(dossiers);
       
        }*/
        public void CreateDossiersPivot(DossiersPivot dossiersPivot)
        {
            GEN_Dossiers dossiers = Mapper.Map<DossiersPivot, GEN_Dossiers>(dossiersPivot);
            dossiersRepository.Add(dossiers);
        }

        public void DeleteDossiersPivot(DossiersPivot dossiersPivot)
        {
            dossiersRepository.Delete(dossiersPivot.DossierId,Mapper.Map<DossiersPivot, GEN_Dossiers>(dossiersPivot));

        }

        public IEnumerable<DossiersContactsPivot> GentingContact(long id)
        {
            IEnumerable<GEN_DossiersContacts> dossiers = dossiersRepository.GetingAContact(id).ToList();
            IEnumerable<DossiersContactsPivot> dossiersPivot = Mapper.Map<IEnumerable<GEN_DossiersContacts>, IEnumerable<DossiersContactsPivot>>(dossiers);
            return dossiersPivot;
        }

        public IEnumerable<DossiersSitesPivot> GentingSite(long id)
        {
            IEnumerable<GEN_DossiersSites> dossiers = dossiersRepository.GetingASite(id).ToList();
            IEnumerable<DossiersSitesPivot> dossiersPivot = Mapper.Map<IEnumerable<GEN_DossiersSites>, IEnumerable<DossiersSitesPivot>>(dossiers);
            return dossiersPivot;
        }

        public IEnumerable<DossiersPivot> GetActifDossier()
        {


            IEnumerable<GEN_Dossiers> dossiers = dossiersRepository.GetingActif();//.ToList();
            IEnumerable<DossiersPivot> dossiersPivot = Mapper.Map<IEnumerable<GEN_Dossiers>, IEnumerable<DossiersPivot>>(dossiers);
            return dossiersPivot;
        }

        public IEnumerable<DossiersPivot> GetAllDossier()
        {
            IEnumerable<GEN_Dossiers> dossiers = dossiersRepository.GetAll();
            IEnumerable<DossiersPivot> dossiersPivot = Mapper.Map<IEnumerable<GEN_Dossiers>, IEnumerable<DossiersPivot>>(dossiers);
            return dossiersPivot;
        }

        public IEnumerable<PiecesPivot> GetCPT_Piece(long? id )
        {
            IEnumerable<CPT_Pieces> dossiers = dossiersRepository.GetPiece(id);
            IEnumerable<PiecesPivot> dossiersPivot = Mapper.Map<IEnumerable<CPT_Pieces>, IEnumerable<PiecesPivot>>(dossiers);
            return dossiersPivot;
        }

        public IEnumerable<DossiersPivot> GetDossier()
        {
            IEnumerable<GEN_Dossiers> dossiers = dossiersRepository.GetOnlyDossier();
            IEnumerable<DossiersPivot> dossiersPivot = Mapper.Map<IEnumerable<GEN_Dossiers>, IEnumerable<DossiersPivot>>(dossiers);
            return dossiersPivot;
        }

        public IEnumerable<DossiersPivot> GetDossierByCond()
        {
            IEnumerable<GEN_Dossiers> dossiers = dossiersRepository.GetAdossierByCond();
            IEnumerable<DossiersPivot> dossiersPivot = Mapper.Map<IEnumerable<GEN_Dossiers>, IEnumerable<DossiersPivot>>(dossiers);
            return dossiersPivot;
           // return dossiers.AsQueryable();
        }

        public IEnumerable<DossiersPivot> GetDossiersByActif(bool actif)
        {
            IEnumerable<GEN_Dossiers> dossiers = dossiersRepository.DossiersByActif(actif).ToList();
         IEnumerable<DossiersPivot> dossiersPivot = Mapper.Map<IEnumerable<GEN_Dossiers>, IEnumerable<DossiersPivot>>(dossiers);
            return dossiersPivot;
        }

        public IEnumerable<DossiersPivot> GetDossiersByDossiersId()
        {
            IEnumerable<GEN_Dossiers> dossiers = dossiersRepository.GetDossiersByDossiersId().ToList();
            IEnumerable<DossiersPivot> dossiersPivot = Mapper.Map<IEnumerable<GEN_Dossiers>, IEnumerable<DossiersPivot>>(dossiers);
            return dossiersPivot;
        }

        ///public DossiersPivot GetDossiersPivot(long id);
        public DossiersPivot GetDossiersAndInclude(long? id)
        {
            GEN_Dossiers dossiers = dossiersRepository.GetAdossierIncluding(id);
            DossiersPivot dossiersPivot = Mapper.Map<GEN_Dossiers, DossiersPivot>(dossiers);
            return dossiersPivot;

        }

        public DossiersPivot GetDossiersPivot(long? id)
        {
            var dossiers = dossiersRepository.GetById((int)id);
            DossiersPivot dossiersPivot = Mapper.Map<GEN_Dossiers, DossiersPivot>(dossiers);
            return dossiersPivot;
        }

        public DossiersPivot getingDossierActif()
        {
           GEN_Dossiers dossiers = dossiersRepository.GetDossierActif();
            DossiersPivot dossiersPivot = Mapper.Map<GEN_Dossiers, DossiersPivot>(dossiers);
            return dossiersPivot;

        }

        public IEnumerable<DossiersContactsPivot> GetingDossierContact()
        {

            IEnumerable<GEN_DossiersContacts> dossiers = dossiersRepository.GetAdossierContact();
            IEnumerable<DossiersContactsPivot> dossiersPivot = Mapper.Map<IEnumerable<GEN_DossiersContacts>, IEnumerable<DossiersContactsPivot>>(dossiers);
            return dossiersPivot;
        }

        public IEnumerable<DossiersSitesPivot> GetingDossierSites()
        {
            IEnumerable<GEN_DossiersSites> dossiers = dossiersRepository.GetAdossierSite();
            IEnumerable<DossiersSitesPivot> dossiersPivot = Mapper.Map<IEnumerable<GEN_DossiersSites>, IEnumerable<DossiersSitesPivot>>(dossiers);
            return dossiersPivot;

        }

        public IEnumerable<ItemsPivot> GetingModelItem(string valeur)
        {
            IEnumerable<GEN_Items> dossiers = dossiersRepository.GetAModelItem(valeur).ToList();
            IEnumerable<ItemsPivot> dossiersPivot = Mapper.Map<IEnumerable<GEN_Items>, IEnumerable<ItemsPivot>>(dossiers);
            return dossiersPivot;
        }

        

        /*public IEnumerable<DossiersPivot> GetDossiersPivotByNom(string Nom)
        {
        
            throw new NotImplementedException();
         }*/
        public void SaveDossiers()
        {
            unitOfWork.Commit();
        }

        public void UpdateDossierPivot(DossiersPivot dossiers)
        {
            var vrr = Mapper.Map<DossiersPivot, GEN_Dossiers>(dossiers);
            dossiersRepository.UpdateValues(dossiers.DossierId, vrr);
                //Update(dossiers.DossierId,vrr);
          
        }

        public void Validation_Db(DossiersPivot objet)
        {
            var Gen_dossier = Mapper.Map<DossiersPivot, GEN_Dossiers>(objet);
            dossiersRepository.Validate_db(Gen_dossier);
        }
    }
}
