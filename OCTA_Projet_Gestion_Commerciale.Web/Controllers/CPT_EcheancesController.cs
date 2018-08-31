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
    public class CPT_EcheancesController : Controller
    {
        private readonly IEcheancesService acheancesServise;
        private readonly IDossiersService dossiersService;

        public CPT_EcheancesController(IEcheancesService acheancesServise, IDossiersService dossiersService)
        {
            this.acheancesServise = acheancesServise;
            this.dossiersService = dossiersService;
        }

        public ActionResult Index()
        {
            var comptes = acheancesServise.GetALL();

            IEnumerable<CPT_EcheancesViewModel> comptes_Views = Mapper.Map<IEnumerable<EcheancesPivot>, IEnumerable<CPT_EcheancesViewModel>>(comptes);

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
                var cpt_Echeance = acheancesServise.GetEcheance((int)id);
                if (cpt_Echeance == null)
                {

                    TempData["errorMessage"] = "L'echeance que vous cherchez n'existe pas.";
                    return RedirectToAction("Index");
                }
                //  ViewBag.IdDossier = new SelectList(db.GEN_Dossiers.Where(e => e.Actif), "Id", "CodeDossier", gEN_Devises.IdDossier);
                ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier", cpt_Echeance.IdDossier);
                CPT_EcheancesFormViewModel cpt_EcheanceFormModel = Mapper.Map<EcheancesPivot, CPT_EcheancesFormViewModel>(cpt_Echeance);
                return View(cpt_EcheanceFormModel);
            }

        }





        // POST: Commun/Devises/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdEcriture,IdTypePaiement,IdModePaiement,DateEcheance,Pourcentage,MontantTC,IdDeviseTC,MontantTR,IdDeviseTR,Statut,IdDossier,IdDossierSite")] EcheancesPivot cpt_Echeance)
        {



            // if (ModelState.IsValid)
            if (cpt_Echeance != null)
            {
                if (cpt_Echeance.Id > 0)
                {
                    cpt_Echeance.IdDossier = Constantes.IdentifiantDossier;
                    cpt_Echeance.sys_dateUpdate = DateTime.Now;
                    cpt_Echeance.sys_dateCreation = DateTime.Now;
                    cpt_Echeance.IdEcriture = null;
                    
                    cpt_Echeance.sys_user = Constantes.IdentifiantUser;


                    acheancesServise.UpdateEcheancesPivot(cpt_Echeance);
                    acheancesServise.SaveEcheancesPivot();
                }
                else
                {

                    cpt_Echeance.IdDossier = Constantes.IdentifiantDossier;
                    cpt_Echeance.sys_dateUpdate = DateTime.Now;
                    cpt_Echeance.sys_dateCreation = DateTime.Now;
                    cpt_Echeance.sys_user = Constantes.IdentifiantUser;
                    cpt_Echeance.IdEcriture = null;



                    acheancesServise.CreateEcheancesPivot(cpt_Echeance);
                    acheancesServise.SaveEcheancesPivot();
                }


                return RedirectToAction("Index");
            }



            ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier", cpt_Echeance.IdDossier);
            CPT_EcheancesFormViewModel cpt_comptsFormModel = Mapper.Map<EcheancesPivot, CPT_EcheancesFormViewModel>(cpt_Echeance);
            return View(cpt_comptsFormModel);
        }



        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // DevisesPivot gEN_Devises = deviseServise.GetDevise(id);
            EcheancesPivot cpt_compte = acheancesServise.GetEcheance((int)id);
            //db.GEN_Devises.Find(id);
            if (cpt_compte == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier", cpt_compte.IdDossier);
            //db.GEN_Dossiers.Where(e => e.Actif), "Id", "CodeDossier", gEN_Devises.IdDossier);

            CPT_EcheancesFormViewModel cpt_compteFormModel = Mapper.Map<EcheancesPivot, CPT_EcheancesFormViewModel>(cpt_compte);
            return View(cpt_compteFormModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdEcriture,IdTypePaiement,IdModePaiement,DateEcheance,Pourcentage,MontantTC,IdDeviseTC,MontantTR,IdDeviseTR,Statut,IdDossier,IdDossierSite")] EcheancesPivot cpt_compteG)
        {

            if (ModelState.IsValid)
            {
                cpt_compteG.IdDossier = Constantes.IdentifiantDossier;
                cpt_compteG.sys_dateUpdate = DateTime.Now;
                cpt_compteG.sys_dateCreation = DateTime.Now;
                cpt_compteG.sys_user = Constantes.IdentifiantUser;
                cpt_compteG.IdEcriture = null;
                acheancesServise.UpdateEcheancesPivot(cpt_compteG);
                //   db.SaveChanges();
                acheancesServise.SaveEcheancesPivot();
                return RedirectToAction("Index");
            }
            ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier", cpt_compteG.IdDossier);
            //db.GEN_Dossiers.Where(e => e.Actif), "Id", "CodeDossier", gEN_Devises.IdDossier);

            CPT_EcheancesFormViewModel cpt_compteGFormModel = Mapper.Map<EcheancesPivot, CPT_EcheancesFormViewModel>(cpt_compteG);
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
            EcheancesPivot cpt_compte = acheancesServise.GetEcheance((int)id);
            //db.GEN_Devises.Find(id);
            if (cpt_compte == null)
            {
                return HttpNotFound();
            }

            CPT_EcheancesFormViewModel cpt_codd = Mapper.Map<EcheancesPivot, CPT_EcheancesFormViewModel>(cpt_compte);
            return View(cpt_codd);
        }




        // POST: Commun/TypePaiement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed([Bind(Include = "Id")] CPT_EcheancesFormViewModel cpt_calsses)
        {
            EcheancesPivot cods = Mapper.Map<CPT_EcheancesFormViewModel, EcheancesPivot>(cpt_calsses);
            EcheancesPivot codes = acheancesServise.GetEcheance(cods.Id);


            acheancesServise.DeletEcheancesPivot(codes);
            // db.SaveChanges();
            acheancesServise.SaveEcheancesPivot();
            return RedirectToAction("Index");



        }


    }
}