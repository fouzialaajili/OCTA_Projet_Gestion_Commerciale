﻿using AutoMapper;
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
    public class CPT_RelevesBancairesController : Controller
    {
        private readonly IRelevesBancairesService RelevesBancairesServise;
        private readonly IDossiersService dossiersService;

        public CPT_RelevesBancairesController(IRelevesBancairesService RelevesBancairesServise, IDossiersService dossiersService)
        {
            this.RelevesBancairesServise = RelevesBancairesServise;
            this.dossiersService = dossiersService;
        }

        public ActionResult Index()
        {
            var comptes = RelevesBancairesServise.GetALL();

            IEnumerable<CPT_RelevesBancairesViewModel> comptes_Views = Mapper.Map<IEnumerable<RelevesBancairesPivot>, IEnumerable<CPT_RelevesBancairesViewModel>>(comptes);

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
                ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier", cpt_Comptes.IdDossier);
                CPT_RelevesBancairesFormViewModel cpt_ComptesFormModel = Mapper.Map<RelevesBancairesPivot, CPT_RelevesBancairesFormViewModel>(cpt_Comptes);
                return View(cpt_ComptesFormModel);
            }

        }





        // POST: Commun/Devises/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DateIntegration,IdCompteBancaire,IdDevise,Description,SoldeDebut,SoldeFin,Valide,IdDossier,Fichier")] RelevesBancairesPivot cpt_comptes)
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

                    cpt_comptes.IdCompteBancaire = null;
                    cpt_comptes.IdDevise = null;
                    cpt_comptes.Fichier = null;
                    RelevesBancairesServise.UpdateRelevesBancairesPivot(cpt_comptes);
                    RelevesBancairesServise.SaveRelevesBancairesPivot();
                }
                else
                {

                    cpt_comptes.IdDossier = Constantes.IdentifiantDossier;
                    cpt_comptes.sys_dateUpdate = DateTime.Now;
                    cpt_comptes.sys_dateCreation = DateTime.Now;
                    cpt_comptes.sys_user = Constantes.IdentifiantUser;
                    cpt_comptes.Fichier = null;
                    cpt_comptes.IdCompteBancaire = null;
                    cpt_comptes.IdDevise = null;


                    RelevesBancairesServise.CreateRelevesBancairesPivot(cpt_comptes);
                    RelevesBancairesServise.SaveRelevesBancairesPivot();
                }


                return RedirectToAction("Index");
            }



            ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier", cpt_comptes.IdDossier);
            CPT_RelevesBancairesFormViewModel cpt_comptsFormModel = Mapper.Map<RelevesBancairesPivot, CPT_RelevesBancairesFormViewModel>(cpt_comptes);
            return View(cpt_comptsFormModel);
        }



        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // DevisesPivot gEN_Devises = deviseServise.GetDevise(id);
            RelevesBancairesPivot cpt_compte = RelevesBancairesServise.GetRelevesBancaires((int)id);
            //db.GEN_Devises.Find(id);
            if (cpt_compte == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier", cpt_compte.IdDossier);
            //db.GEN_Dossiers.Where(e => e.Actif), "Id", "CodeDossier", gEN_Devises.IdDossier);

            CPT_RelevesBancairesFormViewModel cpt_compteFormModel = Mapper.Map<RelevesBancairesPivot, CPT_RelevesBancairesFormViewModel>(cpt_compte);
            return View(cpt_compteFormModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DateIntegration,IdCompteBancaire,IdDevise,Description,SoldeDebut,SoldeFin,Valide,IdDossier,Fichier")]  RelevesBancairesPivot cpt_compteG)
        {

            if (ModelState.IsValid)
            {
                cpt_compteG.IdDossier = Constantes.IdentifiantDossier;
                cpt_compteG.sys_dateUpdate = DateTime.Now;
                cpt_compteG.sys_dateCreation = DateTime.Now;
                cpt_compteG.sys_user = Constantes.IdentifiantUser;
                cpt_compteG.IdCompteBancaire = null;
                cpt_compteG.IdDevise = null;
                cpt_compteG.Fichier = null;
                RelevesBancairesServise.UpdateRelevesBancairesPivot(cpt_compteG);
                //   db.SaveChanges();
                RelevesBancairesServise.SaveRelevesBancairesPivot();
                return RedirectToAction("Index");
            }
            ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier", cpt_compteG.IdDossier);
            //db.GEN_Dossiers.Where(e => e.Actif), "Id", "CodeDossier", gEN_Devises.IdDossier);

            CPT_RelevesBancairesFormViewModel cpt_compteGFormModel = Mapper.Map<RelevesBancairesPivot, CPT_RelevesBancairesFormViewModel>(cpt_compteG);
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
            RelevesBancairesPivot cpt_compte = RelevesBancairesServise.GetRelevesBancaires((int)id);
            //db.GEN_Devises.Find(id);
            if (cpt_compte == null)
            {
                return HttpNotFound();
            }

            CPT_RelevesBancairesFormViewModel cpt_codd = Mapper.Map<RelevesBancairesPivot, CPT_RelevesBancairesFormViewModel>(cpt_compte);
            return View(cpt_codd);
        }




        // POST: Commun/TypePaiement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed([Bind(Include = "Id")] CPT_RelevesBancairesFormViewModel cpt_calsses)
        {
            RelevesBancairesPivot cods = Mapper.Map<CPT_RelevesBancairesFormViewModel, RelevesBancairesPivot>(cpt_calsses);
           RelevesBancairesPivot codes = RelevesBancairesServise.GetRelevesBancaires(cods.Id);


            RelevesBancairesServise.DeletRelevesBancairesPivot(codes);
            // db.SaveChanges();
            RelevesBancairesServise.SaveRelevesBancairesPivot();
            return RedirectToAction("Index");



        }


    }
}