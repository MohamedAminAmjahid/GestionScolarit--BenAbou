using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GestionScolarité.Data;
using GestionScolarité.Models;

namespace GestionScolarité.Controllers
{
    public class EtudiantsController : Controller
    {
        private GestionScolaritéContext db = new GestionScolaritéContext();

        // GET: Etudiants
        public ActionResult Index()
        {
            return View(db.Etudiants.ToList());
        }
        public ActionResult ListerEtudiant()
        {
            return View(db.Etudiants.ToList());
        }
        public ActionResult Confirmer(int id)
        {
            foreach (var item in db.Etudiants)
            {
                if (item.Id == id) item.Status = "Confirmé";
            }
            db.SaveChanges();
            return RedirectToAction("ListerEtudiant");
        }

        // GET: Etudiants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Etudiant etudiant = db.Etudiants.Find(id);
            if (etudiant == null)
            {
                return HttpNotFound();
            }
            return View(etudiant);
        }

        // GET: Etudiants/Create
        public ActionResult InscriptionEtudiant()
        {
            return View();
        }

        // POST: Etudiants/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InscriptionEtudiant([Bind(Include = "Id,Status,Section,Nom,Prenom,Role,Mail,Password")] Etudiant etudiant)
        {
            if (ModelState.IsValid)
            {
                etudiant.Role = "Etudiant";
                etudiant.Status = "Non confirmé";
                etudiant.Section = "0";
                db.Etudiants.Add(etudiant);
                db.SaveChanges();
                return RedirectToAction("Authentification", "Home");
            }

            return View(etudiant);
        }

        // GET: Etudiants/Edit/5
        public ActionResult Edit(int? id)
        {
            List<String> liste = new List<String>();
            liste.Add("1er année");
            liste.Add("2éme année");
            liste.Add("3éme annnée");
            liste.Add("M1");
            liste.Add("M2");
            ViewBag.Sections = new SelectList(liste);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Etudiant etudiant = db.Etudiants.Find(id);
            if (etudiant == null)
            {
                return HttpNotFound();
            }
            return View(etudiant);
        }

        // POST: Etudiants/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Status,Section,Nom,Prenom,Role,Mail,Password")] Etudiant etudiant)
        {
            if (ModelState.IsValid)
            {
                etudiant.Role = "Etudiant";
                db.Entry(etudiant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(etudiant);
        }

        // GET: Etudiants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Etudiant etudiant = db.Etudiants.Find(id);
            if (etudiant == null)
            {
                return HttpNotFound();
            }
            return View(etudiant);
        }

        // POST: Etudiants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Etudiant etudiant = db.Etudiants.Find(id);
            db.Etudiants.Remove(etudiant);
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
    }
}
