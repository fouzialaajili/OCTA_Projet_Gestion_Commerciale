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
    public class GEN_DossiersContactsController : Controller
    {
        private readonly IDossiersContactsService dossiersContactsServise;
        private readonly IDossiersService dossiersService;

        public GEN_DossiersContactsController(IDossiersContactsService dossiersContactsServise, IDossiersService dossiersService)
        {
            this.dossiersContactsServise = dossiersContactsServise;
            this.dossiersService = dossiersService;
        }

        public ActionResult Index()
        {
            var comptes = dossiersContactsServise.GetALL();

            IEnumerable<DossierContactsViewModel> comptes_Views = Mapper.Map<IEnumerable<DossiersContactsPivot>, IEnumerable<DossierContactsViewModel>>(comptes);

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
                var dossiers = dossiersContactsServise.GetDossiersContactsPivot((int)id);
                if (dossiers == null)
                {

                    TempData["errorMessage"] = "Le  document que vous cherchez n'existe pas.";
                    return RedirectToAction("Index");
                }
                //  ViewBag.IdDossier = new SelectList(db.GEN_Dossiers.Where(e => e.Actif), "Id", "CodeDossier", gEN_Devises.IdDossier);
                ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier", dossiers.IdDossier);
                DossierContactsFromViewModel dossiersFormModel = Mapper.Map<DossiersContactsPivot, DossierContactsFromViewModel>(dossiers);
                return View(dossiersFormModel);
            }

        }





        // POST: Commun/Devises/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DossiersContactsId,Civilite,Nom,Prenom,Tel,Gsm,Email,Actif,ParDefault,IdDossier")] DossiersContactsPivot dossiers)
        {



            // if (ModelState.IsValid)
            if (dossiers != null)
            {
                if (dossiers.DossiersContactsId > 0)
                {
                    dossiers.IdDossier = Constantes.IdentifiantDossier;
                    dossiers.sys_dateUpdate = DateTime.Now;
                    dossiers.sys_dateCreation = DateTime.Now;
                    dossiers.sys_user = Constantes.IdentifiantUser;
                    dossiers.Actif = true;

                    dossiersContactsServise.UpdateDossiersContactsPivot(dossiers);
                    dossiersContactsServise.SaveDossiersContacts();
                }
                else
                {

                    dossiers.IdDossier = Constantes.IdentifiantDossier;
                    dossiers.sys_dateUpdate = DateTime.Now;
                    dossiers.sys_dateCreation = DateTime.Now;
                    dossiers.sys_user = Constantes.IdentifiantUser;
                    dossiers.Actif = true;
                    dossiersContactsServise.CreateDossiersContactsPivot(dossiers);
                    dossiersContactsServise.SaveDossiersContacts();
                }


                return RedirectToAction("Index");
            }



            ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier", dossiers.IdDossier);
            DossierContactsFromViewModel cpt_dossierFormModel = Mapper.Map<DossiersContactsPivot, DossierContactsFromViewModel>(dossiers);
            return View(cpt_dossierFormModel);
        }



        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // DevisesPivot gEN_Devises = deviseServise.GetDevise(id);
            DossiersContactsPivot doss= dossiersContactsServise.GetDossiersContactsPivot((int)id);
            //db.GEN_Devises.Find(id);
            if (doss == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier", doss.IdDossier);
            //db.GEN_Dossiers.Where(e => e.Actif), "Id", "CodeDossier", gEN_Devises.IdDossier);

            DossierContactsFromViewModel cpt_compteFormModel = Mapper.Map<DossiersContactsPivot, DossierContactsFromViewModel>(doss);
            return View(cpt_compteFormModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DossiersContactsId,Civilite,Nom,Prenom,Tel,Gsm,Email,Actif,ParDefault,IdDossier")]  DossiersContactsPivot dossier)
        {

            if (ModelState.IsValid)
            {
                dossier.IdDossier = Constantes.IdentifiantDossier;
                dossier.sys_dateUpdate = DateTime.Now;
                dossier.sys_dateCreation = DateTime.Now;
                dossier.sys_user = Constantes.IdentifiantUser;
                dossier.Actif = true;

                dossiersContactsServise.UpdateDossiersContactsPivot(dossier);
                //   db.SaveChanges();
                dossiersContactsServise.SaveDossiersContacts();
                return RedirectToAction("Index");
            }
            ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier", dossier.IdDossier);
            DossierContactsFromViewModel cpt_compteGFormModel = Mapper.Map<DossiersContactsPivot, DossierContactsFromViewModel>(dossier);
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
          DossiersContactsPivot Dossier = dossiersContactsServise.GetDossiersContactsPivot((int)id);
            //db.GEN_Devises.Find(id);
            if (Dossier == null)
            {
                return HttpNotFound();
            }

            DossierContactsFromViewModel cpt_codd = Mapper.Map<DossiersContactsPivot, DossierContactsFromViewModel>(Dossier);
            return View(cpt_codd);
        }




        // POST: Commun/TypePaiement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed([Bind(Include = "DossiersContactsId")] DossierContactsFromViewModel cpt_calsses)
        {
            DossiersContactsPivot cods = Mapper.Map<DossierContactsFromViewModel, DossiersContactsPivot>(cpt_calsses);
            DossiersContactsPivot codes = dossiersContactsServise.GetDossiersContactsPivot(cods.DossiersContactsId);


            dossiersContactsServise.DeleteDossiersContactsPivot(codes);
            // db.SaveChanges();
            dossiersContactsServise.SaveDossiersContacts();
            return RedirectToAction("Index");



        }


    }
}