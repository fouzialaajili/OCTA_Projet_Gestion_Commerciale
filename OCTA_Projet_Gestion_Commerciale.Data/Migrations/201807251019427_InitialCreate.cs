namespace OCTA_Projet_Gestion_Commerciale.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admin",
                c => new
                    {
                        AdminId = c.Long(nullable: false, identity: true),
                        AdminLogin = c.String(),
                        AdminPassword = c.String(),
                        AdminActif = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AdminId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Admin");
        }
    }
}
