using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GestionScolarité.Data
{
    public class GestionScolaritéContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public GestionScolaritéContext() : base("name=GestionScolaritéContext")
        {
        }

        public System.Data.Entity.DbSet<GestionScolarité.Models.Utilisateur> Utilisateurs { get; set; }

        public System.Data.Entity.DbSet<GestionScolarité.Models.Etudiant> Etudiants { get; set; }

        public System.Data.Entity.DbSet<GestionScolarité.Models.Enseignant> Enseignants { get; set; }

        public System.Data.Entity.DbSet<GestionScolarité.Models.Matier> Matiers { get; set; }
        public System.Data.Entity.DbSet<GestionScolarité.Models.Section> Sections { get; set; }
        public System.Data.Entity.DbSet<GestionScolarité.Models.Note> Motes { get; set; }
    }
}
