using AutoMapper;

using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using OCTA_Projet_Gestion_Commerciale.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCTA_Projet_Gestion_Commerciale.Web.Mappages
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        public DomainToViewModelMappingProfile()
        {
            CreateMap<AdminPivot, AdminViewModel>()
               .ReverseMap()
               .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<TiersPivot, GEN_Tiers_ViewModel>()
               .ReverseMap()
               .IgnoreAllPropertiesWithAnInaccessibleSetter();

        }
    }
}