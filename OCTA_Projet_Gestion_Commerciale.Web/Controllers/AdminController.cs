using AutoMapper;
using OCTA_Projet_Gestion_Commerciale.Service.Interface;
using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using OCTA_Projet_Gestion_Commerciale.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OCTA_Projet_Gestion_Commerciale.Web.Controllers
{
    public class AdminController : Controller
    {

        private readonly IAdminService adminService;


        public AdminController(IAdminService adminService)
        {
            this.adminService = adminService;
      

        }
        

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(AdminFormViewModel gES_Admin)
        {
            var admin = Mapper.Map<AdminFormViewModel, AdminPivot>(gES_Admin);

            adminService.CreateAdminPivot(admin);

            adminService.SaveAdminPivot();

            return View();
        }
        
    }
}