namespace OCTA_Projet_Gestion_Commerciale.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class yareb1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.GES_Affaire", "AffaireSysDateCreation", c => c.DateTime());
            AlterColumn("dbo.GES_Affaire", "AffaireSysDateUpdate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.GES_Affaire", "AffaireSysDateUpdate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.GES_Affaire", "AffaireSysDateCreation", c => c.DateTime(nullable: false));
        }
    }
}
