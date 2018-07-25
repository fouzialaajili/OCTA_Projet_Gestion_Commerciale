namespace OCTA_Projet_Gestion_Commerciale.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstMigation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Licence",
                c => new
                    {
                        LicenceId = c.Long(nullable: false, identity: true),
                        LicenceNumeroSerieid = c.Int(nullable: false),
                        LicenceRaisonSociale = c.String(),
                        LicenceNombreSociete = c.Int(nullable: false),
                        LicenceNombreUser = c.Int(nullable: false),
                        LicenceActif = c.Boolean(nullable: false),
                        LicenceCHash = c.String(),
                        LicenceDateFinContrat = c.DateTime(nullable: false),
                        LicenceRenouvellable = c.String(),
                        LicenceSysDateCreation = c.DateTime(nullable: false),
                        LicenceSysDateUpdate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.LicenceId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Licence");
        }
    }
}
