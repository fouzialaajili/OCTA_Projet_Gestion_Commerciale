using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Model
{
    public partial class GEN_Dossiers
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




        public virtual ICollection<CPT_Classe> CPT_Classe { get; set; }
        public virtual ICollection<GEN_Model> GEN_Model { get; set; }
        public virtual ICollection<CPT_CodesTVA> CPT_CodesTVA { get; set; }
        public virtual ICollection<CPT_CompteG> CPT_CompteG { get; set; }
        public virtual ICollection<CPT_ComptesBancaires> CPT_ComptesBancaires { get; set; }
        public virtual ICollection<CPT_Journaux> CPT_Journaux { get; set; }
        public virtual ICollection<CPT_ParametrageComptable> CPT_ParametrageComptable { get; set; }
        public virtual ICollection<CPT_Pieces> CPT_Pieces { get; set; }
        public virtual ICollection<GEN_Documents> GEN_Documents { get; set; }
        public virtual ICollection<GEN_DossiersContacts> GEN_DossiersContacts { get; set; }
        public virtual ICollection<GEN_DossiersSites> GEN_DossiersSites { get; set; }
        public virtual ICollection<GEN_Exercices> GEN_Exercices { get; set; }
        public virtual ICollection<GEN_Numeration> GEN_Numeration { get; set; }
        public virtual ICollection<GES_Numerotation> GES_Numerotation { get; set; }
        public virtual ICollection<GEN_Preferences> GEN_Preferences { get; set; }
        public virtual ICollection<GEN_Tiers> GEN_Tiers { get; set; }
        public virtual ICollection<GEN_TypePaiement> GEN_TypePaiement { get; set; }
        public virtual ICollection<GES_Motif> GES_Motif { get; set; }
        public virtual ICollection<GES_MotifTicket> GES_MotifTicket { get; set; }
        public virtual ICollection<GES_MouvementStock> GES_MouvementStock { get; set; }
        public virtual ICollection<GES_Objectif> GES_Objectif { get; set; }
        public virtual ICollection<GES_Opportunite> GES_Opportunite { get; set; }
        public virtual ICollection<GES_Article> SocieteArticle { get; set; }
        public virtual ICollection<GES_Affaire> SocieteAffaire { get; set; }
        public virtual ICollection<GES_Categorie> SocieteCategorie { get; set; }
        public virtual ICollection<GES_Depot> SocieteDepot { get; set; }
    //    public virtual ICollection<GEN_Devises> SocieteDevise { get; set; }
        public virtual ICollection<GES_Doclie> SocieteDoclie { get; set; }
        public virtual ICollection<GES_Doclieart> SocieteDoclieart { get; set; }
        public virtual ICollection<GES_DocumentCommercial> SocieteDocumentCommercial { get; set; }
        public virtual ICollection<GES_DocumentCommercialDetailSerie> SocieteDocumentCommercialDetailSerie { get; set; }
        public virtual ICollection<GES_Famille> SocieteFamille { get; set; }
        public virtual ICollection<GES_Impression> SocieteImpression { get; set; }
        public virtual ICollection<GES_Marque> SocieteMarque { get; set; }
        public virtual ICollection<GES_Tolerance> SocieteTolerance { get; set; }
        public virtual ICollection<GES_Unite> SocieteUnite { get; set; }
        public virtual ICollection<GES_Periode> GES_Periode { get; set; }
        public virtual ICollection<GES_Reglement> GES_Reglement { get; set; }
        public virtual ICollection<GES_Representant> GES_Representant { get; set; }
        public virtual ICollection<GES_Ticket> GES_Ticket { get; set; }
     //   public virtual ICollection<CPT_CodesTVA> SocieteTVA { get; set; }   
        public virtual ICollection<GEN_Devises> GEN_Devises { get; set; }
        
    }
}
