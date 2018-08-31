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
    public class CPT_ComptesBancairesController : Controller
    {
        private readonly IComptesBancairesService compteBancaireServise;
        private readonly IDossiersService dossiersService;

        public CPT_ComptesBancairesController(IComptesBancairesService compteBancaireServise, IDossiersService dossiersService)
        {
            this.compteBancaireServise = compteBancaireServise;
            this.dossiersService = dossiersService;
        }

        public ActionResult Index()
        {
            var comptes = compteBancaireServise.GetALL();

            IEnumerable<CPT_ComptesBancairesViewModel> comptes_Views = Mapper.Map<IEnumerable<ComptesBancairesPivot>, IEnumerable<CPT_ComptesBancairesViewModel>>(comptes);

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
                var cpt_Comptes = compteBancaireServise.GetComptesBancaires((int)id);
                if (cpt_Comptes == null)
                {

                    TempData["errorMessage"] = "Le compte G que vous cherchez n'existe pas.";
                    return RedirectToAction("Index");
                }
                //  ViewBag.IdDossier = new SelectList(db.GEN_Dossiers.Where(e => e.Actif), "Id", "CodeDossier", gEN_Devises.IdDossier);
                ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier", cpt_Comptes.IdDossier);
                CPT_ComptesBancairesFormViewModel cpt_ComptesFormModel = Mapper.Map<ComptesBancairesPivot, CPT_ComptesBancairesFormViewModel>(cpt_Comptes);
                return View(cpt_ComptesFormModel);
            }

        }





        // POST: Commun/Devises/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdBanque,NomAgence,Adresse,Contact,Tel,RIB,Actif,ParDefault,IdCompteG,IdDevise,IdDossier,GEN_Items_Id")] ComptesBancairesPivot cpt_comptes)
        {



            // if (ModelState.IsValid)
            if (cpt_comptes != null)
            {
                if (cpt_comptes.Id > 0)
                {
                    cpt_comptes.IdDossier = Constantes.IdentifiantDossier;
                    cpt_comptes.sys_dateUpdate = DateTime.Now;
                    cpt_comptes.sys_dateCreation = DateTime.Now;
                    cpt_comptes.sys_user = Constantes.IdentifiantUser;
                    cpt_comptes.Actif = true;
                    cpt_comptes.ParDefault = true;

                    compteBancaireServise.UpdateComptesBancairesPivot(cpt_comptes);
                    compteBancaireServise.SaveComptesBancairesPivot();
                }
                else
                {

                    cpt_comptes.IdDossier = Constantes.IdentifiantDossier;
                    cpt_comptes.sys_dateUpdate = DateTime.Now;
                    cpt_comptes.sys_dateCreation = DateTime.Now;
                    cpt_comptes.sys_user = Constantes.IdentifiantUser;

                    cpt_comptes.ParDefault = true;
                    cpt_comptes.Actif = true;


                    compteBancaireServise.CreateComptesBancairesPivot(cpt_comptes);
                    compteBancaireServise.SaveComptesBancairesPivot();
                }


                return RedirectToAction("Index");
            }



            ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier", cpt_comptes.IdDossier);
            CPT_ComptesBancairesFormViewModel cpt_comptsFormModel = Mapper.Map<ComptesBancairesPivot, CPT_ComptesBancairesFormViewModel>(cpt_comptes);
            return View(cpt_comptsFormModel);
        }



        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // DevisesPivot gEN_Devises = deviseServise.GetDevise(id);
            ComptesBancairesPivot cpt_compte = compteBancaireServise.GetComptesBancaires((int)id);
            //db.GEN_Devises.Find(id);
            if (cpt_compte == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier", cpt_compte.IdDossier);
            //db.GEN_Dossiers.Where(e => e.Actif), "Id", "CodeDossier", gEN_Devises.IdDossier);

            CPT_ComptesBancairesFormViewModel cpt_compteFormModel = Mapper.Map<ComptesBancairesPivot, CPT_ComptesBancairesFormViewModel>(cpt_compte);
            return View(cpt_compteFormModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdBanque,NomAgence,Adresse,Contact,Tel,RIB,Actif,ParDefault,IdCompteG,IdDevise,IdDossier,GEN_Items_Id")] ComptesBancairesPivot cpt_compteG)
        {

            if (ModelState.IsValid)
            {
                cpt_compteG.IdDossier = Constantes.IdentifiantDossier;
                cpt_compteG.sys_dateUpdate = DateTime.Now;
                cpt_compteG.sys_dateCreation = DateTime.Now;
                cpt_compteG.sys_user = Constantes.IdentifiantUser;
                compteBancaireServise.UpdateComptesBancairesPivot(cpt_compteG);
                //   db.SaveChanges();
                compteBancaireServise.SaveComptesBancairesPivot();
                return RedirectToAction("Index");
            }
            ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier", cpt_compteG.IdDossier);
            //db.GEN_Dossiers.Where(e => e.Actif), "Id", "CodeDossier", gEN_Devises.IdDossier);

            CPT_ComptesBancairesFormViewModel cpt_compteGFormModel = Mapper.Map<ComptesBancairesPivot, CPT_ComptesBancairesFormViewModel>(cpt_compteG);
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
            ComptesBancairesPivot cpt_compte = compteBancaireServise.GetComptesBancaires((int)id);
            //db.GEN_Devises.Find(id);
            if (cpt_compte == null)
            {
                return HttpNotFound();
            }

            CPT_ComptesBancairesFormViewModel cpt_codd = Mapper.Map<ComptesBancairesPivot, CPT_ComptesBancairesFormViewModel>(cpt_compte);
            return View(cpt_codd);
        }




        // POST: Commun/TypePaiement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed([Bind(Include = "Id")] CPT_ComptesBancairesFormViewModel cpt_calsses)
        {
            ComptesBancairesPivot cods = Mapper.Map<CPT_ComptesBancairesFormViewModel, ComptesBancairesPivot>(cpt_calsses);
            ComptesBancairesPivot codes = compteBancaireServise.GetComptesBancaires(cods.Id);


            compteBancaireServise.DeletComptesBancairesPivot(codes);
            // db.SaveChanges();
            compteBancaireServise.SaveComptesBancairesPivot();
            return RedirectToAction("Index");



        }


    }
}