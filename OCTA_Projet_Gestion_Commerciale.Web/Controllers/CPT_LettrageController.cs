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
    public class CPT_LettrageController : Controller
    {
        private readonly ILettrageService LettrageServise;
        private readonly IDossiersService dossiersService;

        public CPT_LettrageController(ILettrageService LettrageServise, IDossiersService dossiersService)
        {
            this.LettrageServise = LettrageServise;
            this.dossiersService = dossiersService;
        }

        public ActionResult Index()
        {
            var Lettrage = LettrageServise.GetALL();

            IEnumerable<CPT_LettrageViewModel> Lettrage_Views = Mapper.Map<IEnumerable<LettragePivot>, IEnumerable<CPT_LettrageViewModel>>(Lettrage);

            return View(Lettrage_Views.AsQueryable());


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
                var cpt_Lettrage = LettrageServise.GetLettrage((int)id);
                if (cpt_Lettrage == null)
                {

                    TempData["errorMessage"] = "Le lettrage que vous cherchez n'existe pas.";
                    return RedirectToAction("Index");
                }
                //  ViewBag.IdDossier = new SelectList(db.GEN_Dossiers.Where(e => e.Actif), "Id", "CodeDossier", gEN_Devises.IdDossier);
             //   ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier");
                CPT_LettrageFormViewModel cpt_LettrageFormModel = Mapper.Map<LettragePivot, CPT_LettrageFormViewModel>(cpt_Lettrage);
                return View(cpt_LettrageFormModel);
            }

        }





        // POST: Commun/Devises/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdEcheance,MontantRegle,CodeLettrage,DateLettrage")] LettragePivot cpt_Lettrage)
        {



            // if (ModelState.IsValid)
            if (cpt_Lettrage != null)
            {
                if (cpt_Lettrage.Id > 0)
                {
                    // cpt_Lettrage.IdDossier = Constantes.IdentifiantDossier;
                    cpt_Lettrage.sys_dateUpdate = DateTime.Now;
                    cpt_Lettrage.sys_dateCreation = DateTime.Now;
                    cpt_Lettrage.sys_user = Constantes.IdentifiantUser;
                    cpt_Lettrage.IdEcheance = null;
                    LettrageServise.UpdateLettragePivot(cpt_Lettrage);
                    LettrageServise.SaveLettragePivot();
                }
                else
                {


                    cpt_Lettrage.sys_dateUpdate = DateTime.Now;
                    cpt_Lettrage.sys_dateCreation = DateTime.Now;
                    cpt_Lettrage.sys_user = Constantes.IdentifiantUser;
                    cpt_Lettrage.IdEcheance = null;

                    LettrageServise.CreateLettragePivot(cpt_Lettrage);
                    LettrageServise.SaveLettragePivot();
                }


                return RedirectToAction("Index");
            }



           // ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier", cpt_Journaux.IdDossier);
            CPT_LettrageFormViewModel cpt_LettrageFormModel = Mapper.Map<LettragePivot, CPT_LettrageFormViewModel>(cpt_Lettrage);
            return View(cpt_LettrageFormModel);
        }



        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // DevisesPivot gEN_Devises = deviseServise.GetDevise(id);
           LettragePivot cpt_Lettrage = LettrageServise.GetLettrage((int)id);
            //db.GEN_Devises.Find(id);
            if (cpt_Lettrage == null)
            {
                return HttpNotFound();
            }
            // ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier", cpt_Journaux.IdDossier);
            //db.GEN_Dossiers.Where(e => e.Actif), "Id", "CodeDossier", gEN_Devises.IdDossier);

            CPT_LettrageFormViewModel cpt_LettrageFormModel = Mapper.Map<LettragePivot, CPT_LettrageFormViewModel>(cpt_Lettrage);
            return View(cpt_LettrageFormModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdEcheance,MontantRegle,CodeLettrage,DateLettrage")] LettragePivot cpt_Lettrage)
        {

            if (ModelState.IsValid)
            {
               // cpt_Lettrage.IdDossier = Constantes.IdentifiantDossier;
                cpt_Lettrage.sys_dateUpdate = DateTime.Now;
                cpt_Lettrage.sys_dateCreation = DateTime.Now;
                cpt_Lettrage.sys_user = Constantes.IdentifiantUser;
                cpt_Lettrage.IdEcheance = null;
                LettrageServise.UpdateLettragePivot(cpt_Lettrage);
                //   db.SaveChanges();
                LettrageServise.SaveLettragePivot();
                return RedirectToAction("Index");
            }
           // ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier", cpt_Journaux.IdDossier);
            //db.GEN_Dossiers.Where(e => e.Actif), "Id", "CodeDossier", gEN_Devises.IdDossier);

            CPT_LettrageFormViewModel cpt_LettrageFormModel = Mapper.Map<LettragePivot, CPT_LettrageFormViewModel>(cpt_Lettrage);
            return View(cpt_LettrageFormModel);

        }


        public ActionResult Delete(long? id)
        {
            //ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier");
            //db.GEN_Dossiers.Where(e => e.Actif), "Id", "CodeDossier");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LettragePivot cpt_Lettrage = LettrageServise.GetLettrage((int)id);
            //db.GEN_Devises.Find(id);
            if (cpt_Lettrage == null)
            {
                return HttpNotFound();
            }

            CPT_LettrageFormViewModel cpt_codd = Mapper.Map<LettragePivot, CPT_LettrageFormViewModel>(cpt_Lettrage);
            return View(cpt_codd);
        }




        // POST: Commun/TypePaiement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed([Bind(Include = "Id")] CPT_LettrageFormViewModel cpt_Lettrage)
        {
           LettragePivot cods = Mapper.Map<CPT_LettrageFormViewModel, LettragePivot>(cpt_Lettrage);
            LettragePivot codes = LettrageServise.GetLettrage(cods.Id);


            LettrageServise.DeletLettragePivot(codes);
            // db.SaveChanges();
            LettrageServise.SaveLettragePivot();
            return RedirectToAction("Index");



        }


    }
}