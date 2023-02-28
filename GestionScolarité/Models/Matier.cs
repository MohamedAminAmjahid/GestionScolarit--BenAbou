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

        public int IdSection { get; set; }
        public int IdEnseignant { get; set; }
        public string Status { get; set; }
        /*
        public Matier()
        {
            this.Status = "Notaffected";
        }
        */

    }
}