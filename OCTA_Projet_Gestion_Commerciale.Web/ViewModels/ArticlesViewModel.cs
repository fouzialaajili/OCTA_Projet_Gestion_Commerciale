using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCTA_Projet_Gestion_Commerciale.Web.ViewModels
{
    public class ArticlesViewModel
 {

        public long ArticleId { get; set; }


        public long ArticleTypeArticle { get; set; }
        public string ArticleCodeArticle
        { get; set; }
        public string ArticleDescription { get; set; }
        public string ArticleDescriptif
        { get; set; }
        public string ArticleCodeABarre { get; set; }
        public string ArticleEstSerialiser
        { get; set; }
        public bool ArticleEstGererEnStock { get; set; }
        public bool ArticleEstVendu
        { get; set; }
        public bool ArticleEstAchat { get; set; }
        public double ArticlePrixAchatDefault
        { get; set; }
        public double ArticlePrixVenteDefault { get; set; }
        public double ArticleCoefficientMarge
        { get; set; }
        public int ArticleSeuilStockMin { get; set; }
        public int ArticleSeuilStockMax
        { get; set; }
        public bool ArticleGarantieMaintenance { get; set; }
        public int ArticleGarantiemois
        { get; set; }


        public bool ArticlePubliable { get; set; }
        public bool ArticleActif
        { get; set; }
        public string ArticleImage
        { get; set; }
        public int ArticleSysuser { get; set; }
        public DateTime ArticleSysDateCreation { get; set; }
        public DateTime ArticlesSysDateUpdate { get; set; }

        public long? ArticleSocieteId { get; set; }
        public GEN_Dossiers_ViewModel ArticleSociete { get; set; }
        public long? ArticleDepotId { get; set; }
        public DepotViewModel ArticleDepot { get; set; }
        public long? ArticleCategorieId { get; set; }
        public CategorieViewModel ArticleCategorie { get; set; }
        public long? ArticleUniteId { get; set; }
        public UniteViewModel ArticleUnite { get; set; }
        public long? ArticleMarqueId { get; set; }
        public MarqueViewModel ArticleMarque { get; set; }

        public ICollection<FournisseurArticleViewModel> ArticleFournisseurArticle { get; set; }
        public ICollection<MouvementStockViewModel> ArticleMouvementStock { get; set; }
        public ICollection<NomenclatureViewModel> ArticleNomenclature { get; set; }
        public ICollection<ArticePrixViewModel> ArticleArticlesPrix { get; set; }
        public ICollection<DocummentCommercialDetailViewModel> ArticleDocumentCommercialDetail { get; set; }
        public ICollection<ArticlesKitsViewModel> ArticleArticlesKit { get; set; }
        public ICollection<ArticlesKitsViewModel> ArticleArticlesKit1 { get; set; }






























        //public long ArticleId { get; set; }


        //public long ArticleTypeArticle { get; set; }
        //public string ArticleCodeArticle
        //{ get; set; }
        //public string ArticleDescription { get; set; }
        //public string ArticleDescriptif
        //{ get; set; }
        //public string ArticleCodeABarre { get; set; }
        //public string ArticleEstSerialiser
        //{ get; set; }
        //public bool ArticleEstGererEnStock { get; set; }
        //public bool ArticleEstVendu
        //{ get; set; }
        //public bool ArticleEstAchat { get; set; }
        //public double ArticlePrixAchatDefault
        //{ get; set; }
        //public double ArticlePrixVenteDefault { get; set; }
        //public double ArticleCoefficientMarge
        //{ get; set; }
        //public int ArticleSeuilStockMin { get; set; }
        //public int ArticleSeuilStockMax
        //{ get; set; }
        //public bool ArticleGarantieMaintenance { get; set; }
        //public int ArticleGarantiemois
        //{ get; set; }


        //public bool ArticlePubliable { get; set; }
        //public bool ArticleActif
        //{ get; set; }
        //public string ArticleImage
        //{ get; set; }
        //public int ArticleSysuser { get; set; }
        //public DateTime ArticleSysDateCreation { get; set; }
        //public DateTime ArticlesSysDateUpdate { get; set; }

        //public long? ArticleSocieteId { get; set; }

        //public long? ArticleDepotId { get; set; }

        //public long? ArticleCategorieId { get; set; }
        //public long? ArticleUniteId { get; set; }

        //public long? ArticleMarqueId { get; set; }
        //public MarqueViewModel ArticleMarque { get; set; }

        //public ICollection<FournisseurArticleViewModel> ArticleFournisseurArticle { get; set; }
        //public ICollection<MouvementStockViewModel> ArticleMouvementStock { get; set; }
        //public ICollection<NomenclatureViewModel> ArticleNomenclature { get; set; }
        //public ICollection<ArticePrixViewModel> ArticleArticlesPrix { get; set; }
        //public ICollection<DocummentCommercialDetailViewModel> ArticleDocumentCommercialDetail { get; set; }
        //public ICollection<ArticlesKitsViewModel> ArticleArticlesKit { get; set; }
        //public ICollection<ArticlesKitsViewModel> ArticleArticlesKit1 { get; set; }

    }
}