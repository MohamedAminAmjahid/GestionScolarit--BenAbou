namespace GestionScolarité.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Utilisateurs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Prenom = c.String(),
                        Role = c.String(),
                        Mail = c.String(),
                        Password = c.String(),
                        Section = c.String(),
                        Tel = c.String(),
                        Status = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Matiers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Section = c.String(),
                        idEtudiant = c.Int(nullable: false),
                        Note = c.Single(nullable: false),
                        idEnseignant = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Matiers");
            DropTable("dbo.Utilisateurs");
        }
    }
}
