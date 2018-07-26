using OCTA_Projet_Gestion_Commerciale.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OCTA_Projet_Gestion_Commerciale.Web.Controllers
{
    public class DevisesController : Controller
    {
        private readonly IDevisesService deviseServise;
        public DevisesController(IDevisesService deviseServise)
        {
            this.deviseServise = deviseServise;
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
            var devises = deviseServise.GetAllDevises();//.Where(x=>x.DevisesIdDossier==1 && x.DevisesActif);
            //var gEN_Devises = db.GEN_Devises.Where(e => e.IdDossier == CurrentPreference.IdDossier && e.Actif);
            //var rr = gEN_Devises.ToList();
            return View(devises);
        }
    }
}