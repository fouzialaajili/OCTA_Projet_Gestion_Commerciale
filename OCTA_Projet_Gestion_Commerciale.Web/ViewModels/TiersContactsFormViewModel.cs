using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCTA_Projet_Gestion_Commerciale.Web.ViewModels
{
    public class TiersContactsFormViewModel
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

        public TiersFormViewModel GEN_Tiers { get; set; }
        public ICollection<TicketFormViewModel> GES_Ticket { get; set; }
    }
}