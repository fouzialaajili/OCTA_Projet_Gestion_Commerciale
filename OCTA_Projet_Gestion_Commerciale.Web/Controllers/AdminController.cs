using AutoMapper;
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
    public class AdminController : Controller
    {

        private readonly IAdminService adminService;
        private readonly IDossiersService dossiersService;

        public AdminController(IAdminService adminService, IDossiersService dossiersService)
        {
            this.adminService = adminService;
            this.dossiersService = dossiersService;
        }

        public ActionResult Index()
        {
            var admin = adminService.GetALL();

            IEnumerable<AdminViewModel> admin_Views = Mapper.Map<IEnumerable<AdminPivot>, IEnumerable<AdminViewModel>>(admin);

            return View(admin_Views.AsQueryable());


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
                var admin = adminService.GetAdmin((int)id);
                if (admin == null)
                {

                    TempData["errorMessage"] = "L'echeance que vous cherchez n'existe pas.";
                    return RedirectToAction("Index");
                }

                AdminFormViewModel adminFormModel = Mapper.Map<AdminPivot, AdminFormViewModel>(admin);
                return View(adminFormModel);
            }

        }





        // POST: Commun/Devises/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AdminId,AdminLogin,AdminPassword,AdminActif")]AdminPivot admin)
        {



            // if (ModelState.IsValid)
            if (admin != null)
            {
                if (admin.AdminId > 0)
                {


                    admin.AdminActif = true;

                    adminService.UpdateAdminPivot(admin);
                    adminService.SaveAdminPivot();
                }
                else
                {
                    admin.AdminActif = true;


                    adminService.CreateAdminPivot(admin);
                    adminService.SaveAdminPivot();
                }


                return RedirectToAction("Index");
            }


         AdminFormViewModel adminFormModel = Mapper.Map<AdminPivot, AdminFormViewModel>(admin);
            return View(adminFormModel);
        }



        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // DevisesPivot gEN_Devises = deviseServise.GetDevise(id);
            AdminPivot admin = adminService.GetAdmin((int)id);
            //db.GEN_Devises.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }

            AdminFormViewModel adminFormModel = Mapper.Map<AdminPivot, AdminFormViewModel>(admin);
            return View(adminFormModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AdminId,AdminLogin,AdminPassword,AdminActif")] AdminPivot admin)
        {

            if (ModelState.IsValid)
            {
                admin.AdminActif = true;

                adminService.UpdateAdminPivot(admin);
                //   db.SaveChanges();
                adminService.SaveAdminPivot();
                return RedirectToAction("Index");
            }
          

           AdminFormViewModel adminFormModel = Mapper.Map<AdminPivot, AdminFormViewModel>(admin);
            return View(adminFormModel);

        }


        public ActionResult Delete(long? id)
        {
           
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminPivot admin = adminService.GetAdmin((int)id);
            //db.GEN_Devises.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }

            AdminFormViewModel adminss = Mapper.Map<AdminPivot, AdminFormViewModel>(admin);
            return View(adminss);
        }




        // POST: Commun/TypePaiement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed([Bind(Include = "AdminId")] AdminFormViewModel admine)
        {
            AdminPivot adminess = Mapper.Map<AdminFormViewModel, AdminPivot>(admine);
            AdminPivot admines = adminService.GetAdmin(adminess.AdminId);


            adminService.DeleteAdminPivot(admines);
           
            adminService.SaveAdminPivot();
            return RedirectToAction("Index");



        }


    }
}