using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCTA_Projet_Gestion_Commerciale.Web.ViewModels
{
    public class TypePaiementDetailFormViewModel
    {
        public long TypePaiementDetailId { get; set; }

        public long? IdTypePaiement { get; set; }

        public long? IdModePaiement { get; set; }

        public long? DateCalcul { get; set; }

        public double? Pourcentage { get; set; }

        public int? NombreJour { get; set; }

        public long? Delai { get; set; }

        public string sys_user { get; set; }

        public DateTime? sys_dateUpdate { get; set; }

        public DateTime? sys_dateCreation { get; set; }

    }
}