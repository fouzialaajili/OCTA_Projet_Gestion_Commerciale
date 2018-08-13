using AutoMapper;
using Infragistics.Web.Mvc;
using OCTA_Projet_Gestion_Commerciale.Data;
using OCTA_Projet_Gestion_Commerciale.Data.Utils;
using OCTA_Projet_Gestion_Commerciale.Model;
using OCTA_Projet_Gestion_Commerciale.Service.Interface;
using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using OCTA_Projet_Gestion_Commerciale.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace OCTA_Projet_Gestion_Commerciale.Web.Controllers
{
    public class DossiersController : Controller
    {
        private readonly IDossiersService dossiersServise;
        private readonly IDevisesService devisesService;
        private readonly IDossiersContactsService dossiersContactsService;
        private readonly IDossiersSitesService dossiersSitesService;
        public string Model1 = "FormeJuridique";
        public string Model2 = "Pays";
        public DossiersController(IDossiersService dossiersServise, IDossiersContactsService dossiersContactsService, IDevisesService devisesService, IDossiersSitesService dossiersSitesService)
        {
            this.dossiersSitesService = dossiersSitesService;
            this.dossiersContactsService = dossiersContactsService;
            this.dossiersServise = dossiersServise;
            this.devisesService = devisesService;

        }
        // GET: Devises


        public ActionResult Index()
        {

            //  var gEN_Dossiers = db.GEN_Dossiers.Where(e => e.IdSociete == CurrentSocieteId && e.CodeDossier != "" && e.Actif);

            ViewBag.Message = TempData["Message"];

            //var gEN_Dossiers= dossiersServise.GetAllDossier();
            var gEN_Dossiers = dossiersServise.GetDossierByCond();

            IEnumerable<DossierViewModel> dossiersViews = Mapper.Map<IEnumerable<DossiersPivot>, IEnumerable<DossierViewModel>>(gEN_Dossiers);

            return View(dossiersViews.AsQueryable());
        }




        public ActionResult DossierSites()
        {
            var gEN_DossiersSites = dossiersServise.GetingDossierSites();
            IEnumerable<DossiersSitesViewModel> dossiersViews = Mapper.Map<IEnumerable<DossiersSitesPivot>, IEnumerable<DossiersSitesViewModel>>(gEN_DossiersSites);
            //db.GEN_DossiersSites.Where(e => e.IdDossier == CurrentPreference.IdDossier && e.Actif);
            return View(dossiersViews.AsQueryable());
        }

        public ActionResult DossierContacts()
        {
            var gEN_DossiersContacts = dossiersServise.GetingDossierContact();
            IEnumerable<DossierContactsViewModel> dossiersViews = Mapper.Map<IEnumerable<DossiersContactsPivot>, IEnumerable<DossierContactsViewModel>>(gEN_DossiersContacts);
            //db.GEN_DossiersContacts.Where(e => e.IdDossier == CurrentPreference.IdDossier && e.Actif);
            return View(dossiersViews.AsQueryable());
        }



        public ActionResult listContacts(long id, bool? isDelete)
        {
            var list = new List<KeyValuePair<int, string>>() {
                new KeyValuePair<int, string>( 0,"Non"),
                new KeyValuePair<int, string>( 1,"Oui"),
            };

            var ListParDefaut = list.Select(x => new { ID = x.Key, VALUE = x.Value });
            ViewBag.ListParDefaut = ListParDefaut;

            var gEN_DossiersContacts = dossiersServise.GentingContact(id);

            IEnumerable<DossierContactsViewModel> dossiersContactViews = Mapper.Map<IEnumerable<DossiersContactsPivot>, IEnumerable<DossierContactsViewModel>>(gEN_DossiersContacts);
            //db.GEN_DossiersContacts.Where(x => x.IdDossier == id && x.Actif);
            ViewBag.IdDossier = id;
            ViewBag.isDelete = isDelete.HasValue;
            return View(dossiersContactViews.AsQueryable());
        }

        public ActionResult listSites(long id, bool? isDelete)
        {
            var list = new List<KeyValuePair<int, string>>() {
                new KeyValuePair<int, string>( 0,"Non"),
                new KeyValuePair<int, string>( 1,"Oui"),
            };

            var ListParDefaut = list.Select(x => new { ID = x.Key, VALUE = x.Value });
            ViewBag.ListParDefaut = ListParDefaut;


            var gEN_DossiersSites = dossiersServise.GentingSite(id);
            IEnumerable<DossiersSitesViewModel> dossiersSiteViews = Mapper.Map<IEnumerable<DossiersSitesPivot>, IEnumerable<DossiersSitesViewModel>>(gEN_DossiersSites);

            //db.GEN_DossiersSites.Where(x => x.IdDossier == id && x.Actif);
            ViewBag.IdDossier = id;
            ViewBag.isDelete = isDelete.HasValue;
            if (gEN_DossiersSites.FirstOrDefault() == null)
            {

                //GEN_DossiersSites site = new GEN_DossiersSites();
                //site.Nom = "Site Principale";
                //site.ParDefault = 1;
                //site.IdDossier = 0;
                //var sites = new List<GEN_DossiersSites>();
                //sites.Add(site);
                DossiersSitesPivot site = new DossiersSitesPivot();
                site.Nom = "Site Principale";
                site.ParDefault = 1;
                site.IdDossier = 0;
                var sites = new List<DossiersSitesPivot>();
                sites.Add(site);
                IEnumerable<DossiersSitesViewModel> dossiersSiteView = Mapper.Map<IEnumerable<DossiersSitesPivot>, IEnumerable<DossiersSitesViewModel>>(sites);

                
                return View(dossiersSiteView.AsQueryable());
            }

            return View(dossiersSiteViews.AsQueryable());
        }






        // GET: GEN/GEN_Dossiers/Create
        public ActionResult Create(long? id)
        {
            //ViewBag.IdSociete = new SelectList(db.GEN_Societes, "Id", "RaisonSociale");
            DossiersPivot gEN_Dossiers;
            if (id == null)
            {
                gEN_Dossiers = dossiersServise.getingDossierActif();
                //db.GEN_Dossiers.Where(x => x.Actif == false && x.CodeDossier == "").FirstOrDefault();
                if (gEN_Dossiers != null)
                {
                    // db.GEN_Dossiers.Remove(gEN_Dossiers);

                    dossiersServise.DeleteDossiersPivot(gEN_Dossiers);
                    dossiersServise.SaveDossiers();
                    // db.SaveChanges();
                }

                ViewBag.IdTypeDossier = new SelectList(dossiersServise.GetingModelItem(Model1), "Id", "Libelle");
                //new SelectList(db.GEN_Items.Where(e => e.GEN_Model.Model == "FormeJuridique" && e.GEN_Model.IdSociete == CurrentSocieteId), "Id", "Libelle");

                // ViewBag.Pays = new SelectList(db.GEN_Items.Where(e => e.GEN_Model.Model == "Pays" && e.GEN_Model.IdSociete == CurrentSocieteId), "Id", "Libelle");
                ViewBag.DossierPays = new SelectList(dossiersServise.GetingModelItem(Model2), "Id", "Libelle");


                //ViewBag.IdDeviseTenueCompte = new SelectList(db.GEN_Devises.Where(e => e.IdDossier == CurrentPreference.IdDossier && e.Actif), "Id", "Code");

                ViewBag.IdDeviseTenueCompte = new SelectList(devisesService.GetDeviseByCond(), "DevisesId", "DevisesCode");

              
                return View();
            }
            else
            {

                gEN_Dossiers = dossiersServise.GetDossiersAndInclude(id);

                DossierFormViewModel gEN_Doss = Mapper.Map<DossiersPivot,DossierFormViewModel>(gEN_Dossiers);

                //db.GEN_Dossiers.Where(x => x.Id == id).Include(x => x.GEN_DossiersContacts).FirstOrDefault();
                ViewBag.Message = TempData["errorMessage"] + "";
                if (gEN_Dossiers == null)
                {
                    TempData["Message"] = "Le dossier que vous cherchez n'existe pas.";
                    return RedirectToAction("Index");
                }

                ViewBag.IdTypeDossier = new SelectList(dossiersServise.GetingModelItem(Model1), "Id", "Libelle"); 
                //new SelectList(db.GEN_Items.Where(e => e.GEN_Model.Model == "FormeJuridique" && e.GEN_Model.IdSociete == CurrentSocieteId), "Id", "Libelle");
                // ViewBag.Pays = new SelectList(db.GEN_Items.Where(e => e.GEN_Model.Model == "Pays" && e.GEN_Model.IdSociete == CurrentSocieteId), "Id", "Libelle");
                ViewBag.DossierPays = new SelectList(dossiersServise.GetingModelItem(Model2), "Id", "Libelle");

                // ViewBag.IdDeviseTenueCompte = new SelectList(db.GEN_Devises.Where(e => e.IdDossier == CurrentPreference.IdDossier && e.Actif), "Id", "Code");

                ViewBag.IdDeviseTenueCompte = new SelectList(devisesService.GetDeviseByCond(), "DevisesId", "DevisesCode"); ;
                return View(gEN_Doss);



            }

        }

        // POST: GEN/GEN_Dossiers/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DossierId,CodeDossier,DossierRaisonSociale,IdTypeDossier,DossierAdresse,DossierTel,DossierFax,DossierEmail,DossierVille,DossierPays,DossierSiteWeb,DossierCapitalSocial,IdDeviseTenueCompte,DossierIdentifiantFiscale,DossierIdentifiantTVA,DossierPatente,DossierRegistreCommerce,DossierNumeroCNSS,DossierICE,DossierComptaActif,DossierGescomAtif,DossierPaieActif,DossierActif,DossierCleSecuriteCompta,DossierCleSecuritePaie,DossierCleSecuriteGescom,DossierCleSecurite")] DossiersPivot gEN_Dossiers)
        {
            
            ViewBag.IdTypeDossier = new SelectList(dossiersServise.GetingModelItem(Model1), "Id", "Libelle", gEN_Dossiers.IdTypeDossier);
            //new SelectList(db.GEN_Items.Where(e => e.GEN_Model.Model == "FormeJuridique" && e.GEN_Model.IdSociete == CurrentSocieteId), "Id", "Libelle", gEN_Dossiers.IdTypeSociete);
            // ViewBag.Pays = new SelectList(db.GEN_Items.Where(e => e.GEN_Model.Model == "Pays" && e.GEN_Model.IdSociete == CurrentSocieteId), "Id", "Libelle", gEN_Dossiers.Pays);
            ViewBag.DossierPays = new SelectList(dossiersServise.GetingModelItem(Model2), "Id", "Libelle", gEN_Dossiers.DossierPays);



            // ViewBag.IdDeviseTenueCompte = new SelectList(db.GEN_Devises.Where(e => e.IdDossier == CurrentPreference.IdDossier && e.Actif), "Id", "Code", gEN_Dossiers.IdDeviseTenueCompte);
            ViewBag.IdDeviseTenueCompte = new SelectList(devisesService.GetDeviseByCond(),  "DevisesId", "DevisesCode", gEN_Dossiers.IdDeviseTenueCompte);

            var errors = ModelState.Where(x => x.Key != "DossierId").Select(x => x.Value.Errors) .Where(y => y.Count > 0).ToList();
            if (errors.Count == 0) 
            {
               DossiersPivot gen_dossierCreer = gEN_Dossiers;
                if (gEN_Dossiers.DossierId > 0)
                {
                    // gen_dossierCreer.IdSociete = CurrentSocieteId;
                    //gen_dossierCreer.Doss = CurrentSocieteId;
                    gen_dossierCreer.DossierActif = true;
                    gen_dossierCreer.Dossiersys_user = Constantes.IdentifiantUser;
                    gen_dossierCreer.Dossiersys_dateUpdate = DateTime.Now;
                    //db.Entry(gEN_Dossiers).State = EntityState.Modified;
                    dossiersServise.UpdateDossierPivot(gen_dossierCreer);
                    dossiersServise.SaveDossiers();
                }
                else
                {
                    gen_dossierCreer  = dossiersServise.getingDossierActif();
                 
                    //db.GEN_Dossiers.Where(x => x.Actif == false && x.CodeDossier == "").FirstOrDefault();


                    if (gen_dossierCreer == null)
                    {
                        gen_dossierCreer = gEN_Dossiers;
                        gen_dossierCreer.DossierActif = true;
                        gen_dossierCreer.Dossiersys_dateCreation = DateTime.Now;
                        gen_dossierCreer.Dossiersys_dateUpdate = DateTime.Now;
                        gen_dossierCreer.Dossiersys_user = Constantes.IdentifiantUser;
                        //  gen_dossierCreer.DossierIdSociete = CurrentSocieteId;

                        // db.GEN_Dossiers.Add(gen_dossierCreer);
                        dossiersServise.CreateDossiersPivot(gen_dossierCreer);
                        dossiersServise.SaveDossiers();
                        //db.SaveChanges();
                    }
                    else
                    {
                        gen_dossierCreer.DossierActif = gEN_Dossiers.DossierActif;
                        gen_dossierCreer.DossierAdresse = gEN_Dossiers.DossierAdresse;
                        gen_dossierCreer.DossierCapitalSocial = gEN_Dossiers.DossierCapitalSocial;
                        gen_dossierCreer.DossierCleSecurite = gEN_Dossiers.DossierCleSecurite;
                        gen_dossierCreer.DossierCleSecuriteCompta = gEN_Dossiers.DossierCleSecuriteCompta;
                        gen_dossierCreer.DossierCleSecuriteGescom = gEN_Dossiers.DossierCleSecuriteGescom;
                        gen_dossierCreer.DossierCleSecuritePaie = gEN_Dossiers.DossierCleSecuritePaie;
                        gen_dossierCreer.CodeDossier = gEN_Dossiers.CodeDossier;
                        gen_dossierCreer.DossierComptaActif = gEN_Dossiers.DossierComptaActif;
                        gen_dossierCreer.DossierEmail = gEN_Dossiers.DossierEmail;
                        gen_dossierCreer.DossierFax = gEN_Dossiers.DossierFax;
                        gen_dossierCreer.DossierGescomAtif = gEN_Dossiers.DossierGescomAtif;
                        gen_dossierCreer.DossierICE = gEN_Dossiers.DossierICE;
                        gen_dossierCreer.IdDeviseTenueCompte = gEN_Dossiers.IdDeviseTenueCompte;
                        gen_dossierCreer.DossierIdentifiantFiscale = gEN_Dossiers.DossierIdentifiantFiscale;
                        gen_dossierCreer.DossierIdentifiantTVA = gEN_Dossiers.DossierIdentifiantTVA;
                        gen_dossierCreer.IdTypeDossier = gEN_Dossiers.IdTypeDossier;
                        gen_dossierCreer.DossierNumeroCNSS = gEN_Dossiers.DossierNumeroCNSS;
                        gen_dossierCreer.DossierPaieActif = gEN_Dossiers.DossierPaieActif;
                        gen_dossierCreer.DossierPatente = gEN_Dossiers.DossierPatente;
                        gen_dossierCreer.DossierPays = gEN_Dossiers.DossierPays;
                        gen_dossierCreer.DossierRaisonSociale = gEN_Dossiers.DossierRaisonSociale;
                        gen_dossierCreer.DossierRegistreCommerce = gEN_Dossiers.DossierRegistreCommerce;
                        gen_dossierCreer.DossierSiteWeb = gEN_Dossiers.DossierSiteWeb;
                        gen_dossierCreer.DossierTel = gEN_Dossiers.DossierTel;
                        gen_dossierCreer.DossierVille = gEN_Dossiers.DossierVille;
                        gen_dossierCreer.Dossiersys_dateUpdate = DateTime.Now;
                        gen_dossierCreer.Dossiersys_dateCreation = DateTime.Now;
                        gen_dossierCreer.Dossiersys_user =Constantes.IdentifiantUser;
                        //gen_dossierCreer.DossierIdSociete = CurrentSocieteId;

                        // db.Entry(gen_dossierCreer).State = EntityState.Modified;
                        dossiersServise.UpdateDossierPivot(gen_dossierCreer);
                        dossiersServise.SaveDossiers();
                    }
                }

                //db.SaveChanges();
                dossiersServise.SaveDossiers();
                  return RedirectToAction("Index");
               // return RedirectToAction("Create", new { id = gen_dossierCreer.DossierId });
            }

           
            DossierFormViewModel gEN_Doss = Mapper.Map<DossiersPivot, DossierFormViewModel>(gEN_Dossiers);
            return View(gEN_Doss);
         }







        public ActionResult SaveDataContacts()
        {
            GridModel gridModel = new GridModel();
            List<Transaction<DossiersContactsPivot>> transactions = gridModel.LoadTransactions<DossiersContactsPivot>(HttpContext.Request.Form["ig_transactions"]);
            //var orders = RepositoryFactory.GetOrderRepository();
            long idDossier = 0;
            foreach (Transaction<DossiersContactsPivot> t in transactions)
            {
                int id = 0;
                Int32.TryParse(t.rowId, out id);

                if (idDossier == 0)
                {
                    if (t.row != null)
                    {
                        long.TryParse(t.row.IdDossier.Value.ToString(), out idDossier);
                        if (idDossier == 0)
                        {
                            // var gEN_Dossiers = db.GEN_Dossiers.Where(x => x.Actif == false && x.CodeDossier == "").FirstOrDefault();
                            //  gEN_Dossiers = dossiersServise.getingDossierActif();
                            //db.GEN_Dossiers.Where(x => x.Actif == false && x.CodeDossier == "").FirstOrDefault();

                            var gEN_Dossiers = dossiersServise.getingDossierActif();
                            
                            if (gEN_Dossiers == null)
                            {
                                gEN_Dossiers = new DossiersPivot();
                                gEN_Dossiers.DossierActif = false;
                                gEN_Dossiers.CodeDossier = "";
                                gEN_Dossiers.DossierRaisonSociale = "";
                                //using (var dbIgnoreValidation = new octaEntities())
                                //{
                                //    dbIgnoreValidation.Configuration.ValidateOnSaveEnabled = false;
                                //    dbIgnoreValidation.GEN_Dossiers.Add(gEN_Dossiers);
                                //    dbIgnoreValidation.SaveChanges();
                                //}

                                dossiersServise.Validation_Db(gEN_Dossiers);
                                //private OctaEntities dbIgnoreValidation = new OctaEntities();
                                //dbIgnoreValidation.GEN_Dossiers.Add(gEN_Dossiers);
                                //dbIgnoreValidation.SaveChanges();
                            }
                            idDossier = gEN_Dossiers.DossierId;
                        }
                    }
                }


                var isToRemove = transactions.Where(e => e.rowId == t.rowId).Count() > 1;

                if (t.type == "newrow" && !isToRemove)
                {
                    t.row.IdDossier = idDossier;
                    t.row.sys_dateCreation = DateTime.Now;
                    t.row.sys_dateUpdate = DateTime.Now;
                    t.row.sys_user =Constantes.IdentifiantUser;
                    //t.row.Actif = true;
                    // db.GEN_DossiersContacts.Add(t.row);

                   dossiersContactsService.CreateDossiersContactsPivot(t.row);
                }
                else if (t.type == "deleterow")
                {
                    var row = dossiersContactsService.GetDossiersContactsPivot(id);
                        //db.GEN_DossiersContacts.Find(id);
                    if (row != null)
                    {
                        // db.GEN_DossiersContacts.Remove(row);
                        dossiersContactsService.DeleteDossiersContactsPivot(row);
                    }

                }
                else if (t.type == "row" && !isToRemove)
                {
                    var row = dossiersContactsService.GetDossiersContactsPivot(id);
                        //db.GEN_DossiersContacts.Find(id);
                    if (row == null)
                    {
                        t.row.IdDossier = idDossier;
                        t.row.sys_dateCreation = DateTime.Now;
                        t.row.sys_dateUpdate = DateTime.Now;
                        t.row.sys_user = Constantes.IdentifiantUser;
                        //t.row.Actif = true;
                        // db.GEN_DossiersContacts.Add(t.row);
                        dossiersContactsService.CreateDossiersContactsPivot(t.row);
                    }
                    else
                    {
                        row.Civilite = t.row.Civilite;
                        row.Nom = t.row.Nom;
                        row.Prenom = t.row.Prenom;
                        row.Tel = t.row.Tel;
                        row.Email = t.row.Email;
                        row.Actif = t.row.Actif;
                        row.Gsm = t.row.Gsm;
                        row.ParDefault = t.row.ParDefault;
                        t.row.sys_dateUpdate = DateTime.Now;

                        // db.Entry(row).State = EntityState.Modified;
                        dossiersContactsService.UpdateDossiersContactsPivot(row);
                    }


                }
            }

            //db.SaveChanges();
            dossiersContactsService.SaveDossiersContacts();
            JsonResult result = new JsonResult();
            Dictionary<string, bool> response = new Dictionary<string, bool>();
            response.Add("Success", true);
            result.Data = response;
            return result;
        }

        public ActionResult SaveDataSites()
        {
            GridModel gridModel = new GridModel();
            List<Transaction<DossiersSitesPivot>> transactions = gridModel.LoadTransactions<DossiersSitesPivot>(HttpContext.Request.Form["ig_transactions"]);
            //var orders = RepositoryFactory.GetOrderRepository();
            long idDossier = 0;
            foreach (Transaction<DossiersSitesPivot> t in transactions)
            {
                int id = 0;
                Int32.TryParse(t.rowId, out id);

                if (idDossier == 0)
                {
                    if (t.row != null)
                    {
                        long.TryParse(t.row.IdDossier.Value.ToString(), out idDossier);
                        if (idDossier == 0)
                        {
                            //  var gEN_Dossiers = db.GEN_Dossiers.Where(x => x.Actif == false && x.CodeDossier == "").FirstOrDefault();
                            var gEN_Dossiers = dossiersServise.getingDossierActif();
                            if (gEN_Dossiers == null)
                            {
                                gEN_Dossiers = new DossiersPivot();
                                gEN_Dossiers.DossierActif = false;
                                gEN_Dossiers.CodeDossier = "";
                                gEN_Dossiers.DossierRaisonSociale = "";
                                //using (var dbIgnoreValidation = new StoreEntities())
                                //{
                                //    dbIgnoreValidation.Configuration.ValidateOnSaveEnabled = false;
                                //    dbIgnoreValidation.Dossiers.Add();
                                //    //Add(gEN_Dossiers);
                                //    dbIgnoreValidation.SaveChanges();
                                //}
                                dossiersServise.Validation_Db(gEN_Dossiers);

                                //db.GEN_Dossiers.Add(gEN_Dossiers);
                                //db.SaveChanges();
                            }
                            idDossier = gEN_Dossiers.DossierId;
                        }

                    }

                }


                //var row = db.GEN_DossiersSites.Find(id);
                var row = dossiersSitesService.GetDossiersSitePivot(id);
                if ((t.type == "newrow") || (row == null && (t.type == "row")))
                {
                    t.row.IdDossier = idDossier;
                    t.row.sys_dateCreation = DateTime.Now;
                    t.row.sys_dateUpdate = DateTime.Now;
                    t.row.sys_user =Constantes.IdentifiantUser;
                    //t.row.Actif = true;
                    //db.GEN_DossiersSites.Add(t.row);
                    dossiersSitesService.CreateDossiersSitePivot(t.row);
                 /***/   dossiersSitesService.SaveDossiersSite();
                }
                else if (t.type == "deleterow")
                {
                    //var row = db.GEN_DossiersSites.Find(id);
                    if (row != null)
                    {
                        // db.GEN_DossiersSites.Remove(row);
                        dossiersSitesService.DeleteDossiersSitePivot(row);
                    /***/    dossiersSitesService.SaveDossiersSite();
                    }
                }
                else if (t.type == "row")
                {
                    row.Nom = t.row.Nom;
                    row.Adresse = t.row.Adresse;
                    row.ParDefault = t.row.ParDefault;
                    row.Actif = t.row.Actif;
                    row.Adresse = t.row.Adresse;
                    row.Email = t.row.Email;
                    row.Tel = t.row.Tel;
                    row.Fax = t.row.Fax;
                    //row.IdDossier = t.row.IdDossier;
                    row.Pays = t.row.Pays;
                    row.Ville = t.row.Ville;
                    t.row.sys_dateUpdate = DateTime.Now;
                    //row.Civilite = t.row.Civilite;
                    //row.Nom = t.row.Nom;
                    //row.Prenom = t.row.Prenom;
                    //row.Tel = t.row.Tel;
                    //row.Email = t.row.Email;

                    // db.Entry(row).State = EntityState.Modified;
                    dossiersSitesService.UpdateDossierSitePivot(row);
                    /****/
                    dossiersSitesService.SaveDossiersSite();
                }
            }

            // db.SaveChanges();
            dossiersSitesService.SaveDossiersSite();
             JsonResult result = new JsonResult();
            Dictionary<string, bool> response = new Dictionary<string, bool>();
            response.Add("Success", true);
            result.Data = response;
            return result;
        }



        // GET: Commun/Dossiers/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DossiersPivot gEN_Dossiers = dossiersServise.GetDossiersPivot(id);
                //db.GEN_Dossiers.Find(id);

            ViewBag.IdTypeDossier = new SelectList(dossiersServise.GetingModelItem(Model1), "Id", "Libelle", gEN_Dossiers.IdTypeDossier);
            //db.GEN_Items.Where(e => e.GEN_Model.Model == "FormeJuridique" && e.GEN_Model.IdSociete == CurrentSocieteId), "Id", "Libelle", gEN_Dossiers.IdTypeSociete);
            ViewBag.DossierPays = new SelectList(dossiersServise.GetingModelItem(Model2), "Id", "Libelle", gEN_Dossiers.DossierPays);
            //db.GEN_Items.Where(e => e.GEN_Model.Model == "Pays" && e.GEN_Model.IdSociete == CurrentSocieteId), "Id", "Libelle", gEN_Dossiers.Pays);
            ViewBag.IdDeviseTenueCompte = new SelectList(devisesService.GetDeviseByCond(), "DevisesId", "DevisesCode", gEN_Dossiers.IdDeviseTenueCompte);
            //db.GEN_Devises.Where(e => e.IdDossier == CurrentPreference.IdDossier && e.Actif), "Id", "Code", gEN_Dossiers.IdDeviseTenueCompte);
            if (gEN_Dossiers == null)
            {
                return HttpNotFound();
            }
            return View(gEN_Dossiers);
        }

        // GET: Commun/Dossiers/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DossiersPivot gEN_Dossiers = dossiersServise.GetDossiersPivot(id);
                //db.GEN_Dossiers.Find(id);
            if (gEN_Dossiers == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdSociete = new SelectList(dossiersServise.GetDossier(), "DossierId", "DossierRaisonSociale", gEN_Dossiers.DossierId);

            return View(gEN_Dossiers);
        }

        // POST: Commun/Dossiers/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DossierId,CodeDossier,DossierRaisonSociale,IdTypeDossier,DossierAdresse,DossierTel,DossierFax,DossierEmail,DossierVille,DossierPays,DossierSiteWeb,DossierCapitalSocial,IdDeviseTenueCompte,DossierIdentifiantFiscale,DossierIdentifiantTVA,DossierPatente,DossierRegistreCommerce,DossierNumeroCNSS,DossierICE,DossierComptaActif,DossierGescomAtif,DossierPaieActif,DossierActif,DossierCleSecuriteCompta,DossierCleSecuritePaie,DossierCleSecuriteGescom,DossierCleSecurite")] DossiersPivot gEN_Dossiers)
        {
            if (ModelState.IsValid)
            {
                // db.Entry(gEN_Dossiers).State = EntityState.Modified;
                dossiersServise.UpdateDossierPivot(gEN_Dossiers);
                //   db.SaveChanges();
                dossiersServise.SaveDossiers();
                return RedirectToAction("Index");
            }
            ViewBag.IdSociete = new SelectList(dossiersServise.GetDossier(), "DossierId", "DossierRaisonSociale", gEN_Dossiers.DossierId);
            //db.GEN_Societes, "Id", "RaisonSociale", gEN_Dossiers.IdSociete);
            return View(gEN_Dossiers);
        }

        // GET: Commun/Dossiers/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DossiersPivot gEN_Dossiers = dossiersServise.GetDossiersPivot(id);
                //db.GEN_Dossiers.Find(id);
            ViewBag.IdTypeDossier = new SelectList(dossiersServise.GetingModelItem(Model1), "Id", "Libelle", gEN_Dossiers.IdTypeDossier);
            //db.GEN_Items.Where(e => e.GEN_Model.Model == "FormeJuridique" && e.GEN_Model.IdSociete == CurrentSocieteId), "Id", "Libelle", gEN_Dossiers.IdTypeSociete);
            ViewBag.DossierPays = new SelectList(dossiersServise.GetingModelItem(Model2), "Id", "Libelle", gEN_Dossiers.IdTypeDossier);
            //db.GEN_Items.Where(e => e.GEN_Model.Model == "Pays" && e.GEN_Model.IdSociete == CurrentSocieteId), "Id", "Libelle", gEN_Dossiers.Pays);
            ViewBag.IdDeviseTenueCompte = new SelectList(devisesService.GetDeviseByCond(), "DevisesId", "DevisesCode", gEN_Dossiers.IdDeviseTenueCompte);
            //db.GEN_Devises.Where(e => e.IdDossier == CurrentPreference.IdDossier), "Id", "Code", gEN_Dossiers.IdDeviseTenueCompte);
            if (gEN_Dossiers == null)
            {
                return HttpNotFound();
            }
            return View(gEN_Dossiers);
        }

        // POST: Commun/Dossiers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed([Bind(Include = "DossierId")] DossierFormViewModel gEN_dossiers)
        {
            DossiersPivot gEN_Dossiers = dossiersServise.GetDossiersPivot(gEN_dossiers.DossierId);

            //db.GEN_Dossiers.Find(id);
            //var test = from b in db.CPT_Pieces where b.IdDossier == gEN_Dossiers.Id select b;
            var test = dossiersServise.GetCPT_Piece(gEN_Dossiers.DossierId);
            if (test.Count() > 0)
            {
                TempData["errorMessage"] = "Vous ne pouvez pas supprimer ce dossier car une pièce est crée dans ce dossier ";
                return RedirectToAction("Create", new { id = gEN_Dossiers.DossierId });
            }
            else
            {

                //db.GEN_Dossiers.Remove(gEN_Dossiers);
                dossiersServise.DeleteDossiersPivot(gEN_Dossiers);
                // db.SaveChanges();
                dossiersServise.SaveDossiers();
                return RedirectToAction("Index");

            }

        }

        // GET: Commun/Dossiers/ChangeCurrentDossier/5
       

       





















    }
}




