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
    public class GEN_ExercicesController : Controller
    {
        private readonly IExercicesService exerciceServise;
        private readonly IDossiersService dossiersService;

        public GEN_ExercicesController(IExercicesService exerciceServise, IDossiersService dossiersService)
        {
            this.exerciceServise = exerciceServise;
            this.dossiersService = dossiersService;
        }

        public ActionResult Index()
        {
            var exercice = exerciceServise.GetALL();

            IEnumerable<ExercicesViewModel> exercice_Views = Mapper.Map<IEnumerable<ExercicesPivot>, IEnumerable<ExercicesViewModel>>(exercice);

            return View(exercice_Views.AsQueryable());


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
                var exoo= exerciceServise.GetExercices((int)id);
                if (exoo == null)
                {

                    TempData["errorMessage"] = "Le exercice que vous cherchez n'existe pas.";
                    return RedirectToAction("Index");
                }
                //  ViewBag.IdDossier = new SelectList(db.GEN_Dossiers.Where(e => e.Actif), "Id", "CodeDossier", gEN_Devises.IdDossier);
                ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier", exoo.IdDossier);
                ExercicesFromViewModel exooFormModel = Mapper.Map<ExercicesPivot, ExercicesFromViewModel>(exoo);
                return View(exooFormModel);
            }

        }





        // POST: Commun/Devises/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CodeExercice,Libelle,DateDebut,DateFin,ComptaCloture,GescomCloture,Actif,PaieCloture,IdDossier")]  ExercicesPivot exoo)
        {



            // if (ModelState.IsValid)
            if (exoo != null)
            {
                if (exoo.Id > 0)
                {
                    exoo.IdDossier = Constantes.IdentifiantDossier;
                    exoo.sys_dateUpdate = DateTime.Now;
                    exoo.sys_dateCreation = DateTime.Now;
                    exoo.sys_user = Constantes.IdentifiantUser;
                    exoo.Actif = true;


                    exerciceServise.UpdateExercicesPivot(exoo);
                    exerciceServise.SaveExercicesPivot();
                }
                else
                {

                    exoo.IdDossier = Constantes.IdentifiantDossier;
                    exoo.sys_dateUpdate = DateTime.Now;
                    exoo.sys_dateCreation = DateTime.Now;
                    exoo.sys_user = Constantes.IdentifiantUser;

               
                    exoo.Actif = true;


                    exerciceServise.CreateExercicesPivot(exoo);
                    exerciceServise.SaveExercicesPivot();
                }


                return RedirectToAction("Index");
            }



            ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier", exoo.IdDossier);
            ExercicesFromViewModel exoFormModel = Mapper.Map<ExercicesPivot, ExercicesFromViewModel>(exoo);
            return View(exoFormModel);
        }



        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // DevisesPivot gEN_Devises = deviseServise.GetDevise(id);
            ExercicesPivot exercice = exerciceServise.GetExercices((int)id);
            //db.GEN_Devises.Find(id);
            if (exercice == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier", exercice.IdDossier);
            //db.GEN_Dossiers.Where(e => e.Actif), "Id", "CodeDossier", gEN_Devises.IdDossier);

            ExercicesFromViewModel cpt_compteFormModel = Mapper.Map<ExercicesPivot, ExercicesFromViewModel>(exercice);
            return View(cpt_compteFormModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CodeExercice,Libelle,DateDebut,DateFin,ComptaCloture,GescomCloture,Actif,PaieCloture,IdDossier")] ExercicesPivot exoo)
        {

            if (ModelState.IsValid)
            {
                exoo.IdDossier = Constantes.IdentifiantDossier;
                exoo.sys_dateUpdate = DateTime.Now;
                exoo.sys_dateCreation = DateTime.Now;
                exoo.sys_user = Constantes.IdentifiantUser;
                exerciceServise.UpdateExercicesPivot(exoo);
                //   db.SaveChanges();
                exerciceServise.SaveExercicesPivot();
                return RedirectToAction("Index");
            }
            ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier", exoo.IdDossier);
            //db.GEN_Dossiers.Where(e => e.Actif), "Id", "CodeDossier", gEN_Devises.IdDossier);

            ExercicesFromViewModel exercices = Mapper.Map<ExercicesPivot, ExercicesFromViewModel>(exoo);
            return View(exercices);

        }


        public ActionResult Delete(long? id)
        {
            ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier");
            //db.GEN_Dossiers.Where(e => e.Actif), "Id", "CodeDossier");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           ExercicesPivot exercices = exerciceServise.GetExercices((int)id);
            //db.GEN_Devises.Find(id);
            if (exercices == null)
            {
                return HttpNotFound();
            }

            ExercicesFromViewModel cpt_codd = Mapper.Map<ExercicesPivot, ExercicesFromViewModel>(exercices);
            return View(cpt_codd);
        }




        // POST: Commun/TypePaiement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed([Bind(Include = "Id")] ExercicesFromViewModel cpt_calsses)
        {
            ExercicesPivot cods = Mapper.Map<ExercicesFromViewModel, ExercicesPivot>(cpt_calsses);
            ExercicesPivot codes =exerciceServise.GetExercices(cods.Id);


            exerciceServise.DeletExercicesPivot(codes);
            // db.SaveChanges();
            exerciceServise.SaveExercicesPivot();
            return RedirectToAction("Index");



        }


    }
}