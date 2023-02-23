using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionScolarité.Models
{
    public class Matier
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Section { get; set; }
        public int idEtudiant { get; set; }
        public float Note { get; set; }
        public int idEnseignant { get; set; }

    }
}