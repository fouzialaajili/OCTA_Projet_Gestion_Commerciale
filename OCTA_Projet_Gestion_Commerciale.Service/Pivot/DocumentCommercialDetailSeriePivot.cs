
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Service.Pivot
{
   public  class DocumentCommercialDetailSeriePivot
    {
       public long  Id { get; set; }
        public double DocumentCommercialDetailSerieNumeroSerie { get; set; }
   public string DocumentCommercialDetailSerieNumeroLot { get; set; }
        public bool DocumentCommercialDetailSerieGarantie { get; set; }
     public DateTime   DocumentCommercialDetailSerieDateFinMaintenance { get; set; }
        public int DocumentCommercialDetailSerieSysuser { get; set; }
        public DateTime DocumentCommercialDetailSerieSysDateCreation { get; set; }
        public DateTime DocumentCommercialDetailSerieSysDateUpdate { get; set; }
    
        public long?  DocumentCommercialDetailSerieSocieteId { get; set; }
        public DossiersPivot DocumentCommercialDetailSerieSociete { get; set; }
        public long?  DocumentCommercialDetailSerieDocumentCommercialDetailIdDocumentDetail { get; set; }
        public  DocumentCommercialDetailPivot DocumentCommercialDetailSerieDocumentCommercialDetail { get; set; }

    }
}
