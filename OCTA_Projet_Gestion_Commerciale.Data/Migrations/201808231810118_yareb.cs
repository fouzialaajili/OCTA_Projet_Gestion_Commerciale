namespace OCTA_Projet_Gestion_Commerciale.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class yareb : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.GEN_Numeration", "idDossier");
            RenameColumn(table: "dbo.GEN_Numeration", name: "GEN_Dossiers_DossierId", newName: "idDossier");
            RenameIndex(table: "dbo.GEN_Numeration", name: "IX_GEN_Dossiers_DossierId", newName: "IX_idDossier");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.GEN_Numeration", name: "IX_idDossier", newName: "IX_GEN_Dossiers_DossierId");
            RenameColumn(table: "dbo.GEN_Numeration", name: "idDossier", newName: "GEN_Dossiers_DossierId");
            AddColumn("dbo.GEN_Numeration", "idDossier", c => c.Long());
        }
    }
}
