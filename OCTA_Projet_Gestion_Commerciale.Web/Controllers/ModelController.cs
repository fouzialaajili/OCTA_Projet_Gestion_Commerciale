using AutoMapper;
using OCTA_Projet_Gestion_Commerciale.Model;
using OCTA_Projet_Gestion_Commerciale.Service.Interface;
using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using OCTA_Projet_Gestion_Commerciale.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OCTA_Projet_Gestion_Commerciale.Data.Utils;
using System.Net;

namespace OCTA_Projet_Gestion_Commerciale.Web.Controllers
{
    public class ModelController : Controller
    {
        private readonly IModelService modelService;
        public readonly IDossiersService dossiersService;
        public ModelController(IModelService modelService, IDossiersService dossiersService)
        {
            this.modelService = modelService;
            this.dossiersService = dossiersService;

        }
        // GET: Model
        public ActionResult Index()
        {
            IEnumerable<GEN_Model_ViewModel> gEN_Model_ViewModel;
            IEnumerable<ModelPivot> modelPivot;
            IEnumerable<GEN_Dossiers_ViewModel> gEN_Dossiers_ViewModel;
            IEnumerable<DossiersPivot> dossiersPivot;
            dossiersPivot = dossiersService.GetDossiersByActif(true);

           modelPivot = modelService.GetModelByIdDossier(Constantes.CurrentPreferenceIdDossier);
            gEN_Model_ViewModel = Mapper.Map<IEnumerable<ModelPivot>, IEnumerable<GEN_Model_ViewModel>>(modelPivot);
            gEN_Dossiers_ViewModel = Mapper.Map<IEnumerable<DossiersPivot>, IEnumerable<GEN_Dossiers_ViewModel>>(dossiersPivot);

            ViewBag.IdSociete = gEN_Dossiers_ViewModel.OrderBy(x => x.DossierRaisonSociale).Select(x => new { ID = x.DossierId, VALUE = x.DossierRaisonSociale });
            return View(gEN_Model_ViewModel.AsQueryable());
        }
        public ActionResult Create(long? id)
        {
            if (id == null)
            {
                ViewBag.IdSociete = new SelectList(dossiersService.GetAllDossier(), "DossierId", "DossierRaisonSociale");
                return View();
            }
            else
            {
                ModelPivot modelPivot = modelService.GetModel(id);
                GEN_Model_Form_ViewModel gEN_Model = Mapper.Map<ModelPivot, GEN_Model_Form_ViewModel>(modelPivot);

                if (modelPivot == null)
                {
                    return RedirectToAction("Index");
                }
                ViewBag.IdSociete = new SelectList(dossiersService.GetDossiersByDossiersId(), "DossierId", "DossierRaisonSociale", modelPivot.IdDossier);
                return View(gEN_Model);
            }

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Model,IdDossier")] GEN_Model_Form_ViewModel gEN_Model)
        {
            if (ModelState.IsValid)
            {
                if (gEN_Model.Id > 0)
                {
                    gEN_Model.IdDossier = Constantes.CurrentPreferenceIdDossier;
                    ModelPivot modelPivot = Mapper.Map<GEN_Model_Form_ViewModel, ModelPivot>(gEN_Model);

                    modelService.UpdateModel(modelPivot);
                    modelService.SaveModel();
                }
                else
                {
                    gEN_Model.IdDossier = Constantes.CurrentPreferenceIdDossier;
                    ModelPivot modelPivot = Mapper.Map<GEN_Model_Form_ViewModel, ModelPivot>(gEN_Model);

                    modelService.CreateModel(modelPivot);


                }

                return RedirectToAction("Index");

            }

            ViewBag.IdSociete = new SelectList(dossiersService.GetDossiersByDossiersId(), "DossierId", "DossierRaisonSociale", gEN_Model.IdDossier);
            return View(gEN_Model);
        }




        public ActionResult Details(long? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModelPivot modelPivot = modelService.GetModel(id);
            GEN_Model_ViewModel gEN_Model_ViewModel;

            gEN_Model_ViewModel = Mapper.Map<ModelPivot, GEN_Model_ViewModel>(modelPivot);


            ViewBag.IdSociete = new SelectList(dossiersService.GetDossiersByDossiersId(), "DossierId", "DossierRaisonSociale", modelPivot.IdDossier);
            if (modelPivot == null)
            {
                return HttpNotFound();
            }
            return View(gEN_Model_ViewModel);
        }
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModelPivot modelPivot = modelService.GetModel(id);
            if (modelPivot == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdSociete = new SelectList(dossiersService.GetDossiersByDossiersId(), "DossierId", "DossierRaisonSociale", modelPivot.IdDossier);

            GEN_Model_Form_ViewModel gEN_Model_Form_ViewModel;

            gEN_Model_Form_ViewModel = Mapper.Map<ModelPivot, GEN_Model_Form_ViewModel>(modelPivot);


            return View(gEN_Model_Form_ViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Model,IdDossier")] GEN_Model_Form_ViewModel gEN_Model)
        {
            if (ModelState.IsValid)
            {
                gEN_Model.IdDossier = Constantes.CurrentPreferenceIdDossier;
                ModelPivot modelPivot = Mapper.Map<GEN_Model_Form_ViewModel, ModelPivot>(gEN_Model);

                modelService.UpdateModel(modelPivot);
                modelService.SaveModel();
                return RedirectToAction("Index");
            }
            ViewBag.IdSociete = new SelectList(dossiersService.GetDossiersByDossiersId(), "DossierId", "DossierRaisonSociale", gEN_Model.IdDossier);
            return View(gEN_Model);
        }
        public ActionResult Delete(long? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModelPivot modelPivot = modelService.GetModel(id);

            ViewBag.IdSociete = new SelectList(dossiersService.GetDossiersByDossiersId(), "DossierId", "DossierRaisonSociale", modelPivot.IdDossier);
            GEN_Model_ViewModel gEN_Model_ViewModel;

            gEN_Model_ViewModel = Mapper.Map<ModelPivot, GEN_Model_ViewModel>(modelPivot);

            if (gEN_Model_ViewModel == null)
            {
                return HttpNotFound();
            }
            return View(gEN_Model_ViewModel);
        }

        // POST: Commun/Models/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            ModelPivot modelPivot = modelService.GetModel(id);
            // modelPivot.IdDossier = Constantes.CurrentPreferenceIdDossier;

            modelService.DeleteModel(modelPivot);

            return RedirectToAction("Index");
        }



    }
}