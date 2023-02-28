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
        public Etudiant(int id, string nom, string prenom, string role, string mail, string password,string status, int section):base(id, nom, prenom, role, mail, password, section)
        {
            this.Status= status;
        }
        public string Status { get; set; }

    }
}