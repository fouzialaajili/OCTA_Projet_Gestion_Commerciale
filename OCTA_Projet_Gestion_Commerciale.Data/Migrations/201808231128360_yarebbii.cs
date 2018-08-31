namespace OCTA_Projet_Gestion_Commerciale.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class yarebbii : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.GEN_Documents", newName: "GEN_Document");
            DropIndex("dbo.GEN_Document", new[] { "GEN_Dossiers_DossierId" });
            DropColumn("dbo.GEN_Document", "IdDossier");
            RenameColumn(table: "dbo.GEN_Document", name: "GEN_Dossiers_DossierId", newName: "IdDossier");
            AlterColumn("dbo.GEN_Document", "IdDossier", c => c.Long());
            CreateIndex("dbo.GEN_Document", "IdDossier");
        }
        
        public override void Down()
        {
            DropIndex("dbo.GEN_Document", new[] { "IdDossier" });
            AlterColumn("dbo.GEN_Document", "IdDossier", c => c.Long(nullable: false));
            RenameColumn(table: "dbo.GEN_Document", name: "IdDossier", newName: "GEN_Dossiers_DossierId");
            AddColumn("dbo.GEN_Document", "IdDossier", c => c.Long(nullable: false));
            CreateIndex("dbo.GEN_Document", "GEN_Dossiers_DossierId");
            RenameTable(name: "dbo.GEN_Document", newName: "GEN_Documents");
        }
    }
}
