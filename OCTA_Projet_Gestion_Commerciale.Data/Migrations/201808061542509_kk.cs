namespace OCTA_Projet_Gestion_Commerciale.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kk : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.GEN_DossiersSites", "IdDossier");
            RenameColumn(table: "dbo.GEN_DossiersSites", name: "GEN_Dossiers_DossierId", newName: "IdDossier");
            RenameIndex(table: "dbo.GEN_DossiersSites", name: "IX_GEN_Dossiers_DossierId", newName: "IX_IdDossier");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.GEN_DossiersSites", name: "IX_IdDossier", newName: "IX_GEN_Dossiers_DossierId");
            RenameColumn(table: "dbo.GEN_DossiersSites", name: "IdDossier", newName: "GEN_Dossiers_DossierId");
            AddColumn("dbo.GEN_DossiersSites", "IdDossier", c => c.Long());
        }
    }
}
