namespace OCTA_Projet_Gestion_Commerciale.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GG : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GEN_Devise", "GEN_Dossiers_DossierId", "dbo.GEN_Dossier");
            DropIndex("dbo.GEN_Devise", new[] { "GEN_Dossiers_DossierId" });
            DropColumn("dbo.GEN_Devise", "GEN_Dossiers_DossierId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GEN_Devise", "GEN_Dossiers_DossierId", c => c.Long());
            CreateIndex("dbo.GEN_Devise", "GEN_Dossiers_DossierId");
            AddForeignKey("dbo.GEN_Devise", "GEN_Dossiers_DossierId", "dbo.GEN_Dossier", "DossierId");
        }
    }
}
