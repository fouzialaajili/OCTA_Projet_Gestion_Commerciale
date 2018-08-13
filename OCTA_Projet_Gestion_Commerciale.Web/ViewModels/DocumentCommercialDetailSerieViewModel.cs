using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCTA_Projet_Gestion_Commerciale.Web.ViewModels
{
    public class DocumentCommercialDetailSerieViewModel
    {
        public long DocumentCommercialDetailSerieId { get; set; }
        public double DocumentCommercialDetailSerieNumeroSerie { get; set; }
        public string DocumentCommercialDetailSerieNumeroLot { get; set; }
        public bool DocumentCommercialDetailSerieGarantie { get; set; }
        public DateTime DocumentCommercialDetailSerieDateFinMaintenance { get; set; }
        public int DocumentCommercialDetailSerieSysuser { get; set; }
        public DateTime DocumentCommercialDetailSerieSysDateCreation { get; set; }
        public DateTime DocumentCommercialDetailSerieSysDateUpdate { get; set; }

        public long? DocumentCommercialDetailSerieSocieteId { get; set; }
        public long? DocumentCommercialDetailSerieDocumentCommercialDetailIdDocumentDetail { get; set; }
    }
}