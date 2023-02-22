using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionScolarité.Models
{
    public class Note
    {
        public int Id { get; set; }
        public int IdEtudiant { get; set; }
        public int IdMatiere { get; set; }
    }
}