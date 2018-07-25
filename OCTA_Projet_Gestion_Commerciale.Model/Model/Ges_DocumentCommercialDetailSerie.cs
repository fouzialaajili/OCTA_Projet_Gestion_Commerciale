
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Model
{
   public  class GES_DocumentCommercialDetailSerie
    {
       public long  DocumentCommercialDetailSerieId { get; set; }
        public double DocumentCommercialDetailSerieNumeroSerie { get; set; }
   public string DocumentCommercialDetailSerieNumeroLot { get; set; }
        public bool DocumentCommercialDetailSerieGarantie { get; set; }
     public DateTime   DocumentCommercialDetailSerieDateFinMaintenance { get; set; }
        public int DocumentCommercialDetailSerieSysuser { get; set; }
        public DateTime DocumentCommercialDetailSerieSysDateCreation { get; set; }
        public DateTime DocumentCommercialDetailSerieSysDateUpdate { get; set; }
    
        public long  DocumentCommercialDetailSerieSocieteId { get; set; }
        public virtual GEN_Dossiers DocumentCommercialDetailSerieSociete { get; set; }
        public long  DocumentCommercialDetailSerieDocumentCommercialDetailIdDocumentDetail { get; set; }
        public virtual GES_DocumentCommercialDetail DocumentCommercialDetailSerieDocumentCommercialDetail { get; set; }

    }
}
