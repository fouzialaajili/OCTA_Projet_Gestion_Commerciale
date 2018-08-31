using AutoMapper;
using OCTA_Projet_Gestion_Commerciale.Data.Utils;
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
    public class CPT_ComptesBancairesTiersController : Controller
    {
        private readonly IComptesBancairesTiersService compteBancaireServise;
        private readonly IDossiersService dossiersService;

        public CPT_ComptesBancairesTiersController(IComptesBancairesTiersService compteBancaireServise, IDossiersService dossiersService)
        {
            this.compteBancaireServise = compteBancaireServise;
            this.dossiersService = dossiersService;
        }

        public ActionResult Index()
        {
            var comptes = compteBancaireServise.GetALL();

            IEnumerable<CPT_ComptesBancairesTiersViewModel> comptes_Views = Mapper.Map<IEnumerable<ComptesBancairesTiersPivot>, IEnumerable<CPT_ComptesBancairesTiersViewModel>>(comptes);

            return View(comptes_Views.AsQueryable());


        }




        public ActionResult Create(long? id)
        {
            if (id == null)
            {
                //  ViewBag.IdDossier = new SelectList(GEN_Dossiers.Where(e => e.Actif), "Id", "CodeDossier");
                ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier");
                return View();
            }
            else
            {
                // GEN_Devises gEN_Devises = db.GEN_Devises.Find(id);
                var cpt_Comptes = compteBancaireServise.GetComptesBancairesTiers((int)id);
                if (cpt_Comptes == null)
                {

                    TempData["errorMessage"] = "Le compte G que vous cherchez n'existe pas.";
                    return RedirectToAction("Index");
                }
                //  ViewBag.IdDossier = new SelectList(db.GEN_Dossiers.Where(e => e.Actif), "Id", "CodeDossier", gEN_Devises.IdDossier);
              //  ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier");
                CPT_ComptesBancairesTiersFormViewModel cpt_ComptesFormModel = Mapper.Map<ComptesBancairesTiersPivot, CPT_ComptesBancairesTiersFormViewModel>(cpt_Comptes);
                return View(cpt_ComptesFormModel);
            }

        }





        // POST: Commun/Devises/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdBanque,NomAgence,Adresse,Contact,Tel,RIB,Actif,ParDefault,IdCompteG,IdDevise,IdTiers")] ComptesBancairesTiersPivot cpt_comptes)
        {



            // if (ModelState.IsValid)
            if (cpt_comptes != null)
            {
                if (cpt_comptes.Id > 0)
                {
                  
                    cpt_comptes.sys_dateUpdate = DateTime.Now;
                    cpt_comptes.sys_dateCreation = DateTime.Now;
                    cpt_comptes.sys_user = Constantes.IdentifiantUser;
                    cpt_comptes.Actif = true;
               

                    compteBancaireServise.UpdateComptesBancairesTiersPivot(cpt_comptes);
                    compteBancaireServise.SaveComptesBancairesTiersPivot();
                }
                else
                {

                   
                    cpt_comptes.sys_dateUpdate = DateTime.Now;
                    cpt_comptes.sys_dateCreation = DateTime.Now;
                    cpt_comptes.sys_user = Constantes.IdentifiantUser;

                  
                    cpt_comptes.Actif = true;


                    compteBancaireServise.CreateComptesBancairesTiersPivot(cpt_comptes);
                    compteBancaireServise.SaveComptesBancairesTiersPivot();
                }


                return RedirectToAction("Index");
            }



           // ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier", cpt_comptes.IdDossier);
            CPT_ComptesBancairesTiersFormViewModel cpt_comptsFormModel = Mapper.Map<ComptesBancairesTiersPivot, CPT_ComptesBancairesTiersFormViewModel>(cpt_comptes);
            return View(cpt_comptsFormModel);
        }



        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // DevisesPivot gEN_Devises = deviseServise.GetDevise(id);
            ComptesBancairesTiersPivot cpt_compte = compteBancaireServise.GetComptesBancairesTiers((int)id);
            //db.GEN_Devises.Find(id);
            if (cpt_compte == null)
            {
                return HttpNotFound();
            }
           // ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier", cpt_compte.IdDossier);
            //db.GEN_Dossiers.Where(e => e.Actif), "Id", "CodeDossier", gEN_Devises.IdDossier);

            CPT_ComptesBancairesTiersFormViewModel cpt_compteFormModel = Mapper.Map<ComptesBancairesTiersPivot, CPT_ComptesBancairesTiersFormViewModel>(cpt_compte);
            return View(cpt_compteFormModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdBanque,NomAgence,Adresse,Contact,Tel,RIB,Actif,ParDefault,IdCompteG,IdDevise,IdTiers")] ComptesBancairesTiersPivot cpt_compteG)
        {

            if (ModelState.IsValid)
            {
            
                cpt_compteG.sys_dateUpdate = DateTime.Now;
                cpt_compteG.sys_dateCreation = DateTime.Now;
                cpt_compteG.sys_user = Constantes.IdentifiantUser;
                compteBancaireServise.UpdateComptesBancairesTiersPivot(cpt_compteG);
                //   db.SaveChanges();
                compteBancaireServise.SaveComptesBancairesTiersPivot();
                return RedirectToAction("Index");
            }
           // ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier", cpt_compteG.IdDossier);
            //db.GEN_Dossiers.Where(e => e.Actif), "Id", "CodeDossier", gEN_Devises.IdDossier);

            CPT_ComptesBancairesTiersFormViewModel cpt_compteGFormModel = Mapper.Map<ComptesBancairesTiersPivot, CPT_ComptesBancairesTiersFormViewModel>(cpt_compteG);
            return View(cpt_compteGFormModel);

        }


        public ActionResult Delete(long? id)
        {
            ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier");
            //db.GEN_Dossiers.Where(e => e.Actif), "Id", "CodeDossier");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComptesBancairesTiersPivot cpt_compte = compteBancaireServise.GetComptesBancairesTiers((int)id);
            //db.GEN_Devises.Find(id);
            if (cpt_compte == null)
            {
                return HttpNotFound();
            }

            CPT_ComptesBancairesTiersFormViewModel cpt_codd = Mapper.Map<ComptesBancairesTiersPivot, CPT_ComptesBancairesTiersFormViewModel>(cpt_compte);
            return View(cpt_codd);
        }




        // POST: Commun/TypePaiement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed([Bind(Include = "Id")] CPT_ComptesBancairesTiersFormViewModel cpt_calsses)
        {
            ComptesBancairesTiersPivot cods = Mapper.Map<CPT_ComptesBancairesTiersFormViewModel, ComptesBancairesTiersPivot>(cpt_calsses);
            ComptesBancairesTiersPivot codes = compteBancaireServise.GetComptesBancairesTiers(cods.Id);


            compteBancaireServise.DeletComptesBancairesTiersPivot(codes);
            // db.SaveChanges();
            compteBancaireServise.SaveComptesBancairesTiersPivot();
            return RedirectToAction("Index");



        }


    }
}