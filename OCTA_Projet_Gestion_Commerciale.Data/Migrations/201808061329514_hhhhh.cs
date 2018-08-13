namespace OCTA_Projet_Gestion_Commerciale.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hhhhh : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.GEN_Items", "IdModel");
            RenameColumn(table: "dbo.GEN_Items", name: "GEN_Model_Id", newName: "IdModel");
            RenameIndex(table: "dbo.GEN_Items", name: "IX_GEN_Model_Id", newName: "IX_IdModel");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.GEN_Items", name: "IX_IdModel", newName: "IX_GEN_Model_Id");
            RenameColumn(table: "dbo.GEN_Items", name: "IdModel", newName: "GEN_Model_Id");
            AddColumn("dbo.GEN_Items", "IdModel", c => c.Long());
        }
    }
}
