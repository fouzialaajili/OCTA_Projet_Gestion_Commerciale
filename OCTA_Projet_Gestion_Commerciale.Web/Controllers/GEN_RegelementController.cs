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
    public class GEN_RegelementController : Controller
    {
        private readonly IRegelementService regelementServise;
        private readonly IDossiersService dossiersService;

        public GEN_RegelementController(IRegelementService regelementServise, IDossiersService dossiersService)
        {
            this.regelementServise = regelementServise;
            this.dossiersService = dossiersService;
        }

        public ActionResult Index()
        {
            var comptes = regelementServise.GetALL();

            IEnumerable<ReglementViewModel> comptes_Views = Mapper.Map<IEnumerable<RegelementPivot>, IEnumerable<ReglementViewModel>>(comptes);

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
                var  reglement = regelementServise.GetRegelement((int)id);
                if (reglement == null)
                {

                    TempData["errorMessage"] = "Le compte G que vous cherchez n'existe pas.";
                    return RedirectToAction("Index");
                }

                ReglementFormViewModel cpt_ComptesFormModel = Mapper.Map<RegelementPivot, ReglementFormViewModel>(reglement);
                return View(cpt_ComptesFormModel);
            }

        }





        // POST: Commun/Devises/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DateReglement,NumPiece,IdJournal,IdModePaiement,Libelle,Montant,Solde,Liaison")]  RegelementPivot Reglementl)
        {



            // if (ModelState.IsValid)
            if (Reglementl != null)
            {
                if (Reglementl.Id > 0)
                {
                    Reglementl.IdJournal = null;
                    Reglementl.IdModePaiement = null;


                    regelementServise.UpdateRegelementPivot(Reglementl);
                    regelementServise.SaveRegelementPivot();
                }
                else
                {



                    Reglementl.IdJournal = null;
                    Reglementl.IdModePaiement = null;
                    regelementServise.CreateRegelementPivot(Reglementl);
                    regelementServise.SaveRegelementPivot();
                }


                return RedirectToAction("Index");
            }

            ReglementFormViewModel cpt_comptsFormModel = Mapper.Map<RegelementPivot, ReglementFormViewModel>(Reglementl);
            return View(cpt_comptsFormModel);
        }



        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // DevisesPivot gEN_Devises = deviseServise.GetDevise(id);
            RegelementPivot reg = regelementServise.GetRegelement((int)id);
            //db.GEN_Devises.Find(id);
            if (reg == null)
            {
                return HttpNotFound();
            }


            ReglementFormViewModel cpt_compteFormModel = Mapper.Map<RegelementPivot,ReglementFormViewModel>(reg);
            return View(cpt_compteFormModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DateReglement,NumPiece,IdJournal,IdModePaiement,Libelle,Montant,Solde,Liaison")] RegelementPivot reglement)
        {

            if (ModelState.IsValid)
            {
                reglement.IdJournal = null;
                reglement.IdModePaiement = null;

                regelementServise.UpdateRegelementPivot(reglement);
                //   db.SaveChanges();
                regelementServise.SaveRegelementPivot();
                return RedirectToAction("Index");
            }
     

            ReglementFormViewModel cpt_compteGFormModel = Mapper.Map<RegelementPivot, ReglementFormViewModel>(reglement);
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
            RegelementPivot regl = regelementServise.GetRegelement((int)id);
            //db.GEN_Devises.Find(id);
            if (regl == null)
            {
                return HttpNotFound();
            }

            ReglementFormViewModel cpt_codd = Mapper.Map<RegelementPivot, ReglementFormViewModel>(regl);
            return View(cpt_codd);
        }




        // POST: Commun/TypePaiement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed([Bind(Include = "Id")] ReglementFormViewModel reglement)
        {
            RegelementPivot reglements = Mapper.Map<ReglementFormViewModel, RegelementPivot>(reglement);
            RegelementPivot codes = regelementServise.GetRegelement(reglements.Id);


            regelementServise.DeletRegelementPivot(codes);
            // db.SaveChanges();
            regelementServise.SaveRegelementPivot();
            return RedirectToAction("Index");



        }


    }
}