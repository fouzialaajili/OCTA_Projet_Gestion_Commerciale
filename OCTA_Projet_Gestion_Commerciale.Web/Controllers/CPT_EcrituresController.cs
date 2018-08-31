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
    public class CPT_EcrituresController : Controller
    {
        private readonly IEcritureService ecriturecesServise;
        private readonly IDossiersService dossiersService;

        public CPT_EcrituresController(IEcritureService ecriturecesServise, IDossiersService dossiersService)
        {
            this.ecriturecesServise = ecriturecesServise;
            this.dossiersService = dossiersService;
        }

        public ActionResult Index()
        {
            var cpt_Ecriture = ecriturecesServise.GetALL();

            IEnumerable<CPT_EcrituresViewModel> cpt_Ecriture_Views = Mapper.Map<IEnumerable<EcrituresPivot>, IEnumerable<CPT_EcrituresViewModel>>(cpt_Ecriture);

            return View(cpt_Ecriture_Views.AsQueryable());


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
                var cpt_Ecriture = ecriturecesServise.GetEcritures((int)id);
                if (cpt_Ecriture == null)
                {

                    TempData["errorMessage"] = "L'echeance que vous cherchez n'existe pas.";
                    return RedirectToAction("Index");
                }
                //  ViewBag.IdDossier = new SelectList(db.GEN_Dossiers.Where(e => e.Actif), "Id", "CodeDossier", gEN_Devises.IdDossier);
                ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier", cpt_Ecriture.IdDossier);
                CPT_EcrituresFormViewModel cpt_EcheanceFormModel = Mapper.Map<EcrituresPivot, CPT_EcrituresFormViewModel>(cpt_Ecriture);
                return View(cpt_EcheanceFormModel);
            }

        }





        // POST: Commun/Devises/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdPiece,DateEcriture,IdCompteG,LibelleEcriture,Reference,IdTauxTVA,Taux,IdDeviceTC,DebitTC,CreditTC,IdDeviceTR,DebitTR,CreditTR,IdTiers,IdSectionANA,IdSectionBUD,IdTypePaiement,CodePointage,IdentifiantUniqueLettrage,Rapprochement,NumOrdre,IdDossier,IdDossierSite")] EcrituresPivot cpt_Ecriture)
        {



            // if (ModelState.IsValid)
            if (cpt_Ecriture != null)
            {
                if (cpt_Ecriture.Id > 0)
                {
                    cpt_Ecriture.IdDossier = Constantes.IdentifiantDossier;
                    cpt_Ecriture.sys_dateUpdate = DateTime.Now;
                    cpt_Ecriture.sys_dateCreation = DateTime.Now;
                    cpt_Ecriture.IdCompteG = null;
                    cpt_Ecriture.IdPiece = null;
                    cpt_Ecriture.IdDeviceTC = null;
                    cpt_Ecriture.IdDeviceTR = null;
                    cpt_Ecriture.IdDossierSite = null;

                    cpt_Ecriture.sys_user = Constantes.IdentifiantUser;


                    ecriturecesServise.UpdatEcrituresPivot(cpt_Ecriture);
                    ecriturecesServise.SaveEcrituresPivot();
                }
                else
                {

                    cpt_Ecriture.IdDossier = Constantes.IdentifiantDossier;
                    cpt_Ecriture.sys_dateUpdate = DateTime.Now;
                    cpt_Ecriture.sys_dateCreation = DateTime.Now;
                    cpt_Ecriture.sys_user = Constantes.IdentifiantUser;
                    cpt_Ecriture.IdPiece = null;
                    cpt_Ecriture.IdCompteG = null;
                    cpt_Ecriture.IdDeviceTC = null;
                    cpt_Ecriture.IdDeviceTR = null;
                    cpt_Ecriture.IdDossierSite = null;



                    ecriturecesServise.CreateEcrituresPivot(cpt_Ecriture);
                    ecriturecesServise.SaveEcrituresPivot();
                }


                return RedirectToAction("Index");
            }



            ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier", cpt_Ecriture.IdDossier);
            CPT_EcrituresFormViewModel ecrituresFormModel = Mapper.Map<EcrituresPivot, CPT_EcrituresFormViewModel>(cpt_Ecriture);
            return View(ecrituresFormModel);
        }



        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // DevisesPivot gEN_Devises = deviseServise.GetDevise(id);
            EcrituresPivot cpt_ecriture = ecriturecesServise.GetEcritures((int)id);
            //db.GEN_Devises.Find(id);
            if (cpt_ecriture == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier", cpt_ecriture.IdDossier);
            //db.GEN_Dossiers.Where(e => e.Actif), "Id", "CodeDossier", gEN_Devises.IdDossier);

            CPT_EcrituresFormViewModel cpt_ecritureFormModel = Mapper.Map<EcrituresPivot, CPT_EcrituresFormViewModel>(cpt_ecriture);
            return View(cpt_ecritureFormModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdPiece,DateEcriture,IdCompteG,LibelleEcriture,Reference,IdTauxTVA,Taux,IdDeviceTC,DebitTC,CreditTC,IdDeviceTR,DebitTR,CreditTR,IdTiers,IdSectionANA,IdSectionBUD,IdTypePaiement,CodePointage,IdentifiantUniqueLettrage,Rapprochement,NumOrdre,IdDossier,IdDossierSite")] EcrituresPivot cpt_ecriture)
        {

            if (ModelState.IsValid)
            {
                cpt_ecriture.IdDossier = Constantes.IdentifiantDossier;
                cpt_ecriture.sys_dateUpdate = DateTime.Now;
                cpt_ecriture.sys_dateCreation = DateTime.Now;
                cpt_ecriture.sys_user = Constantes.IdentifiantUser;
                cpt_ecriture.IdCompteG = null;
                cpt_ecriture.IdPiece = null;
                cpt_ecriture.IdDeviceTC = null;
                cpt_ecriture.IdDeviceTR = null;
                cpt_ecriture.IdDossierSite = null;

                ecriturecesServise.UpdatEcrituresPivot(cpt_ecriture);
                //   db.SaveChanges();
                ecriturecesServise.SaveEcrituresPivot();
                return RedirectToAction("Index");
            }
            ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier", cpt_ecriture.IdDossier);
            //db.GEN_Dossiers.Where(e => e.Actif), "Id", "CodeDossier", gEN_Devises.IdDossier);

            CPT_EcrituresFormViewModel cpt_ecritureFormModel = Mapper.Map<EcrituresPivot, CPT_EcrituresFormViewModel>(cpt_ecriture);
            return View(cpt_ecritureFormModel);

        }


        public ActionResult Delete(long? id)
        {
            ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier");
            //db.GEN_Dossiers.Where(e => e.Actif), "Id", "CodeDossier");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EcrituresPivot cpt_ecriture = ecriturecesServise.GetEcritures((int)id);
            //db.GEN_Devises.Find(id);
            if (cpt_ecriture == null)
            {
                return HttpNotFound();
            }

            CPT_EcrituresFormViewModel cpt_codd = Mapper.Map<EcrituresPivot, CPT_EcrituresFormViewModel>(cpt_ecriture);
            return View(cpt_codd);
        }




        // POST: Commun/TypePaiement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed([Bind(Include = "Id")] CPT_EcrituresFormViewModel cpt_ecriture)
        {
            EcrituresPivot cods = Mapper.Map<CPT_EcrituresFormViewModel, EcrituresPivot>(cpt_ecriture);
            EcrituresPivot codes = ecriturecesServise.GetEcritures(cods.Id);


            ecriturecesServise.DeletEcrituresPivot(codes);
            // db.SaveChanges();
            ecriturecesServise.SaveEcrituresPivot();
            return RedirectToAction("Index");



        }


    }
}