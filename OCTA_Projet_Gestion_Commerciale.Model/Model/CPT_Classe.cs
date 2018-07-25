namespace Store.Model
{
    using System;
    using System.Collections.Generic;
    public partial class CPT_Classe
    {
       

        public long Id { get; set; }

        
        public string CodeClasse { get; set; }

        public string Libelle { get; set; }

        public long? IdClasse { get; set; }

        public long? IdDossier { get; set; }

        public string sys_user { get; set; }

        public DateTime? Sys_dateUpdate { get; set; }

        public DateTime? Sys_dateCreation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CPT_Classe> CPT_Classe_Childs { get; set; }

        public virtual CPT_Classe CPT_Classe_Parent { get; set; }

        public virtual GEN_Dossiers GEN_Dossiers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CPT_CompteG> CPT_CompteG { get; set; }
    }
}
