namespace OCTA_Projet_Gestion_Commerciale.Service.Pivot
{
    using System;
    using System.Collections.Generic;
   

    public partial class JournauxPivot
    {
        

        public long Id { get; set; }

     
        public string CodeJournal { get; set; }

    
        public string Libelle { get; set; }

        public long? TypeJournal { get; set; }

  
        public long? IdCompteContrepartie { get; set; }

        public long? IdDossier { get; set; }

        
        public long? IdDevise { get; set; }

        public bool Actif { get; set; }

        public string Sys_user { get; set; }

        public DateTime? Sys_DateUpdate { get; set; }

        public DateTime? Sys_DateCreation { get; set; }

        public CompteGPivot CPT_CompteG { get; set; }

        public  DevisesPivot GEN_Devises { get; set; }

        public  DossiersPivot GEN_Dossiers { get; set; }

        public ItemsPivot GEN_Items { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public  ICollection<ParametrageComptablePivot> CPT_ParametrageComptable { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public  ICollection<PiecesPivot> CPT_Pieces { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public  ICollection<RegelementPivot> GEN_Regelement { get; set; }
    }
}
