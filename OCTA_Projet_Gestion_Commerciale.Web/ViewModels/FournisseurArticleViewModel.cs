using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCTA_Projet_Gestion_Commerciale.Web.ViewModels
{
    public class FournisseurArticleViewModel
    {
        public long FournisseurArticleId { get; set; }
        /**/
        public long? FournisseurArticleIdArticle { get; set; }
        /**/
        public long? FournisseurArticleIdfournisseur { get; set; }
        public string FournisseurArticleReference { get; set; }
        public decimal FournisseurArticlePrixAchatTC { get; set; }
        public string FournisseurArticleDeviseAchat { get; set; }
        public decimal FournisseurArticlePrixAchatDevise { get; set; }
        public decimal FournisseurArticlePrixVenteTC { get; set; }
        public string FournisseurArticleDeviseVente { get; set; }
        public string FournisseurArticlePrixVenteDevise { get; set; }

        public long? FournisseurArticleSysuser { get; set; }
        public DateTime? FournisseurArticleSysDateCreation { get; set; }
        public DateTime? FournisseurArticleSysDateUpdate { get; set; }
    }
}