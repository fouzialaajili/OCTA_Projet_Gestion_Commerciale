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
    public class CPT_CompteGDetailTVAController : Controller
    {
        private readonly ICompteGDetailTVAService compteGServise;
        private readonly IDossiersService dossiersService;

        public CPT_CompteGDetailTVAController(ICompteGDetailTVAService compteGServise, IDossiersService dossiersService)
        {
            this.compteGServise = compteGServise;
            this.dossiersService = dossiersService;
        }

        public ActionResult Index()
        {
            var comptes = compteGServise.GetALL();

            IEnumerable<CPT_CompteGDetailTVAViewModel> comptes_Views = Mapper.Map<IEnumerable<CompteGDetailTVAPivot>, IEnumerable<CPT_CompteGDetailTVAViewModel>>(comptes);

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
                var cpt_Comptes = compteGServise.GetCompteGDetailTVA((int)id);
                if (cpt_Comptes == null)
                {

                    TempData["errorMessage"] = "Le compte G que vous cherchez n'existe pas.";
                    return RedirectToAction("Index");
                }
                //  ViewBag.IdDossier = new SelectList(db.GEN_Dossiers.Where(e => e.Actif), "Id", "CodeDossier", gEN_Devises.IdDossier);
              //  ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier", cpt_Comptes.IdDossier);
                CPT_CompteGDetailTVAFormViewModel cpt_ComptesFormModel = Mapper.Map<CompteGDetailTVAPivot, CPT_CompteGDetailTVAFormViewModel>(cpt_Comptes);
                return View(cpt_ComptesFormModel);
            }

        }





        // POST: Commun/Devises/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdCompteGenerale,TauxTva,Percue,Exonere,IdCompteG,IdCodeTVA")]CompteGDetailTVAPivot cpt_comptes)
        {



            // if (ModelState.IsValid)
            if (cpt_comptes != null)
            {
                if (cpt_comptes.Id > 0)
                {
                   // cpt_comptes.IdDossier = Constantes.IdentifiantDossier;
                    cpt_comptes.sys_dateUpdate = DateTime.Now;
                    cpt_comptes.sys_dateCreation = DateTime.Now;
                    cpt_comptes.sys_user = Constantes.IdentifiantUser;
                    cpt_comptes.IdCodeTVA = null;


                    compteGServise.UpdateCompteGDetailTVAPivot(cpt_comptes);
                    compteGServise.SaveCompteGDetailTVAPivot();
                }
                else
                {

                   // cpt_comptes.IdDossier = Constantes.IdentifiantDossier;
                    cpt_comptes.sys_dateUpdate = DateTime.Now;
                    cpt_comptes.sys_dateCreation = DateTime.Now;
                    cpt_comptes.sys_user = Constantes.IdentifiantUser;
                    cpt_comptes.IdCodeTVA = null;
                    


                    compteGServise.CreateCompteGDetailTVAPivot(cpt_comptes);
                    compteGServise.SaveCompteGDetailTVAPivot();
                }


                return RedirectToAction("Index");
            }



            //  ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier");
            CPT_CompteGDetailTVAFormViewModel cpt_comptsFormModel = Mapper.Map<CompteGDetailTVAPivot, CPT_CompteGDetailTVAFormViewModel>(cpt_comptes);
            return View(cpt_comptsFormModel);
        }



        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // DevisesPivot gEN_Devises = deviseServise.GetDevise(id);
            CompteGDetailTVAPivot cpt_compte = compteGServise.GetCompteGDetailTVA((int)id);
            //db.GEN_Devises.Find(id);
            if (cpt_compte == null)
            {
                return HttpNotFound();
            }
            //ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier");
            //db.GEN_Dossiers.Where(e => e.Actif), "Id", "CodeDossier", gEN_Devises.IdDossier);

            CPT_CompteGDetailTVAFormViewModel cpt_compteFormModel = Mapper.Map<CompteGDetailTVAPivot, CPT_CompteGDetailTVAFormViewModel>(cpt_compte);
            return View(cpt_compteFormModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdCompteGenerale,TauxTva,Percue,Exonere,IdCompteG,IdCodeTVA")] CompteGDetailTVAPivot cpt_compteG)
        {

            if (ModelState.IsValid)
            {
               
                cpt_compteG.sys_dateUpdate = DateTime.Now;
                cpt_compteG.sys_dateCreation = DateTime.Now;
                cpt_compteG.sys_user = Constantes.IdentifiantUser;
                cpt_compteG.IdCodeTVA = null;
                compteGServise.UpdateCompteGDetailTVAPivot(cpt_compteG);
                //   db.SaveChanges();
                compteGServise.SaveCompteGDetailTVAPivot();
                return RedirectToAction("Index");
            }
            // ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier");
            //db.GEN_Dossiers.Where(e => e.Actif), "Id", "CodeDossier", gEN_Devises.IdDossier);

            CPT_CompteGDetailTVAFormViewModel cpt_compteGFormModel = Mapper.Map<CompteGDetailTVAPivot, CPT_CompteGDetailTVAFormViewModel>(cpt_compteG);
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
            CompteGDetailTVAPivot cpt_compte = compteGServise.GetCompteGDetailTVA((int)id);
            //db.GEN_Devises.Find(id);
            if (cpt_compte == null)
            {
                return HttpNotFound();
            }

            CPT_CompteGDetailTVAFormViewModel cpt_codd = Mapper.Map<CompteGDetailTVAPivot, CPT_CompteGDetailTVAFormViewModel>(cpt_compte);
            return View(cpt_codd);
        }




        // POST: Commun/TypePaiement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed([Bind(Include = "Id")] CPT_CompteGDetailTVAFormViewModel cpt_calsses)
        {
            CompteGDetailTVAPivot cods = Mapper.Map<CPT_CompteGDetailTVAFormViewModel, CompteGDetailTVAPivot>(cpt_calsses);
            CompteGDetailTVAPivot codes = compteGServise.GetCompteGDetailTVA(cods.Id);


            compteGServise.DeletCompteGDetailTVAPivot(codes);
            // db.SaveChanges();
            compteGServise.SaveCompteGDetailTVAPivot();
            return RedirectToAction("Index");



        }


    }
}