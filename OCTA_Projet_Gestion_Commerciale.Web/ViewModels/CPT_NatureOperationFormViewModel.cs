using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCTA_Projet_Gestion_Commerciale.Web.ViewModels
{
    public class CPT_NatureOperationFormViewModel
    {
        public long Id { get; set; }

        public string NatureOperationNom { get; set; }

        public bool ATraiter { get; set; }

        public bool GenererFactureAchat { get; set; }

        public bool GenererFactureVente { get; set; }

        public bool GenererReglement { get; set; }

        public bool AvecTVA { get; set; }

        public bool AvecTier { get; set; }
        public long? Sens { get; set; }
        public long? Montant { get; set; }

        public bool IsCommission { get; set; }

        public bool AutoriseRegroupement { get; set; }
    }
}