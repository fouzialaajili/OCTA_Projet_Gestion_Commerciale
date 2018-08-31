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
    public class CodesTVAController : Controller
    {
   private readonly ICodesTVAService codesServise;
       private readonly IDossiersService dossiersService;

        public CodesTVAController(ICodesTVAService codesServise, IDossiersService dossiersService)
        {
            this.codesServise = codesServise;
            this.dossiersService = dossiersService;
        }

        public ActionResult Index()
        {
            var codss = codesServise.GetALL();

            IEnumerable<CPT_CodesTVAViewModel> codes_Views = Mapper.Map<IEnumerable<CodesTVAPivot>, IEnumerable<CPT_CodesTVAViewModel>>(codss);

            return View(codes_Views.AsQueryable());


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
                var cpt_Codes = codesServise.GetCodesTVAPivot((int)id);
                if (cpt_Codes == null)
                {

                    TempData["errorMessage"] = "Le codes tva que vous cherchez n'existe pas.";
                    return RedirectToAction("Index");
                }
                //  ViewBag.IdDossier = new SelectList(db.GEN_Dossiers.Where(e => e.Actif), "Id", "CodeDossier", gEN_Devises.IdDossier);
                ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier", cpt_Codes.IdDossier);
                CPT_CodesTVAFormViewModel cpt_codeFormModel = Mapper.Map<CodesTVAPivot, CPT_CodesTVAFormViewModel>(cpt_Codes);
                return View(cpt_codeFormModel);
            }

        }





        // POST: Commun/Devises/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CodeTaux,LibelleTaux,TypeTVA,Percue,Exonere,TauxTVA,IdRubriqueDeclaration,Actif,IdCompteTVA")] CodesTVAPivot cpt_codes)
        {



            // if (ModelState.IsValid)
            if (cpt_codes != null)
            {
                if (cpt_codes.Id > 0)
                {
                    cpt_codes.IdDossier = Constantes.IdentifiantDossier;
                    cpt_codes.sys_dateUpdate = DateTime.Now;
                    cpt_codes.sys_dateCreation = DateTime.Now;
                    cpt_codes.sys_user = Constantes.IdentifiantUser;
                    cpt_codes.Actif = true;
                    cpt_codes.IdCompteTVA = null;
                    // db.Entry(gEN_Devises).State = EntityState.Modified;
                    // deviseServise.GetAttributes(gEN_Devises);
                    codesServise.UpdateCodesTVAPivot(cpt_codes);
                    codesServise.SaveCodesTVAPivot();
                }
                else
                {
                    //gEN_Devises.IdDossier = CurrentPreference.IdDossier;
                    //gEN_Devises.sys_dateCreation = DateTime.Now;
                    //gEN_Devises.sys_dateUpdate = DateTime.Now;
                    //gEN_Devises.sys_user = CurrentUser.Id;
                    // cpt_classe.DevisesActif = true;
                    cpt_codes.IdDossier = Constantes.IdentifiantDossier;
                    cpt_codes.sys_dateUpdate = DateTime.Now;
                    cpt_codes.sys_dateCreation = DateTime.Now;
                    cpt_codes.sys_user = Constantes.IdentifiantUser;
                    cpt_codes.Actif = true;
                    cpt_codes.IdCompteTVA = null;

                    // deviseServise.GetAttributes(gEN_Devises);

                    codesServise.CreateCodesTVAPivot(cpt_codes);
                    codesServise.SaveCodesTVAPivot();
                }

                // db.SaveChanges();

                //  return RedirectToAction("Create", new { id = gEN_Devises.DevisesId });
                return RedirectToAction("Index");
            }

            // ViewBag.IdDossier = new SelectList(db.GEN_Dossiers.Where(e => e.Actif), "Id", "CodeDossier", gEN_Devises.IdDossier);
            //ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier", gEN_Devises.DevisesIdDossier);

            //DevisesFormViewModel gEN_DevisesFormModel = Mapper.Map<DevisesPivot, DevisesFormViewModel>(gEN_Devises);

            //return View(gEN_DevisesFormModel);

            ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier", cpt_codes.IdDossier);
            CPT_CodesTVAFormViewModel cpt_codeseFormModel = Mapper.Map<CodesTVAPivot, CPT_CodesTVAFormViewModel>(cpt_codes);
            return View(cpt_codeseFormModel);
        }


    
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // DevisesPivot gEN_Devises = deviseServise.GetDevise(id);
            CodesTVAPivot cpt_cod = codesServise.GetCodesTVAPivot((int)id);
            //db.GEN_Devises.Find(id);
            if (cpt_cod == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier", cpt_cod.IdDossier);
            //db.GEN_Dossiers.Where(e => e.Actif), "Id", "CodeDossier", gEN_Devises.IdDossier);

            CPT_CodesTVAFormViewModel cpt_codesFormModel = Mapper.Map<CodesTVAPivot, CPT_CodesTVAFormViewModel>(cpt_cod);
            return View(cpt_codesFormModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CodeTaux,LibelleTaux,TypeTVA,Percue,Exonere,TauxTVA,IdRubriqueDeclaration,Actif,IdCompteTVA")]  CodesTVAPivot cpt_codestva)
        {

            if (ModelState.IsValid)
            {
                cpt_codestva.IdDossier = Constantes.IdentifiantDossier;
                cpt_codestva.sys_dateUpdate = DateTime.Now;
                cpt_codestva.sys_dateCreation = DateTime.Now;
                cpt_codestva.sys_user = Constantes.IdentifiantUser;
                codesServise.UpdateCodesTVAPivot(cpt_codestva);
                //   db.SaveChanges();
                codesServise.SaveCodesTVAPivot();
                return RedirectToAction("Index");
            }
            ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier", cpt_codestva.IdDossier);
            //db.GEN_Dossiers.Where(e => e.Actif), "Id", "CodeDossier", gEN_Devises.IdDossier);

            CPT_CodesTVAFormViewModel cpt_codesFormModel = Mapper.Map<CodesTVAPivot, CPT_CodesTVAFormViewModel>(cpt_codestva);
            return View(cpt_codesFormModel);

        }


        public ActionResult Delete(long? id)
        {
            ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier");
            //db.GEN_Dossiers.Where(e => e.Actif), "Id", "CodeDossier");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CodesTVAPivot cpt_codss = codesServise.GetCodesTVAPivot((int)id);
            //db.GEN_Devises.Find(id);
            if (cpt_codss == null)
            {
                return HttpNotFound();
            }

            CPT_CodesTVAFormViewModel cpt_codd = Mapper.Map<CodesTVAPivot, CPT_CodesTVAFormViewModel>(cpt_codss);
            return View(cpt_codd);
        }




        // POST: Commun/TypePaiement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed([Bind(Include = "Id")] CPT_CodesTVAFormViewModel cpt_calsses)
        {
            CodesTVAPivot cods = Mapper.Map<CPT_CodesTVAFormViewModel, CodesTVAPivot>(cpt_calsses);
            CodesTVAPivot codes = codesServise.GetCodesTVAPivot(cods.Id);


            codesServise.DeleteCodesTVAPivot(codes);
            // db.SaveChanges();
            codesServise.SaveCodesTVAPivot();
            return RedirectToAction("Index");



        }


    }
}