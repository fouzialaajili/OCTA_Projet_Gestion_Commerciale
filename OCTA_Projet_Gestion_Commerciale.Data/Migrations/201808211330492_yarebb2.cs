namespace OCTA_Projet_Gestion_Commerciale.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class yarebb2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CPT_RelevesBancairesDetail", "IdNatureOperation1");
            DropColumn("dbo.CPT_RelevesBancairesDetail", "IdReleveBancaire");
            DropColumn("dbo.CPT_RelevesBancairesDetail", "IdTier");
            DropColumn("dbo.CPT_RelevesBancairesDetail", "IdTypePaiement");
            RenameColumn(table: "dbo.CPT_RelevesBancairesDetail", name: "CPT_CompteG_Id", newName: "IdNatureOperation1");
            RenameColumn(table: "dbo.CPT_RelevesBancairesDetail", name: "CPT_RelevesBancaires_Id", newName: "IdReleveBancaire");
            RenameColumn(table: "dbo.CPT_RelevesBancairesDetail", name: "GEN_Tiers_Id", newName: "IdTier");
            RenameColumn(table: "dbo.CPT_RelevesBancairesDetail", name: "GEN_TypePaiement_TypePaiementId", newName: "IdTypePaiement");
            RenameIndex(table: "dbo.CPT_RelevesBancairesDetail", name: "IX_CPT_RelevesBancaires_Id", newName: "IX_IdReleveBancaire");
            RenameIndex(table: "dbo.CPT_RelevesBancairesDetail", name: "IX_GEN_Tiers_Id", newName: "IX_IdTier");
            RenameIndex(table: "dbo.CPT_RelevesBancairesDetail", name: "IX_GEN_TypePaiement_TypePaiementId", newName: "IX_IdTypePaiement");
            RenameIndex(table: "dbo.CPT_RelevesBancairesDetail", name: "IX_CPT_CompteG_Id", newName: "IX_IdNatureOperation1");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.CPT_RelevesBancairesDetail", name: "IX_IdNatureOperation1", newName: "IX_CPT_CompteG_Id");
            RenameIndex(table: "dbo.CPT_RelevesBancairesDetail", name: "IX_IdTypePaiement", newName: "IX_GEN_TypePaiement_TypePaiementId");
            RenameIndex(table: "dbo.CPT_RelevesBancairesDetail", name: "IX_IdTier", newName: "IX_GEN_Tiers_Id");
            RenameIndex(table: "dbo.CPT_RelevesBancairesDetail", name: "IX_IdReleveBancaire", newName: "IX_CPT_RelevesBancaires_Id");
            RenameColumn(table: "dbo.CPT_RelevesBancairesDetail", name: "IdTypePaiement", newName: "GEN_TypePaiement_TypePaiementId");
            RenameColumn(table: "dbo.CPT_RelevesBancairesDetail", name: "IdTier", newName: "GEN_Tiers_Id");
            RenameColumn(table: "dbo.CPT_RelevesBancairesDetail", name: "IdReleveBancaire", newName: "CPT_RelevesBancaires_Id");
            RenameColumn(table: "dbo.CPT_RelevesBancairesDetail", name: "IdNatureOperation1", newName: "CPT_CompteG_Id");
            AddColumn("dbo.CPT_RelevesBancairesDetail", "IdTypePaiement", c => c.Long());
            AddColumn("dbo.CPT_RelevesBancairesDetail", "IdTier", c => c.Long());
            AddColumn("dbo.CPT_RelevesBancairesDetail", "IdReleveBancaire", c => c.Long());
            AddColumn("dbo.CPT_RelevesBancairesDetail", "IdNatureOperation1", c => c.Long());
        }
    }
}
