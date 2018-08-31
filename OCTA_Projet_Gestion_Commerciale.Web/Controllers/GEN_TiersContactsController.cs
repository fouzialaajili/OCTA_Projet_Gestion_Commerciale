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
    public class GEN_TiersContactsController : Controller
    {
        private readonly ITiersContactsService tiersContactsServise;
        private readonly IDossiersService dossiersService;

        public GEN_TiersContactsController(ITiersContactsService tiersContactsServise, IDossiersService dossiersService)
        {
            this.tiersContactsServise = tiersContactsServise;
            this.dossiersService = dossiersService;
        }

        public ActionResult Index()
        {
            var TiersContacts = tiersContactsServise.GetALL();

            IEnumerable<TiersContactsViewModel> TiersContacts_Views = Mapper.Map<IEnumerable<TiersContactsPivot>, IEnumerable<TiersContactsViewModel>>(TiersContacts);

            return View(TiersContacts_Views.AsQueryable());


        }




        public ActionResult Create(long? id)
        {
            if (id == null)
            {
               
                return View();
            }
            else
            {
                // GEN_Devises gEN_Devises = db.GEN_Devises.Find(id);
                var TiersContacts = tiersContactsServise.GetTiersContacts((int)id);
                if (TiersContacts == null)
                {

                    TempData["errorMessage"] = "Tiers Contacts que vous cherchez n'existe pas.";
                    return RedirectToAction("Index");
                }

                TiersContactsFormViewModel TiersContactsFormModel = Mapper.Map<TiersContactsPivot, TiersContactsFormViewModel>(TiersContacts);
                return View(TiersContactsFormModel);
            }

        }





        // POST: Commun/Devises/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GEN_TiersContactsId,Civilite,Nom,Email,Prenom,Tel,Gsm,Actif,ParDefault,Gsm,IdTiers")]TiersContactsPivot TiersContacts)
        {



            // if (ModelState.IsValid)
            if (TiersContacts != null)
            {
                if (TiersContacts.GEN_TiersContactsId > 0)
                {

                    TiersContacts.sys_dateUpdate = DateTime.Now;
                    TiersContacts.sys_dateCreation = DateTime.Now;
                    TiersContacts.sys_user = Constantes.IdentifiantUser;
                    TiersContacts.Actif = true;
                    TiersContacts.IdTiers = null;

                    tiersContactsServise.UpdateTiersContacts(TiersContacts);
                    tiersContactsServise.SaveTiersContacts();
                }
                else
                {


                    TiersContacts.sys_dateUpdate = DateTime.Now;
                    TiersContacts.sys_dateCreation = DateTime.Now;
                    TiersContacts.sys_user = Constantes.IdentifiantUser;
                    TiersContacts.Actif = true;
                    TiersContacts.IdTiers = null;

                    tiersContactsServise.CreateTiersContacts(TiersContacts);
                    tiersContactsServise.SaveTiersContacts();
                }


                return RedirectToAction("Index");
            }

            TiersContactsFormViewModel TiersContactsFormModel = Mapper.Map<TiersContactsPivot, TiersContactsFormViewModel>(TiersContacts);
            return View(TiersContactsFormModel);
        }



        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // DevisesPivot gEN_Devises = deviseServise.GetDevise(id);
            TiersContactsPivot TiersContacts = tiersContactsServise.GetTiersContacts((int)id);
            //db.GEN_Devises.Find(id);
            if (TiersContacts == null)
            {
                return HttpNotFound();
            }


            TiersContactsFormViewModel TiersContactsModels = Mapper.Map<TiersContactsPivot, TiersContactsFormViewModel>(TiersContacts);
            return View(TiersContactsModels);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GEN_TiersContactsId,Civilite,Email,Nom,Prenom,Tel,Gsm,Actif,ParDefault,Gsm,IdTiers")] TiersContactsPivot TiersContacts)
        {

            if (ModelState.IsValid)
            {
                TiersContacts.IdTiers = null;
                TiersContacts.sys_dateUpdate = DateTime.Now;
                TiersContacts.sys_dateCreation = DateTime.Now;
                TiersContacts.sys_user = Constantes.IdentifiantUser;
               tiersContactsServise.UpdateTiersContacts(TiersContacts);
                //   db.SaveChanges();
                tiersContactsServise.SaveTiersContacts();
                return RedirectToAction("Index");
            }


            TiersContactsFormViewModel TiersContactsFormModel = Mapper.Map<TiersContactsPivot, TiersContactsFormViewModel>(TiersContacts);
            return View(TiersContactsFormModel);

        }


        public ActionResult Delete(long? id)
        {
           
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TiersContactsPivot TiersContacts = tiersContactsServise.GetTiersContacts((int)id);
            //db.GEN_Devises.Find(id);
            if (TiersContacts == null)
            {
                return HttpNotFound();
            }

            TiersContactsFormViewModel cpt_codd = Mapper.Map<TiersContactsPivot, TiersContactsFormViewModel>(TiersContacts);
            return View(cpt_codd);
        }




        // POST: Commun/TypePaiement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed([Bind(Include = "GEN_TiersContactsId")] TiersContactsFormViewModel TiersContacts)
        {
            TiersContactsPivot cods = Mapper.Map<TiersContactsFormViewModel, TiersContactsPivot>(TiersContacts);
            TiersContactsPivot codes =tiersContactsServise.GetTiersContacts(cods.GEN_TiersContactsId);


            tiersContactsServise.DeleteTiersContacts(codes);
            // db.SaveChanges();
            tiersContactsServise.SaveTiersContacts();
            return RedirectToAction("Index");



        }


    }
}