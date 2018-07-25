namespace OCTA_Projet_Gestion_Commerciale.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Affaire",
                c => new
                    {
                        AffaireId = c.Long(nullable: false, identity: true),
                        AffaireCode = c.String(),
                        AffaireLibelle = c.String(),
                        AffaireSysuser = c.Int(nullable: false),
                        AffaireSysDateCreation = c.DateTime(nullable: false),
                        AffaireSysDateUpdate = c.DateTime(nullable: false),
                        AffaireSocieteId = c.Long(),
                    })
                .PrimaryKey(t => t.AffaireId)
                .ForeignKey("dbo.GEN_Dossier", t => t.AffaireSocieteId)
                .Index(t => t.AffaireSocieteId);
            
            CreateTable(
                "dbo.GEN_Dossier",
                c => new
                    {
                        DossierId = c.Long(nullable: false, identity: true),
                        CodeDossier = c.String(),
                        DossierRaisonSociale = c.String(),
                        IdTypeDossier = c.Int(),
                        DossierAdresse = c.String(),
                        DossierTel = c.String(),
                        DossierFax = c.String(),
                        DossierEmail = c.String(),
                        DossierVille = c.String(),
                        DossierPays = c.String(),
                        DossierSiteWeb = c.String(),
                        DossierCapitalSocial = c.String(),
                        IdDeviseTenueCompte = c.Int(),
                        DossierIdentifiantFiscale = c.String(),
                        DossierIdentifiantTVA = c.String(),
                        DossierPatente = c.String(),
                        DossierRegistreCommerce = c.String(),
                        DossierNumeroCNSS = c.String(),
                        DossierICE = c.String(),
                        DossierComptaActif = c.Int(),
                        DossierGescomAtif = c.Int(),
                        DossierPaieActif = c.Int(),
                        DossierActif = c.Boolean(nullable: false),
                        DossierCleSecuriteCompta = c.String(),
                        DossierCleSecuritePaie = c.String(),
                        DossierCleSecuriteGescom = c.String(),
                        DossierCleSecurite = c.String(),
                        Dossiersys_user = c.String(),
                        Dossiersys_dateUpdate = c.DateTime(),
                        Dossiersys_dateCreation = c.DateTime(),
                    })
                .PrimaryKey(t => t.DossierId);
            
            CreateTable(
                "dbo.CPT_Classe",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CodeClasse = c.String(),
                        Libelle = c.String(),
                        IdClasse = c.Long(),
                        IdDossier = c.Long(),
                        sys_user = c.String(),
                        Sys_dateUpdate = c.DateTime(),
                        Sys_dateCreation = c.DateTime(),
                        CPT_Classe_Parent_Id = c.Long(),
                        GEN_Dossiers_DossierId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CPT_Classe", t => t.CPT_Classe_Parent_Id)
                .ForeignKey("dbo.GEN_Dossier", t => t.GEN_Dossiers_DossierId)
                .Index(t => t.CPT_Classe_Parent_Id)
                .Index(t => t.GEN_Dossiers_DossierId);
            
            CreateTable(
                "dbo.CPT_CompteG",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Code = c.String(),
                        Libelle = c.String(),
                        IdClasse = c.Long(),
                        IdTypeCompte = c.Long(),
                        IdNatureCompte = c.Long(),
                        IdCodeTvaDefault = c.Long(),
                        Ana = c.Boolean(nullable: false),
                        Rappro = c.Boolean(nullable: false),
                        Lettrage = c.Boolean(nullable: false),
                        Pointage = c.Boolean(nullable: false),
                        Sens = c.Long(),
                        Actif = c.Boolean(nullable: false),
                        SuiviCompteTVA = c.Long(),
                        ReportANouveau = c.Long(),
                        IdDossier = c.Long(),
                        sys_user = c.String(),
                        sys_dateUpdate = c.DateTime(),
                        sys_dateCreation = c.DateTime(),
                        CPT_Classe_Id = c.Long(),
                        CPT_CodesTVA_Id = c.Long(),
                        CPT_CodesTVA_CodeTVADefault_Id = c.Long(),
                        GEN_Dossiers_DossierId = c.Long(),
                        GEN_Items_NatureCompte_Id = c.Long(),
                        GEN_Items_ReportANouveau_Id = c.Long(),
                        GEN_Items_Sens_Id = c.Long(),
                        GEN_Items_SuiviCompteTVA_Id = c.Long(),
                        GEN_Items_TypeCompte_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CPT_Classe", t => t.CPT_Classe_Id)
                .ForeignKey("dbo.Dossier", t => t.CPT_CodesTVA_Id)
                .ForeignKey("dbo.Dossier", t => t.CPT_CodesTVA_CodeTVADefault_Id)
                .ForeignKey("dbo.GEN_Dossier", t => t.GEN_Dossiers_DossierId)
                .ForeignKey("dbo.GEN_Items", t => t.GEN_Items_NatureCompte_Id)
                .ForeignKey("dbo.GEN_Items", t => t.GEN_Items_ReportANouveau_Id)
                .ForeignKey("dbo.GEN_Items", t => t.GEN_Items_Sens_Id)
                .ForeignKey("dbo.GEN_Items", t => t.GEN_Items_SuiviCompteTVA_Id)
                .ForeignKey("dbo.GEN_Items", t => t.GEN_Items_TypeCompte_Id)
                .Index(t => t.CPT_Classe_Id)
                .Index(t => t.CPT_CodesTVA_Id)
                .Index(t => t.CPT_CodesTVA_CodeTVADefault_Id)
                .Index(t => t.GEN_Dossiers_DossierId)
                .Index(t => t.GEN_Items_NatureCompte_Id)
                .Index(t => t.GEN_Items_ReportANouveau_Id)
                .Index(t => t.GEN_Items_Sens_Id)
                .Index(t => t.GEN_Items_SuiviCompteTVA_Id)
                .Index(t => t.GEN_Items_TypeCompte_Id);
            
            CreateTable(
                "dbo.Dossier",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CodeTaux = c.String(),
                        LibelleTaux = c.String(),
                        TypeTVA = c.Long(),
                        Percue = c.Int(),
                        Exonere = c.Int(),
                        TauxTVA = c.Double(),
                        IdCompteTVA = c.Long(),
                        IdRubriqueDeclaration = c.Long(),
                        Actif = c.Boolean(nullable: false),
                        IdDossier = c.Long(),
                        sys_user = c.String(),
                        sys_dateUpdate = c.DateTime(),
                        sys_dateCreation = c.DateTime(),
                        CPT_CompteG_Id = c.Long(),
                        GEN_Items_RebriqueDeclaration_Id = c.Long(),
                        GEN_Items_TypeTVA_Id = c.Long(),
                        CPT_CompteG_Id1 = c.Long(),
                        GEN_Dossiers_DossierId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CPT_CompteG", t => t.CPT_CompteG_Id)
                .ForeignKey("dbo.GEN_Dossier", t => t.IdDossier)
                .ForeignKey("dbo.GEN_Items", t => t.GEN_Items_RebriqueDeclaration_Id)
                .ForeignKey("dbo.GEN_Items", t => t.GEN_Items_TypeTVA_Id)
                .ForeignKey("dbo.CPT_CompteG", t => t.CPT_CompteG_Id1)
                .ForeignKey("dbo.GEN_Dossier", t => t.GEN_Dossiers_DossierId)
                .Index(t => t.IdDossier)
                .Index(t => t.CPT_CompteG_Id)
                .Index(t => t.GEN_Items_RebriqueDeclaration_Id)
                .Index(t => t.GEN_Items_TypeTVA_Id)
                .Index(t => t.CPT_CompteG_Id1)
                .Index(t => t.GEN_Dossiers_DossierId);
            
            CreateTable(
                "dbo.CPT_CompteGDetailTVA",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        IdCodeTVA = c.Long(),
                        IdCompteGenerale = c.Long(),
                        TauxTva = c.Double(),
                        Percue = c.Int(),
                        Exonere = c.Int(),
                        IdCompteG = c.Long(),
                        sys_user = c.String(),
                        sys_dateUpdate = c.DateTime(),
                        sys_dateCreation = c.DateTime(),
                        CPT_CodesTVA_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Dossier", t => t.CPT_CodesTVA_Id)
                .Index(t => t.CPT_CodesTVA_Id);
            
            CreateTable(
                "dbo.GEN_Items",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        IdModel = c.Long(),
                        Libelle = c.String(),
                        Valeur = c.String(),
                        Ordre = c.Int(),
                        GEN_Model_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GEN_Model", t => t.GEN_Model_Id)
                .Index(t => t.GEN_Model_Id);
            
            CreateTable(
                "dbo.GEN_Tier",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        code = c.String(),
                        TypeTiers = c.Long(),
                        RaisonSociale = c.String(),
                        activite = c.String(),
                        FormeJuridique = c.Long(),
                        Adresse = c.String(),
                        adresseLivraison = c.String(),
                        Tel = c.String(),
                        Fax = c.String(),
                        Email = c.String(),
                        Ville = c.Long(),
                        SiteWeb = c.String(),
                        CapitalSocial = c.String(),
                        Pays = c.Long(),
                        IdentifiantFiscale = c.String(),
                        IdentifiantTVA = c.String(),
                        ice = c.String(),
                        Patente = c.String(),
                        IdDeviseDefault = c.Long(),
                        Actif = c.Boolean(nullable: false),
                        IdCompteCollectifClient = c.Long(),
                        IdCompteCollectifFournisseur = c.Long(),
                        IdEcheancement = c.Long(),
                        IdGroupeRemise = c.Long(),
                        IdGroupeStatistiques = c.Long(),
                        IdCategorieFiscale = c.Long(),
                        IdDossier = c.Long(),
                        sys_user = c.String(),
                        sys_dateUpdate = c.DateTime(),
                        sys_dateCreation = c.DateTime(),
                        TvaSocieteId = c.Long(nullable: false),
                        GEN_Items_CategorieFiscale_Id = c.Long(),
                        GEN_Items_FormeJuridique_Id = c.Long(),
                        GEN_Items_TypeTiers_Id = c.Long(),
                        GES_Representant_RepresentantId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CPT_CompteG", t => t.IdCompteCollectifClient)
                .ForeignKey("dbo.CPT_CompteG", t => t.IdCompteCollectifFournisseur)
                .ForeignKey("dbo.Devise", t => t.IdDeviseDefault)
                .ForeignKey("dbo.GEN_Dossier", t => t.IdDossier)
                .ForeignKey("dbo.GEN_Items", t => t.GEN_Items_CategorieFiscale_Id)
                .ForeignKey("dbo.GEN_Items", t => t.GEN_Items_FormeJuridique_Id)
                .ForeignKey("dbo.GEN_Items", t => t.GEN_Items_TypeTiers_Id)
                .ForeignKey("dbo.Representant", t => t.GES_Representant_RepresentantId)
                .ForeignKey("dbo.TypePaiement", t => t.TypeTiers)
                .ForeignKey("dbo.Dossier", t => t.TvaSocieteId, cascadeDelete: true)
                .Index(t => t.TypeTiers)
                .Index(t => t.IdDeviseDefault)
                .Index(t => t.IdCompteCollectifClient)
                .Index(t => t.IdCompteCollectifFournisseur)
                .Index(t => t.IdDossier)
                .Index(t => t.TvaSocieteId)
                .Index(t => t.GEN_Items_CategorieFiscale_Id)
                .Index(t => t.GEN_Items_FormeJuridique_Id)
                .Index(t => t.GEN_Items_TypeTiers_Id)
                .Index(t => t.GES_Representant_RepresentantId);
            
            CreateTable(
                "dbo.CPT_ComptesBancairesTiers",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        NomAgence = c.String(),
                        Adresse = c.String(),
                        Contact = c.String(),
                        Tel = c.String(),
                        RIB = c.String(),
                        IdDevise = c.Long(),
                        Actif = c.Boolean(),
                        ParDefault = c.Int(),
                        IdTiers = c.Long(),
                        sys_user = c.String(),
                        sys_dateUpdate = c.DateTime(),
                        sys_dateCreation = c.DateTime(),
                        GEN_Devises_DevisesId = c.Long(),
                        GEN_Tiers_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Devise", t => t.GEN_Devises_DevisesId)
                .ForeignKey("dbo.GEN_Tier", t => t.GEN_Tiers_Id)
                .Index(t => t.GEN_Devises_DevisesId)
                .Index(t => t.GEN_Tiers_Id);
            
            CreateTable(
                "dbo.Devise",
                c => new
                    {
                        DevisesId = c.Long(nullable: false, identity: true),
                        DevisesCode = c.String(),
                        DevisesCodeIso = c.String(),
                        DevisesSymbole = c.String(),
                        DevisesDescription = c.String(),
                        DevisesCoursDevise = c.Double(),
                        DevisesTenueDeCompte = c.Int(),
                        DevisesActif = c.Boolean(nullable: false),
                        DevisesIdDossier = c.Long(),
                        Devisessys_user = c.String(),
                        Devisessys_dateUpdate = c.DateTime(),
                        Devisessys_dateCreation = c.DateTime(),
                        GEN_Dossiers_DossierId = c.Long(),
                    })
                .PrimaryKey(t => t.DevisesId)
                .ForeignKey("dbo.GEN_Dossier", t => t.DevisesIdDossier)
                .ForeignKey("dbo.GEN_Dossier", t => t.GEN_Dossiers_DossierId)
                .Index(t => t.DevisesIdDossier)
                .Index(t => t.GEN_Dossiers_DossierId);
            
            CreateTable(
                "dbo.CPT_ComptesBancaires",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        IdBanque = c.Long(),
                        NomAgence = c.String(),
                        Adresse = c.String(),
                        Contact = c.String(),
                        Tel = c.String(),
                        RIB = c.String(),
                        IdDevise = c.Long(),
                        Actif = c.Boolean(nullable: false),
                        ParDefault = c.Boolean(nullable: false),
                        IdDossier = c.Long(),
                        sys_user = c.String(),
                        sys_dateUpdate = c.DateTime(),
                        sys_dateCreation = c.DateTime(),
                        IdCompteG = c.Long(),
                        CPT_CompteG_Id = c.Long(),
                        GEN_Devises_DevisesId = c.Long(),
                        GEN_Dossiers_DossierId = c.Long(),
                        GEN_Items_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CPT_CompteG", t => t.CPT_CompteG_Id)
                .ForeignKey("dbo.Devise", t => t.GEN_Devises_DevisesId)
                .ForeignKey("dbo.GEN_Dossier", t => t.GEN_Dossiers_DossierId)
                .ForeignKey("dbo.GEN_Items", t => t.GEN_Items_Id)
                .Index(t => t.CPT_CompteG_Id)
                .Index(t => t.GEN_Devises_DevisesId)
                .Index(t => t.GEN_Dossiers_DossierId)
                .Index(t => t.GEN_Items_Id);
            
            CreateTable(
                "dbo.CPT_RelevesBancaires",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        DateIntegration = c.DateTime(),
                        IdCompteBancaire = c.Long(),
                        Description = c.String(),
                        IdDevise = c.Long(),
                        SoldeDebut = c.Double(),
                        SoldeFin = c.Double(),
                        Valide = c.Boolean(nullable: false),
                        IdDossier = c.Long(),
                        sys_user = c.String(),
                        sys_dateUpdate = c.DateTime(),
                        sys_dateCreation = c.DateTime(),
                        Fichier = c.Binary(),
                        CPT_ComptesBancaires_Id = c.Long(),
                        GEN_Devises_DevisesId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CPT_ComptesBancaires", t => t.CPT_ComptesBancaires_Id)
                .ForeignKey("dbo.Devise", t => t.GEN_Devises_DevisesId)
                .Index(t => t.CPT_ComptesBancaires_Id)
                .Index(t => t.GEN_Devises_DevisesId);
            
            CreateTable(
                "dbo.CPT_RelevesBancairesDetail",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        IdReleveBancaire = c.Long(),
                        DateOperation = c.DateTime(),
                        DateValeur = c.DateTime(),
                        Reference = c.String(),
                        CIB = c.String(),
                        CPB = c.String(),
                        Designation = c.String(),
                        Debit = c.Double(),
                        Credit = c.Double(),
                        Rappro = c.Long(),
                        DateRapprochement = c.DateTime(),
                        sys_user = c.String(),
                        sys_dateUpdate = c.DateTime(),
                        sys_dateCreation = c.DateTime(),
                        TypeOperation = c.Long(),
                        IdTier = c.Long(),
                        IdTypePaiement = c.Long(),
                        NumFacture = c.String(),
                        IdNatureOperation1 = c.Long(),
                        IdCodeTVA1 = c.Long(),
                        DatePaiement = c.DateTime(),
                        IdPieceReglement = c.Long(),
                        IdPieceFacture = c.Long(),
                        IdJournalReglement = c.Long(),
                        IdQua = c.Long(),
                        CPT_CompteG_Id = c.Long(),
                        CPT_RelevesBancaires_Id = c.Long(),
                        GEN_Items_Id = c.Long(),
                        GEN_Tiers_Id = c.Long(),
                        GEN_TypePaiement_TypePaiementId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CPT_CompteG", t => t.CPT_CompteG_Id)
                .ForeignKey("dbo.CPT_RelevesBancaires", t => t.CPT_RelevesBancaires_Id)
                .ForeignKey("dbo.GEN_Items", t => t.GEN_Items_Id)
                .ForeignKey("dbo.GEN_Tier", t => t.GEN_Tiers_Id)
                .ForeignKey("dbo.TypePaiement", t => t.GEN_TypePaiement_TypePaiementId)
                .Index(t => t.CPT_CompteG_Id)
                .Index(t => t.CPT_RelevesBancaires_Id)
                .Index(t => t.GEN_Items_Id)
                .Index(t => t.GEN_Tiers_Id)
                .Index(t => t.GEN_TypePaiement_TypePaiementId);
            
            CreateTable(
                "dbo.TypePaiement",
                c => new
                    {
                        TypePaiementId = c.Long(nullable: false, identity: true),
                        Libelle = c.String(),
                        Actif = c.Boolean(nullable: false),
                        IdDossier = c.Long(),
                    })
                .PrimaryKey(t => t.TypePaiementId)
                .ForeignKey("dbo.GEN_Dossier", t => t.IdDossier)
                .Index(t => t.IdDossier);
            
            CreateTable(
                "dbo.GEN_Regelement",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        DateReglement = c.DateTime(),
                        NumPiece = c.String(),
                        IdJournal = c.Long(),
                        IdModePaiement = c.Long(),
                        Libelle = c.String(),
                        Montant = c.Double(),
                        Solde = c.Double(),
                        Liaison = c.String(),
                        CPT_Journaux_Id = c.Long(),
                        GEN_TypePaiement_TypePaiementId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CPT_Journaux", t => t.CPT_Journaux_Id)
                .ForeignKey("dbo.TypePaiement", t => t.GEN_TypePaiement_TypePaiementId)
                .Index(t => t.CPT_Journaux_Id)
                .Index(t => t.GEN_TypePaiement_TypePaiementId);
            
            CreateTable(
                "dbo.CPT_Journaux",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CodeJournal = c.String(),
                        Libelle = c.String(),
                        TypeJournal = c.Long(),
                        IdCompteContrepartie = c.Long(),
                        IdDossier = c.Long(),
                        IdDevise = c.Long(),
                        Actif = c.Boolean(nullable: false),
                        sys_user = c.String(),
                        sys_DateUpdate = c.DateTime(),
                        sys_DateCreation = c.DateTime(),
                        CPT_CompteG_Id = c.Long(),
                        GEN_Devises_DevisesId = c.Long(),
                        GEN_Dossiers_DossierId = c.Long(),
                        GEN_Items_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CPT_CompteG", t => t.CPT_CompteG_Id)
                .ForeignKey("dbo.Devise", t => t.GEN_Devises_DevisesId)
                .ForeignKey("dbo.GEN_Dossier", t => t.GEN_Dossiers_DossierId)
                .ForeignKey("dbo.GEN_Items", t => t.GEN_Items_Id)
                .Index(t => t.CPT_CompteG_Id)
                .Index(t => t.GEN_Devises_DevisesId)
                .Index(t => t.GEN_Dossiers_DossierId)
                .Index(t => t.GEN_Items_Id);
            
            CreateTable(
                "dbo.CPT_ParametrageComptable",
                c => new
                    {
                        CPT_ParametrageComptableId = c.Long(nullable: false, identity: true),
                        NumeroPiece = c.String(),
                        IdJournalANouveaux = c.Long(),
                        IdJournalAchatIntegration = c.Long(),
                        IdJournalVenteIntegration = c.Long(),
                        ModeBrouillardActive = c.Boolean(nullable: false),
                        LibelleEcritureANouveau = c.String(),
                        LibelleEcriturePiece = c.String(),
                        IdCompteBenefice = c.Long(),
                        IdCompteDeficit = c.Long(),
                        IdCompteEcartPaiementVente = c.Long(),
                        IdCompteEcartPaiementAchat = c.Long(),
                        IdCompteCollectifClient = c.Long(),
                        IdCompteCollectifFournisseur = c.Long(),
                        IdCompteEcartPerte = c.Long(),
                        IdCompteEcartGain = c.Long(),
                        IdJournalBanque = c.Long(),
                        IdDossier = c.Long(),
                        InterdirLaGenFact = c.Boolean(nullable: false),
                        sys_user = c.String(),
                        sys_dateUpdate = c.DateTime(),
                        sys_dateCreation = c.DateTime(),
                    })
                .PrimaryKey(t => t.CPT_ParametrageComptableId)
                .ForeignKey("dbo.CPT_CompteG", t => t.IdCompteBenefice)
                .ForeignKey("dbo.CPT_CompteG", t => t.IdCompteDeficit)
                .ForeignKey("dbo.CPT_Journaux", t => t.IdJournalANouveaux)
                .ForeignKey("dbo.GEN_Dossier", t => t.IdDossier)
                .Index(t => t.IdJournalANouveaux)
                .Index(t => t.IdCompteBenefice)
                .Index(t => t.IdCompteDeficit)
                .Index(t => t.IdDossier);
            
            CreateTable(
                "dbo.CPT_Pieces",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TypePiece = c.Long(),
                        OriginePiece = c.String(),
                        DatePiece = c.DateTime(),
                        DateReference = c.DateTime(),
                        DateFacture = c.DateTime(),
                        RefPiece = c.String(),
                        IdTiers = c.Long(),
                        IdJournal = c.Long(),
                        NumPiece = c.String(),
                        Libelle = c.String(),
                        CourChange = c.Double(),
                        IdDeviseTC = c.Long(),
                        IdDeviseTR = c.Long(),
                        IdDossier = c.Long(),
                        IdDossierSite = c.Long(),
                        Brouillon = c.Int(),
                        sys_user = c.String(),
                        sys_dateUpdate = c.DateTime(),
                        sys_dateCreation = c.DateTime(),
                        GEN_DossiersSites_Id = c.Long(),
                        CPT_Journaux_Id = c.Long(),
                        GEN_DevisesTC_DevisesId = c.Long(),
                        GEN_DevisesTR_DevisesId = c.Long(),
                        GEN_Dossiers_DossierId = c.Long(),
                        GEN_Tiers_Id = c.Long(),
                        GEN_Devises_DevisesId = c.Long(),
                        GEN_Devises_DevisesId1 = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GEN_DossiersSites", t => t.GEN_DossiersSites_Id)
                .ForeignKey("dbo.CPT_Journaux", t => t.CPT_Journaux_Id)
                .ForeignKey("dbo.Devise", t => t.GEN_DevisesTC_DevisesId)
                .ForeignKey("dbo.Devise", t => t.GEN_DevisesTR_DevisesId)
                .ForeignKey("dbo.GEN_Dossier", t => t.GEN_Dossiers_DossierId)
                .ForeignKey("dbo.GEN_Tier", t => t.GEN_Tiers_Id)
                .ForeignKey("dbo.Devise", t => t.GEN_Devises_DevisesId)
                .ForeignKey("dbo.Devise", t => t.GEN_Devises_DevisesId1)
                .Index(t => t.GEN_DossiersSites_Id)
                .Index(t => t.CPT_Journaux_Id)
                .Index(t => t.GEN_DevisesTC_DevisesId)
                .Index(t => t.GEN_DevisesTR_DevisesId)
                .Index(t => t.GEN_Dossiers_DossierId)
                .Index(t => t.GEN_Tiers_Id)
                .Index(t => t.GEN_Devises_DevisesId)
                .Index(t => t.GEN_Devises_DevisesId1);
            
            CreateTable(
                "dbo.CPT_Ecritures",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        IdPiece = c.Long(),
                        DateEcriture = c.DateTime(),
                        IdCompteG = c.Long(),
                        LibelleEcriture = c.String(),
                        Reference = c.String(),
                        IdTauxTVA = c.Long(),
                        Taux = c.Double(),
                        IdDeviceTC = c.Long(),
                        DebitTC = c.Double(),
                        CreditTC = c.Double(),
                        IdDeviceTR = c.Long(),
                        DebitTR = c.Double(),
                        CreditTR = c.Double(),
                        IdTiers = c.Long(),
                        IdSectionANA = c.Long(),
                        IdSectionBUD = c.Long(),
                        IdTypePaiement = c.Long(),
                        CodePointage = c.String(),
                        IdentifiantUniqueLettrage = c.Int(),
                        Rapprochement = c.Long(),
                        NumOrdre = c.Int(),
                        IdDossier = c.Long(),
                        IdDossierSite = c.Long(),
                        sys_user = c.String(),
                        sys_dateUpdate = c.DateTime(),
                        sys_dateCreation = c.DateTime(),
                        CPT_CompteG_Id = c.Long(),
                        CPT_Pieces_Id = c.Long(),
                        GEN_Devises_TC_DevisesId = c.Long(),
                        GEN_Devises_TR_DevisesId = c.Long(),
                        GEN_DossiersSites_Id = c.Long(),
                        GEN_Tiers_Id = c.Long(),
                        GEN_Devises_DevisesId = c.Long(),
                        GEN_Devises_DevisesId1 = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CPT_CompteG", t => t.CPT_CompteG_Id)
                .ForeignKey("dbo.CPT_Pieces", t => t.CPT_Pieces_Id)
                .ForeignKey("dbo.Devise", t => t.GEN_Devises_TC_DevisesId)
                .ForeignKey("dbo.Devise", t => t.GEN_Devises_TR_DevisesId)
                .ForeignKey("dbo.GEN_DossiersSites", t => t.GEN_DossiersSites_Id)
                .ForeignKey("dbo.GEN_Tier", t => t.GEN_Tiers_Id)
                .ForeignKey("dbo.Devise", t => t.GEN_Devises_DevisesId)
                .ForeignKey("dbo.Devise", t => t.GEN_Devises_DevisesId1)
                .Index(t => t.CPT_CompteG_Id)
                .Index(t => t.CPT_Pieces_Id)
                .Index(t => t.GEN_Devises_TC_DevisesId)
                .Index(t => t.GEN_Devises_TR_DevisesId)
                .Index(t => t.GEN_DossiersSites_Id)
                .Index(t => t.GEN_Tiers_Id)
                .Index(t => t.GEN_Devises_DevisesId)
                .Index(t => t.GEN_Devises_DevisesId1);
            
            CreateTable(
                "dbo.CPT_Echeances",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        IdEcriture = c.Long(),
                        IdTypePaiement = c.Long(),
                        IdModePaiement = c.Long(),
                        DateEcheance = c.DateTime(),
                        Pourcentage = c.Double(),
                        MontantTC = c.Double(),
                        IdDeviseTC = c.Long(),
                        MontantTR = c.Double(),
                        IdDeviseTR = c.Long(),
                        Statut = c.Int(),
                        IdDossier = c.Long(),
                        IdDossierSite = c.Long(),
                        sys_user = c.String(),
                        sys_dateUpdate = c.DateTime(),
                        sys_dateCreation = c.DateTime(),
                        CPT_Ecritures_Id = c.Long(),
                        GEN_Items_ModePaiement_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CPT_Ecritures", t => t.CPT_Ecritures_Id)
                .ForeignKey("dbo.GEN_Items", t => t.GEN_Items_ModePaiement_Id)
                .Index(t => t.CPT_Ecritures_Id)
                .Index(t => t.GEN_Items_ModePaiement_Id);
            
            CreateTable(
                "dbo.CPT_Lettrage",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        IdEcheance = c.Long(),
                        MontantRegle = c.Double(),
                        CodeLettrage = c.String(),
                        DateLettrage = c.DateTime(),
                        sys_user = c.String(),
                        sys_dateUpdate = c.DateTime(),
                        sys_dateCreation = c.DateTime(),
                        CPT_Echeances_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CPT_Echeances", t => t.CPT_Echeances_Id)
                .Index(t => t.CPT_Echeances_Id);
            
            CreateTable(
                "dbo.CPT_TVALettrage",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        EcheanceId = c.Long(),
                        LettrageId = c.Long(),
                        MntTTC = c.Double(),
                        CompteTVA = c.Long(),
                        CodeCompteTVA = c.String(),
                        TAuxTVA = c.Double(),
                        MntTVA = c.Double(),
                        CompteHT = c.Long(),
                        CodeCompteHT = c.String(),
                        MntHT = c.Double(),
                        TypePayment = c.String(),
                        CPT_Lettrage_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CPT_Lettrage", t => t.CPT_Lettrage_Id)
                .Index(t => t.CPT_Lettrage_Id);
            
            CreateTable(
                "dbo.GEN_DossiersSites",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nom = c.String(),
                        Adresse = c.String(),
                        Tel = c.String(),
                        Fax = c.String(),
                        Email = c.String(),
                        Ville = c.String(),
                        Pays = c.String(),
                        Actif = c.Boolean(nullable: false),
                        IdDossier = c.Long(),
                        ParDefault = c.Int(),
                        sys_user = c.String(),
                        sys_dateUpdate = c.DateTime(),
                        sys_dateCreation = c.DateTime(),
                        GEN_Dossiers_DossierId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GEN_Dossier", t => t.GEN_Dossiers_DossierId)
                .Index(t => t.GEN_Dossiers_DossierId);
            
            CreateTable(
                "dbo.GEN_TypePaiementDetail",
                c => new
                    {
                        TypePaiementDetailId = c.Long(nullable: false, identity: true),
                        IdTypePaiement = c.Long(),
                        IdModePaiement = c.Long(),
                        DateCalcul = c.Long(),
                        Pourcentage = c.Double(),
                        NombreJour = c.Int(),
                        Delai = c.Long(),
                        sys_user = c.String(),
                        sys_dateUpdate = c.DateTime(),
                        sys_dateCreation = c.DateTime(),
                        GEN_Items_DateCalcul_Id = c.Long(),
                        GEN_Items_Delai_Id = c.Long(),
                        GEN_Items_ModePaiement_Id = c.Long(),
                    })
                .PrimaryKey(t => t.TypePaiementDetailId)
                .ForeignKey("dbo.GEN_Items", t => t.GEN_Items_DateCalcul_Id)
                .ForeignKey("dbo.GEN_Items", t => t.GEN_Items_Delai_Id)
                .ForeignKey("dbo.GEN_Items", t => t.GEN_Items_ModePaiement_Id)
                .ForeignKey("dbo.TypePaiement", t => t.IdTypePaiement)
                .Index(t => t.IdTypePaiement)
                .Index(t => t.GEN_Items_DateCalcul_Id)
                .Index(t => t.GEN_Items_Delai_Id)
                .Index(t => t.GEN_Items_ModePaiement_Id);
            
            CreateTable(
                "dbo.Opportunite",
                c => new
                    {
                        OpportuniteId = c.Long(nullable: false, identity: true),
                        OpportuniteNumero = c.Int(nullable: false),
                        OpportuniteIdtiers = c.Long(),
                        OpportuniteDateopportunite = c.DateTime(),
                        OpportuniteIdcommercial = c.Long(),
                        OpportuniteStatut = c.String(),
                        OpportuniteIdDevise = c.Long(),
                        OpportuniteBudgetClient = c.Int(nullable: false),
                        OpportuniteBudgetEstime = c.Int(nullable: false),
                        OpportuniteLibelle = c.String(),
                        OpportuniteSysuser = c.Long(),
                        OpportuniteSysDateCreation = c.DateTime(),
                        OpportuniteSysDateUpdate = c.DateTime(),
                        OpportuniteDossierd = c.Long(),
                    })
                .PrimaryKey(t => t.OpportuniteId)
                .ForeignKey("dbo.Devise", t => t.OpportuniteIdDevise)
                .ForeignKey("dbo.GEN_Dossier", t => t.OpportuniteDossierd)
                .ForeignKey("dbo.GEN_Tier", t => t.OpportuniteIdcommercial)
                .Index(t => t.OpportuniteIdcommercial)
                .Index(t => t.OpportuniteIdDevise)
                .Index(t => t.OpportuniteDossierd);
            
            CreateTable(
                "dbo.Motif",
                c => new
                    {
                        MotifId = c.Long(nullable: false, identity: true),
                        OpportuniteId = c.Long(),
                        MotifEtat = c.String(),
                        MotifMotif = c.String(),
                        MotifDescription = c.String(),
                        MotifSysDateCreation = c.DateTime(),
                        MotifSysDateUpdate = c.DateTime(),
                        MotifdossierId = c.Long(),
                    })
                .PrimaryKey(t => t.MotifId)
                .ForeignKey("dbo.Opportunite", t => t.OpportuniteId)
                .ForeignKey("dbo.GEN_Dossier", t => t.MotifdossierId)
                .Index(t => t.OpportuniteId)
                .Index(t => t.MotifdossierId);
            
            CreateTable(
                "dbo.OpportuniteDetail",
                c => new
                    {
                        OpportuniteDetailId = c.Long(nullable: false, identity: true),
                        OpportuniteDetailIdopportunite = c.Long(),
                        OpportuniteDetailType_action = c.Long(),
                        OpportuniteDetailIdcommercial = c.Long(),
                        OpportuniteDetailDateaction = c.DateTime(),
                        OpportuniteDetailHeureaction = c.DateTime(),
                        OpportuniteDetailDescription = c.String(),
                        OpportuniteDetailSysuser = c.Long(),
                        OpportuniteDetailSysDateCreation = c.DateTime(),
                        OpportuniteDetailSysDateUpdate = c.DateTime(),
                    })
                .PrimaryKey(t => t.OpportuniteDetailId)
                .ForeignKey("dbo.GEN_Tier", t => t.OpportuniteDetailIdcommercial)
                .ForeignKey("dbo.Opportunite", t => t.OpportuniteDetailIdopportunite)
                .Index(t => t.OpportuniteDetailIdopportunite)
                .Index(t => t.OpportuniteDetailIdcommercial);
            
            CreateTable(
                "dbo.tiersContact",
                c => new
                    {
                        GEN_TiersContactsId = c.Long(nullable: false, identity: true),
                        Civilite = c.String(),
                        Nom = c.String(),
                        Prenom = c.String(),
                        Tel = c.String(),
                        Gsm = c.String(),
                        Email = c.String(),
                        Actif = c.Boolean(nullable: false),
                        IdTiers = c.Long(),
                        ParDefault = c.Int(),
                        sys_user = c.String(),
                        sys_dateUpdate = c.DateTime(),
                        sys_dateCreation = c.DateTime(),
                    })
                .PrimaryKey(t => t.GEN_TiersContactsId)
                .ForeignKey("dbo.GEN_Tier", t => t.IdTiers)
                .Index(t => t.IdTiers);
            
            CreateTable(
                "dbo.Ticket",
                c => new
                    {
                        TicketId = c.Long(nullable: false, identity: true),
                        TicketNumero = c.Long(nullable: false),
                        TicketDate_ouverture = c.DateTime(),
                        TicketType = c.Long(),
                        TicketStatut = c.String(),
                        TicketObjet = c.String(),
                        TicketDescription = c.String(),
                        TicketDegre = c.String(),
                        TicketIdClient = c.Long(),
                        TicketIdRepresentant = c.Long(),
                        TicketIdcontact = c.Long(),
                        TicketTypeaction = c.Long(),
                        TicketSysuser = c.Long(nullable: false),
                        TicketSysDateCreation = c.DateTime(),
                        TicketSysDateUpdate = c.DateTime(),
                        TicketDossierId = c.Long(),
                    })
                .PrimaryKey(t => t.TicketId)
                .ForeignKey("dbo.GEN_Dossier", t => t.TicketDossierId)
                .ForeignKey("dbo.GEN_Tier", t => t.TicketIdClient)
                .ForeignKey("dbo.tiersContact", t => t.TicketIdcontact)
                .ForeignKey("dbo.Representant", t => t.TicketIdRepresentant)
                .Index(t => t.TicketIdClient)
                .Index(t => t.TicketIdRepresentant)
                .Index(t => t.TicketIdcontact)
                .Index(t => t.TicketDossierId);
            
            CreateTable(
                "dbo.TicketDetail",
                c => new
                    {
                        TicketDetailId = c.Long(nullable: false, identity: true),
                        TicketDetailIdTicket = c.Long(),
                        TicketDetailTypeaction = c.Long(),
                        TicketDetailIdcommercial = c.Long(),
                        TicketDetailDateaction = c.DateTime(),
                        TicketDetailheureaction = c.DateTime(),
                        TicketDetailDescription = c.String(),
                        TicketDetailSysuser = c.Long(),
                        TicketDetailSysDateCreation = c.DateTime(),
                        TicketDetailSysDateUpdate = c.DateTime(),
                    })
                .PrimaryKey(t => t.TicketDetailId)
                .ForeignKey("dbo.GEN_Tier", t => t.TicketDetailIdcommercial)
                .ForeignKey("dbo.Ticket", t => t.TicketDetailIdTicket)
                .Index(t => t.TicketDetailIdTicket)
                .Index(t => t.TicketDetailIdcommercial);
            
            CreateTable(
                "dbo.MotifTicket",
                c => new
                    {
                        MotifTicketId = c.Long(nullable: false, identity: true),
                        MotifIdticket = c.Long(),
                        MotifTicketEtat = c.String(),
                        MotifTicketMotif = c.String(),
                        MotifTicketDescription = c.String(),
                        MotifTicketSysuser = c.Int(nullable: false),
                        MotifTicketSysDateCreation = c.DateTime(),
                        MotifTicketSysDateUpdate = c.DateTime(),
                        MotifTicketTiersContactId = c.Long(),
                        MotifTicketSocieteId = c.Long(),
                    })
                .PrimaryKey(t => t.MotifTicketId)
                .ForeignKey("dbo.GEN_Dossier", t => t.MotifTicketSocieteId)
                .ForeignKey("dbo.Ticket", t => t.MotifTicketTiersContactId)
                .Index(t => t.MotifTicketTiersContactId)
                .Index(t => t.MotifTicketSocieteId);
            
            CreateTable(
                "dbo.Representant",
                c => new
                    {
                        RepresentantId = c.Long(nullable: false, identity: true),
                        RepresentantCode = c.String(),
                        RepresentantCivilite = c.String(),
                        RepresentantNom = c.String(),
                        RepresentantAdresse = c.String(),
                        RepresentantTelephone = c.String(),
                        RepresentantGsm = c.String(),
                        RepresentantVille = c.String(),
                        RepresentantPays = c.String(),
                        RepresentantEmail = c.String(),
                        RepresentantFonction = c.String(),
                        RepresentantActif = c.Boolean(),
                        RepresentantAcheteur = c.Boolean(),
                        RepresentantVenseur = c.Boolean(),
                        RepresentantLogin = c.String(),
                        RepresentantPasswoord = c.String(),
                        RepresentantProfil = c.Long(),
                        RepresentantBc = c.Boolean(),
                        RepresentantSysuser = c.Long(),
                        RepresentantSysDateCreation = c.DateTime(),
                        ZenRepresentantSysDateUpdate = c.DateTime(),
                        RepresentantDossierId = c.Long(),
                    })
                .PrimaryKey(t => t.RepresentantId)
                .ForeignKey("dbo.GEN_Dossier", t => t.RepresentantDossierId)
                .Index(t => t.RepresentantDossierId);
            
            CreateTable(
                "dbo.Objectif",
                c => new
                    {
                        ObjectifId = c.Long(nullable: false, identity: true),
                        ObjectifRepresentantId = c.Long(),
                        ObjectifAnnee = c.DateTime(),
                        ObjectifPeriode = c.Int(nullable: false),
                        ObjectifDatedebut = c.DateTime(),
                        ObjectifDatefin = c.DateTime(),
                        ObjectifObjectif = c.Int(nullable: false),
                        ObjectifCommission = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ObjectifSysuser = c.Long(),
                        ObjectifSysDateCreation = c.DateTime(),
                        ObjectifSysDateUpdate = c.DateTime(),
                        ObjectifDossierId = c.Long(),
                    })
                .PrimaryKey(t => t.ObjectifId)
                .ForeignKey("dbo.GEN_Dossier", t => t.ObjectifDossierId)
                .ForeignKey("dbo.Representant", t => t.ObjectifRepresentantId)
                .Index(t => t.ObjectifRepresentantId)
                .Index(t => t.ObjectifDossierId);
            
            CreateTable(
                "dbo.FournisseurArticle",
                c => new
                    {
                        FournisseurArticleId = c.Long(nullable: false, identity: true),
                        FournisseurArticleIdArticle = c.Long(),
                        FournisseurArticleIdfournisseur = c.Long(),
                        FournisseurArticleReference = c.String(),
                        FournisseurArticlePrixAchatTC = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FournisseurArticleDeviseAchat = c.String(),
                        FournisseurArticlePrixAchatDevise = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FournisseurArticlePrixVenteTC = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FournisseurArticleDeviseVente = c.String(),
                        FournisseurArticlePrixVenteDevise = c.String(),
                        FournisseurArticleSysuser = c.Long(),
                        FournisseurArticleSysDateCreation = c.DateTime(),
                        FournisseurArticleSysDateUpdate = c.DateTime(),
                    })
                .PrimaryKey(t => t.FournisseurArticleId)
                .ForeignKey("dbo.Article", t => t.FournisseurArticleIdArticle)
                .ForeignKey("dbo.GEN_Tier", t => t.FournisseurArticleIdfournisseur)
                .Index(t => t.FournisseurArticleIdArticle)
                .Index(t => t.FournisseurArticleIdfournisseur);
            
            CreateTable(
                "dbo.Article",
                c => new
                    {
                        ArticleId = c.Long(nullable: false, identity: true),
                        ArticleTypeArticle = c.Long(nullable: false),
                        ArticleCodeArticle = c.String(),
                        ArticleDescription = c.String(),
                        ArticleDescriptif = c.String(),
                        ArticleCodeABarre = c.String(),
                        ArticleEstSerialiser = c.String(),
                        ArticleEstGererEnStock = c.Boolean(nullable: false),
                        ArticleEstVendu = c.Boolean(nullable: false),
                        ArticleEstAchat = c.Boolean(nullable: false),
                        ArticlePrixAchatDefault = c.Double(nullable: false),
                        ArticlePrixVenteDefault = c.Double(nullable: false),
                        ArticleCoefficientMarge = c.Double(nullable: false),
                        ArticleSeuilStockMin = c.Int(nullable: false),
                        ArticleSeuilStockMax = c.Int(nullable: false),
                        ArticleGarantieMaintenance = c.Boolean(nullable: false),
                        ArticleGarantiemois = c.Int(nullable: false),
                        ArticlePubliable = c.Boolean(nullable: false),
                        ArticleActif = c.Boolean(nullable: false),
                        ArticleImage = c.String(),
                        ArticleSysuser = c.Int(nullable: false),
                        ArticleSysDateCreation = c.DateTime(nullable: false),
                        ArticlesSysDateUpdate = c.DateTime(nullable: false),
                        ArticleSocieteId = c.Long(),
                        ArticleDepotId = c.Long(),
                        ArticleCategorieId = c.Long(),
                        ArticleUniteId = c.Long(),
                        ArticleMarqueId = c.Long(),
                    })
                .PrimaryKey(t => t.ArticleId)
                .ForeignKey("dbo.Categorie", t => t.ArticleCategorieId)
                .ForeignKey("dbo.Depot", t => t.ArticleDepotId)
                .ForeignKey("dbo.GES_Marque", t => t.ArticleMarqueId)
                .ForeignKey("dbo.GEN_Dossier", t => t.ArticleSocieteId)
                .ForeignKey("dbo.GES_Unite", t => t.ArticleUniteId)
                .Index(t => t.ArticleSocieteId)
                .Index(t => t.ArticleDepotId)
                .Index(t => t.ArticleCategorieId)
                .Index(t => t.ArticleUniteId)
                .Index(t => t.ArticleMarqueId);
            
            CreateTable(
                "dbo.ArticlesKit",
                c => new
                    {
                        ArticlesKitId = c.Long(nullable: false, identity: true),
                        ArticlesKitQantite = c.Int(nullable: false),
                        ArticlesKitDescription = c.String(),
                        ArticlesKitSysuser = c.Int(nullable: false),
                        ArticlesKitSysDateCreation = c.DateTime(nullable: false),
                        ArticlesKitSysDateUpdate = c.DateTime(nullable: false),
                        ArticlesKitArticlesId = c.Long(),
                        ArticlesKitArticleId1 = c.Long(),
                        ArticlesKitArticle1_ArticleId = c.Long(),
                    })
                .PrimaryKey(t => t.ArticlesKitId)
                .ForeignKey("dbo.Article", t => t.ArticlesKitArticleId1)
                .ForeignKey("dbo.Article", t => t.ArticlesKitArticle1_ArticleId)
                .Index(t => t.ArticlesKitArticleId1)
                .Index(t => t.ArticlesKitArticle1_ArticleId);
            
            CreateTable(
                "dbo.ArticlesPrix",
                c => new
                    {
                        ArticlesPrixId = c.Long(nullable: false, identity: true),
                        ArticlesPrixprixAchatTC = c.Double(nullable: false),
                        ArticlesPrixprixVenteTC = c.Double(nullable: false),
                        ArticlesPrixDeviseVente = c.String(),
                        ArticlesPrixDeviseAchat = c.String(),
                        ArticlesPrixPrixVenteDevise = c.Double(nullable: false),
                        ArticlesPrixDateApplication = c.DateTime(nullable: false),
                        ArticlesPrixActif = c.Boolean(nullable: false),
                        ArticlesPrixSysuser = c.Int(nullable: false),
                        ArticlesPrixSysDateCreation = c.DateTime(nullable: false),
                        ArticlesPrixSysDateUpdate = c.DateTime(nullable: false),
                        ArticlesPrixArticleId = c.Long(),
                    })
                .PrimaryKey(t => t.ArticlesPrixId)
                .ForeignKey("dbo.Article", t => t.ArticlesPrixArticleId)
                .Index(t => t.ArticlesPrixArticleId);
            
            CreateTable(
                "dbo.Categorie",
                c => new
                    {
                        CategorieId = c.Long(nullable: false, identity: true),
                        CategorieLibelle = c.String(),
                        CategorieDescription = c.String(),
                        CategorieSysuser = c.Int(nullable: false),
                        CategorieSysDateCreation = c.DateTime(nullable: false),
                        CategorieSysDateUpdate = c.DateTime(nullable: false),
                        CategorieActif = c.Boolean(nullable: false),
                        CategorieSocieteId = c.Long(),
                    })
                .PrimaryKey(t => t.CategorieId)
                .ForeignKey("dbo.GEN_Dossier", t => t.CategorieSocieteId)
                .Index(t => t.CategorieSocieteId);
            
            CreateTable(
                "dbo.Depot",
                c => new
                    {
                        DepotId = c.Long(nullable: false, identity: true),
                        DepotVille = c.String(),
                        DepotPays = c.String(),
                        DepotAdresse = c.String(),
                        DepotDepot = c.String(),
                        DepotCode = c.String(),
                        DepotDescription = c.String(),
                        DepotSysuser = c.Int(nullable: false),
                        DepotSysDateCreation = c.DateTime(nullable: false),
                        DepotSysDateUpdate = c.DateTime(nullable: false),
                        DepotActif = c.Boolean(nullable: false),
                        DepotSocieteId = c.Long(),
                    })
                .PrimaryKey(t => t.DepotId)
                .ForeignKey("dbo.GEN_Dossier", t => t.DepotSocieteId)
                .Index(t => t.DepotSocieteId);
            
            CreateTable(
                "dbo.MouvementStock",
                c => new
                    {
                        MouvementStockId = c.Long(nullable: false, identity: true),
                        MouvementStockCode = c.String(),
                        MouvementStockSens = c.String(),
                        MouvementStockTypearticle = c.Long(),
                        MouvementStockCodebundle = c.String(),
                        MouvementStockIdarticle = c.Long(),
                        MouvementStockNiveau = c.Int(nullable: false),
                        MouvementStockDatemouvement = c.DateTime(),
                        MouvementStockOrigine = c.String(),
                        MouvementStockIddocument = c.Long(),
                        MouvementStockStatut = c.String(),
                        MouvementStockSerialise = c.String(),
                        MouvementStockNumeroserie = c.Int(nullable: false),
                        MouvementStockLot = c.String(),
                        MouvementStockNumerolot = c.Int(nullable: false),
                        MouvementStockQuantite = c.Int(nullable: false),
                        MouvementStockCodeliaison = c.Int(nullable: false),
                        MouvementStockIddepot = c.Long(),
                        MouvementStockDepot = c.String(),
                        MouvementStockMotif = c.String(),
                        MouvementStockDescmotif = c.String(),
                        MouvementStockSys_user = c.Int(nullable: false),
                        MouvementStockSysDateCreation = c.DateTime(),
                        MouvementStockSysDateUpdate = c.DateTime(),
                        MouvementStockDossierId = c.Long(),
                    })
                .PrimaryKey(t => t.MouvementStockId)
                .ForeignKey("dbo.Article", t => t.MouvementStockIdarticle)
                .ForeignKey("dbo.DocumentCommercial", t => t.MouvementStockIddocument)
                .ForeignKey("dbo.Depot", t => t.MouvementStockIddepot)
                .ForeignKey("dbo.GEN_Dossier", t => t.MouvementStockDossierId)
                .Index(t => t.MouvementStockIdarticle)
                .Index(t => t.MouvementStockIddocument)
                .Index(t => t.MouvementStockIddepot)
                .Index(t => t.MouvementStockDossierId);
            
            CreateTable(
                "dbo.DocumentCommercial",
                c => new
                    {
                        DocumentCommercialId = c.Long(nullable: false, identity: true),
                        DocumentCommercialNumeroPiece = c.String(),
                        DocumentCommercialEtatPiece = c.Int(nullable: false),
                        DocumentCommercialTypePiece = c.Long(),
                        DocumentCommercialDateDocument = c.DateTime(nullable: false),
                        DocumentCommercialReference = c.Int(nullable: false),
                        DocumentCommercialTotalHTTC = c.Double(nullable: false),
                        DocumentCommercialTotalTVATC = c.Double(nullable: false),
                        DocumentCommercialTotalTTCTC = c.Double(nullable: false),
                        DocumentCommercialDevise = c.Int(nullable: false),
                        DocumentCommercialTotalHTDevise = c.Double(nullable: false),
                        DocumentCommercialTotalTVADevise = c.Double(nullable: false),
                        DocumentCommercialTotalTTCDevise = c.Double(nullable: false),
                        DocumentCommercialCoursDevise = c.Int(nullable: false),
                        DocumentCommercialStatutRegelement = c.String(),
                        DocumentCommercialCodeLiaison = c.String(),
                        DocumentCommercialStatutDocument = c.String(),
                        DocumentCommercialConditionGe = c.String(),
                        DocumentCommercialSysuser = c.Int(nullable: false),
                        DocumentCommercialSysDateCreation = c.DateTime(nullable: false),
                        DocumentCommercialSysDateUpdate = c.DateTime(nullable: false),
                        DocumentCommercialSocieteId = c.Long(),
                    })
                .PrimaryKey(t => t.DocumentCommercialId)
                .ForeignKey("dbo.GEN_Dossier", t => t.DocumentCommercialSocieteId)
                .Index(t => t.DocumentCommercialSocieteId);
            
            CreateTable(
                "dbo.DocumentCommercialDetail",
                c => new
                    {
                        DocumentCommercialDetailId = c.Long(nullable: false, identity: true),
                        DocumentCommercialDetailDesignation = c.String(),
                        DocumentCommercialDetailDescription = c.String(),
                        DocumentCommercialDetailQuantite = c.Int(nullable: false),
                        DocumentCommercialDetailPrixUnitaireHTTC = c.Double(nullable: false),
                        DocumentCommerciaDetailTVATC = c.Double(nullable: false),
                        DocumentCommercialDetailTTCTC = c.Double(nullable: false),
                        DocumentCommercialDetailDevise = c.Int(nullable: false),
                        DocumentCommercialDetailPrixUnitaireHTDevise = c.Double(nullable: false),
                        DocumentCommercialDetailTVADevise = c.Int(nullable: false),
                        DocumentCommercialDetailTTCDevise = c.String(),
                        DocumentCommercialDetailCoursDevise = c.Int(nullable: false),
                        DocumentCommercialDetailRemise = c.Int(nullable: false),
                        DocumentCommercialDetailCodeLiaison = c.Int(nullable: false),
                        DocumentCommercialDetailStatutLigne = c.Int(nullable: false),
                        DocumentCommercialSysuser = c.Int(nullable: false),
                        DocumentCommercialSysDateCreation = c.DateTime(nullable: false),
                        DocumentCommercialSysDateUpdate = c.DateTime(nullable: false),
                        DocumentCommercialDetailArticleId = c.Long(),
                        DocumentCommercialIdDocumentCommercial = c.Long(),
                    })
                .PrimaryKey(t => t.DocumentCommercialDetailId)
                .ForeignKey("dbo.Article", t => t.DocumentCommercialDetailArticleId)
                .ForeignKey("dbo.DocumentCommercial", t => t.DocumentCommercialIdDocumentCommercial)
                .Index(t => t.DocumentCommercialDetailArticleId)
                .Index(t => t.DocumentCommercialIdDocumentCommercial);
            
            CreateTable(
                "dbo.DocumentCommercialDetailSerie",
                c => new
                    {
                        DocumentCommercialDetailSerieId = c.Long(nullable: false, identity: true),
                        DocumentCommercialDetailSerieNumeroSerie = c.Double(nullable: false),
                        DocumentCommercialDetailSerieNumeroLot = c.String(),
                        DocumentCommercialDetailSerieGarantie = c.Boolean(nullable: false),
                        DocumentCommercialDetailSerieDateFinMaintenance = c.DateTime(nullable: false),
                        DocumentCommercialDetailSerieSysuser = c.Int(nullable: false),
                        DocumentCommercialDetailSerieSysDateCreation = c.DateTime(nullable: false),
                        DocumentCommercialDetailSerieSysDateUpdate = c.DateTime(nullable: false),
                        DocumentCommercialDetailSerieSocieteId = c.Long(),
                        DocumentCommercialDetailSerieDocumentCommercialDetailIdDocumentDetail = c.Long(),
                    })
                .PrimaryKey(t => t.DocumentCommercialDetailSerieId)
                .ForeignKey("dbo.DocumentCommercialDetail", t => t.DocumentCommercialDetailSerieDocumentCommercialDetailIdDocumentDetail)
                .ForeignKey("dbo.GEN_Dossier", t => t.DocumentCommercialDetailSerieSocieteId)
                .Index(t => t.DocumentCommercialDetailSerieSocieteId)
                .Index(t => t.DocumentCommercialDetailSerieDocumentCommercialDetailIdDocumentDetail);
            
            CreateTable(
                "dbo.GES_Marque",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        MarqueCode = c.String(),
                        MarqueLibelle = c.String(),
                        MarqueActif = c.Boolean(nullable: false),
                        MarqueSys_user = c.Int(nullable: false),
                        MarqueSys_DateCreation = c.DateTime(nullable: false),
                        MarqueSys_DateUpdate = c.DateTime(nullable: false),
                        MarqueSocieteId = c.Long(),
                        MarqueSociete_DossierId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GEN_Dossier", t => t.MarqueSociete_DossierId)
                .Index(t => t.MarqueSociete_DossierId);
            
            CreateTable(
                "dbo.Nomenclature",
                c => new
                    {
                        NomenclatureId = c.Long(nullable: false, identity: true),
                        ArticlenomencId = c.Int(nullable: false),
                        NomenclatureLib = c.String(),
                        NomenclatureQuantite = c.Int(nullable: false),
                        NomenclatureSysuser = c.Int(nullable: false),
                        NomenclatureSysDateCreation = c.DateTime(),
                        NomenclatureSysDateUpdate = c.DateTime(),
                        NomenclatureIdarticle = c.Long(),
                    })
                .PrimaryKey(t => t.NomenclatureId)
                .ForeignKey("dbo.Article", t => t.NomenclatureIdarticle)
                .Index(t => t.NomenclatureIdarticle);
            
            CreateTable(
                "dbo.GES_Unite",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        UniteCode = c.String(),
                        UniteLibelle = c.String(),
                        UniteActif = c.Boolean(nullable: false),
                        UniteSysuser = c.Int(nullable: false),
                        UniteSysDateCreation = c.DateTime(nullable: false),
                        UniteSysDateUpdate = c.DateTime(nullable: false),
                        UniteSocieteId = c.Long(),
                        UniteSociete_DossierId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GEN_Dossier", t => t.UniteSociete_DossierId)
                .Index(t => t.UniteSociete_DossierId);
            
            CreateTable(
                "dbo.Reglement",
                c => new
                    {
                        ReglementId = c.Long(nullable: false, identity: true),
                        ReglementType = c.Long(),
                        ReglementReference = c.String(),
                        ReglementLibelle = c.String(),
                        ReglementDatereglement = c.DateTime(),
                        ReglementDateecheance = c.DateTime(),
                        ReglementIdtiers = c.Long(),
                        ReglementIdmoyenpaiement = c.Long(),
                        DevisesId = c.Int(nullable: false),
                        ReglementMontant = c.Int(nullable: false),
                        ReglementBanqueId = c.Long(),
                        ReglementStatut = c.String(),
                        ReglementEtat = c.String(),
                        ReglementDatePaiement = c.DateTime(),
                        ReglementPaye = c.Boolean(nullable: false),
                        ReglementNumreleve = c.Long(),
                        ReglementSysuser = c.Long(),
                        ReglementSysDateCreation = c.DateTime(),
                        ReglementSysDateUpdate = c.DateTime(),
                        ReglementDossierId = c.Long(),
                    })
                .PrimaryKey(t => t.ReglementId)
                .ForeignKey("dbo.GEN_Dossier", t => t.ReglementDossierId)
                .ForeignKey("dbo.GEN_Tier", t => t.ReglementBanqueId)
                .Index(t => t.ReglementBanqueId)
                .Index(t => t.ReglementDossierId);
            
            CreateTable(
                "dbo.GEN_Documents",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Libelle = c.String(),
                        Tags = c.String(),
                        Fichier = c.String(),
                        NomObjetClasse = c.String(),
                        IdObjet = c.Int(nullable: false),
                        IdDossier = c.Long(nullable: false),
                        sys_user = c.String(),
                        sys_dateUpdate = c.DateTime(),
                        sys_dateCreation = c.DateTime(),
                        GEN_Dossiers_DossierId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GEN_Dossier", t => t.GEN_Dossiers_DossierId)
                .Index(t => t.GEN_Dossiers_DossierId);
            
            CreateTable(
                "dbo.GEN_DossiersContact",
                c => new
                    {
                        DossiersContactsId = c.Long(nullable: false, identity: true),
                        Civilite = c.String(),
                        Nom = c.String(),
                        Prenom = c.String(),
                        Tel = c.String(),
                        Gsm = c.String(),
                        Email = c.String(),
                        Actif = c.Boolean(nullable: false),
                        IdDossier = c.Long(),
                        ParDefault = c.Int(),
                        sys_user = c.String(),
                        sys_dateUpdate = c.DateTime(),
                        sys_dateCreation = c.DateTime(),
                    })
                .PrimaryKey(t => t.DossiersContactsId)
                .ForeignKey("dbo.GEN_Dossier", t => t.IdDossier)
                .Index(t => t.IdDossier);
            
            CreateTable(
                "dbo.GEN_Exercices",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CodeExercice = c.String(),
                        Libelle = c.String(),
                        DateDebut = c.DateTime(),
                        DateFin = c.DateTime(),
                        Actif = c.Boolean(nullable: false),
                        ComptaCloture = c.Int(),
                        GescomCloture = c.Int(),
                        PaieCloture = c.Int(),
                        IdDossier = c.Long(),
                        sys_user = c.String(),
                        sys_dateUpdate = c.DateTime(),
                        sys_dateCreation = c.DateTime(),
                        GEN_Dossiers_DossierId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GEN_Dossier", t => t.GEN_Dossiers_DossierId)
                .Index(t => t.GEN_Dossiers_DossierId);
            
            CreateTable(
                "dbo.GEN_Periodes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Libelle = c.String(),
                        DateDebut = c.DateTime(),
                        DateFin = c.DateTime(),
                        Actif = c.Boolean(),
                        ComptaCloture = c.Int(nullable: false),
                        GescomCloture = c.Int(),
                        PaieCloture = c.Int(),
                        IdExercice = c.Long(),
                        sys_user = c.String(),
                        sys_dateUpdate = c.DateTime(),
                        sys_dateCreation = c.DateTime(),
                        GEN_Exercices_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GEN_Exercices", t => t.GEN_Exercices_Id)
                .Index(t => t.GEN_Exercices_Id);
            
            CreateTable(
                "dbo.GEN_Preferences",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        IdUsers = c.String(),
                        IdDossier = c.Long(nullable: false),
                        IdExercices = c.Long(nullable: false),
                        GEN_Dossiers_DossierId = c.Long(),
                        GEN_Exercices_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GEN_Dossier", t => t.GEN_Dossiers_DossierId)
                .ForeignKey("dbo.GEN_Exercices", t => t.GEN_Exercices_Id)
                .Index(t => t.GEN_Dossiers_DossierId)
                .Index(t => t.GEN_Exercices_Id);
            
            CreateTable(
                "dbo.GEN_Numeration",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Objet = c.String(),
                        idDossier = c.Long(),
                        sys_user = c.String(),
                        sys_dateUpdate = c.DateTime(),
                        sys_dateCreation = c.DateTime(),
                        GEN_Dossiers_DossierId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GEN_Dossier", t => t.GEN_Dossiers_DossierId)
                .Index(t => t.GEN_Dossiers_DossierId);
            
            CreateTable(
                "dbo.Numerotation",
                c => new
                    {
                        NumerotationId = c.Long(nullable: false, identity: true),
                        NumerotationType = c.Long(),
                        NumerotationExpression = c.String(),
                        NumerotationNombre = c.Int(nullable: false),
                        NumerotationValeur = c.String(),
                        NumerotationCompteur = c.Int(nullable: false),
                        NumerotationIncrement = c.Int(nullable: false),
                        NumerotationSysuser = c.Long(),
                        NumerotationSysDateCreation = c.DateTime(),
                        NumerotationSysDateUpdate = c.DateTime(),
                        NumerotationDossierId = c.Long(),
                    })
                .PrimaryKey(t => t.NumerotationId)
                .ForeignKey("dbo.GEN_Dossier", t => t.NumerotationDossierId)
                .Index(t => t.NumerotationDossierId);
            
            CreateTable(
                "dbo.Periode",
                c => new
                    {
                        PeriodeId = c.Long(nullable: false, identity: true),
                        PeriodeAnnee = c.DateTime(),
                        PeriodeTypePeriode = c.Long(),
                        PeriodeLibelle = c.String(),
                        PeriodeDateDebut = c.DateTime(),
                        PeriodeDateFin = c.DateTime(),
                        PeriodeEtatPeriode = c.String(),
                        PeriodeSysuser = c.Int(nullable: false),
                        PeriodeSysDateCreation = c.DateTime(),
                        PeriodeSysDateUpdate = c.DateTime(),
                        PeriodeAutoriserVente = c.Boolean(),
                        PeriodeAutoriserAchat = c.Boolean(),
                        PeriodeAutoriserMvtStock = c.Boolean(),
                        PeriodeSocieteId = c.Long(),
                    })
                .PrimaryKey(t => t.PeriodeId)
                .ForeignKey("dbo.GEN_Dossier", t => t.PeriodeSocieteId)
                .Index(t => t.PeriodeSocieteId);
            
            CreateTable(
                "dbo.Doclie",
                c => new
                    {
                        DoclieId = c.Long(nullable: false, identity: true),
                        DoclieNomdoc = c.String(),
                        DoclieLien = c.String(),
                        DoclieSysuser = c.Int(nullable: false),
                        DoclieSysDateCreation = c.DateTime(nullable: false),
                        DoclieSysDateUpdate = c.DateTime(nullable: false),
                        DoclieSocieteId = c.Long(),
                    })
                .PrimaryKey(t => t.DoclieId)
                .ForeignKey("dbo.GEN_Dossier", t => t.DoclieSocieteId)
                .Index(t => t.DoclieSocieteId);
            
            CreateTable(
                "dbo.Doclieart",
                c => new
                    {
                        DoclieartId = c.Long(nullable: false, identity: true),
                        DoclieartNomdoc = c.String(),
                        DoclieartLien = c.String(),
                        DoclieSysuser = c.Int(nullable: false),
                        DoclieSysDateCreation = c.DateTime(nullable: false),
                        DoclieSysDateUpdate = c.DateTime(nullable: false),
                        DoclieartSocieteId = c.Long(),
                    })
                .PrimaryKey(t => t.DoclieartId)
                .ForeignKey("dbo.GEN_Dossier", t => t.DoclieartSocieteId)
                .Index(t => t.DoclieartSocieteId);
            
            CreateTable(
                "dbo.Famille",
                c => new
                    {
                        FamilleId = c.Long(nullable: false, identity: true),
                        FamilleCode = c.Int(nullable: false),
                        FamilleLibelle = c.Int(nullable: false),
                        FamilleSyuser = c.Int(nullable: false),
                        FamilleSysDateCreation = c.DateTime(nullable: false),
                        FamilleSysDateUpdate = c.DateTime(nullable: false),
                        FamilleSocieteId = c.Long(),
                    })
                .PrimaryKey(t => t.FamilleId)
                .ForeignKey("dbo.GEN_Dossier", t => t.FamilleSocieteId)
                .Index(t => t.FamilleSocieteId);
            
            CreateTable(
                "dbo.GES_Impression",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ImpressionType = c.Long(),
                        ImpressionChemin = c.String(),
                        ImpressionLogo = c.String(),
                        ImpressionSocieteId = c.Long(),
                        ImpressionSociete_DossierId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GEN_Dossier", t => t.ImpressionSociete_DossierId)
                .Index(t => t.ImpressionSociete_DossierId);
            
            CreateTable(
                "dbo.GES_Tolerance",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ToleranceEntier = c.Int(nullable: false),
                        ToleranceSocieteId = c.Long(),
                        ToleranceSociete_DossierId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GEN_Dossier", t => t.ToleranceSociete_DossierId)
                .Index(t => t.ToleranceSociete_DossierId);
            
            CreateTable(
                "dbo.Ged",
                c => new
                    {
                        GedId = c.Long(nullable: false, identity: true),
                        GedTypeFichier = c.Long(),
                        GedLibelleFichier = c.String(),
                        GedDescriptionFichier = c.String(),
                        GedFichierSource = c.String(),
                        GedEntiteName = c.String(),
                        GedIdEntite = c.Long(),
                        GedSysuser = c.Long(),
                        GedSysDateCreation = c.DateTime(),
                        GedSysDateUpdate = c.DateTime(),
                    })
                .PrimaryKey(t => t.GedId);
            
            CreateTable(
                "dbo.GEN_Model",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Model = c.String(),
                        IdSociete = c.Long(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GES_Licence",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        LicenceNumeroSerieid = c.Int(nullable: false),
                        LicenceRaisonSociale = c.String(),
                        LicenceNombreSociete = c.Int(nullable: false),
                        LicenceNombreUser = c.Int(nullable: false),
                        LicenceActif = c.Boolean(),
                        LicenceCHash = c.String(),
                        LicenceDateFinContrat = c.DateTime(nullable: false),
                        LicenceRenouvellable = c.String(),
                        LicenceSysDateCreation = c.DateTime(nullable: false),
                        LicenceSysDateUpdate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ReglementFacture",
                c => new
                    {
                        ReglementFactureId = c.Long(nullable: false, identity: true),
                        ReglementId = c.Long(),
                        ReglementFactureIdfacture = c.Long(),
                        ReglementFacturePaye = c.Long(),
                    })
                .PrimaryKey(t => t.ReglementFactureId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GEN_Items", "GEN_Model_Id", "dbo.GEN_Model");
            DropForeignKey("dbo.Affaire", "AffaireSocieteId", "dbo.GEN_Dossier");
            DropForeignKey("dbo.GES_Tolerance", "ToleranceSociete_DossierId", "dbo.GEN_Dossier");
            DropForeignKey("dbo.GES_Impression", "ImpressionSociete_DossierId", "dbo.GEN_Dossier");
            DropForeignKey("dbo.Famille", "FamilleSocieteId", "dbo.GEN_Dossier");
            DropForeignKey("dbo.Doclieart", "DoclieartSocieteId", "dbo.GEN_Dossier");
            DropForeignKey("dbo.Doclie", "DoclieSocieteId", "dbo.GEN_Dossier");
            DropForeignKey("dbo.Periode", "PeriodeSocieteId", "dbo.GEN_Dossier");
            DropForeignKey("dbo.Numerotation", "NumerotationDossierId", "dbo.GEN_Dossier");
            DropForeignKey("dbo.GEN_Numeration", "GEN_Dossiers_DossierId", "dbo.GEN_Dossier");
            DropForeignKey("dbo.GEN_Preferences", "GEN_Exercices_Id", "dbo.GEN_Exercices");
            DropForeignKey("dbo.GEN_Preferences", "GEN_Dossiers_DossierId", "dbo.GEN_Dossier");
            DropForeignKey("dbo.GEN_Periodes", "GEN_Exercices_Id", "dbo.GEN_Exercices");
            DropForeignKey("dbo.GEN_Exercices", "GEN_Dossiers_DossierId", "dbo.GEN_Dossier");
            DropForeignKey("dbo.GEN_DossiersContact", "IdDossier", "dbo.GEN_Dossier");
            DropForeignKey("dbo.GEN_Documents", "GEN_Dossiers_DossierId", "dbo.GEN_Dossier");
            DropForeignKey("dbo.Dossier", "GEN_Dossiers_DossierId", "dbo.GEN_Dossier");
            DropForeignKey("dbo.CPT_Classe", "GEN_Dossiers_DossierId", "dbo.GEN_Dossier");
            DropForeignKey("dbo.CPT_CompteG", "GEN_Items_TypeCompte_Id", "dbo.GEN_Items");
            DropForeignKey("dbo.CPT_CompteG", "GEN_Items_SuiviCompteTVA_Id", "dbo.GEN_Items");
            DropForeignKey("dbo.CPT_CompteG", "GEN_Items_Sens_Id", "dbo.GEN_Items");
            DropForeignKey("dbo.CPT_CompteG", "GEN_Items_ReportANouveau_Id", "dbo.GEN_Items");
            DropForeignKey("dbo.CPT_CompteG", "GEN_Items_NatureCompte_Id", "dbo.GEN_Items");
            DropForeignKey("dbo.CPT_CompteG", "GEN_Dossiers_DossierId", "dbo.GEN_Dossier");
            DropForeignKey("dbo.CPT_CompteG", "CPT_CodesTVA_CodeTVADefault_Id", "dbo.Dossier");
            DropForeignKey("dbo.Dossier", "CPT_CompteG_Id1", "dbo.CPT_CompteG");
            DropForeignKey("dbo.GEN_Tier", "TvaSocieteId", "dbo.Dossier");
            DropForeignKey("dbo.Reglement", "ReglementBanqueId", "dbo.GEN_Tier");
            DropForeignKey("dbo.Reglement", "ReglementDossierId", "dbo.GEN_Dossier");
            DropForeignKey("dbo.FournisseurArticle", "FournisseurArticleIdfournisseur", "dbo.GEN_Tier");
            DropForeignKey("dbo.FournisseurArticle", "FournisseurArticleIdArticle", "dbo.Article");
            DropForeignKey("dbo.Article", "ArticleUniteId", "dbo.GES_Unite");
            DropForeignKey("dbo.GES_Unite", "UniteSociete_DossierId", "dbo.GEN_Dossier");
            DropForeignKey("dbo.Article", "ArticleSocieteId", "dbo.GEN_Dossier");
            DropForeignKey("dbo.Nomenclature", "NomenclatureIdarticle", "dbo.Article");
            DropForeignKey("dbo.Article", "ArticleMarqueId", "dbo.GES_Marque");
            DropForeignKey("dbo.GES_Marque", "MarqueSociete_DossierId", "dbo.GEN_Dossier");
            DropForeignKey("dbo.Article", "ArticleDepotId", "dbo.Depot");
            DropForeignKey("dbo.Depot", "DepotSocieteId", "dbo.GEN_Dossier");
            DropForeignKey("dbo.MouvementStock", "MouvementStockDossierId", "dbo.GEN_Dossier");
            DropForeignKey("dbo.MouvementStock", "MouvementStockIddepot", "dbo.Depot");
            DropForeignKey("dbo.MouvementStock", "MouvementStockIddocument", "dbo.DocumentCommercial");
            DropForeignKey("dbo.DocumentCommercial", "DocumentCommercialSocieteId", "dbo.GEN_Dossier");
            DropForeignKey("dbo.DocumentCommercialDetailSerie", "DocumentCommercialDetailSerieSocieteId", "dbo.GEN_Dossier");
            DropForeignKey("dbo.DocumentCommercialDetailSerie", "DocumentCommercialDetailSerieDocumentCommercialDetailIdDocumentDetail", "dbo.DocumentCommercialDetail");
            DropForeignKey("dbo.DocumentCommercialDetail", "DocumentCommercialIdDocumentCommercial", "dbo.DocumentCommercial");
            DropForeignKey("dbo.DocumentCommercialDetail", "DocumentCommercialDetailArticleId", "dbo.Article");
            DropForeignKey("dbo.MouvementStock", "MouvementStockIdarticle", "dbo.Article");
            DropForeignKey("dbo.Article", "ArticleCategorieId", "dbo.Categorie");
            DropForeignKey("dbo.Categorie", "CategorieSocieteId", "dbo.GEN_Dossier");
            DropForeignKey("dbo.ArticlesPrix", "ArticlesPrixArticleId", "dbo.Article");
            DropForeignKey("dbo.ArticlesKit", "ArticlesKitArticle1_ArticleId", "dbo.Article");
            DropForeignKey("dbo.ArticlesKit", "ArticlesKitArticleId1", "dbo.Article");
            DropForeignKey("dbo.GEN_Tier", "TypeTiers", "dbo.TypePaiement");
            DropForeignKey("dbo.Ticket", "TicketIdRepresentant", "dbo.Representant");
            DropForeignKey("dbo.Objectif", "ObjectifRepresentantId", "dbo.Representant");
            DropForeignKey("dbo.Objectif", "ObjectifDossierId", "dbo.GEN_Dossier");
            DropForeignKey("dbo.GEN_Tier", "GES_Representant_RepresentantId", "dbo.Representant");
            DropForeignKey("dbo.Representant", "RepresentantDossierId", "dbo.GEN_Dossier");
            DropForeignKey("dbo.MotifTicket", "MotifTicketTiersContactId", "dbo.Ticket");
            DropForeignKey("dbo.MotifTicket", "MotifTicketSocieteId", "dbo.GEN_Dossier");
            DropForeignKey("dbo.Ticket", "TicketIdcontact", "dbo.tiersContact");
            DropForeignKey("dbo.Ticket", "TicketIdClient", "dbo.GEN_Tier");
            DropForeignKey("dbo.Ticket", "TicketDossierId", "dbo.GEN_Dossier");
            DropForeignKey("dbo.TicketDetail", "TicketDetailIdTicket", "dbo.Ticket");
            DropForeignKey("dbo.TicketDetail", "TicketDetailIdcommercial", "dbo.GEN_Tier");
            DropForeignKey("dbo.tiersContact", "IdTiers", "dbo.GEN_Tier");
            DropForeignKey("dbo.GEN_Tier", "GEN_Items_TypeTiers_Id", "dbo.GEN_Items");
            DropForeignKey("dbo.GEN_Tier", "GEN_Items_FormeJuridique_Id", "dbo.GEN_Items");
            DropForeignKey("dbo.GEN_Tier", "GEN_Items_CategorieFiscale_Id", "dbo.GEN_Items");
            DropForeignKey("dbo.GEN_Tier", "IdDossier", "dbo.GEN_Dossier");
            DropForeignKey("dbo.GEN_Tier", "IdDeviseDefault", "dbo.Devise");
            DropForeignKey("dbo.CPT_ComptesBancairesTiers", "GEN_Tiers_Id", "dbo.GEN_Tier");
            DropForeignKey("dbo.OpportuniteDetail", "OpportuniteDetailIdopportunite", "dbo.Opportunite");
            DropForeignKey("dbo.OpportuniteDetail", "OpportuniteDetailIdcommercial", "dbo.GEN_Tier");
            DropForeignKey("dbo.Motif", "MotifdossierId", "dbo.GEN_Dossier");
            DropForeignKey("dbo.Motif", "OpportuniteId", "dbo.Opportunite");
            DropForeignKey("dbo.Opportunite", "OpportuniteIdcommercial", "dbo.GEN_Tier");
            DropForeignKey("dbo.Opportunite", "OpportuniteDossierd", "dbo.GEN_Dossier");
            DropForeignKey("dbo.Opportunite", "OpportuniteIdDevise", "dbo.Devise");
            DropForeignKey("dbo.Devise", "GEN_Dossiers_DossierId", "dbo.GEN_Dossier");
            DropForeignKey("dbo.Devise", "DevisesIdDossier", "dbo.GEN_Dossier");
            DropForeignKey("dbo.CPT_Pieces", "GEN_Devises_DevisesId1", "dbo.Devise");
            DropForeignKey("dbo.CPT_Pieces", "GEN_Devises_DevisesId", "dbo.Devise");
            DropForeignKey("dbo.CPT_Ecritures", "GEN_Devises_DevisesId1", "dbo.Devise");
            DropForeignKey("dbo.CPT_Ecritures", "GEN_Devises_DevisesId", "dbo.Devise");
            DropForeignKey("dbo.CPT_ComptesBancairesTiers", "GEN_Devises_DevisesId", "dbo.Devise");
            DropForeignKey("dbo.CPT_ComptesBancaires", "GEN_Items_Id", "dbo.GEN_Items");
            DropForeignKey("dbo.CPT_ComptesBancaires", "GEN_Dossiers_DossierId", "dbo.GEN_Dossier");
            DropForeignKey("dbo.CPT_ComptesBancaires", "GEN_Devises_DevisesId", "dbo.Devise");
            DropForeignKey("dbo.CPT_RelevesBancaires", "GEN_Devises_DevisesId", "dbo.Devise");
            DropForeignKey("dbo.GEN_TypePaiementDetail", "IdTypePaiement", "dbo.TypePaiement");
            DropForeignKey("dbo.GEN_TypePaiementDetail", "GEN_Items_ModePaiement_Id", "dbo.GEN_Items");
            DropForeignKey("dbo.GEN_TypePaiementDetail", "GEN_Items_Delai_Id", "dbo.GEN_Items");
            DropForeignKey("dbo.GEN_TypePaiementDetail", "GEN_Items_DateCalcul_Id", "dbo.GEN_Items");
            DropForeignKey("dbo.GEN_Regelement", "GEN_TypePaiement_TypePaiementId", "dbo.TypePaiement");
            DropForeignKey("dbo.GEN_Regelement", "CPT_Journaux_Id", "dbo.CPT_Journaux");
            DropForeignKey("dbo.CPT_Journaux", "GEN_Items_Id", "dbo.GEN_Items");
            DropForeignKey("dbo.CPT_Journaux", "GEN_Dossiers_DossierId", "dbo.GEN_Dossier");
            DropForeignKey("dbo.CPT_Journaux", "GEN_Devises_DevisesId", "dbo.Devise");
            DropForeignKey("dbo.CPT_Pieces", "GEN_Tiers_Id", "dbo.GEN_Tier");
            DropForeignKey("dbo.CPT_Pieces", "GEN_Dossiers_DossierId", "dbo.GEN_Dossier");
            DropForeignKey("dbo.CPT_Pieces", "GEN_DevisesTR_DevisesId", "dbo.Devise");
            DropForeignKey("dbo.CPT_Pieces", "GEN_DevisesTC_DevisesId", "dbo.Devise");
            DropForeignKey("dbo.CPT_Pieces", "CPT_Journaux_Id", "dbo.CPT_Journaux");
            DropForeignKey("dbo.CPT_Ecritures", "GEN_Tiers_Id", "dbo.GEN_Tier");
            DropForeignKey("dbo.GEN_DossiersSites", "GEN_Dossiers_DossierId", "dbo.GEN_Dossier");
            DropForeignKey("dbo.CPT_Pieces", "GEN_DossiersSites_Id", "dbo.GEN_DossiersSites");
            DropForeignKey("dbo.CPT_Ecritures", "GEN_DossiersSites_Id", "dbo.GEN_DossiersSites");
            DropForeignKey("dbo.CPT_Ecritures", "GEN_Devises_TR_DevisesId", "dbo.Devise");
            DropForeignKey("dbo.CPT_Ecritures", "GEN_Devises_TC_DevisesId", "dbo.Devise");
            DropForeignKey("dbo.CPT_Ecritures", "CPT_Pieces_Id", "dbo.CPT_Pieces");
            DropForeignKey("dbo.CPT_Echeances", "GEN_Items_ModePaiement_Id", "dbo.GEN_Items");
            DropForeignKey("dbo.CPT_TVALettrage", "CPT_Lettrage_Id", "dbo.CPT_Lettrage");
            DropForeignKey("dbo.CPT_Lettrage", "CPT_Echeances_Id", "dbo.CPT_Echeances");
            DropForeignKey("dbo.CPT_Echeances", "CPT_Ecritures_Id", "dbo.CPT_Ecritures");
            DropForeignKey("dbo.CPT_Ecritures", "CPT_CompteG_Id", "dbo.CPT_CompteG");
            DropForeignKey("dbo.CPT_ParametrageComptable", "IdDossier", "dbo.GEN_Dossier");
            DropForeignKey("dbo.CPT_ParametrageComptable", "IdJournalANouveaux", "dbo.CPT_Journaux");
            DropForeignKey("dbo.CPT_ParametrageComptable", "IdCompteDeficit", "dbo.CPT_CompteG");
            DropForeignKey("dbo.CPT_ParametrageComptable", "IdCompteBenefice", "dbo.CPT_CompteG");
            DropForeignKey("dbo.CPT_Journaux", "CPT_CompteG_Id", "dbo.CPT_CompteG");
            DropForeignKey("dbo.TypePaiement", "IdDossier", "dbo.GEN_Dossier");
            DropForeignKey("dbo.CPT_RelevesBancairesDetail", "GEN_TypePaiement_TypePaiementId", "dbo.TypePaiement");
            DropForeignKey("dbo.CPT_RelevesBancairesDetail", "GEN_Tiers_Id", "dbo.GEN_Tier");
            DropForeignKey("dbo.CPT_RelevesBancairesDetail", "GEN_Items_Id", "dbo.GEN_Items");
            DropForeignKey("dbo.CPT_RelevesBancairesDetail", "CPT_RelevesBancaires_Id", "dbo.CPT_RelevesBancaires");
            DropForeignKey("dbo.CPT_RelevesBancairesDetail", "CPT_CompteG_Id", "dbo.CPT_CompteG");
            DropForeignKey("dbo.CPT_RelevesBancaires", "CPT_ComptesBancaires_Id", "dbo.CPT_ComptesBancaires");
            DropForeignKey("dbo.CPT_ComptesBancaires", "CPT_CompteG_Id", "dbo.CPT_CompteG");
            DropForeignKey("dbo.GEN_Tier", "IdCompteCollectifFournisseur", "dbo.CPT_CompteG");
            DropForeignKey("dbo.GEN_Tier", "IdCompteCollectifClient", "dbo.CPT_CompteG");
            DropForeignKey("dbo.Dossier", "GEN_Items_TypeTVA_Id", "dbo.GEN_Items");
            DropForeignKey("dbo.Dossier", "GEN_Items_RebriqueDeclaration_Id", "dbo.GEN_Items");
            DropForeignKey("dbo.Dossier", "IdDossier", "dbo.GEN_Dossier");
            DropForeignKey("dbo.CPT_CompteGDetailTVA", "CPT_CodesTVA_Id", "dbo.Dossier");
            DropForeignKey("dbo.CPT_CompteG", "CPT_CodesTVA_Id", "dbo.Dossier");
            DropForeignKey("dbo.Dossier", "CPT_CompteG_Id", "dbo.CPT_CompteG");
            DropForeignKey("dbo.CPT_CompteG", "CPT_Classe_Id", "dbo.CPT_Classe");
            DropForeignKey("dbo.CPT_Classe", "CPT_Classe_Parent_Id", "dbo.CPT_Classe");
            DropIndex("dbo.GES_Tolerance", new[] { "ToleranceSociete_DossierId" });
            DropIndex("dbo.GES_Impression", new[] { "ImpressionSociete_DossierId" });
            DropIndex("dbo.Famille", new[] { "FamilleSocieteId" });
            DropIndex("dbo.Doclieart", new[] { "DoclieartSocieteId" });
            DropIndex("dbo.Doclie", new[] { "DoclieSocieteId" });
            DropIndex("dbo.Periode", new[] { "PeriodeSocieteId" });
            DropIndex("dbo.Numerotation", new[] { "NumerotationDossierId" });
            DropIndex("dbo.GEN_Numeration", new[] { "GEN_Dossiers_DossierId" });
            DropIndex("dbo.GEN_Preferences", new[] { "GEN_Exercices_Id" });
            DropIndex("dbo.GEN_Preferences", new[] { "GEN_Dossiers_DossierId" });
            DropIndex("dbo.GEN_Periodes", new[] { "GEN_Exercices_Id" });
            DropIndex("dbo.GEN_Exercices", new[] { "GEN_Dossiers_DossierId" });
            DropIndex("dbo.GEN_DossiersContact", new[] { "IdDossier" });
            DropIndex("dbo.GEN_Documents", new[] { "GEN_Dossiers_DossierId" });
            DropIndex("dbo.Reglement", new[] { "ReglementDossierId" });
            DropIndex("dbo.Reglement", new[] { "ReglementBanqueId" });
            DropIndex("dbo.GES_Unite", new[] { "UniteSociete_DossierId" });
            DropIndex("dbo.Nomenclature", new[] { "NomenclatureIdarticle" });
            DropIndex("dbo.GES_Marque", new[] { "MarqueSociete_DossierId" });
            DropIndex("dbo.DocumentCommercialDetailSerie", new[] { "DocumentCommercialDetailSerieDocumentCommercialDetailIdDocumentDetail" });
            DropIndex("dbo.DocumentCommercialDetailSerie", new[] { "DocumentCommercialDetailSerieSocieteId" });
            DropIndex("dbo.DocumentCommercialDetail", new[] { "DocumentCommercialIdDocumentCommercial" });
            DropIndex("dbo.DocumentCommercialDetail", new[] { "DocumentCommercialDetailArticleId" });
            DropIndex("dbo.DocumentCommercial", new[] { "DocumentCommercialSocieteId" });
            DropIndex("dbo.MouvementStock", new[] { "MouvementStockDossierId" });
            DropIndex("dbo.MouvementStock", new[] { "MouvementStockIddepot" });
            DropIndex("dbo.MouvementStock", new[] { "MouvementStockIddocument" });
            DropIndex("dbo.MouvementStock", new[] { "MouvementStockIdarticle" });
            DropIndex("dbo.Depot", new[] { "DepotSocieteId" });
            DropIndex("dbo.Categorie", new[] { "CategorieSocieteId" });
            DropIndex("dbo.ArticlesPrix", new[] { "ArticlesPrixArticleId" });
            DropIndex("dbo.ArticlesKit", new[] { "ArticlesKitArticle1_ArticleId" });
            DropIndex("dbo.ArticlesKit", new[] { "ArticlesKitArticleId1" });
            DropIndex("dbo.Article", new[] { "ArticleMarqueId" });
            DropIndex("dbo.Article", new[] { "ArticleUniteId" });
            DropIndex("dbo.Article", new[] { "ArticleCategorieId" });
            DropIndex("dbo.Article", new[] { "ArticleDepotId" });
            DropIndex("dbo.Article", new[] { "ArticleSocieteId" });
            DropIndex("dbo.FournisseurArticle", new[] { "FournisseurArticleIdfournisseur" });
            DropIndex("dbo.FournisseurArticle", new[] { "FournisseurArticleIdArticle" });
            DropIndex("dbo.Objectif", new[] { "ObjectifDossierId" });
            DropIndex("dbo.Objectif", new[] { "ObjectifRepresentantId" });
            DropIndex("dbo.Representant", new[] { "RepresentantDossierId" });
            DropIndex("dbo.MotifTicket", new[] { "MotifTicketSocieteId" });
            DropIndex("dbo.MotifTicket", new[] { "MotifTicketTiersContactId" });
            DropIndex("dbo.TicketDetail", new[] { "TicketDetailIdcommercial" });
            DropIndex("dbo.TicketDetail", new[] { "TicketDetailIdTicket" });
            DropIndex("dbo.Ticket", new[] { "TicketDossierId" });
            DropIndex("dbo.Ticket", new[] { "TicketIdcontact" });
            DropIndex("dbo.Ticket", new[] { "TicketIdRepresentant" });
            DropIndex("dbo.Ticket", new[] { "TicketIdClient" });
            DropIndex("dbo.tiersContact", new[] { "IdTiers" });
            DropIndex("dbo.OpportuniteDetail", new[] { "OpportuniteDetailIdcommercial" });
            DropIndex("dbo.OpportuniteDetail", new[] { "OpportuniteDetailIdopportunite" });
            DropIndex("dbo.Motif", new[] { "MotifdossierId" });
            DropIndex("dbo.Motif", new[] { "OpportuniteId" });
            DropIndex("dbo.Opportunite", new[] { "OpportuniteDossierd" });
            DropIndex("dbo.Opportunite", new[] { "OpportuniteIdDevise" });
            DropIndex("dbo.Opportunite", new[] { "OpportuniteIdcommercial" });
            DropIndex("dbo.GEN_TypePaiementDetail", new[] { "GEN_Items_ModePaiement_Id" });
            DropIndex("dbo.GEN_TypePaiementDetail", new[] { "GEN_Items_Delai_Id" });
            DropIndex("dbo.GEN_TypePaiementDetail", new[] { "GEN_Items_DateCalcul_Id" });
            DropIndex("dbo.GEN_TypePaiementDetail", new[] { "IdTypePaiement" });
            DropIndex("dbo.GEN_DossiersSites", new[] { "GEN_Dossiers_DossierId" });
            DropIndex("dbo.CPT_TVALettrage", new[] { "CPT_Lettrage_Id" });
            DropIndex("dbo.CPT_Lettrage", new[] { "CPT_Echeances_Id" });
            DropIndex("dbo.CPT_Echeances", new[] { "GEN_Items_ModePaiement_Id" });
            DropIndex("dbo.CPT_Echeances", new[] { "CPT_Ecritures_Id" });
            DropIndex("dbo.CPT_Ecritures", new[] { "GEN_Devises_DevisesId1" });
            DropIndex("dbo.CPT_Ecritures", new[] { "GEN_Devises_DevisesId" });
            DropIndex("dbo.CPT_Ecritures", new[] { "GEN_Tiers_Id" });
            DropIndex("dbo.CPT_Ecritures", new[] { "GEN_DossiersSites_Id" });
            DropIndex("dbo.CPT_Ecritures", new[] { "GEN_Devises_TR_DevisesId" });
            DropIndex("dbo.CPT_Ecritures", new[] { "GEN_Devises_TC_DevisesId" });
            DropIndex("dbo.CPT_Ecritures", new[] { "CPT_Pieces_Id" });
            DropIndex("dbo.CPT_Ecritures", new[] { "CPT_CompteG_Id" });
            DropIndex("dbo.CPT_Pieces", new[] { "GEN_Devises_DevisesId1" });
            DropIndex("dbo.CPT_Pieces", new[] { "GEN_Devises_DevisesId" });
            DropIndex("dbo.CPT_Pieces", new[] { "GEN_Tiers_Id" });
            DropIndex("dbo.CPT_Pieces", new[] { "GEN_Dossiers_DossierId" });
            DropIndex("dbo.CPT_Pieces", new[] { "GEN_DevisesTR_DevisesId" });
            DropIndex("dbo.CPT_Pieces", new[] { "GEN_DevisesTC_DevisesId" });
            DropIndex("dbo.CPT_Pieces", new[] { "CPT_Journaux_Id" });
            DropIndex("dbo.CPT_Pieces", new[] { "GEN_DossiersSites_Id" });
            DropIndex("dbo.CPT_ParametrageComptable", new[] { "IdDossier" });
            DropIndex("dbo.CPT_ParametrageComptable", new[] { "IdCompteDeficit" });
            DropIndex("dbo.CPT_ParametrageComptable", new[] { "IdCompteBenefice" });
            DropIndex("dbo.CPT_ParametrageComptable", new[] { "IdJournalANouveaux" });
            DropIndex("dbo.CPT_Journaux", new[] { "GEN_Items_Id" });
            DropIndex("dbo.CPT_Journaux", new[] { "GEN_Dossiers_DossierId" });
            DropIndex("dbo.CPT_Journaux", new[] { "GEN_Devises_DevisesId" });
            DropIndex("dbo.CPT_Journaux", new[] { "CPT_CompteG_Id" });
            DropIndex("dbo.GEN_Regelement", new[] { "GEN_TypePaiement_TypePaiementId" });
            DropIndex("dbo.GEN_Regelement", new[] { "CPT_Journaux_Id" });
            DropIndex("dbo.TypePaiement", new[] { "IdDossier" });
            DropIndex("dbo.CPT_RelevesBancairesDetail", new[] { "GEN_TypePaiement_TypePaiementId" });
            DropIndex("dbo.CPT_RelevesBancairesDetail", new[] { "GEN_Tiers_Id" });
            DropIndex("dbo.CPT_RelevesBancairesDetail", new[] { "GEN_Items_Id" });
            DropIndex("dbo.CPT_RelevesBancairesDetail", new[] { "CPT_RelevesBancaires_Id" });
            DropIndex("dbo.CPT_RelevesBancairesDetail", new[] { "CPT_CompteG_Id" });
            DropIndex("dbo.CPT_RelevesBancaires", new[] { "GEN_Devises_DevisesId" });
            DropIndex("dbo.CPT_RelevesBancaires", new[] { "CPT_ComptesBancaires_Id" });
            DropIndex("dbo.CPT_ComptesBancaires", new[] { "GEN_Items_Id" });
            DropIndex("dbo.CPT_ComptesBancaires", new[] { "GEN_Dossiers_DossierId" });
            DropIndex("dbo.CPT_ComptesBancaires", new[] { "GEN_Devises_DevisesId" });
            DropIndex("dbo.CPT_ComptesBancaires", new[] { "CPT_CompteG_Id" });
            DropIndex("dbo.Devise", new[] { "GEN_Dossiers_DossierId" });
            DropIndex("dbo.Devise", new[] { "DevisesIdDossier" });
            DropIndex("dbo.CPT_ComptesBancairesTiers", new[] { "GEN_Tiers_Id" });
            DropIndex("dbo.CPT_ComptesBancairesTiers", new[] { "GEN_Devises_DevisesId" });
            DropIndex("dbo.GEN_Tier", new[] { "GES_Representant_RepresentantId" });
            DropIndex("dbo.GEN_Tier", new[] { "GEN_Items_TypeTiers_Id" });
            DropIndex("dbo.GEN_Tier", new[] { "GEN_Items_FormeJuridique_Id" });
            DropIndex("dbo.GEN_Tier", new[] { "GEN_Items_CategorieFiscale_Id" });
            DropIndex("dbo.GEN_Tier", new[] { "TvaSocieteId" });
            DropIndex("dbo.GEN_Tier", new[] { "IdDossier" });
            DropIndex("dbo.GEN_Tier", new[] { "IdCompteCollectifFournisseur" });
            DropIndex("dbo.GEN_Tier", new[] { "IdCompteCollectifClient" });
            DropIndex("dbo.GEN_Tier", new[] { "IdDeviseDefault" });
            DropIndex("dbo.GEN_Tier", new[] { "TypeTiers" });
            DropIndex("dbo.GEN_Items", new[] { "GEN_Model_Id" });
            DropIndex("dbo.CPT_CompteGDetailTVA", new[] { "CPT_CodesTVA_Id" });
            DropIndex("dbo.Dossier", new[] { "GEN_Dossiers_DossierId" });
            DropIndex("dbo.Dossier", new[] { "CPT_CompteG_Id1" });
            DropIndex("dbo.Dossier", new[] { "GEN_Items_TypeTVA_Id" });
            DropIndex("dbo.Dossier", new[] { "GEN_Items_RebriqueDeclaration_Id" });
            DropIndex("dbo.Dossier", new[] { "CPT_CompteG_Id" });
            DropIndex("dbo.Dossier", new[] { "IdDossier" });
            DropIndex("dbo.CPT_CompteG", new[] { "GEN_Items_TypeCompte_Id" });
            DropIndex("dbo.CPT_CompteG", new[] { "GEN_Items_SuiviCompteTVA_Id" });
            DropIndex("dbo.CPT_CompteG", new[] { "GEN_Items_Sens_Id" });
            DropIndex("dbo.CPT_CompteG", new[] { "GEN_Items_ReportANouveau_Id" });
            DropIndex("dbo.CPT_CompteG", new[] { "GEN_Items_NatureCompte_Id" });
            DropIndex("dbo.CPT_CompteG", new[] { "GEN_Dossiers_DossierId" });
            DropIndex("dbo.CPT_CompteG", new[] { "CPT_CodesTVA_CodeTVADefault_Id" });
            DropIndex("dbo.CPT_CompteG", new[] { "CPT_CodesTVA_Id" });
            DropIndex("dbo.CPT_CompteG", new[] { "CPT_Classe_Id" });
            DropIndex("dbo.CPT_Classe", new[] { "GEN_Dossiers_DossierId" });
            DropIndex("dbo.CPT_Classe", new[] { "CPT_Classe_Parent_Id" });
            DropIndex("dbo.Affaire", new[] { "AffaireSocieteId" });
            DropTable("dbo.ReglementFacture");
            DropTable("dbo.GES_Licence");
            DropTable("dbo.GEN_Model");
            DropTable("dbo.Ged");
            DropTable("dbo.GES_Tolerance");
            DropTable("dbo.GES_Impression");
            DropTable("dbo.Famille");
            DropTable("dbo.Doclieart");
            DropTable("dbo.Doclie");
            DropTable("dbo.Periode");
            DropTable("dbo.Numerotation");
            DropTable("dbo.GEN_Numeration");
            DropTable("dbo.GEN_Preferences");
            DropTable("dbo.GEN_Periodes");
            DropTable("dbo.GEN_Exercices");
            DropTable("dbo.GEN_DossiersContact");
            DropTable("dbo.GEN_Documents");
            DropTable("dbo.Reglement");
            DropTable("dbo.GES_Unite");
            DropTable("dbo.Nomenclature");
            DropTable("dbo.GES_Marque");
            DropTable("dbo.DocumentCommercialDetailSerie");
            DropTable("dbo.DocumentCommercialDetail");
            DropTable("dbo.DocumentCommercial");
            DropTable("dbo.MouvementStock");
            DropTable("dbo.Depot");
            DropTable("dbo.Categorie");
            DropTable("dbo.ArticlesPrix");
            DropTable("dbo.ArticlesKit");
            DropTable("dbo.Article");
            DropTable("dbo.FournisseurArticle");
            DropTable("dbo.Objectif");
            DropTable("dbo.Representant");
            DropTable("dbo.MotifTicket");
            DropTable("dbo.TicketDetail");
            DropTable("dbo.Ticket");
            DropTable("dbo.tiersContact");
            DropTable("dbo.OpportuniteDetail");
            DropTable("dbo.Motif");
            DropTable("dbo.Opportunite");
            DropTable("dbo.GEN_TypePaiementDetail");
            DropTable("dbo.GEN_DossiersSites");
            DropTable("dbo.CPT_TVALettrage");
            DropTable("dbo.CPT_Lettrage");
            DropTable("dbo.CPT_Echeances");
            DropTable("dbo.CPT_Ecritures");
            DropTable("dbo.CPT_Pieces");
            DropTable("dbo.CPT_ParametrageComptable");
            DropTable("dbo.CPT_Journaux");
            DropTable("dbo.GEN_Regelement");
            DropTable("dbo.TypePaiement");
            DropTable("dbo.CPT_RelevesBancairesDetail");
            DropTable("dbo.CPT_RelevesBancaires");
            DropTable("dbo.CPT_ComptesBancaires");
            DropTable("dbo.Devise");
            DropTable("dbo.CPT_ComptesBancairesTiers");
            DropTable("dbo.GEN_Tier");
            DropTable("dbo.GEN_Items");
            DropTable("dbo.CPT_CompteGDetailTVA");
            DropTable("dbo.Dossier");
            DropTable("dbo.CPT_CompteG");
            DropTable("dbo.CPT_Classe");
            DropTable("dbo.GEN_Dossier");
            DropTable("dbo.Affaire");
        }
    }
}
