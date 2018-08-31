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
    public class CPT_JournauxController : Controller
    {
        private readonly IJournauxService JournauxServise;
        private readonly IDossiersService dossiersService;

        public CPT_JournauxController(IJournauxService JournauxServise, IDossiersService dossiersService)
        {
            this.JournauxServise = JournauxServise;
            this.dossiersService = dossiersService;
        }

        public ActionResult Index()
        {
            var Journaux = JournauxServise.GetALL();

            IEnumerable<CPT_JournauxViewModel> Journaux_Views = Mapper.Map<IEnumerable<JournauxPivot>, IEnumerable<CPT_JournauxViewModel>>(Journaux);

            return View(Journaux_Views.AsQueryable());


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
                var cpt_Journaux = JournauxServise.GetJournaux((int)id);
                if (cpt_Journaux == null)
                {

                    TempData["errorMessage"] = "Le journal que vous cherchez n'existe pas.";
                    return RedirectToAction("Index");
                }
                //  ViewBag.IdDossier = new SelectList(db.GEN_Dossiers.Where(e => e.Actif), "Id", "CodeDossier", gEN_Devises.IdDossier);
                ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier", cpt_Journaux.IdDossier);
                CPT_JournauxFormViewModel cpt_JournauxFormModel = Mapper.Map<JournauxPivot, CPT_JournauxFormViewModel>(cpt_Journaux);
                return View(cpt_JournauxFormModel);
            }

        }





        // POST: Commun/Devises/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CodeJournal,Libelle,TypeJournal,Actif,IdCompteContrepartie")] JournauxPivot cpt_Journaux)
        {



            // if (ModelState.IsValid)
            if (cpt_Journaux != null)
            {
                if (cpt_Journaux.Id > 0)
                {
                    cpt_Journaux.IdDossier = Constantes.IdentifiantDossier;
                    cpt_Journaux.sys_DateUpdate = DateTime.Now;
                    cpt_Journaux.sys_DateCreation = DateTime.Now;
                    cpt_Journaux.sys_user = Constantes.IdentifiantUser;
                    cpt_Journaux.Actif = true;
                    cpt_Journaux.IdDevise = null;
                    cpt_Journaux.IdCompteContrepartie = null;
                    JournauxServise.UpdateJournauxPivot(cpt_Journaux);
                    JournauxServise.SaveJournauxPivot();
                }
                else
                {

                    cpt_Journaux.IdDossier = Constantes.IdentifiantDossier;
                    cpt_Journaux.sys_DateUpdate = DateTime.Now;
                    cpt_Journaux.sys_DateCreation = DateTime.Now;
                    cpt_Journaux.sys_user = Constantes.IdentifiantUser;
                    cpt_Journaux.Actif = true;
                    cpt_Journaux.IdDevise = null;
                    cpt_Journaux.IdCompteContrepartie = null;

                    JournauxServise.CreateJournauxPivot(cpt_Journaux);
                    JournauxServise.SaveJournauxPivot();
                }


                return RedirectToAction("Index");
            }



            ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier", cpt_Journaux.IdDossier);
            CPT_JournauxFormViewModel cpt_JournauxFormModel = Mapper.Map<JournauxPivot, CPT_JournauxFormViewModel>(cpt_Journaux);
            return View(cpt_JournauxFormModel);
        }



        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // DevisesPivot gEN_Devises = deviseServise.GetDevise(id);
            JournauxPivot cpt_Journaux = JournauxServise.GetJournaux((int)id);
            //db.GEN_Devises.Find(id);
            if (cpt_Journaux == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier", cpt_Journaux.IdDossier);
            //db.GEN_Dossiers.Where(e => e.Actif), "Id", "CodeDossier", gEN_Devises.IdDossier);

            CPT_JournauxFormViewModel cpt_JournauxFormModel = Mapper.Map<JournauxPivot, CPT_JournauxFormViewModel>(cpt_Journaux);
            return View(cpt_JournauxFormModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CodeJournal,Libelle,TypeJournal,Actif,IdCompteContrepartie")] JournauxPivot cpt_Journaux)
        {

            if (ModelState.IsValid)
            {
                cpt_Journaux.IdDossier = Constantes.IdentifiantDossier;
                cpt_Journaux.sys_DateUpdate = DateTime.Now;
                cpt_Journaux.sys_DateCreation = DateTime.Now;
                cpt_Journaux.sys_user = Constantes.IdentifiantUser;
                cpt_Journaux.IdDevise = null;
                cpt_Journaux.IdCompteContrepartie = null;
                JournauxServise.UpdateJournauxPivot(cpt_Journaux);
                //   db.SaveChanges();
                JournauxServise.SaveJournauxPivot();
                return RedirectToAction("Index");
            }
            ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier", cpt_Journaux.IdDossier);
            //db.GEN_Dossiers.Where(e => e.Actif), "Id", "CodeDossier", gEN_Devises.IdDossier);

            CPT_JournauxFormViewModel cpt_JournauxFormModel = Mapper.Map<JournauxPivot, CPT_JournauxFormViewModel>(cpt_Journaux);
            return View(cpt_JournauxFormModel);

        }


        public ActionResult Delete(long? id)
        {
            ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier");
            //db.GEN_Dossiers.Where(e => e.Actif), "Id", "CodeDossier");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JournauxPivot cpt_Journaux = JournauxServise.GetJournaux((int)id);
            //db.GEN_Devises.Find(id);
            if (cpt_Journaux == null)
            {
                return HttpNotFound();
            }

            CPT_JournauxFormViewModel cpt_codd = Mapper.Map<JournauxPivot, CPT_JournauxFormViewModel>(cpt_Journaux);
            return View(cpt_codd);
        }




        // POST: Commun/TypePaiement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed([Bind(Include = "Id")] CPT_JournauxFormViewModel cpt_calsses)
        {
            JournauxPivot cods = Mapper.Map<CPT_JournauxFormViewModel, JournauxPivot>(cpt_calsses);
            JournauxPivot codes = JournauxServise.GetJournaux(cods.Id);


            JournauxServise.DeletJournauxPivot(codes);
            // db.SaveChanges();
            JournauxServise.SaveJournauxPivot();
            return RedirectToAction("Index");



        }


    }
}