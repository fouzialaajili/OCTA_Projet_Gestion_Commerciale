namespace OCTA_Projet_Gestion_Commerciale.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gg : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.GES_Admin",
            //    c => new
            //        {
            //            AdminId = c.Long(nullable: false, identity: true),
            //            AdminLogin = c.String(),
            //            AdminPassword = c.String(),
            //            AdminActif = c.Boolean(nullable: false),
            //        })
            //    .PrimaryKey(t => t.AdminId);



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
            DropForeignKey("dbo.CPT_CompteG", "GEN_Dossiers_DossierId", "dbo.GEN_Dossier");
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
            DropForeignKey("dbo.GES_ArticlesKit", "ArticlesKitArticleId", "dbo.GES_Article");
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
            DropForeignKey("dbo.GEN_DossiersSites", "IdDossier", "dbo.GEN_Dossier");
            DropForeignKey("dbo.CPT_Pieces", "IdDossier", "dbo.GEN_Dossier");
            DropForeignKey("dbo.CPT_Pieces", "IdDeviseTR", "dbo.GEN_Devise");
            DropForeignKey("dbo.CPT_Pieces", "IdDeviseTC", "dbo.GEN_Devise");
            DropForeignKey("dbo.CPT_Pieces", "IdJournal", "dbo.CPT_Journaux");
            DropForeignKey("dbo.GEN_TypePaiementDetail", "IdTypePaiement", "dbo.GEN_TypePaiement");
            DropForeignKey("dbo.GEN_TypePaiementDetail", "GEN_Items_ModePaiement_Id", "dbo.GEN_Items");
            DropForeignKey("dbo.GEN_TypePaiementDetail", "GEN_Items_Delai_Id", "dbo.GEN_Items");
            DropForeignKey("dbo.GEN_TypePaiementDetail", "GEN_Items_DateCalcul_Id", "dbo.GEN_Items");
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
            DropForeignKey("dbo.CPT_CompteG", "CPT_CodesTVA_CodeTVADefault_Id", "dbo.CPT_CodesTVA");
            DropForeignKey("dbo.CPT_CodesTVA", "CPT_CompteG_Id1", "dbo.CPT_CompteG");
            DropForeignKey("dbo.CPT_CodesTVA", "GEN_Items_TypeTVA_Id", "dbo.GEN_Items");
            DropForeignKey("dbo.CPT_CodesTVA", "GEN_Items_RebriqueDeclaration_Id", "dbo.GEN_Items");
            DropForeignKey("dbo.GEN_Items", "IdModel", "dbo.GEN_Model");
            DropForeignKey("dbo.GEN_Model", "IdDossier", "dbo.GEN_Dossier");
            DropForeignKey("dbo.CPT_CodesTVA", "GEN_Dossiers_DossierId", "dbo.GEN_Dossier");
            DropForeignKey("dbo.CPT_CompteGDetailTVA", "CPT_CodesTVA_Id", "dbo.CPT_CodesTVA");
            DropForeignKey("dbo.CPT_CompteG", "CPT_CodesTVA_Id", "dbo.CPT_CodesTVA");
            DropForeignKey("dbo.CPT_CodesTVA", "CPT_CompteG_Id", "dbo.CPT_CompteG");
            DropForeignKey("dbo.CPT_CompteG", "CPT_Classe_Id", "dbo.CPT_Classe");
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
            DropIndex("dbo.GES_ArticlesKit", new[] { "ArticlesKitArticleId" });
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
            DropIndex("dbo.GEN_DossiersSites", new[] { "IdDossier" });
            DropIndex("dbo.GEN_TypePaiementDetail", new[] { "GEN_Items_ModePaiement_Id" });
            DropIndex("dbo.GEN_TypePaiementDetail", new[] { "GEN_Items_Delai_Id" });
            DropIndex("dbo.GEN_TypePaiementDetail", new[] { "GEN_Items_DateCalcul_Id" });
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
            DropIndex("dbo.GEN_Model", new[] { "IdDossier" });
            DropIndex("dbo.GEN_Items", new[] { "IdModel" });
            DropIndex("dbo.CPT_CompteGDetailTVA", new[] { "CPT_CodesTVA_Id" });
            DropIndex("dbo.CPT_CodesTVA", new[] { "GEN_Dossiers_DossierId2" });
            DropIndex("dbo.CPT_CodesTVA", new[] { "GEN_Dossiers_DossierId1" });
            DropIndex("dbo.CPT_CodesTVA", new[] { "CPT_CompteG_Id1" });
            DropIndex("dbo.CPT_CodesTVA", new[] { "GEN_Items_TypeTVA_Id" });
            DropIndex("dbo.CPT_CodesTVA", new[] { "GEN_Items_RebriqueDeclaration_Id" });
            DropIndex("dbo.CPT_CodesTVA", new[] { "GEN_Dossiers_DossierId" });
            DropIndex("dbo.CPT_CodesTVA", new[] { "CPT_CompteG_Id" });
            DropIndex("dbo.CPT_CompteG", new[] { "GEN_Items_TypeCompte_Id" });
            DropIndex("dbo.CPT_CompteG", new[] { "GEN_Items_SuiviCompteTVA_Id" });
            DropIndex("dbo.CPT_CompteG", new[] { "GEN_Items_Sens_Id" });
            DropIndex("dbo.CPT_CompteG", new[] { "GEN_Items_ReportANouveau_Id" });
            DropIndex("dbo.CPT_CompteG", new[] { "GEN_Items_NatureCompte_Id" });
            DropIndex("dbo.CPT_CompteG", new[] { "GEN_Dossiers_DossierId" });
            DropIndex("dbo.CPT_CompteG", new[] { "CPT_CodesTVA_CodeTVADefault_Id" });
            DropIndex("dbo.CPT_CompteG", new[] { "CPT_CodesTVA_Id" });
            DropIndex("dbo.CPT_CompteG", new[] { "CPT_Classe_Id" });
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
            DropTable("dbo.GEN_Model");
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