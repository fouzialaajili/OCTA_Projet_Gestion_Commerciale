using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCTA_Projet_Gestion_Commerciale.Web.ViewModels
{
    public class ReglementFormViewModel
    {
        public long Id { get; set; }

        public DateTime? DateReglement { get; set; }

        public string NumPiece { get; set; }

        public long? IdJournal { get; set; }

        public long? IdModePaiement { get; set; }

        public string Libelle { get; set; }

        public double? Montant { get; set; }

        public double? Solde { get; set; }

        public string Liaison { get; set; }

        public CPT_JournauxFormViewModel CPT_Journaux { get; set; }

        public TypePaiementFormViewModel GEN_TypePaiement { get; set; }

    }
}