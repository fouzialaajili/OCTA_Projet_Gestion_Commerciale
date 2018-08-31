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
    public class GES_ArticlesController : Controller
    {
        private readonly IArticlesService ArticlesServise;
        private readonly IDossiersService dossiersService;

        public GES_ArticlesController(IArticlesService ArticlesServise, IDossiersService dossiersService)
        {
            this.ArticlesServise = ArticlesServise;
            this.dossiersService = dossiersService;
        }

        public ActionResult Index()
        {
            var Article = ArticlesServise.GetALL();

            IEnumerable<ArticlesViewModel> Article_Views = Mapper.Map<IEnumerable<ArticlePivot>, IEnumerable<ArticlesViewModel>>(Article);

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
                var Article = ArticlesServise.GetArticlePivot((int)id);
                if (Article == null)
                {

                    TempData["errorMessage"] = "La classe que vous cherchez n'existe pas.";
                    return RedirectToAction("Index");
                }

                ArticlesFormViewModel ArticleFormModel = Mapper.Map<ArticlePivot, ArticlesFormViewModel>(Article);
                return View(ArticleFormModel);
            }

        }





        // POST: Commun/Devises/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ArticleId,ArticleTypeArticle,ArticleCodeArticle,ArticleDescription,ArticleDescriptif,ArticleCodeABarre,ArticleEstSerialiser,ArticleEstGererEnStock,ArticleEstVendu,ArticleEstAchat,ArticlePrixAchatDefault,ArticlePrixVenteDefault,ArticleCoefficientMarge,ArticleSeuilStockMin,ArticleSeuilStockMax,ArticleGarantieMaintenance,ArticleGarantiemois,ArticlePubliable,ArticleActif,ArticleImage,ArticleSocieteId,ArticleDepotId,ArticleCategorieId,ArticleUniteId,ArticleMarqueId")] ArticlePivot Article)
        {



            // if (ModelState.IsValid)
            if (Article != null)
            {
                if (Article.ArticleId > 0)
                {
                    Article.ArticleSocieteId = Constantes.IdentifiantDossier;
                    Article.ArticlesSysDateUpdate = DateTime.Now;
                    Article.ArticleSysDateCreation = DateTime.Now;
                    Article.ArticleSysuser = Constantes.IdentifUser;
                    Article.ArticleActif = true;
                    Article.ArticlePubliable = true;
                    Article.ArticleGarantieMaintenance = true;
                    Article.ArticleEstAchat = false;
                    Article.ArticleEstVendu = false;
                    Article.ArticleEstGererEnStock = false;
                    Article.ArticleDepotId = null;
                    Article.ArticleCategorieId = null;
                    Article.ArticleUniteId = null;
                    Article.ArticleMarqueId = null;
                    ArticlesServise.UpdateArticlePivot(Article);
                    ArticlesServise.SaveArticlePivot();
                }
                else
                {

                    Article.ArticleSocieteId = Constantes.IdentifiantDossier;
                    Article.ArticlesSysDateUpdate = DateTime.Now;
                    Article.ArticleSysDateCreation = DateTime.Now;
                    Article.ArticleSysuser = Constantes.IdentifUser;
                    Article.ArticleActif = true;
                    Article.ArticlePubliable = true;
                    Article.ArticleGarantieMaintenance = true;
                    Article.ArticleEstAchat = false;
                    Article.ArticleEstVendu = false;
                    Article.ArticleEstGererEnStock = false;
                    Article.ArticleDepotId = null;
                    Article.ArticleCategorieId = null;
                    Article.ArticleUniteId = null;
                    Article.ArticleMarqueId = null;

                    ArticlesServise.CreateArticlePivot(Article);
                    ArticlesServise.SaveArticlePivot();
                }

            
                return RedirectToAction("Index");
            }

            ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier", Article.ArticleSocieteId);
            ArticlesFormViewModel ArticleFormModel = Mapper.Map<ArticlePivot, ArticlesFormViewModel>(Article);
            return View(ArticleFormModel);
        }



        /********/
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // DevisesPivot gEN_Devises = deviseServise.GetDevise(id);
            ArticlePivot Article = ArticlesServise.GetArticlePivot((int)id);
            //db.GEN_Devises.Find(id);
            if (Article == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier", Article.ArticleSocieteId);


            ArticlesFormViewModel ArticleFormModel = Mapper.Map<ArticlePivot, ArticlesFormViewModel>(Article);
            return View(ArticleFormModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ArticleId,ArticleTypeArticle,ArticleCodeArticle,ArticleDescription,ArticleDescriptif,ArticleCodeABarre,ArticleEstSerialiser,ArticleEstGererEnStock,ArticleEstVendu,ArticleEstAchat,ArticlePrixAchatDefault,ArticlePrixVenteDefault,ArticleCoefficientMarge,ArticleSeuilStockMin,ArticleSeuilStockMax,ArticleGarantieMaintenance,ArticleGarantiemois,ArticlePubliable,ArticleActif,ArticleImage,ArticleSocieteId,ArticleDepotId,ArticleCategorieId,ArticleUniteId,ArticleMarqueId")]  ArticlePivot Article)
        {

            if (ModelState.IsValid)
            {
                Article.ArticleSocieteId = Constantes.IdentifiantDossier;
                Article.ArticlesSysDateUpdate = DateTime.Now;
                Article.ArticleSysDateCreation = DateTime.Now;
                Article.ArticleSysuser = Constantes.IdentifUser;
                Article.ArticleActif = true;
                Article.ArticlePubliable = true;
                Article.ArticleGarantieMaintenance = true;
                Article.ArticleEstAchat = false;
                Article.ArticleEstVendu = false;
                Article.ArticleEstGererEnStock = false;
                Article.ArticleDepotId = null;
                Article.ArticleCategorieId = null;
                Article.ArticleUniteId = null;
                Article.ArticleMarqueId = null;
                ArticlesServise.UpdateArticlePivot(Article);
                //   db.SaveChanges();
                ArticlesServise.SaveArticlePivot();
                return RedirectToAction("Index");
            }
            ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier", Article.ArticleSocieteId);
            //db.GEN_Dossiers.Where(e => e.Actif), "Id", "CodeDossier", gEN_Devises.IdDossier);

            ArticlesFormViewModel ArticleFormModel = Mapper.Map<ArticlePivot, ArticlesFormViewModel>(Article);
            return View(ArticleFormModel);

        }


        public ActionResult Delete(long? id)
        {
            ViewBag.IdDossier = new SelectList(dossiersService.GetActifDossier(), "DossierId", "CodeDossier");
            //db.GEN_Dossiers.Where(e => e.Actif), "Id", "CodeDossier");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticlePivot Article = ArticlesServise.GetArticlePivot((int)id);
            //db.GEN_Devises.Find(id);
            if (Article == null)
            {
                return HttpNotFound();
            }

            ArticlesFormViewModel Articles = Mapper.Map<ArticlePivot, ArticlesFormViewModel>(Article);
            return View(Articles);
        }




        // POST: Commun/TypePaiement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed([Bind(Include = "ArticleId")]  ArticlesFormViewModel Article)
        {
            ArticlePivot Articles = Mapper.Map<ArticlesFormViewModel, ArticlePivot>(Article);
            ArticlePivot calasse = ArticlesServise.GetArticlePivot(Articles.ArticleId);


            ArticlesServise.DeleteArticlePivot(calasse);
            // db.SaveChanges();
            ArticlesServise.SaveArticlePivot();
            return RedirectToAction("Index");



        }


    }
}