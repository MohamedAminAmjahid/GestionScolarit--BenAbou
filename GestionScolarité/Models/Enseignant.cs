using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionScolarité.Models
{
    public class Enseignant:Utilisateur
    {
        public Enseignant() { }
        public Enseignant(int id, string nom, string prenom, string role, string mail, string password, string tel, List<string> matieres) : base(id, nom, prenom, role, mail, password)
        {
            this.Tel = tel;
            this.Matieres = matieres;
        }
        public string Tel { get; set; }
        public List<string> Matieres { get;set; }

    }
}