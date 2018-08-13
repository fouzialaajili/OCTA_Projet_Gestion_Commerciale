using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Service.Pivot
{
   public  class CategoriePivot
    {
        public long CategorieId { get; set; }
        public string CategorieLibelle { get; set; }
        public string CategorieDescription
        { get; set; }
        public int CategorieSysuser { get; set; }
        public DateTime CategorieSysDateCreation { get; set; }
        public DateTime CategorieSysDateUpdate { get; set; }
        public bool CategorieActif { get; set; }
        public long? CategorieSocieteId { get; set; }
        public DossiersPivot CategorieSociete { get; set; }
        public ICollection<ArticlePivot> CategorieArticle { get; set; }
    }
}
