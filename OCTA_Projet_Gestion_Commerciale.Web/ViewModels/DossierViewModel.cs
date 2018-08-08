using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCTA_Projet_Gestion_Commerciale.Web.ViewModels
{
    public class DossierViewModel
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

        // public virtual GEN_Societes GEN_Societes { get; set; }



        /*****************/

        public  ICollection<CPT_ClasseViewModel> CPT_Classe { get; set; }
        public  ICollection<ModelViewModel> GEN_Model { get; set; }
        public  ICollection<CPT_CodesTVAViewModel> CPT_CodesTVA { get; set; }
        public  ICollection<CPT_CompteGViewModel> CPT_CompteG { get; set; }
        public  ICollection<CPT_ComptesBancairesViewModel> CPT_ComptesBancaires { get; set; }
        public  ICollection<CPT_JournauxViewModel> CPT_Journaux { get; set; }
        public  ICollection<CPT_ParametrageComptableViewModel> CPT_ParametrageComptable { get; set; }
        public  ICollection<CPT_PiecesViewModel> CPT_Pieces { get; set; }
        public  ICollection<DocumentsViewModel> GEN_Documents { get; set; }
        public  ICollection<DossierContactsViewModel> GEN_DossiersContacts { get; set; }
        public  ICollection<DossiersSitesViewModel> GEN_DossiersSites { get; set; }
        public  ICollection<ExercicesViewModel> GEN_Exercices { get; set; }
        public  ICollection<NumerationsViewModel> GEN_Numeration { get; set; }
        public  ICollection<NumerotationViewModel> GES_Numerotation { get; set; }
        public  ICollection<PreferencesViewModel> GEN_Preferences { get; set; }
        public  ICollection<TiersViewModel> GEN_Tiers { get; set; }
        public  ICollection<TypePaiementViewModel> GEN_TypePaiement { get; set; }
        public  ICollection<MotifViewModel> GES_Motif { get; set; }
        public  ICollection<MotifTicketsViewModel> GES_MotifTicket { get; set; }
        public  ICollection<MouvementStockViewModel> GES_MouvementStock { get; set; }
        public  ICollection<ObjectifViewModel> GES_Objectif { get; set; }
        public  ICollection<OpportuniteViewModel> GES_Opportunite { get; set; }
        public  ICollection<ArticlesViewModel> SocieteArticle { get; set; }
        public  ICollection<AffaireViewModel> SocieteAffaire { get; set; }
        public  ICollection<CategorieViewModel> SocieteCategorie { get; set; }
        public  ICollection<DepotViewModel> SocieteDepot { get; set; }

        public  ICollection<DoclieViewModel> SocieteDoclie { get; set; }
        public  ICollection<DoclieartViewModel> SocieteDoclieart { get; set; }
        public  ICollection<DocumentCommercialViewModel> SocieteDocumentCommercial { get; set; }
        public  ICollection<DocumentCommercialDetailSerieViewModel> SocieteDocumentCommercialDetailSerie { get; set; }
        public  ICollection<FamilleViewModel> SocieteFamille { get; set; }
        public  ICollection<ImpressionViewModel> SocieteImpression { get; set; }
        public  ICollection<MarqueViewModel> SocieteMarque { get; set; }
        public  ICollection<ToleranceViewModel> SocieteTolerance { get; set; }
        public  ICollection<UniteViewModel> SocieteUnite { get; set; }
        public  ICollection<GES_PeriodeViewModel> GES_Periode { get; set; }
        public  ICollection<ReglementViewModel> GES_Reglement { get; set; }
        public  ICollection<RepresentantViewModel> GES_Representant { get; set; }
        public  ICollection<TicketViewModel> GES_Ticket { get; set; }
        public  ICollection<CPT_CodesTVAViewModel> SocieteTVA { get; set; }
        public  ICollection<DevisesViewModel> GEN_Devises { get; set; }

    }
}