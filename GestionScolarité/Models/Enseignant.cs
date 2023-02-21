using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionScolarité.Models
{
    public class Enseignant:Utilisateur
    {
        public Enseignant() { }
        public Enseignant(int id, string nom, string prenom, string role, string mail, string password,  string section, string tel) : base(id, nom, prenom, role, mail, password, section)
        {
            this.Tel = tel;
        }
        public string Tel { get; set; }

    }
}