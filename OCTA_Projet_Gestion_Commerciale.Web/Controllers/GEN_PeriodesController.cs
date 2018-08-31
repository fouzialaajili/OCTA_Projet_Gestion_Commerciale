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
    public class GEN_PeriodesController : Controller
    {
        private readonly IPeriodesService peroideServise;
        private readonly IDossiersService dossiersService;

        public GEN_PeriodesController(IPeriodesService peroideServise, IDossiersService dossiersService)
        {
            this.peroideServise = peroideServise;
            this.dossiersService = dossiersService;
        }

        public ActionResult Index()
        {
            var peroide = peroideServise.GetALL();

            IEnumerable<PeriodesViewModel> peroide_Views = Mapper.Map<IEnumerable<PeriodesPivot>, IEnumerable<PeriodesViewModel>>(peroide);

            return View(peroide_Views.AsQueryable());


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
                var peroides = peroideServise.GetPeriodes((int)id);
                if (peroides == null)
                {

                    TempData["errorMessage"] = "Le exercice que vous cherchez n'existe pas.";
                    return RedirectToAction("Index");
                }
                PeriodesFormViewModel peroidFormModel = Mapper.Map<PeriodesPivot, PeriodesFormViewModel>(peroides);
                return View(peroidFormModel);
            }

        }





        // POST: Commun/Devises/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Libelle,DateDebut,DateFin,Actif,ComptaCloture,GescomCloture,PaieCloture,IdExercice")] PeriodesPivot pero)
        {

            if (pero != null)
            {
                if (pero.Id > 0)
                {

                    pero.sys_dateUpdate = DateTime.Now;
                    pero.sys_dateCreation = DateTime.Now;
                    pero.sys_user = Constantes.IdentifiantUser;
                    pero.Actif = true;

                    pero.IdExercice = 1;

                   peroideServise.UpdatePeriodes(pero);
                    peroideServise.SavePeriodes();
                }
                else
                {

                    pero.Actif = true;
                    pero.sys_dateUpdate = DateTime.Now;
                    pero.sys_dateCreation = DateTime.Now;
                    pero.sys_user = Constantes.IdentifiantUser;
                    pero.IdExercice = 1;

                    peroideServise.CreatePeriodes(pero);
                    peroideServise.SavePeriodes();
                }


                return RedirectToAction("Index");
            }

            PeriodesFormViewModel per = Mapper.Map<PeriodesPivot, PeriodesFormViewModel>(pero);
            return View(per);
        }



        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // DevisesPivot gEN_Devises = deviseServise.GetDevise(id);
            PeriodesPivot peroides = peroideServise.GetPeriodes((int)id);
            //db.GEN_Devises.Find(id);
            if (peroides == null)
            {
                return HttpNotFound();
            }


          PeriodesFormViewModel peroide = Mapper.Map<PeriodesPivot, PeriodesFormViewModel>(peroides);
            return View(peroide);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Libelle,DateDebut,DateFin,Actif,ComptaCloture,GescomCloture,PaieCloture,IdExercice")] PeriodesPivot peroide)
        {

            if (ModelState.IsValid)
            {
                peroide.Actif = true;
                peroide.sys_dateUpdate = DateTime.Now;
                peroide.sys_dateCreation = DateTime.Now;
                peroide.sys_user = Constantes.IdentifiantUser;
                peroide.IdExercice = 1;
                peroideServise.UpdatePeriodes(peroide);
                //   db.SaveChanges();
                peroideServise.SavePeriodes();
                return RedirectToAction("Index");
            }

            PeriodesFormViewModel Num = Mapper.Map<PeriodesPivot, PeriodesFormViewModel>(peroide);
            return View(Num);

        }


        public ActionResult Delete(long? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PeriodesPivot peroide = peroideServise.GetPeriodes((int)id);
            //db.GEN_Devises.Find(id);
            if (peroide == null)
            {
                return HttpNotFound();
            }

            PeriodesFormViewModel peroides = Mapper.Map<PeriodesPivot, PeriodesFormViewModel>(peroide);
            return View(peroides);
        }




        // POST: Commun/TypePaiement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed([Bind(Include = "Id")] PeriodesFormViewModel peroidess)
        {
            PeriodesPivot peroides = Mapper.Map<PeriodesFormViewModel, PeriodesPivot>(peroidess);
            PeriodesPivot per = peroideServise.GetPeriodes(peroides.Id);


            peroideServise.DeletePeriodes(per);
            // db.SaveChanges();
            peroideServise.SavePeriodes();
            return RedirectToAction("Index");



        }


    }
}