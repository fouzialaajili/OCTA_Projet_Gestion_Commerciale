namespace OCTA_Projet_Gestion_Commerciale.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class yarebb : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CPT_ComptesBancaires", "IdDossier");
            DropColumn("dbo.CPT_ComptesBancaires", "IdCompteG");
            DropColumn("dbo.CPT_ComptesBancaires", "IdDevise");
            RenameColumn(table: "dbo.CPT_ComptesBancaires", name: "GEN_Dossiers_DossierId", newName: "IdDossier");
            RenameColumn(table: "dbo.CPT_ComptesBancaires", name: "CPT_CompteG_Id", newName: "IdCompteG");
            RenameColumn(table: "dbo.CPT_ComptesBancaires", name: "GEN_Devises_DevisesId", newName: "IdDevise");
            RenameIndex(table: "dbo.CPT_ComptesBancaires", name: "IX_GEN_Devises_DevisesId", newName: "IX_IdDevise");
            RenameIndex(table: "dbo.CPT_ComptesBancaires", name: "IX_GEN_Dossiers_DossierId", newName: "IX_IdDossier");
            RenameIndex(table: "dbo.CPT_ComptesBancaires", name: "IX_CPT_CompteG_Id", newName: "IX_IdCompteG");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.CPT_ComptesBancaires", name: "IX_IdCompteG", newName: "IX_CPT_CompteG_Id");
            RenameIndex(table: "dbo.CPT_ComptesBancaires", name: "IX_IdDossier", newName: "IX_GEN_Dossiers_DossierId");
            RenameIndex(table: "dbo.CPT_ComptesBancaires", name: "IX_IdDevise", newName: "IX_GEN_Devises_DevisesId");
            RenameColumn(table: "dbo.CPT_ComptesBancaires", name: "IdDevise", newName: "GEN_Devises_DevisesId");
            RenameColumn(table: "dbo.CPT_ComptesBancaires", name: "IdCompteG", newName: "CPT_CompteG_Id");
            RenameColumn(table: "dbo.CPT_ComptesBancaires", name: "IdDossier", newName: "GEN_Dossiers_DossierId");
            AddColumn("dbo.CPT_ComptesBancaires", "IdDevise", c => c.Long());
            AddColumn("dbo.CPT_ComptesBancaires", "IdCompteG", c => c.Long());
            AddColumn("dbo.CPT_ComptesBancaires", "IdDossier", c => c.Long());
        }
    }
}
