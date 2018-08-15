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
    public class ClasseController : Controller
    {

        private readonly IClasseService classeServise;
        private readonly IDossiersService dossiersService;

        public ClasseController(IClasseService classeServise, IDossiersService dossiersService)
        {
            this.classeServise = classeServise;
            this.dossiersService = dossiersService;
        }
   
        public ActionResult Index()
        {
           var classses = classeServise.GetALL();

           IEnumerable<CPT_ClasseViewModel> classes_Views = Mapper.Map<IEnumerable<ClassePivot>, IEnumerable<CPT_ClasseViewModel>>(classses);

           return View(classes_Views.AsQueryable());


        }


        /**********/

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
                var cpt_Classs = classeServise.GetClasse(id);
                if (cpt_Classs == null)
                {

                    TempData["errorMessage"] = "La classe que vous cherchez n'existe pas.";
                    return RedirectToAction("Index");
                }
                //  ViewBag.IdDossier = new SelectList(db.GEN_Dossiers.Where(e => e.Actif), "Id", "CodeDossier", gEN_Devises.IdDossier);
                ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier", cpt_Classs.IdDossier);
                CPT_ClasseFormViewModel cpt_classeFormModel = Mapper.Map<ClassePivot, CPT_ClasseFormViewModel>(cpt_Classs);
                return View(cpt_classeFormModel);
            }

        }





        // POST: Commun/Devises/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CodeClasse,Libelle,IdClasse,IdDossier")] ClassePivot cpt_classe)
        {



            // if (ModelState.IsValid)
            if (cpt_classe != null)
            {
                if (cpt_classe.Id > 0)
                {
                    cpt_classe.IdDossier = Constantes.IdentifiantDossier;
                    cpt_classe.Sys_dateUpdate = DateTime.Now;
                    cpt_classe.Sys_dateCreation = DateTime.Now;
                    cpt_classe.sys_user = Constantes.IdentifiantUser;
                  //  gEN_Devises.DevisesActif = true;
                    // db.Entry(gEN_Devises).State = EntityState.Modified;
                    // deviseServise.GetAttributes(gEN_Devises);
                   classeServise.UpdateClassePivot(cpt_classe);
                    classeServise.SaveClassePivot();
                }
                else
                {
                    //gEN_Devises.IdDossier = CurrentPreference.IdDossier;
                    //gEN_Devises.sys_dateCreation = DateTime.Now;
                    //gEN_Devises.sys_dateUpdate = DateTime.Now;
                    //gEN_Devises.sys_user = CurrentUser.Id;
                    // cpt_classe.DevisesActif = true;
                    cpt_classe.IdDossier = Constantes.IdentifiantDossier;
                    cpt_classe.Sys_dateUpdate = DateTime.Now;
                    cpt_classe.Sys_dateCreation = DateTime.Now;
                    cpt_classe.sys_user = Constantes.IdentifiantUser;


                    // deviseServise.GetAttributes(gEN_Devises);

                    classeServise.CreateClassePivot(cpt_classe);
                    classeServise.SaveClassePivot();
                }

                // db.SaveChanges();

                //  return RedirectToAction("Create", new { id = gEN_Devises.DevisesId });
                return RedirectToAction("Index");
            }

            // ViewBag.IdDossier = new SelectList(db.GEN_Dossiers.Where(e => e.Actif), "Id", "CodeDossier", gEN_Devises.IdDossier);
            //ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier", gEN_Devises.DevisesIdDossier);

            //DevisesFormViewModel gEN_DevisesFormModel = Mapper.Map<DevisesPivot, DevisesFormViewModel>(gEN_Devises);

            //return View(gEN_DevisesFormModel);

            ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier", cpt_classe.IdDossier);
            CPT_ClasseFormViewModel cpt_classeFormModel = Mapper.Map<ClassePivot, CPT_ClasseFormViewModel>(cpt_classe);
            return View(cpt_classeFormModel);
        }



        /********/
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // DevisesPivot gEN_Devises = deviseServise.GetDevise(id);
            ClassePivot cpt_class = classeServise.GetClasse(id);
            //db.GEN_Devises.Find(id);
            if (cpt_class == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier", cpt_class.IdDossier);
            //db.GEN_Dossiers.Where(e => e.Actif), "Id", "CodeDossier", gEN_Devises.IdDossier);

            CPT_ClasseFormViewModel cpt_classeFormModel = Mapper.Map<ClassePivot, CPT_ClasseFormViewModel>(cpt_class);
            return View(cpt_classeFormModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CodeClasse,Libelle,IdClasse,IdDossier")] ClassePivot cpt_classe)
        {
         
            if (ModelState.IsValid)
            {
                cpt_classe.IdDossier = Constantes.IdentifiantDossier;
                cpt_classe.Sys_dateUpdate = DateTime.Now;
                cpt_classe.Sys_dateCreation= DateTime.Now;
                cpt_classe.sys_user = Constantes.IdentifiantUser;
                classeServise.UpdateClassePivot(cpt_classe);
                //   db.SaveChanges();
                classeServise.SaveClassePivot();
                return RedirectToAction("Index");
            }
            ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier", cpt_classe.IdDossier);
            //db.GEN_Dossiers.Where(e => e.Actif), "Id", "CodeDossier", gEN_Devises.IdDossier);

            CPT_ClasseFormViewModel cpt_classeFormModel = Mapper.Map<ClassePivot, CPT_ClasseFormViewModel>(cpt_classe);
            return View(cpt_classeFormModel);

        }


        public ActionResult Delete(long? id)
        {
            ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier");
            //db.GEN_Dossiers.Where(e => e.Actif), "Id", "CodeDossier");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassePivot cpt_calss = classeServise.GetClasse(id);
            //db.GEN_Devises.Find(id);
            if (cpt_calss == null)
            {
                return HttpNotFound();
            }

            CPT_ClasseFormViewModel cpt_classe = Mapper.Map<ClassePivot, CPT_ClasseFormViewModel>(cpt_calss);
            return View(cpt_classe);
        }




        // POST: Commun/TypePaiement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed([Bind(Include = "Id")] CPT_ClasseFormViewModel cpt_calsses)
        {
            ClassePivot calass = Mapper.Map<CPT_ClasseFormViewModel, ClassePivot>(cpt_calsses);
            ClassePivot calasse =classeServise.GetClasse(calass.Id);


            classeServise.DeleteClassePivot(calasse);
            // db.SaveChanges();
            classeServise.SaveClassePivot();
            return RedirectToAction("Index");



        }


    }
}