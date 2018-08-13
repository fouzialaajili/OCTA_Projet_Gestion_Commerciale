namespace OCTA_Projet_Gestion_Commerciale.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class un : DbMigration
    {
        public override void Up()
        {
           /* CreateTable(
                "dbo.GES_Admin",
                c => new
                    {
                        AdminId = c.Long(nullable: false, identity: true),
                        AdminLogin = c.String(),
                        AdminPassword = c.String(),
                        AdminActif = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AdminId);
            
            CreateTable(
                "dbo.GES_Affaire",
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
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CPT_Classe", t => t.IdClasse)
                .ForeignKey("dbo.GEN_Dossier", t => t.IdClasse)
                .Index(t => t.IdClasse);
            
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
                        GEN_Items_Id = c.Long(),
                        GEN_Items_Id1 = c.Long(),
                        GEN_Items_Id2 = c.Long(),
                        GEN_Items_Id3 = c.Long(),
                        GEN_Items_Id4 = c.Long(),
                        GEN_Items_NatureCompte_Id = c.Long(),
                        GEN_Items_ReportANouveau_Id = c.Long(),
                        GEN_Items_Sens_Id = c.Long(),
                        GEN_Items_SuiviCompteTVA_Id = c.Long(),
                        GEN_Items_TypeCompte_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CPT_Classe", t => t.IdClasse)
                .ForeignKey("dbo.GEN_Items", t => t.GEN_Items_Id)
                .ForeignKey("dbo.GEN_Items", t => t.GEN_Items_Id1)
                .ForeignKey("dbo.GEN_Items", t => t.GEN_Items_Id2)
                .ForeignKey("dbo.GEN_Items", t => t.GEN_Items_Id3)
                .ForeignKey("dbo.GEN_Items", t => t.GEN_Items_Id4)
                .ForeignKey("dbo.CPT_CodesTVA", t => t.IdCodeTvaDefault)
                .ForeignKey("dbo.GEN_Dossier", t => t.IdDossier)
                .ForeignKey("dbo.GEN_Items", t => t.GEN_Items_NatureCompte_Id)
                .ForeignKey("dbo.GEN_Items", t => t.GEN_Items_ReportANouveau_Id)
                .ForeignKey("dbo.GEN_Items", t => t.GEN_Items_Sens_Id)
                .ForeignKey("dbo.GEN_Items", t => t.GEN_Items_SuiviCompteTVA_Id)
                .ForeignKey("dbo.GEN_Items", t => t.GEN_Items_TypeCompte_Id)
                .Index(t => t.IdClasse)
                .Index(t => t.IdCodeTvaDefault)
                .Index(t => t.IdDossier)
                .Index(t => t.GEN_Items_Id)
                .Index(t => t.GEN_Items_Id1)
                .Index(t => t.GEN_Items_Id2)
                .Index(t => t.GEN_Items_Id3)
                .Index(t => t.GEN_Items_Id4)
                .Index(t => t.GEN_Items_NatureCompte_Id)
                .Index(t => t.GEN_Items_ReportANouveau_Id)
                .Index(t => t.GEN_Items_Sens_Id)
                .Index(t => t.GEN_Items_SuiviCompteTVA_Id)
                .Index(t => t.GEN_Items_TypeCompte_Id);
            
            CreateTable(
                "dbo.CPT_CodesTVA",
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
                        GEN_Dossiers_DossierId = c.Long(),
                        GEN_Items_Id = c.Long(),
                        GEN_Items_Id1 = c.Long(),
                        GEN_Items_RebriqueDeclaration_Id = c.Long(),
                        GEN_Items_TypeTVA_Id = c.Long(),
                        GEN_Dossiers_DossierId1 = c.Long(),
                        GEN_Dossiers_DossierId2 = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CPT_CompteG", t => t.CPT_CompteG_Id)
                .ForeignKey("dbo.GEN_Dossier", t => t.GEN_Dossiers_DossierId)
                .ForeignKey("dbo.GEN_Items", t => t.GEN_Items_Id)
                .ForeignKey("dbo.GEN_Items", t => t.GEN_Items_Id1)
                .ForeignKey("dbo.GEN_Items", t => t.GEN_Items_RebriqueDeclaration_Id)
                .ForeignKey("dbo.GEN_Items", t => t.GEN_Items_TypeTVA_Id)
                .ForeignKey("dbo.GEN_Dossier", t => t.GEN_Dossiers_DossierId1)
                .ForeignKey("dbo.GEN_Dossier", t => t.GEN_Dossiers_DossierId2)
                .Index(t => t.CPT_CompteG_Id)
                .Index(t => t.GEN_Dossiers_DossierId)
                .Index(t => t.GEN_Items_Id)
                .Index(t => t.GEN_Items_Id1)
                .Index(t => t.GEN_Items_RebriqueDeclaration_Id)
                .Index(t => t.GEN_Items_TypeTVA_Id)
                .Index(t => t.GEN_Dossiers_DossierId1)
                .Index(t => t.GEN_Dossiers_DossierId2);
            
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
                .ForeignKey("dbo.CPT_CodesTVA", t => t.CPT_CodesTVA_Id)
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
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GEN_Model", t => t.IdModel)
                .Index(t => t.IdModel);
            
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
                .ForeignKey("dbo.GEN_Devise", t => t.GEN_Devises_DevisesId)
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
                        IdDevise = c.Long(),
                        Description = c.String(),
                        SoldeDebut = c.Double(),
                        SoldeFin = c.Double(),
                        Valide = c.Boolean(nullable: false),
                        IdDossier = c.Long(),
                        sys_user = c.String(),
                        sys_dateUpdate = c.DateTime(),
                        sys_dateCreation = c.DateTime(),
                        Fichier = c.Binary(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CPT_ComptesBancaires", t => t.IdCompteBancaire)
                .ForeignKey("dbo.GEN_Devise", t => t.IdDevise)
                .Index(t => t.IdCompteBancaire)
                .Index(t => t.IdDevise);
            
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
                        GEN_TypePaiement_TypePaiementId = c.Long(),
                        GEN_Tiers_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CPT_CompteG", t => t.CPT_CompteG_Id)
                .ForeignKey("dbo.CPT_RelevesBancaires", t => t.CPT_RelevesBancaires_Id)
                .ForeignKey("dbo.GEN_Items", t => t.GEN_Items_Id)
                .ForeignKey("dbo.GEN_TypePaiement", t => t.GEN_TypePaiement_TypePaiementId)
                .ForeignKey("dbo.GEN_Tiers", t => t.GEN_Tiers_Id)
                .Index(t => t.CPT_CompteG_Id)
                .Index(t => t.CPT_RelevesBancaires_Id)
                .Index(t => t.GEN_Items_Id)
                .Index(t => t.GEN_TypePaiement_TypePaiementId)
                .Index(t => t.GEN_Tiers_Id);
            
            CreateTable(
                "dbo.GEN_Tiers",
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
                        Ville = c.String(),
                        SiteWeb = c.String(),
                        CapitalSocial = c.String(),
                        Pays = c.String(),
                        TypeTierCode = c.String(),
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
                        GEN_Items_CategorieFiscale_Id = c.Long(),
                        GEN_Items_FormeJuridique_Id = c.Long(),
                        GEN_Items_TypeTiers_Id = c.Long(),
                        GEN_Items_Id = c.Long(),
                        GEN_Items_Id1 = c.Long(),
                        GEN_Items_Id2 = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CPT_CompteG", t => t.IdCompteCollectifClient)
                .ForeignKey("dbo.CPT_CompteG", t => t.IdCompteCollectifFournisseur)
                .ForeignKey("dbo.GEN_Devise", t => t.IdDeviseDefault)
                .ForeignKey("dbo.GEN_Dossier", t => t.IdDossier)
                .ForeignKey("dbo.GEN_Items", t => t.GEN_Items_CategorieFiscale_Id)
                .ForeignKey("dbo.GEN_Items", t => t.GEN_Items_FormeJuridique_Id)
                .ForeignKey("dbo.GEN_Items", t => t.GEN_Items_TypeTiers_Id)
                .ForeignKey("dbo.GEN_TypePaiement", t => t.IdEcheancement)
                .ForeignKey("dbo.GEN_Items", t => t.GEN_Items_Id)
                .ForeignKey("dbo.GEN_Items", t => t.GEN_Items_Id1)
                .ForeignKey("dbo.GEN_Items", t => t.GEN_Items_Id2)
                .Index(t => t.IdDeviseDefault)
                .Index(t => t.IdCompteCollectifClient)
                .Index(t => t.IdCompteCollectifFournisseur)
                .Index(t => t.IdEcheancement)
                .Index(t => t.IdDossier)
                .Index(t => t.GEN_Items_CategorieFiscale_Id)
                .Index(t => t.GEN_Items_FormeJuridique_Id)
                .Index(t => t.GEN_Items_TypeTiers_Id)
                .Index(t => t.GEN_Items_Id)
                .Index(t => t.GEN_Items_Id1)
                .Index(t => t.GEN_Items_Id2);
            
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
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GEN_Devise", t => t.IdDevise)
                .ForeignKey("dbo.GEN_Tiers", t => t.IdTiers)
                .Index(t => t.IdDevise)
                .Index(t => t.IdTiers);
            
            CreateTable(
                "dbo.GEN_Devise",
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
                    })
                .PrimaryKey(t => t.DevisesId)
                .ForeignKey("dbo.GEN_Dossier", t => t.DevisesIdDossier)
                .Index(t => t.DevisesIdDossier);
            
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
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CPT_CompteG", t => t.IdCompteG)
                .ForeignKey("dbo.CPT_Pieces", t => t.IdPiece)
                .ForeignKey("dbo.GEN_Devise", t => t.IdDeviceTC)
                .ForeignKey("dbo.GEN_Devise", t => t.IdDeviceTR)
                .ForeignKey("dbo.GEN_DossiersSites", t => t.IdDossierSite)
                .ForeignKey("dbo.GEN_Tiers", t => t.IdDossierSite)
                .Index(t => t.IdPiece)
                .Index(t => t.IdCompteG)
                .Index(t => t.IdDeviceTC)
                .Index(t => t.IdDeviceTR)
                .Index(t => t.IdDossierSite);
            
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
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CPT_Echeances", t => t.IdEcheance)
                .Index(t => t.IdEcheance);
            
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
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CPT_Lettrage", t => t.LettrageId)
                .Index(t => t.LettrageId);
            
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
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CPT_Journaux", t => t.IdJournal)
                .ForeignKey("dbo.GEN_Devise", t => t.IdDeviseTC)
                .ForeignKey("dbo.GEN_Devise", t => t.IdDeviseTR)
                .ForeignKey("dbo.GEN_Dossier", t => t.IdDossier)
                .ForeignKey("dbo.GEN_DossiersSites", t => t.IdDossierSite)
                .ForeignKey("dbo.GEN_Tiers", t => t.IdTiers)
                .Index(t => t.IdTiers)
                .Index(t => t.IdJournal)
                .Index(t => t.IdDeviseTC)
                .Index(t => t.IdDeviseTR)
                .Index(t => t.IdDossier)
                .Index(t => t.IdDossierSite);
            
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
                .ForeignKey("dbo.GEN_Devise", t => t.GEN_Devises_DevisesId)
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
                        Id = c.Long(nullable: false, identity: true),
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CPT_CompteG", t => t.IdCompteBenefice)
                .ForeignKey("dbo.CPT_CompteG", t => t.IdCompteDeficit)
                .ForeignKey("dbo.CPT_Journaux", t => t.IdJournalANouveaux)
                .ForeignKey("dbo.GEN_Dossier", t => t.IdDossier)
                .Index(t => t.IdJournalANouveaux)
                .Index(t => t.IdCompteBenefice)
                .Index(t => t.IdCompteDeficit)
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
                .ForeignKey("dbo.GEN_TypePaiement", t => t.GEN_TypePaiement_TypePaiementId)
                .Index(t => t.CPT_Journaux_Id)
                .Index(t => t.GEN_TypePaiement_TypePaiementId);
            
            CreateTable(
                "dbo.GEN_TypePaiement",
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
                    })
                .PrimaryKey(t => t.TypePaiementDetailId)
                .ForeignKey("dbo.GEN_Items", t => t.DateCalcul)
                .ForeignKey("dbo.GEN_Items", t => t.Delai)
                .ForeignKey("dbo.GEN_Items", t => t.IdModePaiement)
                .ForeignKey("dbo.GEN_TypePaiement", t => t.IdTypePaiement)
                .Index(t => t.IdTypePaiement)
                .Index(t => t.IdModePaiement)
                .Index(t => t.DateCalcul)
                .Index(t => t.Delai);
            
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
                "dbo.GES_Opportunite",
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
                .ForeignKey("dbo.GEN_Devise", t => t.OpportuniteIdDevise)
                .ForeignKey("dbo.GEN_Dossier", t => t.OpportuniteDossierd)
                .ForeignKey("dbo.GEN_Tiers", t => t.OpportuniteIdcommercial)
                .Index(t => t.OpportuniteIdcommercial)
                .Index(t => t.OpportuniteIdDevise)
                .Index(t => t.OpportuniteDossierd);
            
            CreateTable(
                "dbo.GES_Motif",
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
                .ForeignKey("dbo.GES_Opportunite", t => t.OpportuniteId)
                .ForeignKey("dbo.GEN_Dossier", t => t.MotifdossierId)
                .Index(t => t.OpportuniteId)
                .Index(t => t.MotifdossierId);
            
            CreateTable(
                "dbo.GES_OpportuniteDetail",
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
                .ForeignKey("dbo.GEN_Tiers", t => t.OpportuniteDetailIdcommercial)
                .ForeignKey("dbo.GES_Opportunite", t => t.OpportuniteDetailIdopportunite)
                .Index(t => t.OpportuniteDetailIdopportunite)
                .Index(t => t.OpportuniteDetailIdcommercial);
            
            CreateTable(
                "dbo.GEN_TiersContacts",
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
                .ForeignKey("dbo.GEN_Tiers", t => t.IdTiers)
                .Index(t => t.IdTiers);
            
            CreateTable(
                "dbo.GES_Ticket",
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
                .ForeignKey("dbo.GEN_Tiers", t => t.TicketIdClient)
                .ForeignKey("dbo.GEN_TiersContacts", t => t.TicketIdcontact)
                .ForeignKey("dbo.GES_Representant", t => t.TicketIdRepresentant)
                .Index(t => t.TicketIdClient)
                .Index(t => t.TicketIdRepresentant)
                .Index(t => t.TicketIdcontact)
                .Index(t => t.TicketDossierId);
            
            CreateTable(
                "dbo.GES_TicketDetail",
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
                .ForeignKey("dbo.GEN_Tiers", t => t.TicketDetailIdcommercial)
                .ForeignKey("dbo.GES_Ticket", t => t.TicketDetailIdTicket)
                .Index(t => t.TicketDetailIdTicket)
                .Index(t => t.TicketDetailIdcommercial);
            
            CreateTable(
                "dbo.GES_MotifTicket",
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
                .ForeignKey("dbo.GES_Ticket", t => t.MotifTicketTiersContactId)
                .Index(t => t.MotifTicketTiersContactId)
                .Index(t => t.MotifTicketSocieteId);
            
            CreateTable(
                "dbo.GES_Representant",
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
                "dbo.GES_Objectif",
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
                .ForeignKey("dbo.GES_Representant", t => t.ObjectifRepresentantId)
                .Index(t => t.ObjectifRepresentantId)
                .Index(t => t.ObjectifDossierId);
            
            CreateTable(
                "dbo.GES_FournisseurArticle",
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
                .ForeignKey("dbo.GES_Article", t => t.FournisseurArticleIdArticle)
                .ForeignKey("dbo.GEN_Tiers", t => t.FournisseurArticleIdfournisseur)
                .Index(t => t.FournisseurArticleIdArticle)
                .Index(t => t.FournisseurArticleIdfournisseur);
            
            CreateTable(
                "dbo.GES_Article",
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
                .ForeignKey("dbo.GES_Categorie", t => t.ArticleCategorieId)
                .ForeignKey("dbo.GES_Depot", t => t.ArticleDepotId)
                .ForeignKey("dbo.GES_Marque", t => t.ArticleMarqueId)
                .ForeignKey("dbo.GEN_Dossier", t => t.ArticleSocieteId)
                .ForeignKey("dbo.GES_Unite", t => t.ArticleUniteId)
                .Index(t => t.ArticleSocieteId)
                .Index(t => t.ArticleDepotId)
                .Index(t => t.ArticleCategorieId)
                .Index(t => t.ArticleUniteId)
                .Index(t => t.ArticleMarqueId);
            
            CreateTable(
                "dbo.GES_ArticlesKit",
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
                .ForeignKey("dbo.GES_Article", t => t.ArticlesKitArticleId1)
                .ForeignKey("dbo.GES_Article", t => t.ArticlesKitArticle1_ArticleId)
                .Index(t => t.ArticlesKitArticleId1)
                .Index(t => t.ArticlesKitArticle1_ArticleId);
            
            CreateTable(
                "dbo.GES_ArticlesPrix",
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
                .ForeignKey("dbo.GES_Article", t => t.ArticlesPrixArticleId)
                .Index(t => t.ArticlesPrixArticleId);
            
            CreateTable(
                "dbo.GES_Categorie",
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
                "dbo.GES_Depot",
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
                "dbo.GES_MouvementStock",
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
                .ForeignKey("dbo.GES_Article", t => t.MouvementStockIdarticle)
                .ForeignKey("dbo.GES_DocumentCommercial", t => t.MouvementStockIddocument)
                .ForeignKey("dbo.GES_Depot", t => t.MouvementStockIddepot)
                .ForeignKey("dbo.GEN_Dossier", t => t.MouvementStockDossierId)
                .Index(t => t.MouvementStockIdarticle)
                .Index(t => t.MouvementStockIddocument)
                .Index(t => t.MouvementStockIddepot)
                .Index(t => t.MouvementStockDossierId);
            
            CreateTable(
                "dbo.GES_DocumentCommercial",
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
                "dbo.GES_DocumentCommercialDetail",
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
                .ForeignKey("dbo.GES_Article", t => t.DocumentCommercialDetailArticleId)
                .ForeignKey("dbo.GES_DocumentCommercial", t => t.DocumentCommercialIdDocumentCommercial)
                .Index(t => t.DocumentCommercialDetailArticleId)
                .Index(t => t.DocumentCommercialIdDocumentCommercial);
            
            CreateTable(
                "dbo.GES_DocumentCommercialDetailSerie",
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
                .ForeignKey("dbo.GES_DocumentCommercialDetail", t => t.DocumentCommercialDetailSerieDocumentCommercialDetailIdDocumentDetail)
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
                "dbo.GES_Nomenclature",
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
                .ForeignKey("dbo.GES_Article", t => t.NomenclatureIdarticle)
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
                "dbo.GES_Reglement",
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
                .ForeignKey("dbo.GEN_Tiers", t => t.ReglementBanqueId)
                .Index(t => t.ReglementBanqueId)
                .Index(t => t.ReglementDossierId);
            
            CreateTable(
                "dbo.GEN_Model",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Model = c.String(),
                        IdDossier = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GEN_Dossier", t => t.IdDossier)
                .Index(t => t.IdDossier);
            
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
                "dbo.GES_Numerotation",
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
                "dbo.GES_Periode",
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
                "dbo.GES_Doclie",
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
                "dbo.GES_Doclieart",
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
                "dbo.GES_Famille",
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
                "dbo.GES_Ged",
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
                "dbo.CPT_NatureOperation",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        NatureOperationNom = c.String(),
                        ATraiter = c.Boolean(nullable: false),
                        GenererFactureAchat = c.Boolean(nullable: false),
                        GenererFactureVente = c.Boolean(nullable: false),
                        GenererReglement = c.Boolean(nullable: false),
                        AvecTVA = c.Boolean(nullable: false),
                        AvecTier = c.Boolean(nullable: false),
                        Sens = c.Long(),
                        Montant = c.Long(),
                        IsCommission = c.Boolean(nullable: false),
                        AutoriseRegroupement = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CPT_PlanAnalytique",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Code = c.String(),
                        Libelle = c.String(),
                        IdPlanAnalytique = c.Long(),
                        IdDossier = c.Long(),
                        sys_user = c.String(),
                        sys_dateUpdate = c.DateTime(),
                        sys_dateCreation = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GES_ReglementFacture",
                c => new
                    {
                        ReglementFactureId = c.Long(nullable: false, identity: true),
                        ReglementId = c.Long(),
                        ReglementFactureIdfacture = c.Long(),
                        ReglementFacturePaye = c.Long(),
                    })
                .PrimaryKey(t => t.ReglementFactureId);*/
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GES_Affaire", "AffaireSocieteId", "dbo.GEN_Dossier");
            DropForeignKey("dbo.CPT_CodesTVA", "GEN_Dossiers_DossierId2", "dbo.GEN_Dossier");
            DropForeignKey("dbo.GES_Tolerance", "ToleranceSociete_DossierId", "dbo.GEN_Dossier");
            DropForeignKey("dbo.GES_Impression", "ImpressionSociete_DossierId", "dbo.GEN_Dossier");
            DropForeignKey("dbo.GES_Famille", "FamilleSocieteId", "dbo.GEN_Dossier");
            DropForeignKey("dbo.GES_Doclieart", "DoclieartSocieteId", "dbo.GEN_Dossier");
            DropForeignKey("dbo.GES_Doclie", "DoclieSocieteId", "dbo.GEN_Dossier");
            DropForeignKey("dbo.GES_Periode", "PeriodeSocieteId", "dbo.GEN_Dossier");
            DropForeignKey("dbo.GES_Numerotation", "NumerotationDossierId", "dbo.GEN_Dossier");
            DropForeignKey("dbo.GEN_Numeration", "GEN_Dossiers_DossierId", "dbo.GEN_Dossier");
            DropForeignKey("dbo.GEN_Preferences", "GEN_Exercices_Id", "dbo.GEN_Exercices");
            DropForeignKey("dbo.GEN_Preferences", "GEN_Dossiers_DossierId", "dbo.GEN_Dossier");
            DropForeignKey("dbo.GEN_Periodes", "GEN_Exercices_Id", "dbo.GEN_Exercices");
            DropForeignKey("dbo.GEN_Exercices", "GEN_Dossiers_DossierId", "dbo.GEN_Dossier");
            DropForeignKey("dbo.GEN_DossiersContact", "IdDossier", "dbo.GEN_Dossier");
            DropForeignKey("dbo.GEN_Documents", "GEN_Dossiers_DossierId", "dbo.GEN_Dossier");
            DropForeignKey("dbo.CPT_CodesTVA", "GEN_Dossiers_DossierId1", "dbo.GEN_Dossier");
            DropForeignKey("dbo.CPT_Classe", "IdClasse", "dbo.GEN_Dossier");
            DropForeignKey("dbo.CPT_CompteG", "GEN_Items_TypeCompte_Id", "dbo.GEN_Items");
            DropForeignKey("dbo.CPT_CompteG", "GEN_Items_SuiviCompteTVA_Id", "dbo.GEN_Items");
            DropForeignKey("dbo.CPT_CompteG", "GEN_Items_Sens_Id", "dbo.GEN_Items");
            DropForeignKey("dbo.CPT_CompteG", "GEN_Items_ReportANouveau_Id", "dbo.GEN_Items");
            DropForeignKey("dbo.CPT_CompteG", "GEN_Items_NatureCompte_Id", "dbo.GEN_Items");
            DropForeignKey("dbo.CPT_CompteG", "IdDossier", "dbo.GEN_Dossier");
            DropForeignKey("dbo.CPT_CompteG", "IdCodeTvaDefault", "dbo.CPT_CodesTVA");
            DropForeignKey("dbo.CPT_CodesTVA", "GEN_Items_TypeTVA_Id", "dbo.GEN_Items");
            DropForeignKey("dbo.CPT_CodesTVA", "GEN_Items_RebriqueDeclaration_Id", "dbo.GEN_Items");
            DropForeignKey("dbo.GEN_Tiers", "GEN_Items_Id2", "dbo.GEN_Items");
            DropForeignKey("dbo.GEN_Tiers", "GEN_Items_Id1", "dbo.GEN_Items");
            DropForeignKey("dbo.GEN_Tiers", "GEN_Items_Id", "dbo.GEN_Items");
            DropForeignKey("dbo.GEN_Items", "IdModel", "dbo.GEN_Model");
            DropForeignKey("dbo.GEN_Model", "IdDossier", "dbo.GEN_Dossier");
            DropForeignKey("dbo.CPT_ComptesBancaires", "GEN_Items_Id", "dbo.GEN_Items");
            DropForeignKey("dbo.CPT_ComptesBancaires", "GEN_Dossiers_DossierId", "dbo.GEN_Dossier");
            DropForeignKey("dbo.CPT_RelevesBancaires", "IdDevise", "dbo.GEN_Devise");
            DropForeignKey("dbo.GES_Reglement", "ReglementBanqueId", "dbo.GEN_Tiers");
            DropForeignKey("dbo.GES_Reglement", "ReglementDossierId", "dbo.GEN_Dossier");
            DropForeignKey("dbo.GES_FournisseurArticle", "FournisseurArticleIdfournisseur", "dbo.GEN_Tiers");
            DropForeignKey("dbo.GES_FournisseurArticle", "FournisseurArticleIdArticle", "dbo.GES_Article");
            DropForeignKey("dbo.GES_Article", "ArticleUniteId", "dbo.GES_Unite");
            DropForeignKey("dbo.GES_Unite", "UniteSociete_DossierId", "dbo.GEN_Dossier");
            DropForeignKey("dbo.GES_Article", "ArticleSocieteId", "dbo.GEN_Dossier");
            DropForeignKey("dbo.GES_Nomenclature", "NomenclatureIdarticle", "dbo.GES_Article");
            DropForeignKey("dbo.GES_Article", "ArticleMarqueId", "dbo.GES_Marque");
            DropForeignKey("dbo.GES_Marque", "MarqueSociete_DossierId", "dbo.GEN_Dossier");
            DropForeignKey("dbo.GES_Article", "ArticleDepotId", "dbo.GES_Depot");
            DropForeignKey("dbo.GES_Depot", "DepotSocieteId", "dbo.GEN_Dossier");
            DropForeignKey("dbo.GES_MouvementStock", "MouvementStockDossierId", "dbo.GEN_Dossier");
            DropForeignKey("dbo.GES_MouvementStock", "MouvementStockIddepot", "dbo.GES_Depot");
            DropForeignKey("dbo.GES_MouvementStock", "MouvementStockIddocument", "dbo.GES_DocumentCommercial");
            DropForeignKey("dbo.GES_DocumentCommercial", "DocumentCommercialSocieteId", "dbo.GEN_Dossier");
            DropForeignKey("dbo.GES_DocumentCommercialDetailSerie", "DocumentCommercialDetailSerieSocieteId", "dbo.GEN_Dossier");
            DropForeignKey("dbo.GES_DocumentCommercialDetailSerie", "DocumentCommercialDetailSerieDocumentCommercialDetailIdDocumentDetail", "dbo.GES_DocumentCommercialDetail");
            DropForeignKey("dbo.GES_DocumentCommercialDetail", "DocumentCommercialIdDocumentCommercial", "dbo.GES_DocumentCommercial");
            DropForeignKey("dbo.GES_DocumentCommercialDetail", "DocumentCommercialDetailArticleId", "dbo.GES_Article");
            DropForeignKey("dbo.GES_MouvementStock", "MouvementStockIdarticle", "dbo.GES_Article");
            DropForeignKey("dbo.GES_Article", "ArticleCategorieId", "dbo.GES_Categorie");
            DropForeignKey("dbo.GES_Categorie", "CategorieSocieteId", "dbo.GEN_Dossier");
            DropForeignKey("dbo.GES_ArticlesPrix", "ArticlesPrixArticleId", "dbo.GES_Article");
            DropForeignKey("dbo.GES_ArticlesKit", "ArticlesKitArticle1_ArticleId", "dbo.GES_Article");
            DropForeignKey("dbo.GES_ArticlesKit", "ArticlesKitArticleId1", "dbo.GES_Article");
            DropForeignKey("dbo.GEN_Tiers", "IdEcheancement", "dbo.GEN_TypePaiement");
            DropForeignKey("dbo.GES_Ticket", "TicketIdRepresentant", "dbo.GES_Representant");
            DropForeignKey("dbo.GES_Objectif", "ObjectifRepresentantId", "dbo.GES_Representant");
            DropForeignKey("dbo.GES_Objectif", "ObjectifDossierId", "dbo.GEN_Dossier");
            DropForeignKey("dbo.GES_Representant", "RepresentantDossierId", "dbo.GEN_Dossier");
            DropForeignKey("dbo.GES_MotifTicket", "MotifTicketTiersContactId", "dbo.GES_Ticket");
            DropForeignKey("dbo.GES_MotifTicket", "MotifTicketSocieteId", "dbo.GEN_Dossier");
            DropForeignKey("dbo.GES_Ticket", "TicketIdcontact", "dbo.GEN_TiersContacts");
            DropForeignKey("dbo.GES_Ticket", "TicketIdClient", "dbo.GEN_Tiers");
            DropForeignKey("dbo.GES_Ticket", "TicketDossierId", "dbo.GEN_Dossier");
            DropForeignKey("dbo.GES_TicketDetail", "TicketDetailIdTicket", "dbo.GES_Ticket");
            DropForeignKey("dbo.GES_TicketDetail", "TicketDetailIdcommercial", "dbo.GEN_Tiers");
            DropForeignKey("dbo.GEN_TiersContacts", "IdTiers", "dbo.GEN_Tiers");
            DropForeignKey("dbo.GEN_Tiers", "GEN_Items_TypeTiers_Id", "dbo.GEN_Items");
            DropForeignKey("dbo.GEN_Tiers", "GEN_Items_FormeJuridique_Id", "dbo.GEN_Items");
            DropForeignKey("dbo.GEN_Tiers", "GEN_Items_CategorieFiscale_Id", "dbo.GEN_Items");
            DropForeignKey("dbo.GEN_Tiers", "IdDossier", "dbo.GEN_Dossier");
            DropForeignKey("dbo.GEN_Tiers", "IdDeviseDefault", "dbo.GEN_Devise");
            DropForeignKey("dbo.CPT_RelevesBancairesDetail", "GEN_Tiers_Id", "dbo.GEN_Tiers");
            DropForeignKey("dbo.CPT_ComptesBancairesTiers", "IdTiers", "dbo.GEN_Tiers");
            DropForeignKey("dbo.CPT_ComptesBancairesTiers", "IdDevise", "dbo.GEN_Devise");
            DropForeignKey("dbo.GES_OpportuniteDetail", "OpportuniteDetailIdopportunite", "dbo.GES_Opportunite");
            DropForeignKey("dbo.GES_OpportuniteDetail", "OpportuniteDetailIdcommercial", "dbo.GEN_Tiers");
            DropForeignKey("dbo.GES_Motif", "MotifdossierId", "dbo.GEN_Dossier");
            DropForeignKey("dbo.GES_Motif", "OpportuniteId", "dbo.GES_Opportunite");
            DropForeignKey("dbo.GES_Opportunite", "OpportuniteIdcommercial", "dbo.GEN_Tiers");
            DropForeignKey("dbo.GES_Opportunite", "OpportuniteDossierd", "dbo.GEN_Dossier");
            DropForeignKey("dbo.GES_Opportunite", "OpportuniteIdDevise", "dbo.GEN_Devise");
            DropForeignKey("dbo.GEN_Devise", "DevisesIdDossier", "dbo.GEN_Dossier");
            DropForeignKey("dbo.CPT_Ecritures", "IdDossierSite", "dbo.GEN_Tiers");
            DropForeignKey("dbo.CPT_Ecritures", "IdDossierSite", "dbo.GEN_DossiersSites");
            DropForeignKey("dbo.CPT_Ecritures", "IdDeviceTR", "dbo.GEN_Devise");
            DropForeignKey("dbo.CPT_Ecritures", "IdDeviceTC", "dbo.GEN_Devise");
            DropForeignKey("dbo.CPT_Ecritures", "IdPiece", "dbo.CPT_Pieces");
            DropForeignKey("dbo.CPT_Pieces", "IdTiers", "dbo.GEN_Tiers");
            DropForeignKey("dbo.CPT_Pieces", "IdDossierSite", "dbo.GEN_DossiersSites");
            DropForeignKey("dbo.GEN_DossiersSites", "GEN_Dossiers_DossierId", "dbo.GEN_Dossier");
            DropForeignKey("dbo.CPT_Pieces", "IdDossier", "dbo.GEN_Dossier");
            DropForeignKey("dbo.CPT_Pieces", "IdDeviseTR", "dbo.GEN_Devise");
            DropForeignKey("dbo.CPT_Pieces", "IdDeviseTC", "dbo.GEN_Devise");
            DropForeignKey("dbo.CPT_Pieces", "IdJournal", "dbo.CPT_Journaux");
            DropForeignKey("dbo.GEN_TypePaiementDetail", "IdTypePaiement", "dbo.GEN_TypePaiement");
            DropForeignKey("dbo.GEN_TypePaiementDetail", "IdModePaiement", "dbo.GEN_Items");
            DropForeignKey("dbo.GEN_TypePaiementDetail", "Delai", "dbo.GEN_Items");
            DropForeignKey("dbo.GEN_TypePaiementDetail", "DateCalcul", "dbo.GEN_Items");
            DropForeignKey("dbo.GEN_Regelement", "GEN_TypePaiement_TypePaiementId", "dbo.GEN_TypePaiement");
            DropForeignKey("dbo.GEN_TypePaiement", "IdDossier", "dbo.GEN_Dossier");
            DropForeignKey("dbo.CPT_RelevesBancairesDetail", "GEN_TypePaiement_TypePaiementId", "dbo.GEN_TypePaiement");
            DropForeignKey("dbo.GEN_Regelement", "CPT_Journaux_Id", "dbo.CPT_Journaux");
            DropForeignKey("dbo.CPT_Journaux", "GEN_Items_Id", "dbo.GEN_Items");
            DropForeignKey("dbo.CPT_Journaux", "GEN_Dossiers_DossierId", "dbo.GEN_Dossier");
            DropForeignKey("dbo.CPT_Journaux", "GEN_Devises_DevisesId", "dbo.GEN_Devise");
            DropForeignKey("dbo.CPT_ParametrageComptable", "IdDossier", "dbo.GEN_Dossier");
            DropForeignKey("dbo.CPT_ParametrageComptable", "IdJournalANouveaux", "dbo.CPT_Journaux");
            DropForeignKey("dbo.CPT_ParametrageComptable", "IdCompteDeficit", "dbo.CPT_CompteG");
            DropForeignKey("dbo.CPT_ParametrageComptable", "IdCompteBenefice", "dbo.CPT_CompteG");
            DropForeignKey("dbo.CPT_Journaux", "CPT_CompteG_Id", "dbo.CPT_CompteG");
            DropForeignKey("dbo.CPT_Echeances", "GEN_Items_ModePaiement_Id", "dbo.GEN_Items");
            DropForeignKey("dbo.CPT_TVALettrage", "LettrageId", "dbo.CPT_Lettrage");
            DropForeignKey("dbo.CPT_Lettrage", "IdEcheance", "dbo.CPT_Echeances");
            DropForeignKey("dbo.CPT_Echeances", "CPT_Ecritures_Id", "dbo.CPT_Ecritures");
            DropForeignKey("dbo.CPT_Ecritures", "IdCompteG", "dbo.CPT_CompteG");
            DropForeignKey("dbo.CPT_ComptesBancaires", "GEN_Devises_DevisesId", "dbo.GEN_Devise");
            DropForeignKey("dbo.GEN_Tiers", "IdCompteCollectifFournisseur", "dbo.CPT_CompteG");
            DropForeignKey("dbo.GEN_Tiers", "IdCompteCollectifClient", "dbo.CPT_CompteG");
            DropForeignKey("dbo.CPT_RelevesBancairesDetail", "GEN_Items_Id", "dbo.GEN_Items");
            DropForeignKey("dbo.CPT_RelevesBancairesDetail", "CPT_RelevesBancaires_Id", "dbo.CPT_RelevesBancaires");
            DropForeignKey("dbo.CPT_RelevesBancairesDetail", "CPT_CompteG_Id", "dbo.CPT_CompteG");
            DropForeignKey("dbo.CPT_RelevesBancaires", "IdCompteBancaire", "dbo.CPT_ComptesBancaires");
            DropForeignKey("dbo.CPT_ComptesBancaires", "CPT_CompteG_Id", "dbo.CPT_CompteG");
            DropForeignKey("dbo.CPT_CompteG", "GEN_Items_Id4", "dbo.GEN_Items");
            DropForeignKey("dbo.CPT_CompteG", "GEN_Items_Id3", "dbo.GEN_Items");
            DropForeignKey("dbo.CPT_CompteG", "GEN_Items_Id2", "dbo.GEN_Items");
            DropForeignKey("dbo.CPT_CompteG", "GEN_Items_Id1", "dbo.GEN_Items");
            DropForeignKey("dbo.CPT_CompteG", "GEN_Items_Id", "dbo.GEN_Items");
            DropForeignKey("dbo.CPT_CodesTVA", "GEN_Items_Id1", "dbo.GEN_Items");
            DropForeignKey("dbo.CPT_CodesTVA", "GEN_Items_Id", "dbo.GEN_Items");
            DropForeignKey("dbo.CPT_CodesTVA", "GEN_Dossiers_DossierId", "dbo.GEN_Dossier");
            DropForeignKey("dbo.CPT_CompteGDetailTVA", "CPT_CodesTVA_Id", "dbo.CPT_CodesTVA");
            DropForeignKey("dbo.CPT_CodesTVA", "CPT_CompteG_Id", "dbo.CPT_CompteG");
            DropForeignKey("dbo.CPT_CompteG", "IdClasse", "dbo.CPT_Classe");
            DropForeignKey("dbo.CPT_Classe", "IdClasse", "dbo.CPT_Classe");
            DropIndex("dbo.GES_Tolerance", new[] { "ToleranceSociete_DossierId" });
            DropIndex("dbo.GES_Impression", new[] { "ImpressionSociete_DossierId" });
            DropIndex("dbo.GES_Famille", new[] { "FamilleSocieteId" });
            DropIndex("dbo.GES_Doclieart", new[] { "DoclieartSocieteId" });
            DropIndex("dbo.GES_Doclie", new[] { "DoclieSocieteId" });
            DropIndex("dbo.GES_Periode", new[] { "PeriodeSocieteId" });
            DropIndex("dbo.GES_Numerotation", new[] { "NumerotationDossierId" });
            DropIndex("dbo.GEN_Numeration", new[] { "GEN_Dossiers_DossierId" });
            DropIndex("dbo.GEN_Preferences", new[] { "GEN_Exercices_Id" });
            DropIndex("dbo.GEN_Preferences", new[] { "GEN_Dossiers_DossierId" });
            DropIndex("dbo.GEN_Periodes", new[] { "GEN_Exercices_Id" });
            DropIndex("dbo.GEN_Exercices", new[] { "GEN_Dossiers_DossierId" });
            DropIndex("dbo.GEN_DossiersContact", new[] { "IdDossier" });
            DropIndex("dbo.GEN_Documents", new[] { "GEN_Dossiers_DossierId" });
            DropIndex("dbo.GEN_Model", new[] { "IdDossier" });
            DropIndex("dbo.GES_Reglement", new[] { "ReglementDossierId" });
            DropIndex("dbo.GES_Reglement", new[] { "ReglementBanqueId" });
            DropIndex("dbo.GES_Unite", new[] { "UniteSociete_DossierId" });
            DropIndex("dbo.GES_Nomenclature", new[] { "NomenclatureIdarticle" });
            DropIndex("dbo.GES_Marque", new[] { "MarqueSociete_DossierId" });
            DropIndex("dbo.GES_DocumentCommercialDetailSerie", new[] { "DocumentCommercialDetailSerieDocumentCommercialDetailIdDocumentDetail" });
            DropIndex("dbo.GES_DocumentCommercialDetailSerie", new[] { "DocumentCommercialDetailSerieSocieteId" });
            DropIndex("dbo.GES_DocumentCommercialDetail", new[] { "DocumentCommercialIdDocumentCommercial" });
            DropIndex("dbo.GES_DocumentCommercialDetail", new[] { "DocumentCommercialDetailArticleId" });
            DropIndex("dbo.GES_DocumentCommercial", new[] { "DocumentCommercialSocieteId" });
            DropIndex("dbo.GES_MouvementStock", new[] { "MouvementStockDossierId" });
            DropIndex("dbo.GES_MouvementStock", new[] { "MouvementStockIddepot" });
            DropIndex("dbo.GES_MouvementStock", new[] { "MouvementStockIddocument" });
            DropIndex("dbo.GES_MouvementStock", new[] { "MouvementStockIdarticle" });
            DropIndex("dbo.GES_Depot", new[] { "DepotSocieteId" });
            DropIndex("dbo.GES_Categorie", new[] { "CategorieSocieteId" });
            DropIndex("dbo.GES_ArticlesPrix", new[] { "ArticlesPrixArticleId" });
            DropIndex("dbo.GES_ArticlesKit", new[] { "ArticlesKitArticle1_ArticleId" });
            DropIndex("dbo.GES_ArticlesKit", new[] { "ArticlesKitArticleId1" });
            DropIndex("dbo.GES_Article", new[] { "ArticleMarqueId" });
            DropIndex("dbo.GES_Article", new[] { "ArticleUniteId" });
            DropIndex("dbo.GES_Article", new[] { "ArticleCategorieId" });
            DropIndex("dbo.GES_Article", new[] { "ArticleDepotId" });
            DropIndex("dbo.GES_Article", new[] { "ArticleSocieteId" });
            DropIndex("dbo.GES_FournisseurArticle", new[] { "FournisseurArticleIdfournisseur" });
            DropIndex("dbo.GES_FournisseurArticle", new[] { "FournisseurArticleIdArticle" });
            DropIndex("dbo.GES_Objectif", new[] { "ObjectifDossierId" });
            DropIndex("dbo.GES_Objectif", new[] { "ObjectifRepresentantId" });
            DropIndex("dbo.GES_Representant", new[] { "RepresentantDossierId" });
            DropIndex("dbo.GES_MotifTicket", new[] { "MotifTicketSocieteId" });
            DropIndex("dbo.GES_MotifTicket", new[] { "MotifTicketTiersContactId" });
            DropIndex("dbo.GES_TicketDetail", new[] { "TicketDetailIdcommercial" });
            DropIndex("dbo.GES_TicketDetail", new[] { "TicketDetailIdTicket" });
            DropIndex("dbo.GES_Ticket", new[] { "TicketDossierId" });
            DropIndex("dbo.GES_Ticket", new[] { "TicketIdcontact" });
            DropIndex("dbo.GES_Ticket", new[] { "TicketIdRepresentant" });
            DropIndex("dbo.GES_Ticket", new[] { "TicketIdClient" });
            DropIndex("dbo.GEN_TiersContacts", new[] { "IdTiers" });
            DropIndex("dbo.GES_OpportuniteDetail", new[] { "OpportuniteDetailIdcommercial" });
            DropIndex("dbo.GES_OpportuniteDetail", new[] { "OpportuniteDetailIdopportunite" });
            DropIndex("dbo.GES_Motif", new[] { "MotifdossierId" });
            DropIndex("dbo.GES_Motif", new[] { "OpportuniteId" });
            DropIndex("dbo.GES_Opportunite", new[] { "OpportuniteDossierd" });
            DropIndex("dbo.GES_Opportunite", new[] { "OpportuniteIdDevise" });
            DropIndex("dbo.GES_Opportunite", new[] { "OpportuniteIdcommercial" });
            DropIndex("dbo.GEN_DossiersSites", new[] { "GEN_Dossiers_DossierId" });
            DropIndex("dbo.GEN_TypePaiementDetail", new[] { "Delai" });
            DropIndex("dbo.GEN_TypePaiementDetail", new[] { "DateCalcul" });
            DropIndex("dbo.GEN_TypePaiementDetail", new[] { "IdModePaiement" });
            DropIndex("dbo.GEN_TypePaiementDetail", new[] { "IdTypePaiement" });
            DropIndex("dbo.GEN_TypePaiement", new[] { "IdDossier" });
            DropIndex("dbo.GEN_Regelement", new[] { "GEN_TypePaiement_TypePaiementId" });
            DropIndex("dbo.GEN_Regelement", new[] { "CPT_Journaux_Id" });
            DropIndex("dbo.CPT_ParametrageComptable", new[] { "IdDossier" });
            DropIndex("dbo.CPT_ParametrageComptable", new[] { "IdCompteDeficit" });
            DropIndex("dbo.CPT_ParametrageComptable", new[] { "IdCompteBenefice" });
            DropIndex("dbo.CPT_ParametrageComptable", new[] { "IdJournalANouveaux" });
            DropIndex("dbo.CPT_Journaux", new[] { "GEN_Items_Id" });
            DropIndex("dbo.CPT_Journaux", new[] { "GEN_Dossiers_DossierId" });
            DropIndex("dbo.CPT_Journaux", new[] { "GEN_Devises_DevisesId" });
            DropIndex("dbo.CPT_Journaux", new[] { "CPT_CompteG_Id" });
            DropIndex("dbo.CPT_Pieces", new[] { "IdDossierSite" });
            DropIndex("dbo.CPT_Pieces", new[] { "IdDossier" });
            DropIndex("dbo.CPT_Pieces", new[] { "IdDeviseTR" });
            DropIndex("dbo.CPT_Pieces", new[] { "IdDeviseTC" });
            DropIndex("dbo.CPT_Pieces", new[] { "IdJournal" });
            DropIndex("dbo.CPT_Pieces", new[] { "IdTiers" });
            DropIndex("dbo.CPT_TVALettrage", new[] { "LettrageId" });
            DropIndex("dbo.CPT_Lettrage", new[] { "IdEcheance" });
            DropIndex("dbo.CPT_Echeances", new[] { "GEN_Items_ModePaiement_Id" });
            DropIndex("dbo.CPT_Echeances", new[] { "CPT_Ecritures_Id" });
            DropIndex("dbo.CPT_Ecritures", new[] { "IdDossierSite" });
            DropIndex("dbo.CPT_Ecritures", new[] { "IdDeviceTR" });
            DropIndex("dbo.CPT_Ecritures", new[] { "IdDeviceTC" });
            DropIndex("dbo.CPT_Ecritures", new[] { "IdCompteG" });
            DropIndex("dbo.CPT_Ecritures", new[] { "IdPiece" });
            DropIndex("dbo.GEN_Devise", new[] { "DevisesIdDossier" });
            DropIndex("dbo.CPT_ComptesBancairesTiers", new[] { "IdTiers" });
            DropIndex("dbo.CPT_ComptesBancairesTiers", new[] { "IdDevise" });
            DropIndex("dbo.GEN_Tiers", new[] { "GEN_Items_Id2" });
            DropIndex("dbo.GEN_Tiers", new[] { "GEN_Items_Id1" });
            DropIndex("dbo.GEN_Tiers", new[] { "GEN_Items_Id" });
            DropIndex("dbo.GEN_Tiers", new[] { "GEN_Items_TypeTiers_Id" });
            DropIndex("dbo.GEN_Tiers", new[] { "GEN_Items_FormeJuridique_Id" });
            DropIndex("dbo.GEN_Tiers", new[] { "GEN_Items_CategorieFiscale_Id" });
            DropIndex("dbo.GEN_Tiers", new[] { "IdDossier" });
            DropIndex("dbo.GEN_Tiers", new[] { "IdEcheancement" });
            DropIndex("dbo.GEN_Tiers", new[] { "IdCompteCollectifFournisseur" });
            DropIndex("dbo.GEN_Tiers", new[] { "IdCompteCollectifClient" });
            DropIndex("dbo.GEN_Tiers", new[] { "IdDeviseDefault" });
            DropIndex("dbo.CPT_RelevesBancairesDetail", new[] { "GEN_Tiers_Id" });
            DropIndex("dbo.CPT_RelevesBancairesDetail", new[] { "GEN_TypePaiement_TypePaiementId" });
            DropIndex("dbo.CPT_RelevesBancairesDetail", new[] { "GEN_Items_Id" });
            DropIndex("dbo.CPT_RelevesBancairesDetail", new[] { "CPT_RelevesBancaires_Id" });
            DropIndex("dbo.CPT_RelevesBancairesDetail", new[] { "CPT_CompteG_Id" });
            DropIndex("dbo.CPT_RelevesBancaires", new[] { "IdDevise" });
            DropIndex("dbo.CPT_RelevesBancaires", new[] { "IdCompteBancaire" });
            DropIndex("dbo.CPT_ComptesBancaires", new[] { "GEN_Items_Id" });
            DropIndex("dbo.CPT_ComptesBancaires", new[] { "GEN_Dossiers_DossierId" });
            DropIndex("dbo.CPT_ComptesBancaires", new[] { "GEN_Devises_DevisesId" });
            DropIndex("dbo.CPT_ComptesBancaires", new[] { "CPT_CompteG_Id" });
            DropIndex("dbo.GEN_Items", new[] { "IdModel" });
            DropIndex("dbo.CPT_CompteGDetailTVA", new[] { "CPT_CodesTVA_Id" });
            DropIndex("dbo.CPT_CodesTVA", new[] { "GEN_Dossiers_DossierId2" });
            DropIndex("dbo.CPT_CodesTVA", new[] { "GEN_Dossiers_DossierId1" });
            DropIndex("dbo.CPT_CodesTVA", new[] { "GEN_Items_TypeTVA_Id" });
            DropIndex("dbo.CPT_CodesTVA", new[] { "GEN_Items_RebriqueDeclaration_Id" });
            DropIndex("dbo.CPT_CodesTVA", new[] { "GEN_Items_Id1" });
            DropIndex("dbo.CPT_CodesTVA", new[] { "GEN_Items_Id" });
            DropIndex("dbo.CPT_CodesTVA", new[] { "GEN_Dossiers_DossierId" });
            DropIndex("dbo.CPT_CodesTVA", new[] { "CPT_CompteG_Id" });
            DropIndex("dbo.CPT_CompteG", new[] { "GEN_Items_TypeCompte_Id" });
            DropIndex("dbo.CPT_CompteG", new[] { "GEN_Items_SuiviCompteTVA_Id" });
            DropIndex("dbo.CPT_CompteG", new[] { "GEN_Items_Sens_Id" });
            DropIndex("dbo.CPT_CompteG", new[] { "GEN_Items_ReportANouveau_Id" });
            DropIndex("dbo.CPT_CompteG", new[] { "GEN_Items_NatureCompte_Id" });
            DropIndex("dbo.CPT_CompteG", new[] { "GEN_Items_Id4" });
            DropIndex("dbo.CPT_CompteG", new[] { "GEN_Items_Id3" });
            DropIndex("dbo.CPT_CompteG", new[] { "GEN_Items_Id2" });
            DropIndex("dbo.CPT_CompteG", new[] { "GEN_Items_Id1" });
            DropIndex("dbo.CPT_CompteG", new[] { "GEN_Items_Id" });
            DropIndex("dbo.CPT_CompteG", new[] { "IdDossier" });
            DropIndex("dbo.CPT_CompteG", new[] { "IdCodeTvaDefault" });
            DropIndex("dbo.CPT_CompteG", new[] { "IdClasse" });
            DropIndex("dbo.CPT_Classe", new[] { "IdClasse" });
            DropIndex("dbo.GES_Affaire", new[] { "AffaireSocieteId" });
            DropTable("dbo.GES_ReglementFacture");
            DropTable("dbo.CPT_PlanAnalytique");
            DropTable("dbo.CPT_NatureOperation");
            DropTable("dbo.GES_Licence");
            DropTable("dbo.GES_Ged");
            DropTable("dbo.GES_Tolerance");
            DropTable("dbo.GES_Impression");
            DropTable("dbo.GES_Famille");
            DropTable("dbo.GES_Doclieart");
            DropTable("dbo.GES_Doclie");
            DropTable("dbo.GES_Periode");
            DropTable("dbo.GES_Numerotation");
            DropTable("dbo.GEN_Numeration");
            DropTable("dbo.GEN_Preferences");
            DropTable("dbo.GEN_Periodes");
            DropTable("dbo.GEN_Exercices");
            DropTable("dbo.GEN_DossiersContact");
            DropTable("dbo.GEN_Documents");
            DropTable("dbo.GEN_Model");
            DropTable("dbo.GES_Reglement");
            DropTable("dbo.GES_Unite");
            DropTable("dbo.GES_Nomenclature");
            DropTable("dbo.GES_Marque");
            DropTable("dbo.GES_DocumentCommercialDetailSerie");
            DropTable("dbo.GES_DocumentCommercialDetail");
            DropTable("dbo.GES_DocumentCommercial");
            DropTable("dbo.GES_MouvementStock");
            DropTable("dbo.GES_Depot");
            DropTable("dbo.GES_Categorie");
            DropTable("dbo.GES_ArticlesPrix");
            DropTable("dbo.GES_ArticlesKit");
            DropTable("dbo.GES_Article");
            DropTable("dbo.GES_FournisseurArticle");
            DropTable("dbo.GES_Objectif");
            DropTable("dbo.GES_Representant");
            DropTable("dbo.GES_MotifTicket");
            DropTable("dbo.GES_TicketDetail");
            DropTable("dbo.GES_Ticket");
            DropTable("dbo.GEN_TiersContacts");
            DropTable("dbo.GES_OpportuniteDetail");
            DropTable("dbo.GES_Motif");
            DropTable("dbo.GES_Opportunite");
            DropTable("dbo.GEN_DossiersSites");
            DropTable("dbo.GEN_TypePaiementDetail");
            DropTable("dbo.GEN_TypePaiement");
            DropTable("dbo.GEN_Regelement");
            DropTable("dbo.CPT_ParametrageComptable");
            DropTable("dbo.CPT_Journaux");
            DropTable("dbo.CPT_Pieces");
            DropTable("dbo.CPT_TVALettrage");
            DropTable("dbo.CPT_Lettrage");
            DropTable("dbo.CPT_Echeances");
            DropTable("dbo.CPT_Ecritures");
            DropTable("dbo.GEN_Devise");
            DropTable("dbo.CPT_ComptesBancairesTiers");
            DropTable("dbo.GEN_Tiers");
            DropTable("dbo.CPT_RelevesBancairesDetail");
            DropTable("dbo.CPT_RelevesBancaires");
            DropTable("dbo.CPT_ComptesBancaires");
            DropTable("dbo.GEN_Items");
            DropTable("dbo.CPT_CompteGDetailTVA");
            DropTable("dbo.CPT_CodesTVA");
            DropTable("dbo.CPT_CompteG");
            DropTable("dbo.CPT_Classe");
            DropTable("dbo.GEN_Dossier");
            DropTable("dbo.GES_Affaire");
            DropTable("dbo.GES_Admin");
        }
    }
}
