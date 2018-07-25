using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Model
{
    public class Articles
    {
        public long ArticlesId { get; set; }


        public long ArticlesTypeArticle { get; set; }
        public string ArticlesCodeArticle
        { get; set; }
        public string ArticlesDescription { get; set; }
        public string ArticlesDescriptif
        { get; set; }
        public string ArticlesCodeABarre { get; set; }
        public string ArticlesEstSerialiser
        { get; set; }
        public bool ArticlesEstGererEnStock { get; set; }
        public bool  ArticlesEstVendu
        { get; set; }
        public bool ArticlesEstAchat { get; set; }
    public double  ArticlesPrixAchatDefault
        { get; set; }
        public double ArticlesPrixVenteDefault { get; set; }
        public double ArticlesCoefficientMarge
        { get; set; }
        public int  ArticlesSeuilStockMin { get; set; }
        public int  ArticlesSeuilStockMax
        { get; set; }
        public bool  ArticlesGarantieMaintenance { get; set; }
    public int ArticlesGarantiemois
        { get; set; }


        public bool ArticlesPubliable { get; set; }
    public bool ArticlesActif
        { get; set; }
public string ArticlesImage
        { get; set; }
        public int ArticlesSysuser { get; set; }
        public DateTime ArticlesSysDateCreation { get; set; }
        public DateTime ArticlesSysDateUpdate { get; set; }
      
        public long ArticlesSocieteId { get; set; }
        public virtual Societe ArticlesSociete { get; set; }
        public long ArticlesDepotId { get; set; }
        public  virtual Depot ArticlesDepot { get; set; }
        public long ArticlesCategorieId { get; set; }
        public virtual Categorie ArticlesCategorie { get; set; }
        public long  ArticlesUniteId { get; set; }
        public virtual Unite ArticlesUnite { get; set; }
        public long ArticlesMarqueId { get; set; }
        public  virtual Marque ArticlesMarque { get; set; }

        public virtual ICollection<FournisseurArticle> ArticlesFournisseurArticle { get; set; }
        public virtual ICollection<MouvementStock> ArticleMouvementStock { get; set; }
        public virtual ICollection<Nomenclature> ArticleNomenclature { get; set; }
    }
}
