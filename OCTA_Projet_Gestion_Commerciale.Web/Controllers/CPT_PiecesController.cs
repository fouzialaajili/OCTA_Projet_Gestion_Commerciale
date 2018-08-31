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
    public class CPT_PiecesController : Controller
    {
        private readonly IPiecesService piecesServise;
        private readonly IDossiersService dossiersService;

        public CPT_PiecesController(IPiecesService piecesServise, IDossiersService dossiersService)
        {
            this.piecesServise = piecesServise;
            this.dossiersService = dossiersService;
        }

        public ActionResult Index()
        {
            var comptes = piecesServise.GetALL();

            IEnumerable<CPT_PiecesViewModel> comptes_Views = Mapper.Map<IEnumerable<PiecesPivot>, IEnumerable<CPT_PiecesViewModel>>(comptes);

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
                var cpt_Comptes = piecesServise.GetPiecesPivot((int)id);
                if (cpt_Comptes == null)
                {

                    TempData["errorMessage"] = "Le compte G que vous cherchez n'existe pas.";
                    return RedirectToAction("Index");
                }
                //  ViewBag.IdDossier = new SelectList(db.GEN_Dossiers.Where(e => e.Actif), "Id", "CodeDossier", gEN_Devises.IdDossier);
                ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier", cpt_Comptes.IdDossier);
                CPT_PiecesFormViewModel cpt_ComptesFormModel = Mapper.Map<PiecesPivot, CPT_PiecesFormViewModel>(cpt_Comptes);
                return View(cpt_ComptesFormModel);
            }

        }





        // POST: Commun/Devises/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TypePiece,IdTiers,IdJournal,OriginePiece,DatePiece,DateReference,DateFacture,RefPiece,NumPiece,Libelle,CourChange,IdDeviseTC,IdDeviseTR,IdDossier,IdDossierSite,Brouillon")] PiecesPivot cpt_comptes)
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
                    cpt_comptes.IdDeviseTC = null;
                    cpt_comptes.IdDeviseTR = null;
                    cpt_comptes.IdDossierSite = null;
                    cpt_comptes.IdTiers = null;
                    cpt_comptes.IdJournal = null;

                    piecesServise.UpdatePiecesPivot(cpt_comptes);
                    piecesServise.SavePiecesPivot();
                }
                else
                {

                    cpt_comptes.IdDossier = Constantes.IdentifiantDossier;
                    cpt_comptes.sys_dateUpdate = DateTime.Now;
                    cpt_comptes.sys_dateCreation = DateTime.Now;
                    cpt_comptes.sys_user = Constantes.IdentifiantUser;
                    cpt_comptes.IdDeviseTC = null;
                    cpt_comptes.IdDeviseTR = null;
                    cpt_comptes.IdDossierSite = null;
                    cpt_comptes.IdTiers = null;
                    cpt_comptes.IdJournal = null;

                    piecesServise.CreatePiecesPivot(cpt_comptes);
                    piecesServise.SavePiecesPivot();
                }


                return RedirectToAction("Index");
            }



            ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier", cpt_comptes.IdDossier);
            CPT_PiecesFormViewModel cpt_comptsFormModel = Mapper.Map<PiecesPivot, CPT_PiecesFormViewModel>(cpt_comptes);
            return View(cpt_comptsFormModel);
        }



        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // DevisesPivot gEN_Devises = deviseServise.GetDevise(id);
            PiecesPivot cpt_compte = piecesServise.GetPiecesPivot((int)id);
            //db.GEN_Devises.Find(id);
            if (cpt_compte == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier", cpt_compte.IdDossier);
            //db.GEN_Dossiers.Where(e => e.Actif), "Id", "CodeDossier", gEN_Devises.IdDossier);

            CPT_PiecesFormViewModel cpt_compteFormModel = Mapper.Map<PiecesPivot, CPT_PiecesFormViewModel>(cpt_compte);
            return View(cpt_compteFormModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TypePiece,IdTiers,IdJournal,OriginePiece,DatePiece,DateReference,DateFacture,RefPiece,NumPiece,Libelle,CourChange,IdDeviseTC,IdDeviseTR,IdDossier,IdDossierSite,Brouillon")]  PiecesPivot cpt_compteG)
        {

            if (ModelState.IsValid)
            {
                cpt_compteG.IdDossier = Constantes.IdentifiantDossier;
                cpt_compteG.sys_dateUpdate = DateTime.Now;
                cpt_compteG.sys_dateCreation = DateTime.Now;
                cpt_compteG.sys_user = Constantes.IdentifiantUser;
                cpt_compteG.IdDeviseTC = null;
                cpt_compteG.IdDeviseTR = null;
                cpt_compteG.IdDossierSite = null;
                cpt_compteG.IdTiers = null;
                cpt_compteG.IdJournal = null;

                piecesServise.UpdatePiecesPivot(cpt_compteG);
                //   db.SaveChanges();
                piecesServise.SavePiecesPivot();
                return RedirectToAction("Index");
            }
            ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier", cpt_compteG.IdDossier);
            //db.GEN_Dossiers.Where(e => e.Actif), "Id", "CodeDossier", gEN_Devises.IdDossier);

            CPT_PiecesFormViewModel cpt_compteGFormModel = Mapper.Map<PiecesPivot, CPT_PiecesFormViewModel>(cpt_compteG);
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
            PiecesPivot cpt_compte = piecesServise.GetPiecesPivot((int)id);
            //db.GEN_Devises.Find(id);
            if (cpt_compte == null)
            {
                return HttpNotFound();
            }

            CPT_PiecesFormViewModel cpt_codd = Mapper.Map<PiecesPivot, CPT_PiecesFormViewModel>(cpt_compte);
            return View(cpt_codd);
        }




        // POST: Commun/TypePaiement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed([Bind(Include = "Id")] CPT_PiecesFormViewModel cpt_calsses)
        {
           PiecesPivot cods = Mapper.Map<CPT_PiecesFormViewModel, PiecesPivot>(cpt_calsses);
            PiecesPivot codes = piecesServise.GetPiecesPivot(cods.Id);


            piecesServise.DeletPiecesPivot(codes);
            // db.SaveChanges();
            piecesServise.SavePiecesPivot();
            return RedirectToAction("Index");



        }


    }
}