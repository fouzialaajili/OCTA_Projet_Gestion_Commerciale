using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCTA_Projet_Gestion_Commerciale.Web.ViewModels
{
    public class ArticePrixViewModel
    {
        public long ArticlesPrixId { get; set; }
        public double ArticlesPrixprixAchatTC { get; set; }
        public double ArticlesPrixprixVenteTC
        { get; set; }
        public string ArticlesPrixDeviseVente { get; set; }
        public string ArticlesPrixDeviseAchat { get; set; }
        public double ArticlesPrixPrixVenteDevise { get; set; }
        public DateTime ArticlesPrixDateApplication { get; set; }
        public bool ArticlesPrixActif { get; set; }
        public int ArticlesPrixSysuser { get; set; }
        public DateTime ArticlesPrixSysDateCreation { get; set; }
        public DateTime ArticlesPrixSysDateUpdate { get; set; }
        public long? ArticlesPrixArticleId { get; set; }
    }
}