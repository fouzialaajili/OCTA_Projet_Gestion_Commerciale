namespace OCTA_Projet_Gestion_Commerciale.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gg : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.GEN_Devise", "DeviseSocieteId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GEN_Devise", "DeviseSocieteId", c => c.Long(nullable: false));
        }
    }
}
