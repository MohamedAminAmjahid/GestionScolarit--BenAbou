using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionScolarité.Models
{
    public class Utilisateur
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Role { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string Section { get; set; }

        public Utilisateur()
        {

        }

        public Utilisateur(int id,  string nom, string prenom, string role, string mail, string password, string section)
        {
            Id = id;
            Nom = nom;
            Prenom = prenom;
            Role = role;
            Mail = mail;
            Password = password;
            Section = section;
        }
        
      }
}