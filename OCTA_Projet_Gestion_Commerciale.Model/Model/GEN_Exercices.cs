namespace Store.Model
{
    using System;
    using System.Collections.Generic;
 

    public partial class GEN_Exercices
    {
        

        public long Id { get; set; }

      
        public string CodeExercice { get; set; }

        public string Libelle { get; set; }

       
        public DateTime? DateDebut { get; set; }

        public DateTime? DateFin { get; set; }
    
        public bool Actif { get; set; }
      
        public int? ComptaCloture { get; set; }
   
        public int? GescomCloture { get; set; }
      
        public int? PaieCloture { get; set; }
    
        public long? IdDossier { get; set; }

        public string sys_user { get; set; }

        public DateTime? sys_dateUpdate { get; set; }

        public DateTime? sys_dateCreation { get; set; }

        public virtual GEN_Dossiers GEN_Dossiers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GEN_Periodes> GEN_Periodes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GEN_Preferences> GEN_Preferences { get; set; }
    }
}
