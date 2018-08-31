namespace OCTA_Projet_Gestion_Commerciale.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class yarabiii : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CPT_Journaux", "IdDossier");
            DropColumn("dbo.CPT_Journaux", "IdCompteContrepartie");
            DropColumn("dbo.CPT_Journaux", "IdDevise");
            RenameColumn(table: "dbo.CPT_Journaux", name: "GEN_Dossiers_DossierId", newName: "IdDossier");
            RenameColumn(table: "dbo.CPT_Journaux", name: "CPT_CompteG_Id", newName: "IdCompteContrepartie");
            RenameColumn(table: "dbo.CPT_Journaux", name: "GEN_Devises_DevisesId", newName: "IdDevise");
            RenameIndex(table: "dbo.CPT_Journaux", name: "IX_CPT_CompteG_Id", newName: "IX_IdCompteContrepartie");
            RenameIndex(table: "dbo.CPT_Journaux", name: "IX_GEN_Dossiers_DossierId", newName: "IX_IdDossier");
            RenameIndex(table: "dbo.CPT_Journaux", name: "IX_GEN_Devises_DevisesId", newName: "IX_IdDevise");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.CPT_Journaux", name: "IX_IdDevise", newName: "IX_GEN_Devises_DevisesId");
            RenameIndex(table: "dbo.CPT_Journaux", name: "IX_IdDossier", newName: "IX_GEN_Dossiers_DossierId");
            RenameIndex(table: "dbo.CPT_Journaux", name: "IX_IdCompteContrepartie", newName: "IX_CPT_CompteG_Id");
            RenameColumn(table: "dbo.CPT_Journaux", name: "IdDevise", newName: "GEN_Devises_DevisesId");
            RenameColumn(table: "dbo.CPT_Journaux", name: "IdCompteContrepartie", newName: "CPT_CompteG_Id");
            RenameColumn(table: "dbo.CPT_Journaux", name: "IdDossier", newName: "GEN_Dossiers_DossierId");
            AddColumn("dbo.CPT_Journaux", "IdDevise", c => c.Long());
            AddColumn("dbo.CPT_Journaux", "IdCompteContrepartie", c => c.Long());
            AddColumn("dbo.CPT_Journaux", "IdDossier", c => c.Long());
        }
    }
}
