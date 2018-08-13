using AutoMapper;
using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using OCTA_Projet_Gestion_Commerciale.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gestion_Commerciale.Web.Mappages
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<AdminPivot, AdminViewModel>()
                  .ReverseMap()
                  .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<DossiersPivot, GEN_Dossiers_Form_ViewModel>()
               .ReverseMap()
               .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<ModelPivot, GEN_Model_Form_ViewModel>()
               .ReverseMap()
               .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<RegelementPivot, GEN_Regelement_Form_ViewModel>()
               .ReverseMap()
               .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<TiersPivot, GEN_Tiers_Form_ViewModel>()
               .ReverseMap()
               .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<TypePaiementPivot, GEN_TypePaiement_Form_ViewModel>()
               .ReverseMap()
               .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<TypePaiementDetailPivot, GEN_TypePaiementDetail_Form_ViewModel>()
               .ReverseMap()
               .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<RelevesBancairesDetailPivot, CPT_RelevesBancairesDetail_Form_ViewModel>()
               .ReverseMap()
               .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<DossiersPivot, GEN_Dossiers_ViewModel>()
                 .ReverseMap()
                 .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<ModelPivot, GEN_Model_ViewModel>()
               .ReverseMap()
               .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<RegelementPivot, GEN_Regelement_ViewModel>()
               .ReverseMap()
               .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<TiersPivot, GEN_Tiers_ViewModel>()
               .ReverseMap()
               .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<TypePaiementPivot, GEN_TypePaiement_ViewModel>()
               .ReverseMap()
               .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<TypePaiementDetailPivot, GEN_TypePaiementDetail_ViewModel>()
               .ReverseMap()
               .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<RelevesBancairesDetailPivot, CPT_RelevesBancairesDetail_ViewModel>()
               .ReverseMap()
               .IgnoreAllPropertiesWithAnInaccessibleSetter();
          

        }
    }
}