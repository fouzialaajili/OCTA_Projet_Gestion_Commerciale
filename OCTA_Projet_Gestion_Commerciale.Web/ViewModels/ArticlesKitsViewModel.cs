﻿using OCTA_Projet_Gestion_Commerciale.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCTA_Projet_Gestion_Commerciale.Web.ViewModels
{
    public class ArticlesKitsViewModel
    {
        public long ArticlesKitId
        {
            get; set;
        }
        public int ArticlesKitQantite { get; set; }
        public string ArticlesKitDescription { get; set; }
        public int ArticlesKitSysuser { get; set; }
        public DateTime ArticlesKitSysDateCreation { get; set; }
        public long? ArticlesKitArticlesId { get; set; }
       // public  ArticlesViewModel ArticlesKitArticle { get; set; }
        public long? ArticlesKitArticleId { get; set; }
      //  public  ArticlesViewModel ArticlesKitArticle1 { get; set; }
    }
}