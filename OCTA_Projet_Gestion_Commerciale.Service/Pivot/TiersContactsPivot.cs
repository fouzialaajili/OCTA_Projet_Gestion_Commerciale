namespace OCTA_Projet_Gestion_Commerciale.Service.Pivot
{
    using System;
    using System.Collections.Generic;
  

    public partial class TiersContactsPivot
    {
        public long GEN_TiersContactsId { get; set; }


        public string Civilite { get; set; }

        public string Nom { get; set; }

        public string Prenom { get; set; }

  
        public string Tel { get; set; }


        public string Gsm { get; set; }

 
        public string Email { get; set; }

        public bool Actif { get; set; }

        public long? IdTiers { get; set; }

        public int? ParDefault { get; set; }

        public string sys_user { get; set; }

        public DateTime? sys_dateUpdate { get; set; }

        public DateTime? sys_dateCreation { get; set; }

        public TiersPivot GEN_Tiers { get; set; }
        public ICollection<TicketPivot> GES_Ticket { get; set; }
    }
}
