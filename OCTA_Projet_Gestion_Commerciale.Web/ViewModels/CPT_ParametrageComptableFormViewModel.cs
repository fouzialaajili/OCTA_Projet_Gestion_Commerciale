﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCTA_Projet_Gestion_Commerciale.Web.ViewModels
{
    public class CPT_ParametrageComptableFormViewModel
    {
        public long Id { get; set; }

        public string NumeroPiece { get; set; }

        public long? IdJournalANouveaux { get; set; }

        public long? IdJournalAchatIntegration { get; set; }

        public long? IdJournalVenteIntegration { get; set; }

        public bool ModeBrouillardActive { get; set; }


        public string LibelleEcritureANouveau { get; set; }


        public string LibelleEcriturePiece { get; set; }


        public long? IdCompteBenefice { get; set; }


        public long? IdCompteDeficit { get; set; }


        public long? IdCompteEcartPaiementVente { get; set; }


        public long? IdCompteEcartPaiementAchat { get; set; }

        public long? IdCompteCollectifClient { get; set; }


        public long? IdCompteCollectifFournisseur { get; set; }


        public long? IdCompteEcartPerte { get; set; }


        public long? IdCompteEcartGain { get; set; }

        public long? IdJournalBanque { get; set; }

        public long? IdDossier { get; set; }

        public bool InterdirLaGenFact { get; set; }

        public string sys_user { get; set; }

        public DateTime? sys_dateUpdate { get; set; }

        public DateTime? sys_dateCreation { get; set; }
        public CPT_CompteGFormViewModel CPT_CompteG { get; set; }

        public CPT_CompteGFormViewModel CPT_CompteG_CompteDeficit { get; set; }

        public CPT_JournauxFormViewModel CPT_Journaux { get; set; }

        public GEN_Dossiers_Form_ViewModel GEN_Dossiers { get; set; }
    }
}
