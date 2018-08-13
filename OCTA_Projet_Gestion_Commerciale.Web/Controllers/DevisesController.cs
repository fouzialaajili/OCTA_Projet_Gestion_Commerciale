using AutoMapper;
using OCTA_Projet_Gestion_Commerciale.Data.Utils;
using OCTA_Projet_Gestion_Commerciale.Model;
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
    public class DevisesController : Controller
    {
        private readonly IDevisesService deviseServise;
         private readonly IDossiersService dossiersService;
        public DevisesController(IDevisesService deviseServise, IDossiersService dossiersService)
        {
            this.deviseServise = deviseServise;
            this.dossiersService = dossiersService;

        }
        // GET: Devises
        public ActionResult Index()
        {
            var list = new List<KeyValuePair<int, string>>() {
                new KeyValuePair<int, string>( 0,"Non"),
                new KeyValuePair<int, string>( 1,"Oui"),
            };
            ViewBag.Message = TempData["errorMessage"];
            var ListTenueDecompte = list.Select(x => new { ID = x.Key, VALUE = x.Value });
            ViewBag.ListTenueDecompte = ListTenueDecompte;
          

            var devises = deviseServise.GetDeviseByCond();
      
            IEnumerable<DevisesViewModel> devises_Views = Mapper.Map<IEnumerable<DevisesPivot>, IEnumerable<DevisesViewModel>>(devises);

            return View(devises_Views.AsQueryable());

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
                var gEN_Devises = deviseServise.GetDevise(id);
                if (gEN_Devises == null)
                {

                    TempData["errorMessage"] = "La devise que vous cherchez n'existe pas.";
                    return RedirectToAction("Index");
                }
                //  ViewBag.IdDossier = new SelectList(db.GEN_Dossiers.Where(e => e.Actif), "Id", "CodeDossier", gEN_Devises.IdDossier);
                ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier", gEN_Devises.DevisesIdDossier);
                  DevisesFormViewModel  gEN_DevisesFormModel = Mapper.Map<DevisesPivot, DevisesFormViewModel>(gEN_Devises);
                return View(gEN_DevisesFormModel);
            }

        }





        // POST: Commun/Devises/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DevisesId,DevisesCode,DevisesCodeIso,DevisesDescription,DevisesCoursDevise,DevisesTenueDeCompte,DevisesActif,DevisesIdDossier,DevisesSymbole")] DevisesPivot  gEN_Devises)
        {
            
         

           // if (ModelState.IsValid)
           if(gEN_Devises!=null)
            {
                if (gEN_Devises.DevisesId > 0)
                {
                   gEN_Devises.DevisesIdDossier = Constantes.IdentifiantDossier;
                   gEN_Devises.Devisessys_dateUpdate = DateTime.Now;
                    gEN_Devises.Devisessys_dateCreation = DateTime.Now;
                    gEN_Devises.Devisessys_user = Constantes.IdentifiantUser;
                    gEN_Devises.DevisesActif = true;
                 // db.Entry(gEN_Devises).State = EntityState.Modified;
                   // deviseServise.GetAttributes(gEN_Devises);
                    deviseServise.UpdateDevise(gEN_Devises);
                    deviseServise.SaveDevise();
                }
                else
                {
                    //gEN_Devises.IdDossier = CurrentPreference.IdDossier;
                    //gEN_Devises.sys_dateCreation = DateTime.Now;
                    //gEN_Devises.sys_dateUpdate = DateTime.Now;
                    //gEN_Devises.sys_user = CurrentUser.Id;
                    gEN_Devises.DevisesActif = true;
                    gEN_Devises.DevisesIdDossier = Constantes.IdentifiantDossier;
                    gEN_Devises.Devisessys_dateUpdate = DateTime.Now;
                    gEN_Devises.Devisessys_dateCreation = DateTime.Now;
                    gEN_Devises.Devisessys_user = Constantes.IdentifiantUser;


                    // deviseServise.GetAttributes(gEN_Devises);

                    deviseServise.CreateDevise(gEN_Devises);
                    deviseServise.SaveDevise();
                }

                // db.SaveChanges();

                //  return RedirectToAction("Create", new { id = gEN_Devises.DevisesId });
                return RedirectToAction("Index");
            }

            // ViewBag.IdDossier = new SelectList(db.GEN_Dossiers.Where(e => e.Actif), "Id", "CodeDossier", gEN_Devises.IdDossier);
            ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier", gEN_Devises.DevisesIdDossier);

            DevisesFormViewModel gEN_DevisesFormModel = Mapper.Map<DevisesPivot,DevisesFormViewModel>(gEN_Devises);

            return View(gEN_DevisesFormModel);
        }




        // GET: Commun/Devises/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // DevisesPivot gEN_Devises = deviseServise.GetDevise(id);
            DevisesPivot gEN_Devises = deviseServise.GetDevise(id);
            //db.GEN_Devises.Find(id);
            if (gEN_Devises == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier", gEN_Devises.DevisesIdDossier);
            //db.GEN_Dossiers.Where(e => e.Actif), "Id", "CodeDossier", gEN_Devises.IdDossier);

            DevisesFormViewModel gEN_Devise= Mapper.Map<DevisesPivot,DevisesFormViewModel>(gEN_Devises);
            return View(gEN_Devise);
        }

        // POST: Commun/Devises/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DevisesId,DevisesCode,DevisesCodeIso,DevisesDescription,DevisesCoursDevise,DevisesTenueDeCompte,DevisesActif,DevisesIdDossier,DevisesSymbole")] DevisesPivot gEN_Devises)
        {
            var gEN_DeviseTest = deviseServise.Getingdevises();
                //from b in db.GEN_Devises where b.IdDossier == CurrentPreference.IdDossier && b.TenueDeCompte == 1 select b;

            if (gEN_DeviseTest.Count() > 0 && gEN_Devises.DevisesTenueDeCompte == 1)
            {
                ModelState.AddModelError("TenueDeCompte", "Il existe déjà une devise en tenue de compte");

            }
            if (ModelState.IsValid)
            {
                gEN_Devises.DevisesIdDossier = Constantes.IdentifiantDossier;
                gEN_Devises.Devisessys_dateUpdate = DateTime.Now;
                gEN_Devises.Devisessys_user =Constantes.IdentifiantUser;
                //db.Entry(gEN_Devises).State = EntityState.Modified;
                deviseServise.UpdateDevise(gEN_Devises);

                //db.SaveChanges();
                deviseServise.SaveDevise();
                return RedirectToAction("Index");
            }
            ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier", gEN_Devises.DevisesIdDossier);
            //db.GEN_Dossiers.Where(e => e.Actif), "Id", "CodeDossier", gEN_Devises.IdDossier);

            DevisesFormViewModel gEN_Devise = Mapper.Map<DevisesPivot, DevisesFormViewModel>(gEN_Devises);
            return View(gEN_Devise);
        }

        // GET: Commun/Devises/Delete/5
        public ActionResult Delete(long? id)
        {
            ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier");
                //db.GEN_Dossiers.Where(e => e.Actif), "Id", "CodeDossier");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DevisesPivot gEN_Devises = deviseServise.GetDevise(id);
                //db.GEN_Devises.Find(id);
            if (gEN_Devises == null)
            {
                return HttpNotFound();
            }

            DevisesFormViewModel gEN_Devis = Mapper.Map<DevisesPivot, DevisesFormViewModel>(gEN_Devises);
            return View(gEN_Devis);
        }


       

        // POST: Commun/TypePaiement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed([Bind(Include = "DevisesId")] DevisesFormViewModel gEN_Devises)
        {
            DevisesPivot gEN_Devis = Mapper.Map<DevisesFormViewModel,DevisesPivot>(gEN_Devises);
            DevisesPivot gEN_deviss = deviseServise.GetDevise(gEN_Devis.DevisesId);

           
            deviseServise.DeleteDevise(gEN_deviss);
            // db.SaveChanges();
            deviseServise.SaveDevise();
           return RedirectToAction("Index");

            

        }





















    }
}