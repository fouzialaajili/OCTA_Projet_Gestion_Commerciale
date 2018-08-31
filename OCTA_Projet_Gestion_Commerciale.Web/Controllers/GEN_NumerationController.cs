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
    public class GEN_NumerationController : Controller
    {
        private readonly INumerationService numerationServise;
        private readonly IDossiersService dossiersService;

        public GEN_NumerationController(INumerationService numerationServise, IDossiersService dossiersService)
        {
            this.numerationServise = numerationServise;
            this.dossiersService = dossiersService;
        }

        public ActionResult Index()
        {
            var numeration = numerationServise.GetALL();

            IEnumerable<NumerationsViewModel> numeration_Views = Mapper.Map<IEnumerable<NumerationPivot>, IEnumerable<NumerationsViewModel>>(numeration);

            return View(numeration_Views.AsQueryable());


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
                var numeration = numerationServise.GetNumeration((int)id);
                if (numeration == null)
                {

                    TempData["errorMessage"] = "Le exercice que vous cherchez n'existe pas.";
                    return RedirectToAction("Index");
                }
                //  ViewBag.IdDossier = new SelectList(db.GEN_Dossiers.Where(e => e.Actif), "Id", "CodeDossier", gEN_Devises.IdDossier);

                NumerationsFormViewModel numerationFormModel = Mapper.Map<NumerationPivot, NumerationsFormViewModel>(numeration);
                return View(numerationFormModel);
            }

        }





        // POST: Commun/Devises/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Objet,IdDossier")] NumerationPivot numeration)
        {

            if (numeration != null)
            {
                if (numeration.Id > 0)
                {
                    numeration.idDossier = Constantes.IdentifiantDossier;
                    numeration.sys_dateUpdate = DateTime.Now;
                    numeration.sys_dateCreation = DateTime.Now;
                    numeration.sys_user = Constantes.IdentifiantUser;



                    numerationServise.UpdateNumerationPivot(numeration);
                    numerationServise.SaveNumerationPivot();
                }
                else
                {

                    numeration.idDossier = Constantes.IdentifiantDossier;
                    numeration.sys_dateUpdate = DateTime.Now;
                    numeration.sys_dateCreation = DateTime.Now;
                    numeration.sys_user = Constantes.IdentifiantUser;

                    numerationServise.CreateNumerationPivot(numeration);
                    numerationServise.SaveNumerationPivot();
                }


                return RedirectToAction("Index");
            }

            NumerationsFormViewModel numerationFormModel = Mapper.Map<NumerationPivot, NumerationsFormViewModel>(numeration);
            return View(numerationFormModel);
        }



        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // DevisesPivot gEN_Devises = deviseServise.GetDevise(id);
            NumerationPivot num = numerationServise.GetNumeration((int)id);
            //db.GEN_Devises.Find(id);
            if (num == null)
            {
                return HttpNotFound();
            }


            NumerationsFormViewModel NumFormModel = Mapper.Map<NumerationPivot, NumerationsFormViewModel>(num);
            return View(NumFormModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Objet,IdDossier")] NumerationPivot numm)
        {

            if (ModelState.IsValid)
            {
                numm.idDossier = Constantes.IdentifiantDossier;
                numm.sys_dateUpdate = DateTime.Now;
                numm.sys_dateCreation = DateTime.Now;
                numm.sys_user = Constantes.IdentifiantUser;
                numerationServise.UpdateNumerationPivot(numm);
                //   db.SaveChanges();
                numerationServise.SaveNumerationPivot();
                return RedirectToAction("Index");
            }

            NumerationsFormViewModel Num = Mapper.Map<NumerationPivot, NumerationsFormViewModel>(numm);
            return View(Num);

        }


        public ActionResult Delete(long? id)
        {
          
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NumerationPivot Num = numerationServise.GetNumeration((int)id);
            //db.GEN_Devises.Find(id);
            if (Num == null)
            {
                return HttpNotFound();
            }

            NumerationsFormViewModel numm = Mapper.Map<NumerationPivot, NumerationsFormViewModel>(Num);
            return View(numm);
        }




        // POST: Commun/TypePaiement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed([Bind(Include = "Id")] NumerationsFormViewModel numero)
        {
            NumerationPivot cods = Mapper.Map<NumerationsFormViewModel, NumerationPivot>(numero);
            NumerationPivot codes = numerationServise.GetNumeration(cods.Id);


            numerationServise.DeletNumerationPivot(codes);
            // db.SaveChanges();
            numerationServise.SaveNumerationPivot();
            return RedirectToAction("Index");



        }


    }
}