using AutoMapper;
using OCTA_Projet_Gestion_Commerciale.Data.Utils;
using OCTA_Projet_Gestion_Commerciale.Service.Implementation;
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
    public class TypePaiementController : Controller
    {
        private readonly ITypePaiementService typePaiementService;
        public TypePaiementController(ITypePaiementService typePaiementService)
        {
            this.typePaiementService = typePaiementService;

        }
        // GET: TypePaiementK
        public ActionResult Index()
        {

            IEnumerable <GEN_TypePaiement_ViewModel> gEN_TypePaiement;
            ViewBag.Message = TempData["Message"];
            gEN_TypePaiement = Mapper.Map< IEnumerable<TypePaiementPivot >, IEnumerable<GEN_TypePaiement_ViewModel>>(typePaiementService.GetTypePaiementByIDDossier(1));
return View(gEN_TypePaiement.AsQueryable());

        }
        // GET: Commun/TypePaiement/Create
        public ActionResult Create(int? id)
        {
            TypePaiementPivot typePaiementPivot;
            GEN_TypePaiement_Form_ViewModel gEN_TypePaiement;
            if (id == null)
            {

                typePaiementPivot = typePaiementService.GetTypePaiement();
                if (typePaiementPivot != null)
                {
                    typePaiementService.DeleteTypePaiement(typePaiementPivot);


                }

                return View();
            }
            else
            {
                typePaiementPivot = typePaiementService.GetTypePaiement((long)id);
                ViewBag.Message = TempData["errorMessage"] + "";
                if (typePaiementPivot == null)
                {
                    TempData["Message"] = "Le type d'échéancement que vous cherchez n'existe pas.";
                    return RedirectToAction("Index");
                }

                gEN_TypePaiement = Mapper.Map<TypePaiementPivot, GEN_TypePaiement_Form_ViewModel>(typePaiementPivot);

                return View(gEN_TypePaiement);
            }
        } // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TypePaiementId,Libelle,Actif")] GEN_TypePaiement_Form_ViewModel gEN_TypePaiement)
        {
            TypePaiementPivot typePaiementPivot;
               var errors = ModelState.Where(x => x.Key != "Id").Select(x => x.Value.Errors)
                          .Where(y => y.Count > 0)
                          .ToList();
            if (errors.Count == 0)
            {
                GEN_TypePaiement_Form_ViewModel gEN_TypePaiementCreer = gEN_TypePaiement;
                if (gEN_TypePaiementCreer.TypePaiementId> 0)
                {
                    gEN_TypePaiementCreer.IdDossier = Constantes.CurrentPreferenceIdDossier;
                    typePaiementPivot = Mapper.Map<GEN_TypePaiement_Form_ViewModel, TypePaiementPivot>(gEN_TypePaiementCreer);


                    typePaiementService.UpdateTypePaiement(typePaiementPivot);
                }
                else
                {

                    typePaiementPivot = typePaiementService.GetTypePaiement();



                    if (typePaiementPivot == null)
                    {
                        typePaiementPivot = Mapper.Map<GEN_TypePaiement_Form_ViewModel, TypePaiementPivot>(gEN_TypePaiementCreer);

                        typePaiementPivot.IdDossier = Constantes.CurrentPreferenceIdDossier; ;
                        typePaiementService.CreateTypePaiement(typePaiementPivot);
                        //db.SaveChanges();
                    }
                    else
                    {
                        gEN_TypePaiementCreer.IdDossier = Constantes.CurrentPreferenceIdDossier;
                        gEN_TypePaiementCreer.Actif = gEN_TypePaiement.Actif;
                        gEN_TypePaiementCreer.Libelle = gEN_TypePaiement.Libelle;
                        typePaiementPivot = Mapper.Map<GEN_TypePaiement_Form_ViewModel, TypePaiementPivot>(gEN_TypePaiementCreer);


                        typePaiementService.UpdateTypePaiement(typePaiementPivot);
                    }
                }


                return RedirectToAction("Create", new { id = gEN_TypePaiementCreer.TypePaiementId });
            }

            return View(gEN_TypePaiement);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed([Bind(Include = "TypePaiementId")] GEN_TypePaiement_Form_ViewModel gEN_TypePaiement)
        {
            TypePaiementPivot modelPivot = typePaiementService.GetTypePaiement(gEN_TypePaiement.TypePaiementId);
            // modelPivot.IdDossier = Constantes.CurrentPreferenceIdDossier;

            typePaiementService.DeleteTypePaiement(modelPivot);
            return RedirectToAction("Index");
        }
    }
    }