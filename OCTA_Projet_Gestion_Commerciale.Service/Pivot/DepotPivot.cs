using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Service.Pivot
{
    public class DepotPivot
    {
        public int Id { get; set; }

        public string DepotVille { get; set; }
        public string DepotPays { get; set; }
    public string DepotAdresse { get; set; }
        public string DepotDepot { get; set; }
        public string DepotCode{ get; set; }
        public string DepotDescription
        { get; set; }
        public int DepotSysuser { get; set; }
        public DateTime DepotSysDateCreation { get; set; }
        public DateTime DepotSysDateUpdate { get; set; }
        public bool DepotActif { get; set; }
        public long DepotSocieteId { get; set; }
        public  DossiersPivot DepotSociete { get; set; }
        public ICollection<MouvementStockPivot> DepotMouvementStock { get; set; }
        public  ICollection<ArticlePivot> DepotArticle { get; set; }
     
       
    }
}
