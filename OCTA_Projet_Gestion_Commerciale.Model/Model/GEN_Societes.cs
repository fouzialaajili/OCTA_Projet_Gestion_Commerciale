namespace OCTA_Projet_Gestion_Commerciale.Model
{
    using System;
    using System.Collections.Generic;
  

    public partial class GEN_Societes
    {
       
        public long Id { get; set; }
        
        public string RaisonSociale { get; set; }

  
        public DateTime? DateCommande { get; set; }
        
        public string NumeroCommande { get; set; }

        public int NombreUser { get; set; }

        public int NombreDossiers { get; set; }

  
        public DateTime DateEcheance { get; set; }

        public int Actif { get; set; }

        public string CleSecurite { get; set; }

        public string sys_user { get; set; }

        public DateTime? sys_dateUpdate { get; set; }

        public DateTime? sys_dateCreation { get; set; }

       
        public virtual ICollection<GEN_Dossiers> GEN_Dossiers { get; set; }

       
        public virtual ICollection<GEN_Model> GEN_Model { get; set; }
    }
}
