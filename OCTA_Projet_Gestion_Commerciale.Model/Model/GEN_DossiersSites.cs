namespace OCTA_Projet_Gestion_Commerciale.Model
{
    using System;
    using System.Collections.Generic;


    public partial class GEN_DossiersSites
    {
      
        public long Id { get; set; }


        public string Nom { get; set; }

        public string Adresse { get; set; }

  
        public string Tel { get; set; }


        public string Fax { get; set; }

  
        public string Email { get; set; }


        public string Ville { get; set; }

  
        public string Pays { get; set; }

        public bool Actif { get; set; }

        public long? IdDossier { get; set; }

        public int? ParDefault { get; set; }

        public string sys_user { get; set; }

        public DateTime? sys_dateUpdate { get; set; }

        public DateTime? sys_dateCreation { get; set; }

       
        public virtual ICollection<CPT_Ecritures> CPT_Ecritures { get; set; }

    
        public virtual ICollection<CPT_Pieces> CPT_Pieces { get; set; }

        public virtual GEN_Dossiers GEN_Dossiers { get; set; }
    }
}
