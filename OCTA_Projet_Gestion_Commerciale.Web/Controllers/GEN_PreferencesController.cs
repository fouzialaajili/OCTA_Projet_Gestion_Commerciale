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
    public class GEN_PreferencesController : Controller
    {
        private readonly IPreferencesService preferencesServise;
        private readonly IDossiersService dossiersService;

        public GEN_PreferencesController(IPreferencesService preferencesServise, IDossiersService dossiersService)
        {
            this.preferencesServise = preferencesServise;
            this.dossiersService = dossiersService;
        }

        public ActionResult Index()
        {
            var perference = preferencesServise.GetALL();

            IEnumerable<PreferencesViewModel> perference_Views = Mapper.Map<IEnumerable<PreferencesPivot>, IEnumerable<PreferencesViewModel>>(perference);

            return View(perference_Views.AsQueryable());


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
                var preference = preferencesServise.GetPreferences((int)id);
                if (preference == null)
                {

                    TempData["errorMessage"] = "Le exercice que vous cherchez n'existe pas.";
                    return RedirectToAction("Index");
                }
                PreferencesFormViewModel peroidFormModel = Mapper.Map<PreferencesPivot, PreferencesFormViewModel>(preference);
                return View(peroidFormModel);
            }

        }





        // POST: Commun/Devises/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdUsers,IdDossier,IdExercice")]  PreferencesPivot pero)
        {

            if (pero != null)
            {
                if (pero.Id > 0)
                {

                    pero.IdUsers = Constantes.IdentifiantUser;
                    pero.IdDossier = Constantes.IdentifiantDossier;
                    pero.IdExercices =2;


                    preferencesServise.UpdatePreferencesPivot(pero);
                    preferencesServise.SavePreferencesPivot();
                }
                else
                {


                    pero.IdUsers = Constantes.IdentifiantUser;
                    pero.IdDossier = Constantes.IdentifiantDossier;
                    pero.IdExercices = 2;

                    preferencesServise.CreatePreferencesPivot(pero);
                    preferencesServise.SavePreferencesPivot();
                }


                return RedirectToAction("Index");
            }

            PreferencesFormViewModel per = Mapper.Map<PreferencesPivot, PreferencesFormViewModel>(pero);
            return View(per);
        }



        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // DevisesPivot gEN_Devises = deviseServise.GetDevise(id);
            PreferencesPivot preference = preferencesServise.GetPreferences((int)id);
            //db.GEN_Devises.Find(id);
            if (preference == null)
            {
                return HttpNotFound();
            }


            PreferencesFormViewModel preferences = Mapper.Map<PreferencesPivot, PreferencesFormViewModel>(preference);
            return View(preferences);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdUsers,IdDossier,IdExercice")] PreferencesPivot preferences)
        {

            if (ModelState.IsValid)
            {

                preferences.IdUsers = Constantes.IdentifiantUser;
                preferences.IdDossier = Constantes.IdentifiantDossier;
                preferences.IdExercices = 2;
                preferencesServise.UpdatePreferencesPivot(preferences);
                //   db.SaveChanges();
                preferencesServise.SavePreferencesPivot();
                return RedirectToAction("Index");
            }

            PreferencesFormViewModel Num = Mapper.Map<PreferencesPivot,PreferencesFormViewModel>(preferences);
            return View(Num);

        }


        public ActionResult Delete(long? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PreferencesPivot preferences = preferencesServise.GetPreferences((int)id);
            //db.GEN_Devises.Find(id);
            if (preferences == null)
            {
                return HttpNotFound();
            }

            PreferencesFormViewModel preferencess = Mapper.Map<PreferencesPivot, PreferencesFormViewModel>(preferences);
            return View(preferencess);
        }




        // POST: Commun/TypePaiement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed([Bind(Include = "Id")] PreferencesFormViewModel preferences)
        {
            PreferencesPivot preference = Mapper.Map<PreferencesFormViewModel, PreferencesPivot>(preferences);
            PreferencesPivot per = preferencesServise.GetPreferences(preferences.Id);


            preferencesServise.DeletPreferencesPivot(per);
            // db.SaveChanges();
            preferencesServise.SavePreferencesPivot();
            return RedirectToAction("Index");



        }


    }
}