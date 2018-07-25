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

        }
    }
}