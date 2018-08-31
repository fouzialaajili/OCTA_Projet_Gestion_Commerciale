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
    public class GES_ArticlesKitController : Controller
    {

        private readonly IArticlesKitService ArticlesServise;
        private readonly IDossiersService dossiersService;

        public GES_ArticlesKitController(IArticlesKitService ArticlesServise, IDossiersService dossiersService)
        {
            this.ArticlesServise = ArticlesServise;
            this.dossiersService = dossiersService;
        }

        public ActionResult Index()
        {
            var Article = ArticlesServise.GetALL();

            IEnumerable<ArticlesKitsViewModel> Article_Views = Mapper.Map<IEnumerable<ArticlesKitPivot>, IEnumerable<ArticlesKitsViewModel>>(Article);

            return View(Article_Views.AsQueryable());


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
                var Article = ArticlesServise.GetArticlesKit((int)id);
                if (Article == null)
                {

                    TempData["errorMessage"] = "La classe que vous cherchez n'existe pas.";
                    return RedirectToAction("Index");
                }

                ArticlesKitsFormViewModel ArticleFormModel = Mapper.Map<ArticlesKitPivot, ArticlesKitsFormViewModel>(Article);
                return View(ArticleFormModel);
            }

        }





        // POST: Commun/Devises/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ArticlesKitId,ArticlesKitQantite,ArticlesKitDescription,ArticlesKitArticlesId")] ArticlesKitPivot Article)
        {



            // if (ModelState.IsValid)
            if (Article != null)
            {
                if (Article.ArticlesKitId > 0)
                {
                    Article.ArticlesKitArticlesId = null;
                    Article.ArticlesKitArticleId1 = null;
                    Article.ArticlesKitSysDateUpdate = DateTime.Now;
                    Article.ArticlesKitSysDateCreation = DateTime.Now;
                    Article.ArticlesKitSysuser = Constantes.IdentifUser;
                    ArticlesServise.UpdateArticlesKitPivot(Article);
                    ArticlesServise.SaveArticlesKitPivot();

                }
                else
                {
                    Article.ArticlesKitArticlesId = null;
                    Article.ArticlesKitArticleId1 = null;

                    Article.ArticlesKitSysDateUpdate = DateTime.Now;
                    Article.ArticlesKitSysDateCreation = DateTime.Now;
                    Article.ArticlesKitSysuser = Constantes.IdentifUser;
                  

                    ArticlesServise.CreateArticlesKitPivot(Article);
                    ArticlesServise.SaveArticlesKitPivot();
                }


                return RedirectToAction("Index");
            }

            ArticlesKitsFormViewModel ArticleFormModel = Mapper.Map<ArticlesKitPivot, ArticlesKitsFormViewModel>(Article);
            return View(ArticleFormModel);
        }



        /********/
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ArticlesKitPivot Article = ArticlesServise.GetArticlesKit((int)id);
            //db.GEN_Devises.Find(id);
            if (Article == null)
            {
                return HttpNotFound();
            }



            ArticlesKitsFormViewModel ArticleFormModel = Mapper.Map<ArticlesKitPivot, ArticlesKitsFormViewModel>(Article);
            return View(ArticleFormModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ArticlesKitId,ArticlesKitQantite,ArticlesKitDescription,ArticlesKitArticlesId")]  ArticlesKitPivot Article)
        {

            if (ModelState.IsValid)
            {
                Article.ArticlesKitArticlesId = null;
                Article.ArticlesKitArticleId1 = null;

                Article.ArticlesKitSysDateUpdate = DateTime.Now;
                Article.ArticlesKitSysDateCreation = DateTime.Now;
                Article.ArticlesKitSysuser = Constantes.IdentifUser;
              
                ArticlesServise.UpdateArticlesKitPivot(Article);
                //   db.SaveChanges();
                ArticlesServise.SaveArticlesKitPivot();
                return RedirectToAction("Index");
            }
            

            ArticlesKitsFormViewModel ArticleFormModel = Mapper.Map<ArticlesKitPivot, ArticlesKitsFormViewModel>(Article);
            return View(ArticleFormModel);

        }


        public ActionResult Delete(long? id)
        {
       
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticlesKitPivot Article = ArticlesServise.GetArticlesKit((int)id);
            //db.GEN_Devises.Find(id);
            if (Article == null)
            {
                return HttpNotFound();
            }

            ArticlesKitsFormViewModel Articles = Mapper.Map<ArticlesKitPivot, ArticlesKitsFormViewModel>(Article);
            return View(Articles);
        }




        // POST: Commun/TypePaiement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed([Bind(Include = "ArticlesKitId")]  ArticlesKitsFormViewModel Article)
        {
            ArticlesKitPivot Articles = Mapper.Map<ArticlesKitsFormViewModel, ArticlesKitPivot>(Article);
            ArticlesKitPivot calasse = ArticlesServise.GetArticlesKit(Articles.ArticlesKitId);


            ArticlesServise.DeleteArticlesKitPivot(calasse);
            // db.SaveChanges();
            ArticlesServise.SaveArticlesKitPivot();
            return RedirectToAction("Index");



        }


    }
}