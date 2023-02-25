using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionScolarité.Models
{
    public class Enseignant:Utilisateur
    {
        public Enseignant() { }
        public Enseignant(int id, string nom, string prenom, string role, string mail, string password,  int section, string tel, string specialite) : base(id, nom, prenom, role, mail, password, section)
        {
            this.Tel = tel;
            this.Specialite = specialite;
        }
        public string Tel { get; set; }
        public string Specialite { get; set; }


    }
}