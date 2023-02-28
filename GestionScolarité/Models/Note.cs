using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc.Routing.Constraints;

namespace GestionScolarité.Models
{
    public class Note
    {
        public int Id { get; set; }
        [Range(0.0, 20.0, ErrorMessage = "La note doit être entre 0 et 20.")]
        public double Marque { get; set; }
        public int IdEtudiant { get; set; }
        public int IdMatiere { get; set; }
    }
}