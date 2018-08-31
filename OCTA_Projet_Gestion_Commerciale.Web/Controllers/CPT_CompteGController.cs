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
    public class CPT_CompteGController : Controller
    {
        private readonly ICompteGService compteGServise;
        private readonly IDossiersService dossiersService;

        public CPT_CompteGController(ICompteGService compteGServise, IDossiersService dossiersService)
        {
            this.compteGServise = compteGServise;
            this.dossiersService = dossiersService;
        }

        public ActionResult Index()
        {
            var comptes = compteGServise.GetALL();

            IEnumerable<CPT_CompteGViewModel> comptes_Views = Mapper.Map<IEnumerable<CompteGPivot>, IEnumerable<CPT_CompteGViewModel>>(comptes);

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
                var cpt_Comptes = compteGServise.GetCompteG((int)id);
                if (cpt_Comptes == null)
                {

                    TempData["errorMessage"] = "Le compte G que vous cherchez n'existe pas.";
                    return RedirectToAction("Index");
                }
                //  ViewBag.IdDossier = new SelectList(db.GEN_Dossiers.Where(e => e.Actif), "Id", "CodeDossier", gEN_Devises.IdDossier);
                ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier", cpt_Comptes.IdDossier);
                CPT_CompteGFormViewModel cpt_ComptesFormModel = Mapper.Map<CompteGPivot, CPT_CompteGFormViewModel>(cpt_Comptes);
                return View(cpt_ComptesFormModel);
            }

        }





        // POST: Commun/Devises/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Code,Libelle,IdClasse,IdTypeCompte,IdNatureCompte,IdCodeTvaDefault,Ana,Rappro,Lettrage,Pointage,Sens,Actif,SuiviCompteTVA,ReportANouveau,IdDossier")] CompteGPivot cpt_comptes)
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
                    cpt_comptes.IdCodeTvaDefault = null;
                    cpt_comptes.IdClasse = 1;
                    
                    compteGServise.UpdateCompteGPivot(cpt_comptes);
                    compteGServise.SaveCompteGPivot();
                }
                else
                {
                    
                    cpt_comptes.IdDossier = Constantes.IdentifiantDossier;
                    cpt_comptes.sys_dateUpdate = DateTime.Now;
                    cpt_comptes.sys_dateCreation = DateTime.Now;
                    cpt_comptes.sys_user = Constantes.IdentifiantUser;
                    cpt_comptes.IdCodeTvaDefault = null;
                    cpt_comptes.IdClasse = 1;

                    cpt_comptes.Actif = true;
                 

                    compteGServise.CreateCompteGPivot(cpt_comptes);
                    compteGServise.SaveCompteGPivot();
                }

              
                return RedirectToAction("Index");
            }

            

            ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier", cpt_comptes.IdDossier);
            CPT_CompteGFormViewModel cpt_comptsFormModel = Mapper.Map<CompteGPivot, CPT_CompteGFormViewModel>(cpt_comptes);
            return View(cpt_comptsFormModel);
        }



        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // DevisesPivot gEN_Devises = deviseServise.GetDevise(id);
            CompteGPivot cpt_compte = compteGServise.GetCompteG((int)id);
            //db.GEN_Devises.Find(id);
            if (cpt_compte == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier", cpt_compte.IdDossier);
            //db.GEN_Dossiers.Where(e => e.Actif), "Id", "CodeDossier", gEN_Devises.IdDossier);

            CPT_CompteGFormViewModel cpt_compteFormModel = Mapper.Map<CompteGPivot, CPT_CompteGFormViewModel>(cpt_compte);
            return View(cpt_compteFormModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Code,Libelle,IdClasse,IdTypeCompte,IdNatureCompte,IdCodeTvaDefault,Ana,Rappro,Lettrage,Pointage,Sens,Actif,SuiviCompteTVA,ReportANouveau,IdDossier")] CompteGPivot cpt_compteG)
        {

            if (ModelState.IsValid)
            {
                cpt_compteG.IdDossier = Constantes.IdentifiantDossier;
                cpt_compteG.sys_dateUpdate = DateTime.Now;
                cpt_compteG.sys_dateCreation = DateTime.Now;
                cpt_compteG.sys_user = Constantes.IdentifiantUser;
                compteGServise.UpdateCompteGPivot(cpt_compteG);
                //   db.SaveChanges();
                compteGServise.SaveCompteGPivot();
                return RedirectToAction("Index");
            }
            ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier", cpt_compteG.IdDossier);
            //db.GEN_Dossiers.Where(e => e.Actif), "Id", "CodeDossier", gEN_Devises.IdDossier);

            CPT_CompteGFormViewModel cpt_compteGFormModel = Mapper.Map<CompteGPivot, CPT_CompteGFormViewModel>(cpt_compteG);
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
            CompteGPivot cpt_compte = compteGServise.GetCompteG((int)id);
            //db.GEN_Devises.Find(id);
            if (cpt_compte == null)
            {
                return HttpNotFound();
            }

            CPT_CompteGFormViewModel cpt_codd = Mapper.Map<CompteGPivot, CPT_CompteGFormViewModel>(cpt_compte);
            return View(cpt_codd);
        }




        // POST: Commun/TypePaiement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed([Bind(Include = "Id")] CPT_CompteGFormViewModel cpt_calsses)
        {
            CompteGPivot cods = Mapper.Map<CPT_CompteGFormViewModel, CompteGPivot>(cpt_calsses);
            CompteGPivot codes = compteGServise.GetCompteG(cods.Id);


            compteGServise.DeletCompteGPivot(codes);
            // db.SaveChanges();
            compteGServise.SaveCompteGPivot();
            return RedirectToAction("Index");



        }


    }
}