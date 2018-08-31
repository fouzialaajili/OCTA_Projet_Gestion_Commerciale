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
    public class GEN_DossiersSitesController : Controller
    {
        private readonly IDossiersSitesService dossiersSiteServise;
        private readonly IDossiersService dossiersService;

        public GEN_DossiersSitesController(IDossiersSitesService dossiersSiteServise, IDossiersService dossiersService)
        {
            this.dossiersSiteServise = dossiersSiteServise;
            this.dossiersService = dossiersService;
        }

        public ActionResult Index()
        {
            var comptes = dossiersSiteServise.GetAllDossierSite();

            IEnumerable<DossiersSitesViewModel> comptes_Views = Mapper.Map<IEnumerable<DossiersSitesPivot>, IEnumerable<DossiersSitesViewModel >>(comptes);

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
                var dossiers = dossiersSiteServise.GetDossiersSitePivot((int)id);
                if (dossiers == null)
                {

                    TempData["errorMessage"] = "Le  document que vous cherchez n'existe pas.";
                    return RedirectToAction("Index");
                }
                //  ViewBag.IdDossier = new SelectList(db.GEN_Dossiers.Where(e => e.Actif), "Id", "CodeDossier", gEN_Devises.IdDossier);
                ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier", dossiers.IdDossier);
                DossiersSitesFromViewModel dossiersFormModel = Mapper.Map<DossiersSitesPivot, DossiersSitesFromViewModel>(dossiers);
                return View(dossiersFormModel);
            }

        }





        // POST: Commun/Devises/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Adresse,Nom,Pays,Tel,Ville,Email,Actif,ParDefault,Fax,IdDossier")] DossiersSitesPivot dossiers)
        {



            // if (ModelState.IsValid)
            if (dossiers != null)
            {
                if (dossiers.Id > 0)
                {
                    dossiers.IdDossier = Constantes.IdentifiantDossier;
                    dossiers.sys_dateUpdate = DateTime.Now;
                    dossiers.sys_dateCreation = DateTime.Now;
                    dossiers.sys_user = Constantes.IdentifiantUser;
                    dossiers.Actif = true;

                    dossiersSiteServise.UpdateDossierSitePivot(dossiers);
                    dossiersSiteServise.SaveDossiersSite();
                }
                else
                {

                    dossiers.IdDossier = Constantes.IdentifiantDossier;
                    dossiers.sys_dateUpdate = DateTime.Now;
                    dossiers.sys_dateCreation = DateTime.Now;
                    dossiers.sys_user = Constantes.IdentifiantUser;
                    dossiers.Actif = true;
                    dossiersSiteServise.CreateDossiersSitePivot(dossiers);
                    dossiersSiteServise.SaveDossiersSite();
                }


                return RedirectToAction("Index");
            }



            ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier", dossiers.IdDossier);
            DossiersSitesFromViewModel cpt_dossierFormModel = Mapper.Map<DossiersSitesPivot, DossiersSitesFromViewModel>(dossiers);
            return View(cpt_dossierFormModel);
        }



        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // DevisesPivot gEN_Devises = deviseServise.GetDevise(id);
            DossiersSitesPivot doss = dossiersSiteServise.GetDossiersSitePivot((int)id);
            //db.GEN_Devises.Find(id);
            if (doss == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier", doss.IdDossier);
            //db.GEN_Dossiers.Where(e => e.Actif), "Id", "CodeDossier", gEN_Devises.IdDossier);

            DossiersSitesFromViewModel cpt_compteFormModel = Mapper.Map<DossiersSitesPivot, DossiersSitesFromViewModel>(doss);
            return View(cpt_compteFormModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Adresse,Nom,Pays,Tel,Ville,Email,Actif,ParDefault,Fax,IdDossier")]  DossiersSitesPivot dossier)
        {

            if (ModelState.IsValid)
            {
                dossier.IdDossier = Constantes.IdentifiantDossier;
                dossier.sys_dateUpdate = DateTime.Now;
                dossier.sys_dateCreation = DateTime.Now;
                dossier.sys_user = Constantes.IdentifiantUser;
                dossier.Actif = true;

                dossiersSiteServise.UpdateDossierSitePivot(dossier);
                //   db.SaveChanges();
                dossiersSiteServise.SaveDossiersSite();
                return RedirectToAction("Index");
            }
            ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier", dossier.IdDossier);
            DossiersSitesFromViewModel cpt_compteGFormModel = Mapper.Map<DossiersSitesPivot, DossiersSitesFromViewModel>(dossier);
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
            DossiersSitesPivot Dossier = dossiersSiteServise.GetDossiersSitePivot((int)id);
            //db.GEN_Devises.Find(id);
            if (Dossier == null)
            {
                return HttpNotFound();
            }

            DossiersSitesFromViewModel cpt_codd = Mapper.Map<DossiersSitesPivot, DossiersSitesFromViewModel>(Dossier);
            return View(cpt_codd);
        }




        // POST: Commun/TypePaiement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed([Bind(Include = "Id")] DossiersSitesFromViewModel cpt_calsses)
        {
            DossiersSitesPivot cods = Mapper.Map<DossiersSitesFromViewModel, DossiersSitesPivot>(cpt_calsses);
            DossiersSitesPivot codes = dossiersSiteServise.GetDossiersSitePivot(cods.Id);


            dossiersSiteServise.DeleteDossiersSitePivot(codes);
            // db.SaveChanges();
            dossiersSiteServise.SaveDossiersSite();
            return RedirectToAction("Index");



        }


    }
}