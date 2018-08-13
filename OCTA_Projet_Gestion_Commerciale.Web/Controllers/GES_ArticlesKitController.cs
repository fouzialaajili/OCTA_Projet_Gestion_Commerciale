using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OCTA_Projet_Gestion_Commerciale.Data;
using OCTA_Projet_Gestion_Commerciale.Model;

namespace OCTA_Projet_Gestion_Commerciale.Web.Controllers
{
    public class GES_ArticlesKitController : Controller
    {
        private StoreEntities db = new StoreEntities();

        // GET: GES_ArticlesKit
        public ActionResult Index()
        {
            var articlesKitss = db.ArticlesKitss.Include(g => g.ArticlesKitArticle);
            return View(articlesKitss.ToList());
        }

        // GET: GES_ArticlesKit/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GES_ArticlesKit gES_ArticlesKit = db.ArticlesKitss.Find(id);
            if (gES_ArticlesKit == null)
            {
                return HttpNotFound();
            }
            return View(gES_ArticlesKit);
        }

        // GET: GES_ArticlesKit/Create
        public ActionResult Create()
        {
            ViewBag.ArticlesKitArticleId1 = new SelectList(db.Articless, "ArticleId", "ArticleCodeArticle");
            return View();
        }

        // POST: GES_ArticlesKit/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ArticlesKitId,ArticlesKitQantite,ArticlesKitDescription,ArticlesKitSysuser,ArticlesKitSysDateCreation,ArticlesKitSysDateUpdate,ArticlesKitArticlesId,ArticlesKitArticleId1")] GES_ArticlesKit gES_ArticlesKit)
        {
            if (ModelState.IsValid)
            {
                db.ArticlesKitss.Add(gES_ArticlesKit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ArticlesKitArticleId1 = new SelectList(db.Articless, "ArticleId", "ArticleCodeArticle", gES_ArticlesKit.ArticlesKitArticleId1);
            return View(gES_ArticlesKit);
        }

        // GET: GES_ArticlesKit/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GES_ArticlesKit gES_ArticlesKit = db.ArticlesKitss.Find(id);
            if (gES_ArticlesKit == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArticlesKitArticleId1 = new SelectList(db.Articless, "ArticleId", "ArticleCodeArticle", gES_ArticlesKit.ArticlesKitArticleId1);
            return View(gES_ArticlesKit);
        }

        // POST: GES_ArticlesKit/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ArticlesKitId,ArticlesKitQantite,ArticlesKitDescription,ArticlesKitSysuser,ArticlesKitSysDateCreation,ArticlesKitSysDateUpdate,ArticlesKitArticlesId,ArticlesKitArticleId1")] GES_ArticlesKit gES_ArticlesKit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gES_ArticlesKit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArticlesKitArticleId1 = new SelectList(db.Articless, "ArticleId", "ArticleCodeArticle", gES_ArticlesKit.ArticlesKitArticleId1);
            return View(gES_ArticlesKit);
        }

        // GET: GES_ArticlesKit/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GES_ArticlesKit gES_ArticlesKit = db.ArticlesKitss.Find(id);
            if (gES_ArticlesKit == null)
            {
                return HttpNotFound();
            }
            return View(gES_ArticlesKit);
        }

        // POST: GES_ArticlesKit/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            GES_ArticlesKit gES_ArticlesKit = db.ArticlesKitss.Find(id);
            db.ArticlesKitss.Remove(gES_ArticlesKit);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
