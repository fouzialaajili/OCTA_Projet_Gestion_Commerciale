﻿using AutoMapper;
using OCTA_Projet_Gestion_Commerciale.Service.Mappages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCTA_Projet_Gestion_Commerciale.Web.Mappages
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
               x.AddProfile<PivotToViewModelMappingProfile>();
                x.AddProfile<ModelToPivotMappingProfile>();
            });
        }
    }
}