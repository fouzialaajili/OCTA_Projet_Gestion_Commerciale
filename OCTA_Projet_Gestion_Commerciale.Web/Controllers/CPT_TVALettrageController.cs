using AutoMapper;
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
    public class CPT_TVALettrageController : Controller
    {
        private readonly ITVALettrageService LettrageServise;
        private readonly IDossiersService dossiersService;

        public CPT_TVALettrageController(ITVALettrageService LettrageServise, IDossiersService dossiersService)
        {
            this.LettrageServise = LettrageServise;
            this.dossiersService = dossiersService;
        }

        public ActionResult Index()
        {
            var Lettrage = LettrageServise.GetALL();

            IEnumerable<CPT_TVALettrageViewModel> Lettrage_Views = Mapper.Map<IEnumerable<TVALettragePivot>, IEnumerable<CPT_TVALettrageViewModel>>(Lettrage);

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
                var cpt_Lettrage = LettrageServise.GetTVALettrage((int)id);
                if (cpt_Lettrage == null)
                {

                    TempData["errorMessage"] = "Le lettrage que vous cherchez n'existe pas.";
                    return RedirectToAction("Index");
                }
               //ViewBag.IdDossier = new SelectList(db.GEN_Dossiers.Where(e => e.Actif), "Id", "CodeDossier", gEN_Devises.IdDossier);
                //   ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier");
                CPT_TVALettrageFormViewModel cpt_LettrageFormModel = Mapper.Map<TVALettragePivot, CPT_TVALettrageFormViewModel>(cpt_Lettrage);
                return View(cpt_LettrageFormModel);
            }

        }





        // POST: Commun/Devises/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LettrageId,EcheanceId,MntTTC,CompteTVA,CodeCompteTVA,TAuxTVA,MntTVA,CompteHT,CodeCompteHT,MntHT,TypePayment")] TVALettragePivot cpt_Lettrage)
        {



            // if (ModelState.IsValid)
            if (cpt_Lettrage != null)
            {
                if (cpt_Lettrage.Id > 0)
                {
                    // cpt_Lettrage.IdDossier = Constantes.IdentifiantDossier;
                   
                    cpt_Lettrage.EcheanceId = null;
                    LettrageServise.UpdateTVALettragePivot(cpt_Lettrage);
                    LettrageServise.SaveTVALettragePivot();
                }
                else
                {



                    cpt_Lettrage.EcheanceId = null;

                    LettrageServise.CreateTVALettragePivot(cpt_Lettrage);
                    LettrageServise.SaveTVALettragePivot();
                }


                return RedirectToAction("Index");
            }



            // ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier", cpt_Journaux.IdDossier);
            CPT_TVALettrageFormViewModel cpt_LettrageFormModel = Mapper.Map<TVALettragePivot, CPT_TVALettrageFormViewModel>(cpt_Lettrage);
            return View(cpt_LettrageFormModel);
        }



        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // DevisesPivot gEN_Devises = deviseServise.GetDevise(id);
            TVALettragePivot cpt_Lettrage = LettrageServise.GetTVALettrage((int)id);
            //db.GEN_Devises.Find(id);
            if (cpt_Lettrage == null)
            {
                return HttpNotFound();
            }
            // ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier", cpt_Journaux.IdDossier);
            //db.GEN_Dossiers.Where(e => e.Actif), "Id", "CodeDossier", gEN_Devises.IdDossier);

            CPT_TVALettrageFormViewModel cpt_LettrageFormModel = Mapper.Map<TVALettragePivot, CPT_TVALettrageFormViewModel>(cpt_Lettrage);
            return View(cpt_LettrageFormModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LettrageId,EcheanceId,MntTTC,CompteTVA,CodeCompteTVA,TAuxTVA,MntTVA,CompteHT,CodeCompteHT,MntHT,TypePayment")]  TVALettragePivot cpt_Lettrage)
        {

            if (ModelState.IsValid)
            {
                
                cpt_Lettrage.EcheanceId = null;
                LettrageServise.UpdateTVALettragePivot(cpt_Lettrage);
                //   db.SaveChanges();
                LettrageServise.SaveTVALettragePivot();
                return RedirectToAction("Index");
            }
            // ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier", cpt_Journaux.IdDossier);
            //db.GEN_Dossiers.Where(e => e.Actif), "Id", "CodeDossier", gEN_Devises.IdDossier);

            CPT_TVALettrageFormViewModel cpt_LettrageFormModel = Mapper.Map<TVALettragePivot, CPT_TVALettrageFormViewModel>(cpt_Lettrage);
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
            TVALettragePivot cpt_Lettrage = LettrageServise.GetTVALettrage((int)id);
            //db.GEN_Devises.Find(id);
            if (cpt_Lettrage == null)
            {
                return HttpNotFound();
            }

            CPT_TVALettrageFormViewModel cpt_codd = Mapper.Map<TVALettragePivot, CPT_TVALettrageFormViewModel>(cpt_Lettrage);
            return View(cpt_codd);
        }




        // POST: Commun/TypePaiement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed([Bind(Include = "Id")] CPT_TVALettrageFormViewModel cpt_Lettrage)
        {
            TVALettragePivot cods = Mapper.Map<CPT_TVALettrageFormViewModel, TVALettragePivot>(cpt_Lettrage);
            TVALettragePivot codes = LettrageServise.GetTVALettrage(cods.Id);


            LettrageServise.DeletTVALettragePivot(codes);
            // db.SaveChanges();
            LettrageServise.SaveTVALettragePivot();
            return RedirectToAction("Index");



        }


    }
}