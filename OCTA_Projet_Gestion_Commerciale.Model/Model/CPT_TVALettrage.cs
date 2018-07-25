using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Model
{
    public partial class CPT_TVALettrage
    {
        public long Id { get; set; }
        public long? EcheanceId { get; set; }
        public long? LettrageId { get; set; }
        //public long? PieceId { get; set; }
   
        public double? MntTTC { get; set; }
     
        public long? CompteTVA { get; set; }
   
        public string CodeCompteTVA { get; set; }
      
        public double? TAuxTVA { get; set; }
     
        public double? MntTVA { get; set; }
      
        public long? CompteHT { get; set; }
 
        public string CodeCompteHT { get; set; }
     
        public double? MntHT { get; set; }
        public string TypePayment { get; set; }
        public virtual CPT_Lettrage CPT_Lettrage { get; set; }
    }
}
