namespace Store.Model
{
    using System;
    using System.Collections.Generic;
   

    public partial class CPT_CompteGDetailTVA
    {
        public long Id { get; set; }
  
        public long? IdCodeTVA { get; set; }
    
        public long? IdCompteGenerale { get; set; }
     
        public double? TauxTva { get; set; }
      
        public int? Percue { get; set; }
      
        public int? Exonere { get; set; }

        public long? IdCompteG { get; set; }

        public string sys_user { get; set; }

        public DateTime? sys_dateUpdate { get; set; }

        public DateTime? sys_dateCreation { get; set; }

        public virtual CPT_CodesTVA CPT_CodesTVA { get; set; }
    }
}
