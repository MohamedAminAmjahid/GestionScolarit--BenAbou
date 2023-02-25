using GestionScolarité.Data;
using GestionScolarité.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.SessionState;

namespace GestionScolarité.Controllers
{
    public class HomeController : Controller
    {
        private GestionScolaritéContext db = new GestionScolaritéContext();
        public ActionResult Authentification()
        {
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Authentification", "Home");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Authentification(FormCollection collection)
        {
            string nom = collection["Nom"];
            string ModePasse = collection["ModePasse"];
            Utilisateur u = db.Utilisateurs.FirstOrDefault(item => item.Nom == nom && item.Password == ModePasse);
            
            if (u != null)
            {
                Session["idE"] = u.Id;
                FormsAuthentication.SetAuthCookie(u.Role, false);
                if (u.Role == "Directeur")
                {
                    return RedirectToAction("Index", "Utilisateurs");
                }
                else if (u.Role == "Etudiant")
                {
                    Etudiant e = db.Etudiants.FirstOrDefault(item => item.Nom == nom && item.Password == ModePasse);
                    if (e.Status == "Non confirmé")
                    {
                        ViewBag.t = "Votre compte est en cours de confirmation!!!";
                        return View();
                    }
                    return RedirectToAction("Editt", "Etudiants");
                }
                else if (u.Role == "Enseignant")
                {
                    return RedirectToAction("About", "Home");
                    
                }
                else if (u.Role == "Administration")
                {
                    return RedirectToAction("Index", "Utilisateurs");
                }
            }
            ViewBag.t = "Nom ou mode passe est incorrecte!!!";
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}