using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionScolarité.Models
{
    public class Administartif : Utilisateur
    {
        public Administartif() { }
        public Administartif(int id, string nom, string prenom, string role, string mail, string password, int section, string tel, int age) : base(id, nom, prenom, role, mail, password, section)
        {
            this.Tel = tel;
            this.Age = age;
        }
        public string Tel { get; set; }
        public int Age { get; set; }
    }
}