using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using GestionScolarité.Data;
using GestionScolarité.Models;

namespace GestionScolarité.Controllers
{
    public class EnseignantsController : Controller
    {
        private GestionScolaritéContext db = new GestionScolaritéContext();

        // GET: Enseignants
        public ActionResult Index()
        {
            return View(db.Enseignants.ToList());
        }
        public ActionResult ListerEnseignants()
        {
            return View(db.Enseignants.ToList());
        }

        public ActionResult InscriptionEnseignant()
        {
            return View();
        }

        // POST: Enseignants/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InscriptionEnseignant([Bind(Include = "Id,Tel,Nom,Prenom,Role,Mail,Password")] Enseignant enseignant)
        {
            if (ModelState.IsValid)
            {
                enseignant.Role = "Enseignant";
                enseignant.IdSection = 0;
                db.Enseignants.Add(enseignant);
                db.SaveChanges();
                return RedirectToAction("Authentification", "Home");
            }

            return View(enseignant);
        }

        // GET: Enseignants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enseignant enseignant = db.Enseignants.Find(id);
            if (enseignant == null)
            {
                return HttpNotFound();
            }
            return View(enseignant);
        }

       
        public ActionResult Create()
        {
            return View();
        }

        // POST: Enseignants/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Tel,Nom,Prenom,Role,Mail,Password")] Enseignant enseignant)
        {
            if (ModelState.IsValid)
            {
                enseignant.Role = "Enseignant";
                enseignant.IdSection = 0;
                db.Enseignants.Add(enseignant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(enseignant);
        }
       
        
        public ActionResult AddMatier(int? id)
        {
            Session["id"] = id;
            List<String> liste = new List<String>();
            liste.Add("Algorithmique");
            liste.Add("Technologies dotNet");
            liste.Add("Java avancé");
            liste.Add("Python");
            liste.Add("Android");
            liste.Add("Analyse donnée");
            liste.Add("Business Intelligence");
            liste.Add("C/C++");
            liste.Add("Analyse Numérique");
            liste.Add("Oracle");
            ViewBag.Matiers = new SelectList(liste);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enseignant enseignant = db.Enseignants.Find(id);

            Session["section"] = enseignant.IdSection;
            if (enseignant == null)
            {
                return HttpNotFound();
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddMatier(Matier matier)
        {
            if (ModelState.IsValid)
            {
                int id = int.Parse(Session["id"] + "");
                matier.IdEnseignant = id;
                /// Wliiiii choufiiiiihhhaaaaaaaaaaaaaa
                matier.IdSection = 0;
                db.Matiers.Add(matier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(matier);
        }

        public ActionResult Matiers(int id)
        {
            return View(db.Matiers.Where(item => item.IdEnseignant == id));
        }
        public ActionResult Edit(int? id)
        {
            List<String> liste = new List<String>();
            liste.Add("1er année");
            liste.Add("2éme année");
            liste.Add("3éme année");
            liste.Add("M1");
            liste.Add("M2");
            ViewBag.Sections = new SelectList(liste);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enseignant enseignant = db.Enseignants.Find(id);
            if (enseignant == null)
            {
                return HttpNotFound();
            }
            return View(enseignant);
        }

        // POST: Etudiants/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Enseignant enseignant)
        {
            if (ModelState.IsValid)
            {
                enseignant.Role = "Enseignant";
                db.Entry(enseignant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(enseignant);
        }

        // GET: Enseignants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enseignant enseignant = db.Enseignants.Find(id);
            if (enseignant == null)
            {
                return HttpNotFound();
            }
            return View(enseignant);
        }

        // POST: Enseignants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Enseignant enseignant = db.Enseignants.Find(id);
            db.Utilisateurs.Remove(enseignant);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult AffecterMatiere(int id)
        {
            // ViewBag.Matiers = new SelectList(db.Matiers.Where(m => m.Status == "Notaffected"), "Id", "Name");
            ViewBag.Sections = new SelectList(db.Sections, "Id", "Name");
            ViewBag.Matiers = new SelectList(db.Matiers, "Id", "Name");
            ViewBag.IdE = id;
            return View();
        }

        [HttpPost]
        public ActionResult AffecterMatiere(Matier matiere)
        {
            if (ModelState.IsValid)
            {
                Matier matiereToUpdate = db.Matiers.Find(matiere.Id);

                if (matiereToUpdate != null)
                {
                    matiereToUpdate.IdSection = matiere.IdSection;
                    matiereToUpdate.IdEnseignant = matiere.IdEnseignant;
                    matiereToUpdate.Status = "affected";

                    db.SaveChanges();
                    return RedirectToAction("ListerEnseignants");
                }
            }
            return View();
        }
    }
}
