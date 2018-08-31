namespace OCTA_Projet_Gestion_Commerciale.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class yarebi : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.GEN_Preferences", newName: "GEN_Preference");
            DropIndex("dbo.GEN_Preference", new[] { "GEN_Dossiers_DossierId" });
            DropIndex("dbo.GEN_Preference", new[] { "GEN_Exercices_Id" });
            DropColumn("dbo.GEN_Preference", "IdDossier");
            DropColumn("dbo.GEN_Preference", "IdExercices");
            RenameColumn(table: "dbo.GEN_Preference", name: "GEN_Dossiers_DossierId", newName: "IdDossier");
            RenameColumn(table: "dbo.GEN_Preference", name: "GEN_Exercices_Id", newName: "IdExercices");
            AlterColumn("dbo.GEN_Preference", "IdDossier", c => c.Long());
            AlterColumn("dbo.GEN_Preference", "IdExercices", c => c.Long());
            CreateIndex("dbo.GEN_Preference", "IdDossier");
            CreateIndex("dbo.GEN_Preference", "IdExercices");
        }
        
        public override void Down()
        {
            DropIndex("dbo.GEN_Preference", new[] { "IdExercices" });
            DropIndex("dbo.GEN_Preference", new[] { "IdDossier" });
            AlterColumn("dbo.GEN_Preference", "IdExercices", c => c.Long(nullable: false));
            AlterColumn("dbo.GEN_Preference", "IdDossier", c => c.Long(nullable: false));
            RenameColumn(table: "dbo.GEN_Preference", name: "IdExercices", newName: "GEN_Exercices_Id");
            RenameColumn(table: "dbo.GEN_Preference", name: "IdDossier", newName: "GEN_Dossiers_DossierId");
            AddColumn("dbo.GEN_Preference", "IdExercices", c => c.Long(nullable: false));
            AddColumn("dbo.GEN_Preference", "IdDossier", c => c.Long(nullable: false));
            CreateIndex("dbo.GEN_Preference", "GEN_Exercices_Id");
            CreateIndex("dbo.GEN_Preference", "GEN_Dossiers_DossierId");
            RenameTable(name: "dbo.GEN_Preference", newName: "GEN_Preferences");
        }
    }
}
