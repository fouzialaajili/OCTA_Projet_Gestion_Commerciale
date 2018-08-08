using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCTA_Projet_Gestion_Commerciale.Web.ViewModels
{
    public class MouvementStockViewModel
    {
        public long MouvementStockId { get; set; }
        public string MouvementStockCode { get; set; }
        public string MouvementStockSens { get; set; }
        public long? MouvementStockTypearticle { get; set; }
        public string MouvementStockCodebundle { get; set; }
        /***/
        public long? MouvementStockIdarticle { get; set; }
        public int MouvementStockNiveau { get; set; }
        public DateTime? MouvementStockDatemouvement { get; set; }
        public string MouvementStockOrigine { get; set; }
        /***/
        public long? MouvementStockIddocument { get; set; }
        public string MouvementStockStatut { get; set; }
        public string MouvementStockSerialise { get; set; }
        public int MouvementStockNumeroserie { get; set; }
        public string MouvementStockLot { get; set; }
        public int MouvementStockNumerolot { get; set; }
        public int MouvementStockQuantite { get; set; }
        public int MouvementStockCodeliaison { get; set; }
        /***/
        public long? MouvementStockIddepot { get; set; }
        public string MouvementStockDepot { get; set; }
        public string MouvementStockMotif { get; set; }
        public string MouvementStockDescmotif { get; set; }
        public int MouvementStockSys_user { get; set; }
        public DateTime? MouvementStockSysDateCreation { get; set; }
        public DateTime? MouvementStockSysDateUpdate { get; set; }

        public long? MouvementStockDossierId { get; set; }
    }
}