namespace Store.Model
{
    using System;
    using System.Collections.Generic;


    public partial class CPT_ComptesBancairesTiers
    {
        public long Id { get; set; }

        public string NomAgence { get; set; }
        public string Adresse { get; set; }

        public string Contact { get; set; }


        public string Tel { get; set; }


        public string RIB { get; set; }

        public long? IdDevise { get; set; }

        public bool? Actif { get; set; }

        public int? ParDefault { get; set; }

        public long? IdTiers { get; set; }

        public string sys_user { get; set; }

        public DateTime? sys_dateUpdate { get; set; }

        public DateTime? sys_dateCreation { get; set; }

        public virtual GEN_Devises GEN_Devises { get; set; }

        public virtual GEN_Tiers GEN_Tiers { get; set; }
    }
}
