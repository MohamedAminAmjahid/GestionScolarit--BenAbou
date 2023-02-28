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
    public class MatiersController : Controller
    {
        private GestionScolaritéContext db = new GestionScolaritéContext();

        // GET: Matiers
        public ActionResult Index()
        {
            int ids = int.Parse(Session["idE"].ToString());
            if (db.Utilisateurs.Find(ids).Role == "Directeur")
            {
                return View(db.Matiers.ToList());
            }
            else
            {
                return View(db.Matiers.Where(m => m.IdEnseignant == ids).ToList());
            }
        }

        // GET: Matiers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matier matier = db.Matiers.Find(id);
            if (matier == null)
            {
                return HttpNotFound();
            }
            return View(matier);
        }

        // GET: Matiers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Matiers/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,IdSection,IdEnseignant,Status")] Matier matier)
        {
            if (ModelState.IsValid)
            {
                db.Matiers.Add(matier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(matier);
        }

        // GET: Matiers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matier matier = db.Matiers.Find(id);
            if (matier == null)
            {
                return HttpNotFound();
            }
            return View(matier);
        }

        // POST: Matiers/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Matier matier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(matier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(matier);
        }


        // GET: Matiers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matier matier = db.Matiers.Find(id);
            if (matier == null)
            {
                return HttpNotFound();
            }
            return View(matier);
        }

        // POST: Matiers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Matier matier = db.Matiers.Find(id);
            db.Matiers.Remove(matier);
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
