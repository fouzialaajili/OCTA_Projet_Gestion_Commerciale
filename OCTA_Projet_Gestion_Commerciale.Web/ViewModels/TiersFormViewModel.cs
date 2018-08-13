using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCTA_Projet_Gestion_Commerciale.Web.ViewModels
{
    public class TiersFormViewModel
    {
        public long Id { get; set; }
        public string code { get; set; }

        public long? TypeTiers { get; set; }

        public string RaisonSociale { get; set; }

        public string activite { get; set; }

        public long? FormeJuridique { get; set; }

        public string Adresse { get; set; }

        public string adresseLivraison { get; set; }


        public string Tel { get; set; }


        public string Fax { get; set; }

        public string Email { get; set; }

        public long? Ville { get; set; }

        public string SiteWeb { get; set; }

        public string CapitalSocial { get; set; }

        public long? Pays { get; set; }


        public string IdentifiantFiscale { get; set; }

        public string IdentifiantTVA { get; set; }

        public string ice { get; set; }

        public string Patente { get; set; }

        public long? IdDeviseDefault { get; set; }

        public bool Actif { get; set; }

        public long? IdCompteCollectifClient { get; set; }

        public long? IdCompteCollectifFournisseur { get; set; }

        public long? IdEcheancement { get; set; }

        public long? IdGroupeRemise { get; set; }

        public long? IdGroupeStatistiques { get; set; }

        public long? IdCategorieFiscale { get; set; }

        public long? IdDossier { get; set; }

        public string sys_user { get; set; }

        public DateTime? sys_dateUpdate { get; set; }

        public DateTime? sys_dateCreation { get; set; }
    }
}