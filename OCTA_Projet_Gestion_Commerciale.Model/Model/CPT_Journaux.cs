namespace OCTA_Projet_Gestion_Commerciale.Model
{
    using System;
    using System.Collections.Generic;
   

    public partial class CPT_Journaux
    {
        

        public long Id { get; set; }

     
        public string CodeJournal { get; set; }

    
        public string Libelle { get; set; }

        public long? TypeJournal { get; set; }

  
        public long? IdCompteContrepartie { get; set; }

        public long? IdDossier { get; set; }

        
        public long? IdDevise { get; set; }

        public bool Actif { get; set; }

        public string sys_user { get; set; }

        public DateTime? sys_DateUpdate { get; set; }

        public DateTime? sys_DateCreation { get; set; }

        public virtual CPT_CompteG CPT_CompteG { get; set; }

        public virtual GEN_Devises GEN_Devises { get; set; }

        public virtual GEN_Dossiers GEN_Dossiers { get; set; }

        public virtual GEN_Items GEN_Items { get; set; }

  
        public virtual ICollection<CPT_ParametrageComptable> CPT_ParametrageComptable { get; set; }

  
        public virtual ICollection<CPT_Pieces> CPT_Pieces { get; set; }

   
        public virtual ICollection<GEN_Regelement> GEN_Regelement { get; set; }
    }
}
