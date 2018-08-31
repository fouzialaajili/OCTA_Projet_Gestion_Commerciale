using AutoMapper;
using OCTA_Projet_Gestion_Commerciale.Data.Utils;
using OCTA_Projet_Gestion_Commerciale.Service.Implementation;
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
    public class GEN_DocumentsController : Controller
    {
        private readonly IDocumentsService documentsServise;
        private readonly IDossiersService dossiersService;

        public GEN_DocumentsController(IDocumentsService documentsServise, IDossiersService dossiersService)
        {
            this.documentsServise = documentsServise;
            this.dossiersService = dossiersService;
        }

        public ActionResult Index()
        {
            var comptes = documentsServise.GetALL();

            IEnumerable<DocumentsViewModel> comptes_Views = Mapper.Map<IEnumerable<DocumentsPivot>, IEnumerable<DocumentsViewModel>>(comptes);

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
                var cpt_Comptes = documentsServise.GetDocuments((int)id);
                if (cpt_Comptes == null)
                {

                    TempData["errorMessage"] = "Le  document que vous cherchez n'existe pas.";
                    return RedirectToAction("Index");
                }
                //  ViewBag.IdDossier = new SelectList(db.GEN_Dossiers.Where(e => e.Actif), "Id", "CodeDossier", gEN_Devises.IdDossier);
                ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier", cpt_Comptes.IdDossier);
               DocumentsFormViewModel cpt_ComptesFormModel = Mapper.Map<DocumentsPivot, DocumentsFormViewModel>(cpt_Comptes);
                return View(cpt_ComptesFormModel);
            }

        }





        // POST: Commun/Devises/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Libelle,Tags,Fichier,NomObjetClasse,IdObjet,IdDossier")] DocumentsPivot cpt_comptes)
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
                    cpt_comptes.Fichier = null;

                    documentsServise.UpdateDocumentsPivot(cpt_comptes);
                    documentsServise.SaveDocumentsPivot();
                }
                else
                {

                    cpt_comptes.IdDossier = Constantes.IdentifiantDossier;
                    cpt_comptes.sys_dateUpdate = DateTime.Now;
                    cpt_comptes.sys_dateCreation = DateTime.Now;
                    cpt_comptes.sys_user = Constantes.IdentifiantUser;
                    cpt_comptes.Fichier = null;
                    // cpt_comptes.Fichier = null;
                    documentsServise.CreateDocumentsPivot(cpt_comptes);
                    documentsServise.SaveDocumentsPivot();
                }


                return RedirectToAction("Index");
            }



            ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier", cpt_comptes.IdDossier);
            DocumentsFormViewModel cpt_comptsFormModel = Mapper.Map<DocumentsPivot, DocumentsFormViewModel>(cpt_comptes);
            return View(cpt_comptsFormModel);
        }



        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // DevisesPivot gEN_Devises = deviseServise.GetDevise(id);
            DocumentsPivot cpt_compte = documentsServise.GetDocuments((int)id);
            //db.GEN_Devises.Find(id);
            if (cpt_compte == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier", cpt_compte.IdDossier);
            //db.GEN_Dossiers.Where(e => e.Actif), "Id", "CodeDossier", gEN_Devises.IdDossier);

            DocumentsFormViewModel cpt_compteFormModel = Mapper.Map<DocumentsPivot, DocumentsFormViewModel>(cpt_compte);
            return View(cpt_compteFormModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Libelle,Tags,Fichier,NomObjetClasse,IdObjet,IdDossier")]  DocumentsPivot cpt_compteG)
        {

            if (ModelState.IsValid)
            {
                cpt_compteG.IdDossier = Constantes.IdentifiantDossier;
                cpt_compteG.sys_dateUpdate = DateTime.Now;
                cpt_compteG.sys_dateCreation = DateTime.Now;
                cpt_compteG.sys_user = Constantes.IdentifiantUser;
                cpt_compteG.Fichier = null;
                documentsServise.UpdateDocumentsPivot(cpt_compteG);
                //   db.SaveChanges();
                documentsServise.SaveDocumentsPivot();
                return RedirectToAction("Index");
            }
            ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier", cpt_compteG.IdDossier);
            //db.GEN_Dossiers.Where(e => e.Actif), "Id", "CodeDossier", gEN_Devises.IdDossier);

            DocumentsFormViewModel cpt_compteGFormModel = Mapper.Map<DocumentsPivot, DocumentsFormViewModel>(cpt_compteG);
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
            DocumentsPivot cpt_compte =documentsServise.GetDocuments((int)id);
            //db.GEN_Devises.Find(id);
            if (cpt_compte == null)
            {
                return HttpNotFound();
            }

            DocumentsFormViewModel cpt_codd = Mapper.Map<DocumentsPivot, DocumentsFormViewModel>(cpt_compte);
            return View(cpt_codd);
        }




        // POST: Commun/TypePaiement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed([Bind(Include = "Id")] DocumentsFormViewModel cpt_calsses)
        {
            DocumentsPivot cods = Mapper.Map<DocumentsFormViewModel, DocumentsPivot>(cpt_calsses);
            DocumentsPivot codes = documentsServise.GetDocuments(cods.Id);


            documentsServise.DeletDocumentsPivot(codes);
            // db.SaveChanges();
            documentsServise.SaveDocumentsPivot();
            return RedirectToAction("Index");



        }


    }
}