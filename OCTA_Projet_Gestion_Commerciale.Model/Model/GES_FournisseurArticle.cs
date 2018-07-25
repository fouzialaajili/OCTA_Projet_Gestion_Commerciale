using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Model
{
    public class GES_FournisseurArticle
    {
        public long FournisseurArticleId { get; set; }
     /**/   public long FournisseurArticleIdArticle { get; set; }
    /**/    public long FournisseurArticleIdfournisseur { get; set; }
        public string FournisseurArticleReference { get; set; }
        public decimal FournisseurArticlePrixAchatTC { get; set; }
        public string FournisseurArticleDeviseAchat { get; set; }
        public decimal FournisseurArticlePrixAchatDevise { get; set; }
        public decimal FournisseurArticlePrixVenteTC { get; set; }
        public string FournisseurArticleDeviseVente { get; set; }
        public string FournisseurArticlePrixVenteDevise { get; set; }

        public long FournisseurArticleSysuser { get; set; }
        public DateTime? FournisseurArticleSysDateCreation { get; set; }
        public DateTime? FournisseurArticleSysDateUpdate { get; set; }
        virtual public GEN_Tiers FournisseurArticleFichetier { get; set; }
        virtual public GES_Article FournisseurArticleArticle
        { get; set; }




    }
}
