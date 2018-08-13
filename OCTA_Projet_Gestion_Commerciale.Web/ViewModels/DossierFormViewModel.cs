using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCTA_Projet_Gestion_Commerciale.Web.ViewModels
{
    public class DossierFormViewModel
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

        /*****************/

      //  public virtual GEN_Societes GEN_Societes { get; set; }
        //public  ICollection<CPT_ClasseFormViewModel> CPT_Classe { get; set; }
        //public  ICollection<ModelFormViewModel> GEN_Model { get; set; }
        //public  ICollection<CPT_CodesTVAFormViewModel> CPT_CodesTVA { get; set; }
        //public  ICollection<CPT_CompteGFormViewModel> CPT_CompteG { get; set; }
        //public  ICollection<CPT_ComptesBancairesFormViewModel> CPT_ComptesBancaires { get; set; }
        //public  ICollection<CPT_JournauxFormViewModel> CPT_Journaux { get; set; }
        //public  ICollection<CPT_ParametrageComptableFormViewModel> CPT_ParametrageComptable { get; set; }
        //public  ICollection<CPT_PiecesFormViewModel> CPT_Pieces { get; set; }
        //public  ICollection<DocumentsFormViewModel> GEN_Documents { get; set; }
        //public  ICollection<DossierContactsFromViewModel> GEN_DossiersContacts { get; set; }
        //public  ICollection<DossiersSitesFromViewModel> GEN_DossiersSites { get; set; }
        //public  ICollection<ExercicesFromViewModel> GEN_Exercices { get; set; }
        //public  ICollection<NumerationsFormViewModel> GEN_Numeration { get; set; }
        //public  ICollection<NumerotationFormViewModel> GES_Numerotation { get; set; }
        //public  ICollection<PreferencesFormViewModel> GEN_Preferences { get; set; }
        //public  ICollection<TiersFormViewModel> GEN_Tiers { get; set; }
        //public  ICollection<TypePaiementFormViewModel> GEN_TypePaiement { get; set; }
        //public  ICollection<MotifFormViewModel> GES_Motif { get; set; }
        //public  ICollection<MotifTicketsFormViewModel> GES_MotifTicket { get; set; }
        //public  ICollection<MouvementStockFormViewModel> GES_MouvementStock { get; set; }
        //public  ICollection<ObjectifFormViewModel> GES_Objectif { get; set; }
        //public  ICollection<OpportuniteFormViewModel> GES_Opportunite { get; set; }
        //public  ICollection<ArticlesFormViewModel> SocieteArticle { get; set; }
        //public  ICollection<AffaireFormViewModel> SocieteAffaire { get; set; }
        //public  ICollection<CategorieFormViewModel> SocieteCategorie { get; set; }
        //public  ICollection<DepotFormViewModel> SocieteDepot { get; set; }

        //public  ICollection<DoclieFormViewModel> SocieteDoclie { get; set; }
        //public  ICollection<DoclieartFormViewModel> SocieteDoclieart { get; set; }
        //public  ICollection<DocummentCommercialFormViewModel> SocieteDocumentCommercial { get; set; }
        //public  ICollection<DocumentCommercialDetailSerieFormViewModel> SocieteDocumentCommercialDetailSerie { get; set; }
        //public  ICollection<FamilleFormViewModel> SocieteFamille { get; set; }
        //public  ICollection<ImpressionFromViewModel> SocieteImpression { get; set; }
        //public  ICollection<MarqueFormViewModel> SocieteMarque { get; set; }
        //public  ICollection<ToleranceFormViewModel> SocieteTolerance { get; set; }
        //public  ICollection<UniteFormViewModel> SocieteUnite { get; set; }
        //public  ICollection<GES_PeriodeFormViewModel> GES_Periode { get; set; }
        //public  ICollection<ReglementFormViewModel> GES_Reglement { get; set; }
        //public  ICollection<RepresentantFormViewModel> GES_Representant { get; set; }
        //public  ICollection<TicketFormViewModel> GES_Ticket { get; set; }
        //public  ICollection<CPT_CodesTVAFormViewModel> SocieteTVA { get; set; }
        //public  ICollection<DevisesFormViewModel> GEN_Devises { get; set; }
    }
}