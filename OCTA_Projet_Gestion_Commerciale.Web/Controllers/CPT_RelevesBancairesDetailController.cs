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
    public class CPT_RelevesBancairesDetailController : Controller
    {
        private readonly IRelevesBancairesDetailService RelevesBancairesServise;
        private readonly IDossiersService dossiersService;

        public CPT_RelevesBancairesDetailController(IRelevesBancairesDetailService RelevesBancairesServise, IDossiersService dossiersService)
        {
            this.RelevesBancairesServise = RelevesBancairesServise;
            this.dossiersService = dossiersService;
        }

        public ActionResult Index()
        {
            var comptes = RelevesBancairesServise.GetALL();

            IEnumerable<CPT_RelevesBancairesDetailViewModel> comptes_Views = Mapper.Map<IEnumerable<RelevesBancairesDetailPivot>, IEnumerable<CPT_RelevesBancairesDetailViewModel>>(comptes);

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
                var cpt_Comptes = RelevesBancairesServise.GetRelevesBancaires((int)id);
                if (cpt_Comptes == null)
                {

                    TempData["errorMessage"] = "Le compte G que vous cherchez n'existe pas.";
                    return RedirectToAction("Index");
                }
                //  ViewBag.IdDossier = new SelectList(db.GEN_Dossiers.Where(e => e.Actif), "Id", "CodeDossier", gEN_Devises.IdDossier);
               // ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier");
                CPT_RelevesBancairesDetailFormViewModel cpt_ComptesFormModel = Mapper.Map<RelevesBancairesDetailPivot, CPT_RelevesBancairesDetailFormViewModel>(cpt_Comptes);
                return View(cpt_ComptesFormModel);
            }

        }





        // POST: Commun/Devises/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdReleveBancaire,DateOperation,DateValeur,Reference,CIB,CPB,Designation,Debit,Credit,Rappro,DateRapprochement,TypeOperation,IdTier,IdTypePaiement,NumFacture,IdNatureOperation1,IdCodeTVA1,DatePaiement,IdPieceReglement,IdPieceFacture,IdJournalReglement,IdQua")] RelevesBancairesDetailPivot cpt_comptes)
        {



            // if (ModelState.IsValid)
            if (cpt_comptes != null)
            {
                if (cpt_comptes.Id > 0)
                {
                  
                    cpt_comptes.sys_dateUpdate = DateTime.Now;
                    cpt_comptes.sys_dateCreation = DateTime.Now;
                    cpt_comptes.sys_user = Constantes.IdentifiantUser;
                    cpt_comptes.IdNatureOperation1 = null;
                    cpt_comptes.IdReleveBancaire = null;
                    cpt_comptes.IdTypePaiement = null;
                    cpt_comptes.IdTier = null;
                  
                    RelevesBancairesServise.UpdateRelevesBancairesPivot(cpt_comptes);
                    RelevesBancairesServise.SaveRelevesBancairesPivot();
                }
                else
                {

                
                    cpt_comptes.sys_dateUpdate = DateTime.Now;
                    cpt_comptes.sys_dateCreation = DateTime.Now;
                    cpt_comptes.sys_user = Constantes.IdentifiantUser;
                    cpt_comptes.IdNatureOperation1 = null;
                    cpt_comptes.IdReleveBancaire = null;
                    cpt_comptes.IdTypePaiement = null;
                    cpt_comptes.IdTier = null;


                    RelevesBancairesServise.CreateRelevesBancairesPivot(cpt_comptes);
                    RelevesBancairesServise.SaveRelevesBancairesPivot();
                }


                return RedirectToAction("Index");
            }



           // ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier");
            CPT_RelevesBancairesDetailFormViewModel cpt_comptsFormModel = Mapper.Map<RelevesBancairesDetailPivot, CPT_RelevesBancairesDetailFormViewModel>(cpt_comptes);
            return View(cpt_comptsFormModel);
        }



        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // DevisesPivot gEN_Devises = deviseServise.GetDevise(id);
            RelevesBancairesDetailPivot cpt_compte = RelevesBancairesServise.GetRelevesBancaires((int)id);
            //db.GEN_Devises.Find(id);
            if (cpt_compte == null)
            {
                return HttpNotFound();
            }
            //ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier", cpt_compte.IdDossier);
            //db.GEN_Dossiers.Where(e => e.Actif), "Id", "CodeDossier", gEN_Devises.IdDossier);

            CPT_RelevesBancairesDetailFormViewModel cpt_compteFormModel = Mapper.Map<RelevesBancairesDetailPivot, CPT_RelevesBancairesDetailFormViewModel>(cpt_compte);
            return View(cpt_compteFormModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdReleveBancaire,DateOperation,DateValeur,Reference,CIB,CPB,Designation,Debit,Credit,Rappro,DateRapprochement,TypeOperation,IdTier,IdTypePaiement,NumFacture,IdNatureOperation1,IdCodeTVA1,DatePaiement,IdPieceReglement,IdPieceFacture,IdJournalReglement,IdQua")] RelevesBancairesDetailPivot cpt_compteG)
        {

            if (ModelState.IsValid)
            {
              
                cpt_compteG.sys_dateUpdate = DateTime.Now;
                cpt_compteG.sys_dateCreation = DateTime.Now;
                cpt_compteG.sys_user = Constantes.IdentifiantUser;

                cpt_compteG.IdNatureOperation1 = null;
                cpt_compteG.IdReleveBancaire = null;
                cpt_compteG.IdTypePaiement = null;
                cpt_compteG.IdTier = null;

                RelevesBancairesServise.UpdateRelevesBancairesPivot(cpt_compteG);
                //   db.SaveChanges();
                RelevesBancairesServise.SaveRelevesBancairesPivot();
                return RedirectToAction("Index");
            }
          
            //db.GEN_Dossiers.Where(e => e.Actif), "Id", "CodeDossier", gEN_Devises.IdDossier);

            CPT_RelevesBancairesDetailFormViewModel cpt_compteGFormModel = Mapper.Map<RelevesBancairesDetailPivot, CPT_RelevesBancairesDetailFormViewModel>(cpt_compteG);
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
            RelevesBancairesDetailPivot cpt_compte = RelevesBancairesServise.GetRelevesBancaires((int)id);
            //db.GEN_Devises.Find(id);
            if (cpt_compte == null)
            {
                return HttpNotFound();
            }

            CPT_RelevesBancairesDetailFormViewModel cpt_codd = Mapper.Map<RelevesBancairesDetailPivot, CPT_RelevesBancairesDetailFormViewModel>(cpt_compte);
            return View(cpt_codd);
        }




        // POST: Commun/TypePaiement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed([Bind(Include = "Id")] CPT_RelevesBancairesDetailFormViewModel cpt_calsses)
        {
            RelevesBancairesDetailPivot cods = Mapper.Map<CPT_RelevesBancairesDetailFormViewModel, RelevesBancairesDetailPivot>(cpt_calsses);
            RelevesBancairesDetailPivot codes = RelevesBancairesServise.GetRelevesBancaires(cods.Id);


            RelevesBancairesServise.DeletRelevesBancairesPivot(codes);
            // db.SaveChanges();
            RelevesBancairesServise.SaveRelevesBancairesPivot();
            return RedirectToAction("Index");



        }


    }
}