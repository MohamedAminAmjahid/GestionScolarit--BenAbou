using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionScolarité.Models
{
    public class Etudiant : Utilisateur
    {
        public Etudiant()
        {

        }
        public Etudiant(int id, string nom, string prenom, string role, string mail, string password,string status, string section):base(id, nom, prenom, role, mail, password)
        {
            this.Status= status;
            this.Section= section;
        }
        public string Status { get; set; }
        public string Section { get; set; }

    }
}