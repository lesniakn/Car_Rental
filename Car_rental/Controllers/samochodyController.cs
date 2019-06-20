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
    public class samochodyController : Controller
    {
        private CarRentalDBEntities db = new CarRentalDBEntities();

        // GET: samochody
        public ActionResult Index()
        {
            var samochody = db.samochody.Include(s => s.kategorie).Include(s => s.marki).Include(s => s.modele);
            return View(samochody.ToList());
        }

        // GET: samochody/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            samochody samochody = db.samochody.Find(id);
            if (samochody == null)
            {
                return HttpNotFound();
            }
            return View(samochody);
        }

        // GET: samochody/Create
        public ActionResult Create()
        {
            ViewBag.Id_kategoria = new SelectList(db.kategorie, "Id_kategoria", "Nazwa");
            ViewBag.Id_marka = new SelectList(db.marki, "Id_marka", "Nazwa");
            ViewBag.Id_model = new SelectList(db.modele, "Id_model", "Nazwa");
            return View();
        }

        // POST: samochody/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_samochod,Rocznik,Silnik,Id_marka,Id_model,Data_rejestracji,Cena,Id_kategoria")] samochody samochody)
        {
            if (ModelState.IsValid)
            {
                db.samochody.Add(samochody);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_kategoria = new SelectList(db.kategorie, "Id_kategoria", "Nazwa", samochody.Id_kategoria);
            ViewBag.Id_marka = new SelectList(db.marki, "Id_marka", "Nazwa", samochody.Id_marka);
            ViewBag.Id_model = new SelectList(db.modele, "Id_model", "Nazwa", samochody.Id_model);
            return View(samochody);
        }

        // GET: samochody/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            samochody samochody = db.samochody.Find(id);
            if (samochody == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_kategoria = new SelectList(db.kategorie, "Id_kategoria", "Nazwa", samochody.Id_kategoria);
            ViewBag.Id_marka = new SelectList(db.marki, "Id_marka", "Nazwa", samochody.Id_marka);
            ViewBag.Id_model = new SelectList(db.modele, "Id_model", "Nazwa", samochody.Id_model);
            return View(samochody);
        }

        // POST: samochody/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_samochod,Rocznik,Silnik,Id_marka,Id_model,Data_rejestracji,Cena,Id_kategoria")] samochody samochody)
        {
            if (ModelState.IsValid)
            {
                db.Entry(samochody).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_kategoria = new SelectList(db.kategorie, "Id_kategoria", "Nazwa", samochody.Id_kategoria);
            ViewBag.Id_marka = new SelectList(db.marki, "Id_marka", "Nazwa", samochody.Id_marka);
            ViewBag.Id_model = new SelectList(db.modele, "Id_model", "Nazwa", samochody.Id_model);
            return View(samochody);
        }

        // GET: samochody/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            samochody samochody = db.samochody.Find(id);
            if (samochody == null)
            {
                return HttpNotFound();
            }
            return View(samochody);
        }

        // POST: samochody/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            samochody samochody = db.samochody.Find(id);
            db.samochody.Remove(samochody);
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
