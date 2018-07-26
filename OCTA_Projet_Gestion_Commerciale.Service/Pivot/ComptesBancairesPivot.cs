namespace OCTA_Projet_Gestion_Commerciale.Service.Pivot
{
    using System;
    using System.Collections.Generic;


    public partial class ComptesBancairesPivot
    {
       

        public long Id { get; set; }
      
        public long? IdBanque { get; set; }
    
        public string NomAgence { get; set; }
  
        public string Adresse { get; set; }
       
        public string Contact { get; set; }

     
        public string Tel { get; set; }

        
        //[IsRIBUnique]      
        public string RIB { get; set; }

        public long? IdDevise { get; set; }
 
        public bool Actif { get; set; }
   
        public bool ParDefault { get; set; }

        public long? IdDossier { get; set; }

        public string Sys_user { get; set; }

        public DateTime? Sys_dateUpdate { get; set; }

        public DateTime? Sys_dateCreation { get; set; }
  
        public long? IdCompteG { get; set; }

        public CompteGPivot CPT_CompteG { get; set; }

        public DevisesPivot GEN_Devises { get; set; }

        public DossiersPivot GEN_Dossiers { get; set; }

        public ItemsPivot GEN_Items { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public  ICollection<RelevesBancairesPivot> CPT_RelevesBancaires { get; set; }
    }
}
