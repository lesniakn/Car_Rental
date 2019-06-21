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
    public class wypozyczeniaController : Controller
    {
        private CarRentalDBEntities db = new CarRentalDBEntities();

        // GET: wypozyczenia
        public ActionResult Index()
        {
            int temp = Convert.ToInt32(Session["Id_uzytkownik"]);
            var wypozyczenia = db.wypozyczenia.Include(w => w.samochody).Include(w => w.uzytkownicy);
            var mojalista = wypozyczenia.Where(x => x.Id_uzytkownika == temp);
            return View(mojalista.ToList());
        }

        // GET: wypozyczenia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            wypozyczenia wypozyczenia = db.wypozyczenia.Find(id);
            if (wypozyczenia == null)
            {
                return HttpNotFound();
            }
            return View(wypozyczenia);
        }

        // GET: wypozyczenia/Create
        public ActionResult Create()
        {
            ViewBag.Id_samochodu = new SelectList(db.samochody, "Id_samochod", "Id_samochod");
            ViewBag.Id_uzytkownika = new SelectList(db.uzytkownicy, "Id_uzytkownik", "Id_uzytkownik");
            return View();
        }

        // POST: wypozyczenia/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_wypozyczenia,Id_uzytkownika,Id_samochodu,Data_wypozyczenia,Data_zwrotu,Cena")] wypozyczenia wypozyczenia)
        {
            if (ModelState.IsValid)
            {
                db.wypozyczenia.Add(wypozyczenia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_samochodu = new SelectList(db.samochody, "Id_samochod", "Id_samochod", wypozyczenia.Id_samochodu);
            ViewBag.Id_uzytkownika = new SelectList(db.uzytkownicy, "Id_uzytkownik", "Id_uzytkownik", wypozyczenia.Id_uzytkownika);
            return View(wypozyczenia);
        }

        // GET: wypozyczenia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            wypozyczenia wypozyczenia = db.wypozyczenia.Find(id);
            if (wypozyczenia == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_samochodu = new SelectList(db.samochody, "Id_samochod", "Id_samochod", wypozyczenia.Id_samochodu);
            ViewBag.Id_uzytkownika = new SelectList(db.uzytkownicy, "Id_uzytkownik", "Imie", wypozyczenia.Id_uzytkownika);
            return View(wypozyczenia);
        }

        // POST: wypozyczenia/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_wypozyczenia,Id_uzytkownika,Id_samochodu,Data_wypozyczenia,Data_zwrotu,Cena")] wypozyczenia wypozyczenia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wypozyczenia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_samochodu = new SelectList(db.samochody, "Id_samochod", "Id_samochod", wypozyczenia.Id_samochodu);
            ViewBag.Id_uzytkownika = new SelectList(db.uzytkownicy, "Id_uzytkownik", "Imie", wypozyczenia.Id_uzytkownika);
            return View(wypozyczenia);
        }

        // GET: wypozyczenia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            wypozyczenia wypozyczenia = db.wypozyczenia.Find(id);
            if (wypozyczenia == null)
            {
                return HttpNotFound();
            }
            return View(wypozyczenia);
        }

        // POST: wypozyczenia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            wypozyczenia wypozyczenia = db.wypozyczenia.Find(id);
            db.wypozyczenia.Remove(wypozyczenia);
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
