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
    public class AdministratifsController : Controller
    {
        private GestionScolaritéContext db = new GestionScolaritéContext();

        // GET: Administartifs
        public ActionResult Index()
        {
            return View(db.Administartifs.ToList());
        }

        // GET: Administartifs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Administartif administartif = db.Administartifs.Find(id);
            if (administartif == null)
            {
                return HttpNotFound();
            }
            return View(administartif);
        }

        // GET: Administartifs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administartifs/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Tel,Age,Nom,Prenom,Role,Mail,Password,IdSection")] Administartif administartif)
        {
            if (ModelState.IsValid)
            {
                administartif.Role = "Administratif";
                db.Administartifs.Add(administartif);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(administartif);
        }

        // GET: Administartifs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Administartif administartif = db.Administartifs.Find(id);
            if (administartif == null)
            {
                return HttpNotFound();
            }
            return View(administartif);
        }

        public ActionResult Editt()
        {
            int id = int.Parse("" + Session["idE"]);

            Administartif a = db.Administartifs.Find(id);
            if (a == null)
            {
                return HttpNotFound();
            }
            return View(a);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editt([Bind(Include = "Id,Nom,Prenom,Tel,Age,Mail,Password")] Administartif a)
        {
            if (ModelState.IsValid)
            {
                a.Role = "Administratif";
                db.Entry(a).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Editt");
            }
            return View(a);
        }

        // POST: Administartifs/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Tel,Age,Nom,Prenom,Mail,Password,IdSection")] Administartif administartif)
        {
            if (ModelState.IsValid)
            {
                db.Entry(administartif).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(administartif);
        }

        // GET: Administartifs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Administartif administartif = db.Administartifs.Find(id);
            if (administartif == null)
            {
                return HttpNotFound();
            }
            return View(administartif);
        }

        // POST: Administartifs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Administartif administartif = db.Administartifs.Find(id);
            db.Administartifs.Remove(administartif);
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
