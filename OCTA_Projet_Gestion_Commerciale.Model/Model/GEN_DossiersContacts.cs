namespace Store.Model
{
    using System;
    using System.Collections.Generic;


    public partial class GEN_DossiersContacts
    {
        public long DossiersContactsId { get; set; }

      
        public string Civilite { get; set; }

        public string Nom { get; set; }

        public string Prenom { get; set; }


        public string Tel { get; set; }

 
        public string Gsm { get; set; }

        public string Email { get; set; }

        public bool Actif { get; set; }

        public long? IdDossier { get; set; }

        public int? ParDefault { get; set; }

        public string sys_user { get; set; }

        public DateTime? sys_dateUpdate { get; set; }

        public DateTime? sys_dateCreation { get; set; }

        public virtual GEN_Dossiers GEN_Dossiers { get; set; }
    }
}
