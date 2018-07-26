namespace OCTA_Projet_Gestion_Commerciale.Service.Pivot
{
    using System;
    using System.Collections.Generic;
   

    public partial class CompteGDetailTVAPivot
    {
        public long Id { get; set; }
  
        public long? IdCodeTVA { get; set; }
    
        public long? IdCompteGenerale { get; set; }
     
        public double? TauxTva { get; set; }
      
        public int? Percue { get; set; }
      
        public int? Exonere { get; set; }

        public long? IdCompteG { get; set; }

        public string Sys_user { get; set; }

        public DateTime? Sys_dateUpdate { get; set; }

        public DateTime? Sys_dateCreation { get; set; }

        public CodesTVAPivot CPT_CodesTVA { get; set; }
    }
}
