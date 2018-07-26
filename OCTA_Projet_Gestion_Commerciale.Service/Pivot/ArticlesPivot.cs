using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Service.Pivot
{
    public class ArticlePivot
    {
        public long  Id { get; set; }


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
        public  DossiersPivot  ArticleSociete { get; set; }
        public long? ArticleDepotId { get; set; }
        public DepotPivot ArticleDepot { get; set; }
        public long? ArticleCategorieId { get; set; }
        public  CategoriePivot ArticleCategorie { get; set; }
        public long? ArticleUniteId { get; set; }
        public  UnitePivot ArticleUnite { get; set; }
        public long? ArticleMarqueId { get; set; }
        public MarquePivot ArticleMarque { get; set; }

        public  ICollection<FournisseurArticlePivot> ArticleFournisseurArticle { get; set; }
        public ICollection<MouvementStockPivot> ArticleMouvementStock { get; set; }
        public  ICollection<NomenclaturePivot> ArticleNomenclature { get; set; }
        public  ICollection<ArticlesPrixPivot> ArticleArticlesPrix { get; set; }
        public ICollection<DocumentCommercialDetailPivot> ArticleDocumentCommercialDetail { get; set; }
        public  ICollection<ArticlesKitPivot> ArticleArticlesKit { get; set; }
        public  ICollection<ArticlesKitPivot> ArticleArticlesKit1 { get; set; }


    }
}
