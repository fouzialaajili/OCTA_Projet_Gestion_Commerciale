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
    public class CPT_ParametrageComptableController : Controller
    {
        private readonly IParametrageComptableService cpt_ParametrageComptableServise;
        private readonly IDossiersService dossiersService;

        public CPT_ParametrageComptableController(IParametrageComptableService cpt_ParametrageComptableServise, IDossiersService dossiersService)
        {
            this.cpt_ParametrageComptableServise = cpt_ParametrageComptableServise;
            this.dossiersService = dossiersService;
        }

        public ActionResult Index()
        {
            var parametrageComptab = cpt_ParametrageComptableServise.GetALL();

            IEnumerable<CPT_ParametrageComptableViewModel> parametrageComptab_Views = Mapper.Map<IEnumerable<ParametrageComptablePivot>, IEnumerable<CPT_ParametrageComptableViewModel>>(parametrageComptab);

            return View(parametrageComptab_Views.AsQueryable());


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
                var cpt_Comptes = cpt_ParametrageComptableServise.GetParametrageComptable((int)id);
                if (cpt_Comptes == null)
                {

                    TempData["errorMessage"] = "Le compte G que vous cherchez n'existe pas.";
                    return RedirectToAction("Index");
                }
                //  ViewBag.IdDossier = new SelectList(db.GEN_Dossiers.Where(e => e.Actif), "Id", "CodeDossier", gEN_Devises.IdDossier);
                ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier", cpt_Comptes.IdDossier);
                CPT_ParametrageComptableFormViewModel cpt_ComptesFormModel = Mapper.Map<ParametrageComptablePivot, CPT_ParametrageComptableFormViewModel>(cpt_Comptes);
                return View(cpt_ComptesFormModel);
            }

        }





        // POST: Commun/Devises/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NumeroPiece,IdJournalANouveaux,IdJournalAchatIntegration,IdJournalVenteIntegration,ModeBrouillardActive,LibelleEcritureANouveau,LibelleEcriturePiece,IdCompteBenefice,IdCompteDeficit,IdCompteEcartPaiementVente,IdCompteEcartPaiementAchat,IdCompteCollectifClient,IdCompteCollectifFournisseur,IdCompteEcartPerte,IdCompteEcartGain,IdJournalBanque,IdDossier,InterdirLaGenFact")] ParametrageComptablePivot cpt_comptes)
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
                    cpt_comptes.IdCompteBenefice = null;
                    cpt_comptes.IdCompteDeficit = null;
                    cpt_comptes.IdJournalAchatIntegration = null;

                    cpt_ParametrageComptableServise.UpdateParametrageComptable(cpt_comptes);
                    cpt_ParametrageComptableServise.SaveParametrageComptable();
                }
                else
                {

                    cpt_comptes.IdDossier = Constantes.IdentifiantDossier;
                    cpt_comptes.sys_dateUpdate = DateTime.Now;
                    cpt_comptes.sys_dateCreation = DateTime.Now;
                    cpt_comptes.sys_user = Constantes.IdentifiantUser;
                    cpt_comptes.IdCompteBenefice = null;
                    cpt_comptes.IdCompteDeficit = null;
                    cpt_comptes.IdJournalAchatIntegration = null;



                    cpt_ParametrageComptableServise.CreateParametrageComptable(cpt_comptes);
                    cpt_ParametrageComptableServise.SaveParametrageComptable();
                }


                return RedirectToAction("Index");
            }



            ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier", cpt_comptes.IdDossier);
            CPT_ParametrageComptableFormViewModel cpt_comptsFormModel = Mapper.Map<ParametrageComptablePivot, CPT_ParametrageComptableFormViewModel>(cpt_comptes);
            return View(cpt_comptsFormModel);
        }



        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // DevisesPivot gEN_Devises = deviseServise.GetDevise(id);
            ParametrageComptablePivot cpt_compte = cpt_ParametrageComptableServise.GetParametrageComptable((int)id);
            //db.GEN_Devises.Find(id);
            if (cpt_compte == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier", cpt_compte.IdDossier);
            //db.GEN_Dossiers.Where(e => e.Actif), "Id", "CodeDossier", gEN_Devises.IdDossier);

            CPT_ParametrageComptableFormViewModel cpt_compteFormModel = Mapper.Map<ParametrageComptablePivot, CPT_ParametrageComptableFormViewModel>(cpt_compte);
            return View(cpt_compteFormModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NumeroPiece,IdJournalANouveaux,IdJournalAchatIntegration,IdJournalVenteIntegration,ModeBrouillardActive,LibelleEcritureANouveau,LibelleEcriturePiece,IdCompteBenefice,IdCompteDeficit,IdCompteEcartPaiementVente,IdCompteEcartPaiementAchat,IdCompteCollectifClient,IdCompteCollectifFournisseur,IdCompteEcartPerte,IdCompteEcartGain,IdJournalBanque,IdDossier,InterdirLaGenFact")] ParametrageComptablePivot cpt_compteG)
        {

            if (ModelState.IsValid)
            {
                cpt_compteG.IdDossier = Constantes.IdentifiantDossier;
                cpt_compteG.sys_dateUpdate = DateTime.Now;
                cpt_compteG.sys_dateCreation = DateTime.Now;
                cpt_compteG.sys_user = Constantes.IdentifiantUser;
                cpt_compteG.IdCompteBenefice = null;
                cpt_compteG.IdCompteDeficit = null;
                cpt_compteG.IdJournalAchatIntegration = null;
                cpt_ParametrageComptableServise.UpdateParametrageComptable(cpt_compteG);
                // db.SaveChanges();
               cpt_ParametrageComptableServise.SaveParametrageComptable();
                return RedirectToAction("Index");
            }
            ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier", cpt_compteG.IdDossier);
            //db.GEN_Dossiers.Where(e => e.Actif), "Id", "CodeDossier", gEN_Devises.IdDossier);

            CPT_ParametrageComptableFormViewModel cpt_compteGFormModel = Mapper.Map<ParametrageComptablePivot, CPT_ParametrageComptableFormViewModel>(cpt_compteG);
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
            ParametrageComptablePivot cpt_compte = cpt_ParametrageComptableServise.GetParametrageComptable((int)id);
            //db.GEN_Devises.Find(id);
            if (cpt_compte == null)
            {
                return HttpNotFound();
            }

            CPT_ParametrageComptableFormViewModel cpt_codd = Mapper.Map<ParametrageComptablePivot, CPT_ParametrageComptableFormViewModel>(cpt_compte);
            return View(cpt_codd);
        }




        // POST: Commun/TypePaiement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed([Bind(Include = "Id")] CPT_ParametrageComptableFormViewModel cpt_calsses)
        {
            ParametrageComptablePivot cods = Mapper.Map<CPT_ParametrageComptableFormViewModel, ParametrageComptablePivot>(cpt_calsses);
            ParametrageComptablePivot codes = cpt_ParametrageComptableServise.GetParametrageComptable(cods.Id);


            cpt_ParametrageComptableServise.DeleteParametrageComptable(codes);
            // db.SaveChanges();
            cpt_ParametrageComptableServise.SaveParametrageComptable();
            return RedirectToAction("Index");



        }


    }
}