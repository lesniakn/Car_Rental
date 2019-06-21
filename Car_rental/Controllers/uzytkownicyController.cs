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
    public class uzytkownicyController : Controller
    {
        private CarRentalDBEntities db = new CarRentalDBEntities();

        // GET: uzytkownicy
        public ActionResult Index()
        {
            var uzytkownicy = db.uzytkownicy.Include(u => u.Role);
            return View(uzytkownicy.ToList());
        }

        // GET: uzytkownicy/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            uzytkownicy uzytkownicy = db.uzytkownicy.Find(id);
            if (uzytkownicy == null)
            {
                return HttpNotFound();
            }
            return View(uzytkownicy);
        }

        // GET: uzytkownicy/Create
        public ActionResult Create()
        {
            ViewBag.Rola = new SelectList(db.Role, "Id_rola", "Nazwa");
            return View();
        }

        // POST: uzytkownicy/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_uzytkownik,Imie,Nazwisko,Adres_zamieszkania,Data_urodzenia,Login,Haslo,Rola,Nr_prawa_jazdy,PESEL")] uzytkownicy uzytkownicy)
        {
            if (ModelState.IsValid)
            {
                db.uzytkownicy.Add(uzytkownicy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Rola = new SelectList(db.Role, "Id_rola", "Nazwa", uzytkownicy.Rola);
            return View(uzytkownicy);
        }

        // GET: uzytkownicy/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            uzytkownicy uzytkownicy = db.uzytkownicy.Find(id);
            if (uzytkownicy == null)
            {
                return HttpNotFound();
            }
            ViewBag.Rola = new SelectList(db.Role, "Id_rola", "Nazwa", uzytkownicy.Rola);
            return View(uzytkownicy);
        }

        // POST: uzytkownicy/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_uzytkownik,Imie,Nazwisko,Adres_zamieszkania,Data_urodzenia,Login,Haslo,Rola,Nr_prawa_jazdy,PESEL")] uzytkownicy uzytkownicy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uzytkownicy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Rola = new SelectList(db.Role, "Id_rola", "Nazwa", uzytkownicy.Rola);
            return View(uzytkownicy);
        }

        // GET: uzytkownicy/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            uzytkownicy uzytkownicy = db.uzytkownicy.Find(id);
            if (uzytkownicy == null)
            {
                return HttpNotFound();
            }
            return View(uzytkownicy);
        }

        // POST: uzytkownicy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            uzytkownicy uzytkownicy = db.uzytkownicy.Find(id);
            db.uzytkownicy.Remove(uzytkownicy);
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
