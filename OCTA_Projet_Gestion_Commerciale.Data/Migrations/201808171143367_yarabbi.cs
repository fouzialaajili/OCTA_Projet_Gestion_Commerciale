namespace OCTA_Projet_Gestion_Commerciale.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class yarabbi : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CPT_Echeances", "IdEcriture");
            RenameColumn(table: "dbo.CPT_Echeances", name: "CPT_Ecritures_Id", newName: "IdEcriture");
            RenameIndex(table: "dbo.CPT_Echeances", name: "IX_CPT_Ecritures_Id", newName: "IX_IdEcriture");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.CPT_Echeances", name: "IX_IdEcriture", newName: "IX_CPT_Ecritures_Id");
            RenameColumn(table: "dbo.CPT_Echeances", name: "IdEcriture", newName: "CPT_Ecritures_Id");
            AddColumn("dbo.CPT_Echeances", "IdEcriture", c => c.Long());
        }
    }
}
