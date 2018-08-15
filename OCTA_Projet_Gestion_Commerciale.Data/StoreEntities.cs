using OCTA_Projet_Gestion_Commerciale.Data.Configuration;
using OCTA_Projet_Gestion_Commerciale.Model;
using Store.Data.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data
{
  public  class StoreEntities : DbContext
    {


        public StoreEntities() : base("StoreEntities") { }

        public DbSet<GES_Admin> Admins { get; set; }
        public DbSet<GES_Affaire> Affaires { get; set; }
        public DbSet<GES_Article> Articless { get; set; }
        public DbSet<GES_ArticlesKit> ArticlesKitss { get; set; }
        public DbSet<GES_ArticlesPrix> ArticlesPrixs { get; set; }
        public DbSet<GES_Categorie> Categories { get; set; }
        public DbSet<GES_Depot> Depots { get; set; }
        public DbSet<GEN_Devises> Devises { get; set; }
        public DbSet<GES_Doclie> Doclies { get; set; }
        public DbSet<GES_Doclieart> Docliearts { get; set; }
        public DbSet<GES_DocumentCommercial> DocumentCommercials { get; set; }
        public DbSet<GES_DocumentCommercialDetail> DocumentCommercialDetails { get; set; }
        public DbSet<GES_DocumentCommercialDetailSerie> DocumentCommercialDetailSeries { get; set; }
        public DbSet<GES_Famille> Familles { get; set; }


        public DbSet<GES_FournisseurArticle> FournisseurArticles { get; set; }
        public DbSet<GES_Ged> Geds { get; set; }
        public DbSet<GEN_Items> GEN_Items { get; set; }
        public DbSet<GEN_Model> Models { get; set; }
        public DbSet<GES_Impression> Impressions { get; set; }
        public DbSet<GES_Licence> Licences { get; set; }
        public DbSet<GES_Marque> Marques { get; set; }
        public DbSet<GES_Motif> Motifs { get; set; }
        public DbSet<GES_MotifTicket> MotifTickets { get; set; }
        public DbSet<GES_MouvementStock> MouvementStocks { get; set; }
        public DbSet<GES_Nomenclature> Nomenclatures { get; set; }
        public DbSet<GES_Numerotation> Numeratations { get; set; }
        public DbSet<CPT_ParametrageComptable> ParametrageComptables { get; set; }
        public DbSet<GES_Objectif> Objectifs { get; set; }
        public DbSet<GES_Opportunite> Opportunites { get; set; }
        public DbSet<GES_OpportuniteDetail> OpportuniteDetails { get; set; }
        public DbSet<GES_Periode> Periodes { get; set; }
        public DbSet<GES_Reglement> Reglements { get; set; }
        public DbSet<GES_ReglementFacture> ReglementFactures { get; set; }
        public DbSet<GEN_Tiers> Tiers { get; set; }
        public DbSet<GEN_TiersContacts> TiersContacts { get; set; }
        public DbSet<GES_Representant> Representants { get; set; }
        public DbSet<GEN_Dossiers> Dossiers { get; set; }

        public DbSet<GES_Ticket> Tickets { get; set; }
        public DbSet<GES_TicketDetail> TicketDetails { get; set; }

        public DbSet<GES_Tolerance> Tolerances { get; set; }


        public DbSet<GES_Unite> Unites { get; set; }


        public DbSet<CPT_Classe> Classes { get; set; }
        public DbSet<CPT_ComptesBancairesTiers> ComptesBancairesTiers { get; set; }
        public DbSet<CPT_Ecritures> Ecritures { get; set; }
        public DbSet<CPT_Lettrage> Lettrages { get; set; }
        public DbSet<CPT_NatureOperation> NatureOperations { get; set; }
        public DbSet<CPT_Pieces> Pieces { get; set; }
        public DbSet<CPT_PlanAnalytique> PlanAnalytiques { get; set; }
        public DbSet<CPT_RelevesBancaires> RelevesBancaires { get; set; }
        public DbSet<CPT_TVALettrage> TVALettrage { get; set; }
        public DbSet<GEN_DossiersContacts> DossierContacts { get; set; }
        public DbSet<GEN_DossiersSites> GEN_DossiersSites { get; set; }
        public DbSet<GEN_TypePaiement> TypePaiement { get; set; }
        public DbSet<GEN_TypePaiementDetail> TypePaiementDetail { get; set; }
        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new GES_AdminConfiguration());
            modelBuilder.Configurations.Add(new GES_AffaireConfiguration());
            modelBuilder.Configurations.Add(new GES_ArticleConfiguration());
            modelBuilder.Configurations.Add(new GES_ArticlesKitConfiguration());

            modelBuilder.Configurations.Add(new GES_ArticlesPrixConfiguration());
            modelBuilder.Configurations.Add(new GES_CategorieConfiguration());
            modelBuilder.Configurations.Add(new GES_DepotConfiguration());


            modelBuilder.Configurations.Add(new GEN_DevisesConfiguration());
            modelBuilder.Configurations.Add(new GES_DoclieConfiguration());
            modelBuilder.Configurations.Add(new GES_DoclieartConfiguration());

            modelBuilder.Configurations.Add(new GES_DocumentCommercialConfiguration());
            modelBuilder.Configurations.Add(new GES_DocumentCommercialDetailConfiguration());
            modelBuilder.Configurations.Add(new GES_DocumentCommercialDetailSerieConfiguration());
            modelBuilder.Configurations.Add(new GES_FamilleConfiguration());
            /****************************/
            modelBuilder.Configurations.Add(new GEN_TiersConfiguration());
            modelBuilder.Configurations.Add(new GEN_DossiersContactsConfiguration());

            modelBuilder.Configurations.Add(new GEN_TiersContactsConfiguration());

            modelBuilder.Configurations.Add(new GES_FournisseurArticleConfiguration());
            modelBuilder.Configurations.Add(new GES_GedConfiguration());
            modelBuilder.Configurations.Add(new GES_MotifConfiguration());
            modelBuilder.Configurations.Add(new GES_MotifTicketConfiguration());
            modelBuilder.Configurations.Add(new GES_MouvementStockConfiguration());
            modelBuilder.Configurations.Add(new GES_NomenclatureConfiguration());
            modelBuilder.Configurations.Add(new GES_NumerotationConfiguration());
            modelBuilder.Configurations.Add(new GES_ObjectifConfiguration());
            modelBuilder.Configurations.Add(new GES_OpportuniteConfiguration());
            modelBuilder.Configurations.Add(new GES_OpportuniteDetailConfiguration());
            modelBuilder.Configurations.Add(new GEN_TypePaiementConfiguration());
            modelBuilder.Configurations.Add(new GEN_TypePaiementDetailConfiguration());
            modelBuilder.Configurations.Add(new CPT_ParametrageComptableConfiguration());
            modelBuilder.Configurations.Add(new GEN_ItemsConfiguration());
            //modelBuilder.Configurations.Add(new GEN_PeriodeConfiguration());
            //   modelBuilder.Configurations.Add(new ProfilConfiguration());
            //   modelBuilder.Configurations.Add(new ProfilDetailConfiguration());
            modelBuilder.Configurations.Add(new GES_PeriodeConfiguration());
            modelBuilder.Configurations.Add(new GEN_DossiersSitesConfiguration());
            modelBuilder.Configurations.Add(new GES_ReglementConfiguration());
            modelBuilder.Configurations.Add(new GES_ReglementFactureConfiguration());
            modelBuilder.Configurations.Add(new GES_RepresentantConfiguration());
            modelBuilder.Configurations.Add(new GEN_DossiersConfiguration());
            modelBuilder.Configurations.Add(new GES_TicketConfiguration());
            modelBuilder.Configurations.Add(new GES_TicketDetailConfiguration());
            //modelBuilder.Configurations.Add(new CPT_CodesTVAConfiguration());

            modelBuilder.Configurations.Add(new GEN_ModelConfiguration());
            modelBuilder.Configurations.Add(new CPT_ClasseConfiguration());
            modelBuilder.Configurations.Add(new CPT_ComptesBancairesTiersConfiguration());
            modelBuilder.Configurations.Add(new CPT_EcrituresConfiguration());
            modelBuilder.Configurations.Add(new CPT_LettrageConfiguration());
            modelBuilder.Configurations.Add(new CPT_NatureOperationConfiguration());
            modelBuilder.Configurations.Add(new CPT_PiecesConfiguration());
            modelBuilder.Configurations.Add(new CPT_PlanAnalytiqueConfiguration());

            modelBuilder.Configurations.Add(new CPT_RelevesBancairesConfiguration());
            modelBuilder.Configurations.Add(new CPT_TVALettrageConfiguration());
        }
    }
}



















       

      //  public StoreEntities() : base("StoreEntities") { }

      //  public DbSet<GES_Admin> Admins { get; set; }
      //  public DbSet<GES_Affaire> Affaires { get; set; }
      //  public DbSet<GES_Article> Articless { get; set; }
      //  public DbSet<GES_ArticlesKit> ArticlesKitss { get; set; }
      //  public DbSet<GES_ArticlesPrix> ArticlesPrixs { get; set; }
      //  public DbSet<GES_Categorie> Categories { get; set; }
      //  public DbSet<GES_Depot> Depots { get; set; }
      //  public DbSet<GEN_Devises> Devises { get; set; }
      //  public DbSet<GES_Doclie> Doclies { get; set; }
      //  public DbSet<GES_Doclieart> Docliearts { get; set; }
      //  public DbSet<GES_DocumentCommercial> DocumentCommercials { get; set; }
      //  public DbSet<GES_DocumentCommercialDetail> DocumentCommercialDetails { get; set; }
      //  public DbSet<GES_DocumentCommercialDetailSerie> DocumentCommercialDetailSeries { get; set; }
      //  public DbSet<GES_Famille> Familles { get; set; }
     
      
      //  public DbSet<GES_FournisseurArticle> FournisseurArticles { get; set; }
      //  public DbSet<GES_Ged> Geds { get; set; }
      //  //  public DbSet<GEN_Items> Items { get; set; }
      //  public DbSet<GEN_Items> GEN_Items { get; set; }

      //  public DbSet<GEN_Model> Models { get; set; }
      //  public DbSet<GES_Impression> Impressions { get; set;}
      //  // public DbSet<GES_Licence> Licences { get; set; }
      //  public DbSet<GES_Licence> Licences { get; set; }
      //  public DbSet<GES_Marque> Marques { get; set; }
      //  public DbSet<GES_Motif> Motifs { get; set; }
      //  public DbSet<GES_MotifTicket> MotifTickets { get; set; }
      //  public DbSet<GES_MouvementStock> MouvementStocks { get; set; }
      //  public DbSet<GES_Nomenclature> Nomenclatures { get; set; }
      //  public DbSet<GES_Numerotation> Numeratations { get; set; }
      //  public DbSet<CPT_ParametrageComptable> ParametrageComptables { get; set; }
      //  public DbSet<GES_Objectif> Objectifs { get; set; }
      //  public DbSet<GES_Opportunite> Opportunites { get; set; }
      //  public DbSet<GES_OpportuniteDetail> OpportuniteDetails { get; set; }   
      //  public DbSet<GES_Periode> Periodes { get; set; }
      //  public DbSet<GES_Reglement> Reglements { get; set; }
      //  public DbSet<GES_ReglementFacture> ReglementFactures { get; set; }
      //  public DbSet<GEN_Tiers> Tiers { get; set; }
      //  public DbSet<GEN_TiersContacts> TiersContacts { get; set; }
      //  public DbSet<GES_Representant> Representants { get; set; }
        

      //  public DbSet<GES_Ticket> Tickets { get; set; }
      //  public DbSet<GES_TicketDetail> TicketDetails { get; set; }

      //  public DbSet<GES_Tolerance> Tolerances { get; set; }


      //  public DbSet<GES_Unite> Unites { get; set; }


      //  // public DbSet<CPT_Classe> Classes { get; set; }
      //  public DbSet<CPT_Classe> Classes { get; set; }

      //  public DbSet<CPT_CompteG> CPT_CompteGs { get; set; }
      // // public DbSet<CPT_ComptesBancairesTiers> ComptesBancairesTiers { get; set; }

      //  public DbSet<CPT_ComptesBancairesTiers> ComptesBancairesTiers { get; set; }
      //  // public DbSet<CPT_Ecritures> Ecritures { get; set; }
      //  public DbSet<CPT_Ecritures> Ecritures { get; set; }

      //  //  public DbSet<CPT_Lettrage> Lettrages { get; set; }
      //  public DbSet<CPT_Lettrage> Lettrages { get; set; }

      ////  public DbSet<CPT_NatureOperation> NatureOperations { get; set; }
      //  public DbSet<CPT_NatureOperation> NatureOperations { get; set; }
      //  public DbSet<CPT_Pieces> Pieces { get; set; }
      //  public DbSet<CPT_PlanAnalytique> PlanAnalytiques { get; set; }
      //  public DbSet<CPT_RelevesBancaires> RelevesBancaires { get; set; }
      //  public DbSet<CPT_TVALettrage> TVALettrage { get; set; }
      //  public DbSet<GEN_TypePaiement> TypePaiement { get; set; }
      //  public DbSet<GEN_Dossiers> Dossier { get; set; }


      //  public DbSet<GEN_DossiersContacts> DossierContacts { get; set; }
      //  public DbSet<GEN_DossiersSites> GEN_DossiersSites { get; set; }

      //  public virtual void Commit()
      //  {
      //      base.SaveChanges();
      //  }

      //  protected override void OnModelCreating(DbModelBuilder modelBuilder)
      //  {
      //      modelBuilder.Configurations.Add(new GES_AdminConfiguration());
      //      modelBuilder.Configurations.Add(new GES_AffaireConfiguration());
      //      modelBuilder.Configurations.Add(new GES_ArticleConfiguration());
      //      modelBuilder.Configurations.Add(new GES_ArticlesKitConfiguration());

      //      modelBuilder.Configurations.Add(new GES_ArticlesPrixConfiguration());
      //      modelBuilder.Configurations.Add(new GES_CategorieConfiguration());
      //      modelBuilder.Configurations.Add(new GES_DepotConfiguration());
      //      modelBuilder.Configurations.Add(new GEN_ItemsConfiguration());
            


      //      modelBuilder.Configurations.Add(new GEN_DevisesConfiguration());
      //      modelBuilder.Configurations.Add(new GES_DoclieConfiguration());
      //      modelBuilder.Configurations.Add(new GES_DoclieartConfiguration());

      //      modelBuilder.Configurations.Add(new GES_DocumentCommercialConfiguration());
      //      modelBuilder.Configurations.Add(new GES_DocumentCommercialDetailConfiguration());
      //      modelBuilder.Configurations.Add(new GES_DocumentCommercialDetailSerieConfiguration());
      //      modelBuilder.Configurations.Add(new GES_FamilleConfiguration());
      //      /****************************/
      //      modelBuilder.Configurations.Add(new GEN_TiersConfiguration());
      //      modelBuilder.Configurations.Add(new GEN_DossiersContactsConfiguration());

      //      modelBuilder.Configurations.Add(new GEN_TiersContactsConfiguration());
      
      //      modelBuilder.Configurations.Add(new GES_FournisseurArticleConfiguration());
      //      modelBuilder.Configurations.Add(new GES_GedConfiguration());
      //      modelBuilder.Configurations.Add(new GES_MotifConfiguration());
      //      modelBuilder.Configurations.Add(new GES_MotifTicketConfiguration());
      //      modelBuilder.Configurations.Add(new GES_MouvementStockConfiguration());
      //      modelBuilder.Configurations.Add(new GES_NomenclatureConfiguration());
      //      modelBuilder.Configurations.Add(new GES_NumerotationConfiguration());
      //      modelBuilder.Configurations.Add(new GES_ObjectifConfiguration());
      //      modelBuilder.Configurations.Add(new GES_OpportuniteConfiguration());
      //      modelBuilder.Configurations.Add(new GES_OpportuniteDetailConfiguration());
      //      modelBuilder.Configurations.Add(new GEN_TypePaiementConfiguration());
      //      modelBuilder.Configurations.Add(new GEN_TypePaiementDetailConfiguration());
      //      modelBuilder.Configurations.Add(new CPT_ParametrageComptableConfiguration());
      //     // modelBuilder.Configurations.Add(new GEN_ItemsConfiguration());
      //      //modelBuilder.Configurations.Add(new GEN_PeriodeConfiguration());
      //  // modelBuilder.Configurations.Add(new GEN_ModelConfiguration());
      //      //   modelBuilder.Configurations.Add(new ProfilConfiguration());
      //      //   modelBuilder.Configurations.Add(new Profi()lDetailConfiguration());
      //      modelBuilder.Configurations.Add(new GES_PeriodeConfiguration());
      //      modelBuilder.Configurations.Add(new GEN_DossiersSitesConfiguration());
      //      modelBuilder.Configurations.Add(new GES_ReglementConfiguration());
      //      modelBuilder.Configurations.Add(new GES_ReglementFactureConfiguration());
      //      modelBuilder.Configurations.Add(new GES_RepresentantConfiguration());
      //     modelBuilder.Configurations.Add(new GEN_DossiersConfiguration());
      //      modelBuilder.Configurations.Add(new GES_TicketConfiguration());
      //      modelBuilder.Configurations.Add(new GES_TicketDetailConfiguration());
      //      //modelBuilder.Configurations.Add(new CPT_CodesTVAConfiguration());

      //       modelBuilder.Configurations.Add(new GEN_ModelConfiguration());
      //      modelBuilder.Configurations.Add(new CPT_ClasseConfiguration());
      //      modelBuilder.Configurations.Add(new CPT_ComptesBancairesTiersConfiguration());
      //      modelBuilder.Configurations.Add(new CPT_EcrituresConfiguration());
      //      modelBuilder.Configurations.Add(new CPT_LettrageConfiguration());
      //      modelBuilder.Configurations.Add(new CPT_NatureOperationConfiguration());
      //      modelBuilder.Configurations.Add(new CPT_PiecesConfiguration());
      //      modelBuilder.Configurations.Add(new CPT_PlanAnalytiqueConfiguration());
      //      modelBuilder.Configurations.Add(new CPT_RelevesBancairesConfiguration());
      //      modelBuilder.Configurations.Add(new CPT_TVALettrageConfiguration());
      //      modelBuilder.Configurations.Add(new CPT_CompteGConfiguration());
            

