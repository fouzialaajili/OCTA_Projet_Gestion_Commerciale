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
    public class GEN_TypePaiementDetailController : Controller
    {
        private readonly ITypePaiementDetailService typePaiementDetailServise;
        private readonly IDossiersService dossiersService;

        public GEN_TypePaiementDetailController(ITypePaiementDetailService typePaiementDetailServise, IDossiersService dossiersService)
        {
            this.typePaiementDetailServise = typePaiementDetailServise;
            this.dossiersService = dossiersService;
        }

        public ActionResult Index()
        {
            var TypePaiementDetail = typePaiementDetailServise.GetALL();

            IEnumerable<TypePaiementDetailViewModel> TypePaiementDetail_Views = Mapper.Map<IEnumerable<TypePaiementDetailPivot>, IEnumerable<TypePaiementDetailViewModel>>(TypePaiementDetail);

            return View(TypePaiementDetail_Views.AsQueryable());


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
                var TypePaiementDetail = typePaiementDetailServise.GetTypePaiementDetails((int)id);
                if (TypePaiementDetail == null)
                {

                    TempData["errorMessage"] = "Type de paiement que vous cherchez n'existe pas.";
                    return RedirectToAction("Index");
                }

                TypePaiementDetailFormViewModel TypePaiementDetailFormModel = Mapper.Map<TypePaiementDetailPivot, TypePaiementDetailFormViewModel >(TypePaiementDetail);
                return View(TypePaiementDetailFormModel);
            }

        }





        // POST: Commun/Devises/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TypePaiementDetailId,IdTypePaiement,IdModePaiement,DateCalcul,Pourcentage,NombreJour,Delai,GEN_Items_DateCalcul_Id,GEN_Items_Delai_Id,GEN_Items_ModePaiement_Id")]TypePaiementDetailPivot TypePaiementDetail)
        {



            // if (ModelState.IsValid)
            if (TypePaiementDetail != null)
            {
                if (TypePaiementDetail.TypePaiementDetailId > 0)
                {
                    TypePaiementDetail.IdTypePaiement = null;
                    TypePaiementDetail.sys_dateUpdate = DateTime.Now;
                    TypePaiementDetail.sys_dateCreation = DateTime.Now;
                    TypePaiementDetail.sys_user = Constantes.IdentifiantUser;
                    TypePaiementDetail.IdModePaiement = null;

                    typePaiementDetailServise.UpdateTypePaiementDetail(TypePaiementDetail);
                    typePaiementDetailServise.SaveTypePaiementDetail();
                }
                else
                {

                    TypePaiementDetail.IdTypePaiement = null;

                    TypePaiementDetail.sys_dateUpdate = DateTime.Now;
                    TypePaiementDetail.sys_dateCreation = DateTime.Now;
                    TypePaiementDetail.sys_user = Constantes.IdentifiantUser;


                    typePaiementDetailServise.CreateTypePaiementDetail(TypePaiementDetail);
                    typePaiementDetailServise.SaveTypePaiementDetail();
                }


                return RedirectToAction("Index");
            }

            TypePaiementDetailFormViewModel cpt_comptsFormModel = Mapper.Map<TypePaiementDetailPivot, TypePaiementDetailFormViewModel>(TypePaiementDetail);
            return View(cpt_comptsFormModel);
        }



        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // DevisesPivot gEN_Devises = deviseServise.GetDevise(id);
          TypePaiementDetailPivot TypePaiementDetail = typePaiementDetailServise.GetTypePaiementDetails((int)id);
            //db.GEN_Devises.Find(id);
            if (TypePaiementDetail == null)
            {
                return HttpNotFound();
            }


        TypePaiementDetailFormViewModel TypePaiementDetailFormModel = Mapper.Map<TypePaiementDetailPivot, TypePaiementDetailFormViewModel>(TypePaiementDetail);
            return View(TypePaiementDetailFormModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TypePaiementDetailId,IdTypePaiement,IdModePaiement,DateCalcul,Pourcentage,NombreJour,Delai,GEN_Items_DateCalcul_Id,GEN_Items_Delai_Id,GEN_Items_ModePaiement_Id")] TypePaiementDetailPivot TypePaiementDetail)
        {

            if (ModelState.IsValid)
            {
                TypePaiementDetail.IdTypePaiement = null;

                TypePaiementDetail.sys_dateUpdate = DateTime.Now;
                TypePaiementDetail.sys_dateCreation = DateTime.Now;
                TypePaiementDetail.sys_user = Constantes.IdentifiantUser;
                typePaiementDetailServise.UpdateTypePaiementDetail(TypePaiementDetail);
                //   db.SaveChanges();
                typePaiementDetailServise.SaveTypePaiementDetail();
                return RedirectToAction("Index");
            }


            TypePaiementDetailFormViewModel TypePaiementDetailFormModel = Mapper.Map<TypePaiementDetailPivot, TypePaiementDetailFormViewModel>(TypePaiementDetail);
            return View(TypePaiementDetailFormModel);

        }


        public ActionResult Delete(long? id)
        {
         
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           TypePaiementDetailPivot TypePaiementDetail = typePaiementDetailServise.GetTypePaiementDetails((int)id);
            //db.GEN_Devises.Find(id);
            if (TypePaiementDetail == null)
            {
                return HttpNotFound();
            }

          TypePaiementDetailFormViewModel TypePaiementDetails = Mapper.Map<TypePaiementDetailPivot, TypePaiementDetailFormViewModel>(TypePaiementDetail);
            return View(TypePaiementDetails);
        }




        // POST: Commun/TypePaiement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed([Bind(Include = "TypePaiementDetailId")] TypePaiementDetailFormViewModel TypePaiementDetail)
        {
            TypePaiementDetailPivot cods = Mapper.Map<TypePaiementDetailFormViewModel, TypePaiementDetailPivot>(TypePaiementDetail);
        TypePaiementDetailPivot codes = typePaiementDetailServise.GetTypePaiementDetails(cods.TypePaiementDetailId);


            typePaiementDetailServise.DeleteTypePaiementDetail(codes);
            // db.SaveChanges();
            typePaiementDetailServise.SaveTypePaiementDetail();
            return RedirectToAction("Index");



        }


    }
}