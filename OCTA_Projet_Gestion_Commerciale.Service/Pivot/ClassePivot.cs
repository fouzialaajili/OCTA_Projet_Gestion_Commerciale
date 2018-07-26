namespace OCTA_Projet_Gestion_Commerciale.Service.Pivot
{
    using System;
    using System.Collections.Generic;
    public partial class ClassePivot
    {
       

        public long Id { get; set; }

        
        public string CodeClasse { get; set; }

        public string Libelle { get; set; }

        public long? IdClasse { get; set; }

        public long? IdDossier { get; set; }

        public string Sys_user { get; set; }

        public DateTime? Sys_dateUpdate { get; set; }

        public DateTime? Sys_dateCreation { get; set; }

       
        public  ICollection<ClassePivot> CPT_Classe_Childs { get; set; }

        public ClassePivot CPT_Classe_Parent { get; set; }

        public DossiersPivot GEN_Dossiers { get; set; }

   
        public  ICollection<CompteGPivot> CPT_CompteG { get; set; }
    }
}
