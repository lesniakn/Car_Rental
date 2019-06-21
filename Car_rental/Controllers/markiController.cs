using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Car_rental.Models;

namespace Car_rental.Controllers
{
    public class markiController : Controller
    {
        private CarRentalDBEntities db = new CarRentalDBEntities();

        // GET: marki
        public ActionResult Index()
        {
            return View(db.marki.ToList());
        }

        // GET: marki/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            marki marki = db.marki.Find(id);
            if (marki == null)
            {
                return HttpNotFound();
            }
            return View(marki);
        }

        // GET: marki/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: marki/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_marka,Nazwa")] marki marki)
        {
            if (ModelState.IsValid)
            {
                db.marki.Add(marki);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(marki);
        }

        // GET: marki/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            marki marki = db.marki.Find(id);
            if (marki == null)
            {
                return HttpNotFound();
            }
            return View(marki);
        }

        // POST: marki/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_marka,Nazwa")] marki marki)
        {
            if (ModelState.IsValid)
            {
                db.Entry(marki).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(marki);
        }

        // GET: marki/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            marki marki = db.marki.Find(id);
            if (marki == null)
            {
                return HttpNotFound();
            }
            return View(marki);
        }

        // POST: marki/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            marki marki = db.marki.Find(id);
            db.marki.Remove(marki);
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
