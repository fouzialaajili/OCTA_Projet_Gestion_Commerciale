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
    public class ItemsController : Controller
    {

        private readonly IItemsService itemsServise;
        private readonly IModelService modelsService;
        public ItemsController(IItemsService itemsServise, IModelService modelsService)
        {
            this.itemsServise = itemsServise;
            this.modelsService = modelsService;
        }
        // GET: Items
        public ActionResult Index()
        {
            //ViewBag.IdModel = db.GEN_Model.Where(e => e.IdSociete == CurrentSocieteId).OrderByDescending(e => e.Model).Select(x => new { ID = x.Id, VALUE = x.Model });

            ViewBag.IdModel = modelsService.GetModels().OrderByDescending(e => e.Model).Select(x => new { ID = x.Id, VALUE = x.Model });
            IEnumerable<ItemsPivot> itemsPivots = itemsServise.GetAllItems();
            IQueryable<ItemsPivot> gEN_Items = itemsPivots.AsQueryable();
            IEnumerable<ItemsViewModel> items_Views = Mapper.Map<IEnumerable<ItemsPivot>, IEnumerable<ItemsViewModel>>(gEN_Items);
            return View(items_Views.AsQueryable());
        }




        public ActionResult Create(long? id)
        {
            if (id == null)
            {

                // ViewBag.IdModel = new SelectList(db.GEN_Model.Where(e => e.IdSociete == CurrentSocieteId), "Id", "Model");
                ViewBag.IdModel = new SelectList(modelsService.GetModelIdDossier(),"Id","Model");
                return View();
            }
            else
            {
                // GEN_Items gEN_Items = db.GEN_Items.Find(id);
                var gEN_Items = itemsServise.GetItems(id);
                ItemsFormViewModel gEN_Devises = Mapper.Map<ItemsPivot,ItemsFormViewModel>(gEN_Items);

                if (gEN_Items == null)
                {
                    return RedirectToAction("Index");
                }
                // ViewBag.IdModel = new SelectList(db.GEN_Model.Where(e => e.IdSociete == CurrentSocieteId), "Id", "Model", gEN_Items.IdModel);
                ViewBag.IdModel = new SelectList(modelsService.GetModelIdDossier(),"Id", "Model", gEN_Devises.IdModel);
             
                return View(gEN_Devises);

            }

        }

        // POST: Commun/Items/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdModel,Libelle,Valeur,Ordre")] ItemsFormViewModel gEN_ItemsView)
        {
            ItemsPivot gEN_Devises = Mapper.Map<ItemsFormViewModel, ItemsPivot>(gEN_ItemsView);
            if (ModelState.IsValid)
            {
                if (gEN_Devises.Id > 0)
                {
                    itemsServise.UpdateItemsPivot(gEN_Devises);
                    //  db.Entry(gEN_Items).State = EntityState.Modified;
                    itemsServise.SaveItemsPivot();
                   // db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    // db.GEN_Items.Add(gEN_Items);
                    //db.SaveChanges();
                    itemsServise.CreateItemsPivot(gEN_Devises);

                    itemsServise.SaveItemsPivot();
                    return RedirectToAction("Index");

                }

            }
            ViewBag.IdModel = new SelectList(modelsService.GetModelIdDossier(), "Id", "Model", gEN_Devises.IdModel);
            return View(gEN_ItemsView);
        }






        // GET: Commun/Items/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var gEN_Items = itemsServise.GetItems(id);
            ItemsFormViewModel gEN_Item= Mapper.Map<ItemsPivot, ItemsFormViewModel>(gEN_Items);
            //db.GEN_Items.Find(id);
            if (gEN_Items == null)
            {
                return HttpNotFound();
            }
          //  ViewBag.IdModel = new SelectList(itemsServise.GetModel(), "Id", "Model", gEN_Items.IdModel);
           
            ViewBag.IdModel = new SelectList(modelsService.GetModelIdDossier(), "Id", "Model", gEN_Items.IdModel);
            return View(gEN_Item);
        }

        // POST: Commun/Items/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdModel,Libelle,Valeur,Ordre")] ItemsPivot gEN_Items)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(gEN_Items).State = EntityState.Modified;
                itemsServise.UpdateItemsPivot(gEN_Items);
                // db.SaveChanges();
                itemsServise.SaveItemsPivot();
                return RedirectToAction("Index");
            }
           // ViewBag.IdModel = new SelectList(db.GEN_Model.Where(e => e.IdSociete == CurrentSocieteId), "Id", "Model", gEN_Items.IdModel);
            ViewBag.IdModel = new SelectList(modelsService.GetModelIdDossier(), "Id", "Model", gEN_Items.IdModel);
            ItemsFormViewModel gEN_Item = Mapper.Map<ItemsPivot, ItemsFormViewModel>(gEN_Items);
            return View(gEN_Item);
        }

        // GET: Commun/Items/Delete/5
        public ActionResult Delete(long? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // GEN_Items gEN_Items = db.GEN_Items.Find(id);
            var gEN_Items = itemsServise.GetItems(id);
            ItemsFormViewModel gEN_Item = Mapper.Map<ItemsPivot, ItemsFormViewModel>(gEN_Items);

            // ViewBag.IdModel = new SelectList(db.GEN_Model.Where(e => e.IdSociete == CurrentSocieteId), "Id", "Model", gEN_Items.IdModel);
            ViewBag.IdModel = new SelectList(modelsService.GetModelIdDossier(), "Id", "Model", gEN_Items.IdModel);
            if (gEN_Items == null)
            {
                return HttpNotFound();
            }
            return View(gEN_Items);
        }

        // POST: Commun/Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed([Bind(Include = "Id")] ItemsFormViewModel gEN_Items)
        {
            //ViewBag.IdModel = new SelectList(db.GEN_Model.Where(e => e.IdSociete == CurrentSocieteId), "Id", "Model");
            ViewBag.IdModel = new SelectList(modelsService.GetModelIdDossier(), "Id", "Model", gEN_Items.IdModel);
            //GEN_Items gEN_Items = db.GEN_Items.Find(id);
            var gEN_Itemss = itemsServise.GetItems(gEN_Items.Id);
            //db.GEN_Items.Remove(gEN_Items);
            itemsServise.DeleteItemsPivot(gEN_Itemss);
            // db.SaveChanges();
            itemsServise.SaveItemsPivot();
            return RedirectToAction("Index");
        }













    }
}