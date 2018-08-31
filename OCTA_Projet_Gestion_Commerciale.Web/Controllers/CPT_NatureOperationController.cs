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
    public class CPT_NatureOperationController : Controller
    {
        private readonly INatureOperationService NatureOperationServise;
        private readonly IDossiersService dossiersService;

        public CPT_NatureOperationController(INatureOperationService NatureOperationServise, IDossiersService dossiersService)
        {
            this.NatureOperationServise = NatureOperationServise;
            this.dossiersService = dossiersService;
        }

        public ActionResult Index()
        {
            var natureOperation = NatureOperationServise.GetALL();

            IEnumerable<CPT_NatureOperationViewModel> natureOperation_Views = Mapper.Map<IEnumerable<NatureOperationPivot>, IEnumerable<CPT_NatureOperationViewModel>>(natureOperation);

            return View(natureOperation_Views.AsQueryable());


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
                var natureOperation = NatureOperationServise.GetNatureOperation((int)id);
                if (natureOperation == null)
                {

                    TempData["errorMessage"] = "Le compte G que vous cherchez n'existe pas.";
                    return RedirectToAction("Index");
                }
                //  ViewBag.IdDossier = new SelectList(db.GEN_Dossiers.Where(e => e.Actif), "Id", "CodeDossier", gEN_Devises.IdDossier);
               // ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier", natureOperation.IdDossier);
                CPT_NatureOperationFormViewModel natureOperationFormModel = Mapper.Map<NatureOperationPivot, CPT_NatureOperationFormViewModel>(natureOperation);
                return View(natureOperationFormModel);
            }

        }





        // POST: Commun/Devises/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NatureOperationNom,ATraiter,GenererFactureAchat,GenererFactureVente,GenererReglement,AvecTVA,AvecTier,Sens,Montant,IsCommission,AutoriseRegroupement")] NatureOperationPivot natureOperation)
        {



            // if (ModelState.IsValid)
            if (natureOperation != null)
            {
                if (natureOperation.Id > 0)
                {
                    natureOperation.IsCommission = true;
                    natureOperation.GenererReglement = true;
                    natureOperation.GenererFactureVente = true;
                    natureOperation.GenererFactureAchat = true;
                    natureOperation.AvecTier = false;
                    natureOperation.AvecTVA = true;
                    natureOperation.AutoriseRegroupement = false;
                    natureOperation.ATraiter = true;



                    NatureOperationServise.UpdateNatureOperationPivot(natureOperation);
                    NatureOperationServise.SaveNatureOperationPivot();
                }
                else
                {

                    natureOperation.IsCommission = true;
                    natureOperation.GenererReglement = true;
                    natureOperation.GenererFactureVente = true;
                    natureOperation.GenererFactureAchat = true;
                    natureOperation.AvecTier = false;
                    natureOperation.AvecTVA = true;
                    natureOperation.AutoriseRegroupement = false;
                    natureOperation.ATraiter = true;

                    NatureOperationServise.CreateNatureOperationPivot(natureOperation);
                    NatureOperationServise.SaveNatureOperationPivot();
                }


                return RedirectToAction("Index");
            }



           // ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier", cpt_comptes.IdDossier);
            CPT_NatureOperationFormViewModel natureOperationFormModel = Mapper.Map<NatureOperationPivot, CPT_NatureOperationFormViewModel>(natureOperation);
            return View(natureOperationFormModel);
        }



        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // DevisesPivot gEN_Devises = deviseServise.GetDevise(id);
           NatureOperationPivot natureOperation = NatureOperationServise.GetNatureOperation((int)id);
            //db.GEN_Devises.Find(id);
            if (natureOperation == null)
            {
                return HttpNotFound();
            }
           

            CPT_NatureOperationFormViewModel natureOperationFormModel = Mapper.Map<NatureOperationPivot, CPT_NatureOperationFormViewModel>(natureOperation);
            return View(natureOperationFormModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NatureOperationNom,ATraiter,GenererFactureAchat,GenererFactureVente,GenererReglement,AvecTVA,AvecTier,Sens,Montant,IsCommission,AutoriseRegroupement")] NatureOperationPivot natureOperation)
        {

            if (ModelState.IsValid)
            {
                natureOperation.IsCommission = true;
                natureOperation.GenererReglement = true;
                natureOperation.GenererFactureVente = true;
                natureOperation.GenererFactureAchat = true;
                natureOperation.AvecTier = false;
                natureOperation.AvecTVA = true;
                natureOperation.AutoriseRegroupement = false;
                natureOperation.ATraiter = true;

                NatureOperationServise.UpdateNatureOperationPivot(natureOperation);
                //   db.SaveChanges();
                NatureOperationServise.SaveNatureOperationPivot();
                return RedirectToAction("Index");
            }
            

            CPT_NatureOperationFormViewModel natureOperationFormModel = Mapper.Map<NatureOperationPivot, CPT_NatureOperationFormViewModel>(natureOperation);
            return View(natureOperationFormModel);

        }


        public ActionResult Delete(long? id)
        {
            ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier");
            //db.GEN_Dossiers.Where(e => e.Actif), "Id", "CodeDossier");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NatureOperationPivot natureOperation = NatureOperationServise.GetNatureOperation((int)id);
            //db.GEN_Devises.Find(id);
            if (natureOperation == null)
            {
                return HttpNotFound();
            }

            CPT_NatureOperationFormViewModel natureOperations = Mapper.Map<NatureOperationPivot, CPT_NatureOperationFormViewModel>(natureOperation);
            return View(natureOperations);
        }




        // POST: Commun/TypePaiement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed([Bind(Include = "Id")] CPT_NatureOperationFormViewModel natureOperation)
        {
            NatureOperationPivot cods = Mapper.Map<CPT_NatureOperationFormViewModel, NatureOperationPivot>(natureOperation);
            NatureOperationPivot codes = NatureOperationServise.GetNatureOperation(cods.Id);


            NatureOperationServise.DeletNatureOperationPivot(codes);
            // db.SaveChanges();
            NatureOperationServise.SaveNatureOperationPivot();
            return RedirectToAction("Index");



        }


    }
}