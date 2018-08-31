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
    public class GES_AffaireController : Controller
    {
        private readonly IAffaireService AffaireServise;
        private readonly IDossiersService dossiersService;

        public GES_AffaireController(IAffaireService AffaireServise, IDossiersService dossiersService)
        {
            this.AffaireServise = AffaireServise;
            this.dossiersService = dossiersService;
        }

        public ActionResult Index()
        {
            var Affaire = AffaireServise.GetALL();

            IEnumerable<AffaireViewModel> Affaire_Views = Mapper.Map<IEnumerable<AffairePivot>, IEnumerable<AffaireViewModel>>(Affaire);

            return View(Affaire_Views.AsQueryable());


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
                var Affaire = AffaireServise.GetAffaire((int)id);
                if (Affaire == null)
                {

                    TempData["errorMessage"] = "Affaire que vous cherchez n'existe pas.";
                    return RedirectToAction("Index");
                }

                AffaireFormViewModel AffaireFormModel = Mapper.Map<AffairePivot, AffaireFormViewModel>(Affaire);
                return View(AffaireFormModel);
            }

        }





        // POST: Commun/Devises/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AffaireId,AffaireCode,AffaireLibelle,AffaireSocieteId")]  AffairePivot Affaire)
        {



          
            if (Affaire != null)
            {
                if (Affaire.AffaireId > 0)
                {
                    Affaire.AffaireSocieteId = Constantes.IdentifiantDossier;
                    Affaire.AffaireSysDateCreation = DateTime.Now;
                    Affaire.AffaireSysDateUpdate = DateTime.Now;
                    Affaire.AffaireSysuser = Constantes.IdentifUser;

                    AffaireServise.UpdateAffairePivot(Affaire);
                    AffaireServise.SaveAffairePivot();
                }
                else
                {
                    AffaireServise.CreateAffairePivot(Affaire);
                    AffaireServise.SaveAffairePivot();
                }
                
                return RedirectToAction("Index");
            }

            AffaireFormViewModel AffaireFormModel = Mapper.Map<AffairePivot, AffaireFormViewModel>(Affaire);
            return View(AffaireFormModel);
        }



        /********/
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // DevisesPivot gEN_Devises = deviseServise.GetDevise(id);
            AffairePivot Affaire = AffaireServise.GetAffaire((int)id);
            //db.GEN_Devises.Find(id);
            if (Affaire == null)
            {
                return HttpNotFound();
            }


            AffaireFormViewModel AffaireFormModel = Mapper.Map<AffairePivot, AffaireFormViewModel>(Affaire);
            return View(AffaireFormModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AffaireId,AffaireCode,AffaireLibelle,AffaireSocieteId")] AffairePivot Affaire)
        {

            if (ModelState.IsValid)
            {
                Affaire.AffaireSocieteId = Constantes.IdentifiantDossier;
                Affaire.AffaireSysDateCreation = DateTime.Now;
                Affaire.AffaireSysDateUpdate = DateTime.Now;
                Affaire.AffaireSysuser =Constantes.IdentifUser;


                AffaireServise.SaveAffairePivot();
                return RedirectToAction("Index");
            }

            AffaireFormViewModel AffaireFormModel = Mapper.Map<AffairePivot, AffaireFormViewModel>(Affaire);
            return View(AffaireFormModel);

        }


        public ActionResult Delete(long? id)
        {
            ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier");
            //db.GEN_Dossiers.Where(e => e.Actif), "Id", "CodeDossier");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AffairePivot Affaire = AffaireServise.GetAffaire((int)id);
            //db.GEN_Devises.Find(id);
            if (Affaire == null)
            {
                return HttpNotFound();
            }

            AffaireFormViewModel Affaires = Mapper.Map<AffairePivot, AffaireFormViewModel>(Affaire);
            return View(Affaires);
        }




        // POST: Commun/TypePaiement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed([Bind(Include = "AffaireId")]AffaireFormViewModel Affaire)
        {
            AffairePivot Affaires = Mapper.Map<AffaireFormViewModel, AffairePivot>(Affaire);
            AffairePivot calasse = AffaireServise.GetAffaire(Affaire.AffaireId);


            AffaireServise.DeleteAffairePivot(calasse);
            AffaireServise.SaveAffairePivot();
            return RedirectToAction("Index");



        }


    }
}