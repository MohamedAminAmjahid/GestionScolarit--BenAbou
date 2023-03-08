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
                        IdSection = c.Int(nullable: false),
                        Tel = c.String(),
                        Age = c.Int(),
                        Tel1 = c.String(),
                        Specialite = c.String(),
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
                        Status = c.String(),
                        Enseignant_Id = c.Int(),
                        Section_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Utilisateurs", t => t.Enseignant_Id)
                .ForeignKey("dbo.Sections", t => t.Section_Id)
                .Index(t => t.Enseignant_Id)
                .Index(t => t.Section_Id);
            
            CreateTable(
                "dbo.Sections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Notes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Marque = c.Double(nullable: false),
                        Etudiant_Id = c.Int(),
                        Matiere_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Utilisateurs", t => t.Etudiant_Id)
                .ForeignKey("dbo.Matiers", t => t.Matiere_Id)
                .Index(t => t.Etudiant_Id)
                .Index(t => t.Matiere_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notes", "Matiere_Id", "dbo.Matiers");
            DropForeignKey("dbo.Notes", "Etudiant_Id", "dbo.Utilisateurs");
            DropForeignKey("dbo.Matiers", "Section_Id", "dbo.Sections");
            DropForeignKey("dbo.Matiers", "Enseignant_Id", "dbo.Utilisateurs");
            DropIndex("dbo.Notes", new[] { "Matiere_Id" });
            DropIndex("dbo.Notes", new[] { "Etudiant_Id" });
            DropIndex("dbo.Matiers", new[] { "Section_Id" });
            DropIndex("dbo.Matiers", new[] { "Enseignant_Id" });
            DropTable("dbo.Notes");
            DropTable("dbo.Sections");
            DropTable("dbo.Matiers");
            DropTable("dbo.Utilisateurs");
        }
    }
}
