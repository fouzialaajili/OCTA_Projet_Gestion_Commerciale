using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OCTA_Projet_Gestion_Commerciale.Model;
using Infragistics.Web.Mvc;
using AutoMapper;
using OCTA_Projet_Gestion_Commerciale.Data.Repositories;
using OCTA_Projet_Gestion_Commerciale.Service.Interface;
using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using OCTA_Projet_Gestion_Commerciale.Web.ViewModels;
using OCTA_Projet_Gestion_Commerciale.Data.Utils;

namespace OCTA_Projet_Gestion_Commerciale.Web.Controllers
{

 public class TiersController : Controller
    {
        private readonly ITiersService tiersService;
        private readonly IDossiersService dossiersService;
        private readonly ITypePaiementService typePaiementService;
        private readonly IItemsService itemsService;
        private readonly IDevisesService devisesService;
        private readonly IEcritureService ecritureService;
        private readonly ITiersContactsService tiersContactService;
        private readonly ICompte_GService compte_GService;
        public TiersController(ICompte_GService compte_GService, ITiersContactsService tiersContactService, ITiersService tiersService, IDossiersService dossiersService, ITypePaiementService typePaiementService, IItemsService itemsService, IDevisesService devisesService, IEcritureService ecritureService)
        {
            this.compte_GService = compte_GService;
            this.tiersService = tiersService;
            this.dossiersService = dossiersService;
            this.typePaiementService = typePaiementService;
            this.itemsService = itemsService;
            this.devisesService = devisesService;
            this.ecritureService = ecritureService;
            this.tiersContactService = tiersContactService;
        }
        public ActionResult Index(string type)
        {
            IEnumerable<GEN_Tiers_ViewModel> gEN_Tiers_ViewModel;
            IEnumerable<TiersPivot> tiersPivot;

            ViewBag.Message = TempData["Message"];
            ViewBag.type = type;
            ViewBag.IdPays = itemsService.GetItemsByModel("Pays").OrderBy(e => e.Libelle).Select(x => new { ID = x.Id, VALUE = x.Libelle });
            ViewBag.IdVille = itemsService.GetItemsByModel("Ville").OrderBy(e => e.Libelle).Select(x => new { ID = x.Id, VALUE = x.Libelle });
            tiersPivot = tiersService.GetTiersByItems_TypeTiers(type);
            gEN_Tiers_ViewModel = Mapper.Map<IEnumerable<TiersPivot>, IEnumerable<GEN_Tiers_ViewModel>>(tiersPivot);


            return View(gEN_Tiers_ViewModel.AsQueryable());

        }

        public ActionResult listContacts(long id, bool? isDelete)
        {
            IEnumerable<TiersContactsPivot> gEN_TiersContacts = tiersContactService.GetTiersContactsByIdTiersAndActif(id);
            IEnumerable<GEN_TiersContacts_ViewModel> gEN_Tiers_ViewModel = Mapper.Map<IEnumerable<TiersContactsPivot>, IEnumerable<GEN_TiersContacts_ViewModel>>(gEN_TiersContacts);
            ViewBag.IdTiers = id;
            ViewBag.isDelete = isDelete.HasValue;
            return View(gEN_Tiers_ViewModel.AsQueryable());
        }
        public ActionResult IndexClients()
        {
            IEnumerable<GEN_Tiers_ViewModel> gEN_Tiers_ViewModel;
            IEnumerable<TiersPivot> tiersPivot;
            tiersPivot = tiersService.GetALL();
            gEN_Tiers_ViewModel = Mapper.Map<IEnumerable<TiersPivot>, IEnumerable<GEN_Tiers_ViewModel>>(tiersPivot);
            return View(gEN_Tiers_ViewModel);

        }
        public ActionResult IndexSalaries()
        {
            IEnumerable<GEN_Tiers_ViewModel> gEN_Tiers_ViewModel;
            IEnumerable<TiersPivot> tiersPivot;

            tiersPivot = tiersService.GetALL();

            gEN_Tiers_ViewModel = Mapper.Map<IEnumerable<TiersPivot>, IEnumerable<GEN_Tiers_ViewModel>>(tiersPivot);

            //var gEN_Tiers = db.GEN_Tiers;
            //.Where(e => e.IdDossier == CurrentPreference.IdDossier && (e.GEN_Items_TypeTiers.Valeur == "salarie")).Include(g => g.CPT_CompteG.GEN_Items_TypeCompte).Include(g => g.CPT_CompteG1).Include(g => g.CPT_CompteG1).Include(g => g.GEN_Devises).Include(g => g.GEN_Dossiers).Include(g => g.GEN_TypePaiement);
            return View(gEN_Tiers_ViewModel);

        }
        public ActionResult IndexAutres()
        {
            /// var gEN_Tiers = db.GEN_Tiers;
            //.Where(e => e.IdDossier == CurrentPreference.IdDossier && (e.GEN_Items_TypeTiers.Valeur == "autres")).Include(g => g.CPT_CompteG.GEN_Items_TypeCompte).Include(g => g.CPT_CompteG1).Include(g => g.CPT_CompteG1).Include(g => g.GEN_Devises).Include(g => g.GEN_Dossiers).Include(g => g.GEN_TypePaiement);
            IEnumerable<GEN_Tiers_ViewModel> gEN_Tiers_ViewModel;
            IEnumerable<TiersPivot> tiersPivot;

            tiersPivot = tiersService.GetALL();

            gEN_Tiers_ViewModel = Mapper.Map<IEnumerable<TiersPivot>, IEnumerable<GEN_Tiers_ViewModel>>(tiersPivot);


            return View(gEN_Tiers_ViewModel);

        }
        public ActionResult IndexFournisseurs()
        {
            IEnumerable<GEN_Tiers_ViewModel> gEN_Tiers_ViewModel;
            IEnumerable<TiersPivot> tiersPivot;

            tiersPivot = tiersService.GetALL();

            gEN_Tiers_ViewModel = Mapper.Map<IEnumerable<TiersPivot>, IEnumerable<GEN_Tiers_ViewModel>>(tiersPivot);


            return View(gEN_Tiers_ViewModel);
        }


        public ActionResult Create(long? id, string type)
        {


            TiersPivot CurrentObj;
            ViewBag.type = type;

            if (id == null)
            {
                CurrentObj = tiersService.GetTiers();


                if (CurrentObj != null)
                {
                    tiersService.DeleteTiers(CurrentObj);
                }

                ViewBag.Collectif = null;
                ViewBag.IdDeviseDefault = new SelectList(devisesService.GetDevisesByIDDossierAndActif(), "DevisesId", "DevisesCode");
                ViewBag.IdDossier = new SelectList(dossiersService.GetDossiersByActif(true), "DossierId", "CodeDossier");
                ViewBag.IdEcheancement = new SelectList(typePaiementService.GetTypePaiemenByIDDossierAndActif(), "TypePaiementId ", "Libelle");

                ViewBag.TypeTiers = new SelectList(itemsService.GetItemsByModelAndActif(type), "Id", "Libelle");

                ViewBag.FormeJuridique = new SelectList(itemsService.GetItemsByModel("FormeJuridique"), "Id", "Libelle");
                ViewBag.Pays = new SelectList(itemsService.GetItemsByModel("Pays"), "Id", "Libelle");
                ViewBag.Ville = new SelectList(itemsService.GetItemsByModel("Ville"), "Id", "Libelle");
                ViewBag.IdentifiantFiscale = new SelectList(itemsService.GetItemsByModel("IdentifiantFiscale"), "Id", "Libelle");
                ViewBag.IdCategorieFiscale = new SelectList(itemsService.GetItemsByModel("CategorieFiscale"), "Id", "Libelle");
                ViewBag.activite = new SelectList(itemsService.GetItemsByModel("activite"), "Id", "Libelle");
                ViewBag.IdGroupeStatistiques = new SelectList(itemsService.GetItemsByModel("GroupeStatistiques"), "Id", "Libelle");

                ViewBag.IdGroupeRemise = new SelectList(itemsService.GetItemsByModel("GroupeRemise"), "Id", "Libelle");
                ViewBag.IdCompteCollectifClient = new SelectList(compte_GService.GetCPT_CompteGsByActifandIDDossierandValeur("Clients").Select(x => new { Id = x.Id, Value = x.Code + " " + x.Libelle }), "Id", "Value");
                ViewBag.IdCompteCollectifFournisseur = new SelectList(compte_GService.GetCPT_CompteGsByActifandIDDossierandValeur("Fournisseurs").Select(x => new { Id = x.Id, Value = x.Code + " " + x.Libelle }), "Id", "Value");

                return View();
            }
            else
            {
                CurrentObj = tiersService.GetTier(id);
                ViewBag.Message = TempData["errorMessage"] + "";
                if (CurrentObj == null)
                {
                    TempData["Message"] = "Le tier que vous cherchez n'existe pas.";
                    return RedirectToAction("Index", "Tiers");
                }

                // ViewBag.IdDeviseDefault = new SelectList(db.GEN_Devises.Where(e => e.IdDossier == CurrentPreference.IdDossier && e.Actif), "Id", "Code", CurrentObj.IdDeviseDefault);
                // ViewBag.IdDossier = new SelectList(db.GEN_Dossiers.Where(e => e.IdSociete == CurrentSocieteId && e.Actif), "Id", "CodeDossier", CurrentObj.IdDossier);
                // ViewBag.IdEcheancement = new SelectList(db.GEN_TypePaiement.Where(e => e.IdDossier == CurrentPreference.IdDossier && e.Actif), "Id", "Libelle", CurrentObj.IdEcheancement);
                ViewBag.IdDeviseDefault = new SelectList(devisesService.GetDevisesByIDDossierAndActif(), "DevisesId", "DevisesCode");
                ViewBag.IdDossier = new SelectList(dossiersService.GetDossiersByActif(true), "DossierId", "CodeDossier");

                ViewBag.IdEcheancement = new SelectList(typePaiementService.GetTypePaiemenByIDDossierAndActif(), "TypePaiementId ", "Libelle");


                if (type == null)
                {
                    var items = itemsService.GetItems(CurrentObj.TypeTiers);

                    ViewBag.TypeTiers = new SelectList(itemsService.GetItemsByModelAndActif(type), "Id", "Libelle");

                    //ViewBag.TypeTiers = new SelectList(db.GEN_Items.Where(e => e.GEN_Model.Model == "NatureTiers" && e.Valeur.Contains(CurrentObj.GEN_Items_TypeTiers.Valeur) && e.GEN_Model.IdSociete == CurrentSocieteId) items, "Id", "Libelle", CurrentObj.TypeTiers);
                }
                else
                {
                    ViewBag.TypeTiers = new SelectList(itemsService.GetItemsByModelAndActif(type), "Id", "Libelle");

                    //ViewBag.TypeTiers = new SelectList(db.GEN_Items.Where(e => e.GEN_Model.Model == "NatureTiers" && e.Valeur.Contains(type) && e.GEN_Model.IdSociete == CurrentSocieteId), "Id", "Libelle", CurrentObj.TypeTiers);
                }

                ViewBag.FormeJuridique = new SelectList(itemsService.GetItemsByModel("FormeJuridique"), "Id", "Libelle");
                ViewBag.Pays = new SelectList(itemsService.GetItemsByModel("Pays"), "Id", "Libelle");
                ViewBag.Ville = new SelectList(itemsService.GetItemsByModel("Ville"), "Id", "Libelle");
                ViewBag.IdentifiantFiscale = new SelectList(itemsService.GetItemsByModel("IdentifiantFiscale"), "Id", "Libelle");
                ViewBag.IdCategorieFiscale = new SelectList(itemsService.GetItemsByModel("CategorieFiscale"), "Id", "Libelle");
                ViewBag.activite = new SelectList(itemsService.GetItemsByModel("activite"), "Id", "Libelle");
                ViewBag.IdGroupeStatistiques = new SelectList(itemsService.GetItemsByModel("GroupeStatistiques"), "Id", "Libelle");
                ViewBag.IdGroupeRemise = new SelectList(itemsService.GetItemsByModel("GroupeRemise"), "Id", "Libelle");

                ViewBag.IdCompteCollectifClient = new SelectList(compte_GService.GetCPT_CompteGsByActifandIDDossierandValeur("Clients").Select(x => new { Id = x.Id, Value = x.Code + " " + x.Libelle }), "Id", "Value");
                ViewBag.IdCompteCollectifFournisseur = new SelectList(compte_GService.GetCPT_CompteGsByActifandIDDossierandValeur("Fournisseurs").Select(x => new { Id = x.Id, Value = x.Code + " " + x.Libelle }), "Id", "Value");

                var tierForm = Mapper.Map<GEN_Tiers_Form_ViewModel>(CurrentObj);
                var typeTier = itemsService.GetItems(CurrentObj.TypeTiers).Valeur;
                tierForm.TypeTierCode = typeTier;
                //tierForm.typeTierCode = CurrentObj.GEN_Items_TypeTiers.Valeur;
                return View(tierForm);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,code,TypeTier,RaisonSociale,activite,FormeJuridique,Adresse,adresseLivraison,Tel,Fax,Email,Ville,SiteWeb,CapitalSocial,Pays,IdentifiantFiscale,IdentifiantTVA,ice,Patente,IdDeviseDefault,Actif,IdEcheancement,IdGroupeRemise,IdGroupeStatistiques,IdCategorieFiscale,IdDossier,sys_user,sys_dateUpdate,sys_dateCreation")] GEN_Tiers_Form_ViewModel gEN_Tiers, string type)
        {

            TiersPivot tiersPivot;
            var errors = ModelState.Where(x => x.Key != "Id").Select(x => x.Value.Errors)
                            .Where(y => y.Count > 0)
                            .ToList();

            if (errors.Count == 0)
            {
                GEN_Tiers_Form_ViewModel gen_tierCreer = gEN_Tiers;
                if (gen_tierCreer.Id > 0)
                {



                    if (itemsService.GetItems(gen_tierCreer.TypeTiers).Valeur == "client")
                    {
                        gen_tierCreer.IdCompteCollectifFournisseur = null;

                    }
                    else if (itemsService.GetItems(gen_tierCreer.TypeTiers).Valeur == "fournisseur")
                    {
                        gen_tierCreer.IdCompteCollectifClient = null;

                    }
                    gen_tierCreer.sys_user = "" + Constantes.CurrentUserId;
                    tiersPivot = Mapper.Map<GEN_Tiers_Form_ViewModel, TiersPivot>(gen_tierCreer);

                    tiersService.UpdateTiers(tiersPivot);
                }
                else
                {
                    tiersPivot = tiersService.GetTiers();
                    if (tiersPivot == null)
                    {

                        tiersPivot = Mapper.Map<GEN_Tiers_Form_ViewModel, TiersPivot>(gEN_Tiers);
                        tiersPivot.sys_dateCreation = DateTime.Now;
                        tiersPivot.sys_dateUpdate = DateTime.Now;
                        tiersPivot.sys_user = "" + Constantes.CurrentUserId;
                        tiersPivot.IdDossier = Constantes.CurrentPreferenceIdDossier;
                        tiersService.CreateTiers(tiersPivot);
                        tiersService.SaveTiers();

                    }
                    else
                    {

                        tiersPivot.Actif = gEN_Tiers.Actif;
                        tiersPivot.Adresse = gEN_Tiers.Adresse;
                        tiersPivot.CapitalSocial = gEN_Tiers.CapitalSocial;
                        tiersPivot.Email = gEN_Tiers.Email;
                        tiersPivot.Fax = gEN_Tiers.Fax;
                        tiersPivot.IdentifiantFiscale = gEN_Tiers.IdentifiantFiscale;
                        tiersPivot.IdentifiantTVA = gEN_Tiers.IdentifiantTVA;
                        tiersPivot.Patente = gEN_Tiers.Patente;
                        tiersPivot.Pays = gEN_Tiers.Pays;
                        tiersPivot.RaisonSociale = gEN_Tiers.RaisonSociale;
                        tiersPivot.SiteWeb = gEN_Tiers.SiteWeb;
                        tiersPivot.Tel = gEN_Tiers.Tel;
                        tiersPivot.Ville = gEN_Tiers.Ville;
                        tiersPivot.activite = gEN_Tiers.activite;
                        tiersPivot.adresseLivraison = gEN_Tiers.adresseLivraison;
                        tiersPivot.code = gEN_Tiers.code;
                        tiersPivot.FormeJuridique = gEN_Tiers.FormeJuridique;
                        tiersPivot.ice = gEN_Tiers.ice;
                        tiersPivot.IdCategorieFiscale = gEN_Tiers.IdCategorieFiscale;
                        tiersPivot.IdCompteCollectifClient = gEN_Tiers.IdCompteCollectifClient;
                        tiersPivot.IdCompteCollectifFournisseur = gEN_Tiers.IdCompteCollectifFournisseur;
                        tiersPivot.IdDeviseDefault = gEN_Tiers.IdDeviseDefault;

                        tiersPivot.IdDossier = Constantes.CurrentPreferenceIdDossier;
                        tiersPivot.IdEcheancement = gEN_Tiers.IdEcheancement;
                        tiersPivot.IdGroupeRemise = gEN_Tiers.IdGroupeRemise;
                        tiersPivot.IdGroupeStatistiques = gEN_Tiers.IdGroupeStatistiques;
                        tiersPivot.sys_dateCreation = DateTime.Now;
                        tiersPivot.sys_dateUpdate = DateTime.Now;
                        tiersPivot.sys_user = "" + Constantes.CurrentUserId;
                        tiersPivot.TypeTiers = gEN_Tiers.TypeTiers;
                        tiersService.UpdateTiers(tiersPivot);

                    }
                }
                return RedirectToAction("Create", new { id = gen_tierCreer.Id, type = type });
            }
            //return RedirectToAction("Create", new { id = gEN_Tiers.Id, type = type });

            ViewBag.IdDeviseDefault = new SelectList(devisesService.GetDevisesByIDDossierAndActif(), "DevisesId", "DevisesCode");
            ViewBag.IdDossier = new SelectList(dossiersService.GetDossiersByActif(true), "DossierId", "CodeDossier");
            ViewBag.IdEcheancement = new SelectList(typePaiementService.GetTypePaiemenByIDDossierAndActif(), "TypePaiementId ", "Libelle");

            ViewBag.TypeTiers = new SelectList(itemsService.GetItemsByModelAndActif(type), "Id", "Libelle");

            ViewBag.FormeJuridique = new SelectList(itemsService.GetItemsByModel("FormeJuridique"), "Id", "Libelle");
            ViewBag.Pays = new SelectList(itemsService.GetItemsByModel("Pays"), "Id", "Libelle");
            ViewBag.Ville = new SelectList(itemsService.GetItemsByModel("Ville"), "Id", "Libelle");
            ViewBag.IdentifiantFiscale = new SelectList(itemsService.GetItemsByModel("IdentifiantFiscale"), "Id", "Libelle");
            ViewBag.IdCategorieFiscale = new SelectList(itemsService.GetItemsByModel("CategorieFiscale"), "Id", "Libelle");
            ViewBag.activite = new SelectList(itemsService.GetItemsByModel("activite"), "Id", "Libelle");
            ViewBag.IdGroupeStatistiques = new SelectList(itemsService.GetItemsByModel("GroupeStatistiques"), "Id", "Libelle");
            ViewBag.IdGroupeRemise = new SelectList(itemsService.GetItemsByModel("GroupeRemise"), "Id", "Libelle");


            ViewBag.IdCompteCollectifClient = new SelectList(compte_GService.GetCPT_CompteGsByActifandIDDossierandValeur("Clients").Select(x => new { Id = x.Id, Value = x.Code + " " + x.Libelle }), "Id", "Value");
            ViewBag.IdCompteCollectifFournisseur = new SelectList(compte_GService.GetCPT_CompteGsByActifandIDDossierandValeur("Fournisseurs").Select(x => new { Id = x.Id, Value = x.Code + " " + x.Libelle }), "Id", "Value");


            return View(gEN_Tiers);

        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(GEN_Tiers_Form_ViewModel gEN_Tiers, string type)
        {
            TiersPivot tiersPivot = tiersService.GetTier(gEN_Tiers.Id);
            var test = ecritureService.GetEcrituresByIdDossiersAndByIdTiers(tiersPivot);
            //= from b in db.CPT_Ecritures where b.IdDossier == CurrentPreference.IdDossier && b.IdTiers == gEN_Tiers.Id select b;
            if (test.Count() > 0)
            {
                if (type == "client")
                {
                    TempData["errorMessage"] = "Vous ne pouvez pas supprimer ce client car il est utilisé dans une écriture";

                }
                else if (type == "fournisseur")
                {
                    TempData["errorMessage"] = "Vous ne pouvez pas supprimer ce fournisseur car il est utilisé dans une écriture";

                }
                else if (type == "salarie")
                {
                    TempData["errorMessage"] = "Vous ne pouvez pas supprimer ce salarie car il est utilisé dans une écriture";

                }
                else
                {
                    TempData["errorMessage"] = "Vous ne pouvez pas supprimer ce tier car il est utilisé dans une écriture";

                }
                return RedirectToAction("Create", new { id = gEN_Tiers.Id, type = type });
            }
            else
            {
                tiersService.DeleteTiers(tiersPivot);

                return RedirectToAction("Index", new { type = type });
            }
        }

    }
}

