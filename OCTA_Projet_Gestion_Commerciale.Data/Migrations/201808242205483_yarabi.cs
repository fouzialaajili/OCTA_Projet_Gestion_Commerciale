namespace OCTA_Projet_Gestion_Commerciale.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class yarabi : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.GEN_Regelement", "IdJournal");
            DropColumn("dbo.GEN_Regelement", "IdModePaiement");
            RenameColumn(table: "dbo.GEN_Regelement", name: "CPT_Journaux_Id", newName: "IdJournal");
            RenameColumn(table: "dbo.GEN_Regelement", name: "GEN_TypePaiement_TypePaiementId", newName: "IdModePaiement");
            RenameIndex(table: "dbo.GEN_Regelement", name: "IX_CPT_Journaux_Id", newName: "IX_IdJournal");
            RenameIndex(table: "dbo.GEN_Regelement", name: "IX_GEN_TypePaiement_TypePaiementId", newName: "IX_IdModePaiement");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.GEN_Regelement", name: "IX_IdModePaiement", newName: "IX_GEN_TypePaiement_TypePaiementId");
            RenameIndex(table: "dbo.GEN_Regelement", name: "IX_IdJournal", newName: "IX_CPT_Journaux_Id");
            RenameColumn(table: "dbo.GEN_Regelement", name: "IdModePaiement", newName: "GEN_TypePaiement_TypePaiementId");
            RenameColumn(table: "dbo.GEN_Regelement", name: "IdJournal", newName: "CPT_Journaux_Id");
            AddColumn("dbo.GEN_Regelement", "IdModePaiement", c => c.Long());
            AddColumn("dbo.GEN_Regelement", "IdJournal", c => c.Long());
        }
    }
}
