using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCTA_Projet_Gestion_Commerciale.Web.ViewModels
{
    public class GEN_Dossiers_Form_ViewModel
    {
        public long DossierId { get; set; }
        public string CodeDossier { get; set; }
        public string DossierRaisonSociale { get; set; }
        public int? IdTypeDossier { get; set; }
        public string DossierAdresse { get; set; }
        public string DossierTel { get; set; }
        public string DossierFax { get; set; }
        public string DossierEmail { get; set; }
        public string DossierVille { get; set; }
        public string DossierPays { get; set; }
        public string DossierSiteWeb { get; set; }
        public string DossierCapitalSocial { get; set; }
        public int? IdDeviseTenueCompte { get; set; }
        public string DossierIdentifiantFiscale { get; set; }
        public string DossierIdentifiantTVA { get; set; }
        public string DossierPatente { get; set; }
        public string DossierRegistreCommerce { get; set; }
        public string DossierNumeroCNSS { get; set; }
        public string DossierICE { get; set; }
        public int? DossierComptaActif { get; set; }
        public int? DossierGescomAtif { get; set; }
        public int? DossierPaieActif { get; set; }
        public bool DossierActif { get; set; }
        public string DossierCleSecuriteCompta { get; set; }
        public string DossierCleSecuritePaie { get; set; }
        public string DossierCleSecuriteGescom { get; set; }
        public string DossierCleSecurite { get; set; }
        public string Dossiersys_user { get; set; }
        public DateTime? Dossiersys_dateUpdate { get; set; }
        public DateTime? Dossiersys_dateCreation { get; set; }

    }
}