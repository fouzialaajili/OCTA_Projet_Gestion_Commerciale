namespace OCTA_Projet_Gestion_Commerciale.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ya3aliy : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.GEN_Exercices", newName: "GEN_Exercice");
            DropColumn("dbo.GEN_Exercice", "IdDossier");
            RenameColumn(table: "dbo.GEN_Exercice", name: "GEN_Dossiers_DossierId", newName: "IdDossier");
            RenameIndex(table: "dbo.GEN_Exercice", name: "IX_GEN_Dossiers_DossierId", newName: "IX_IdDossier");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.GEN_Exercice", name: "IX_IdDossier", newName: "IX_GEN_Dossiers_DossierId");
            RenameColumn(table: "dbo.GEN_Exercice", name: "IdDossier", newName: "GEN_Dossiers_DossierId");
            AddColumn("dbo.GEN_Exercice", "IdDossier", c => c.Long());
            RenameTable(name: "dbo.GEN_Exercice", newName: "GEN_Exercices");
        }
    }
}
