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
    public class HomeController : Controller

    {

        private CarRentalDBEntities db = new CarRentalDBEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Register()
        {
            ViewBag.Rola = new SelectList(db.Role, "Id_rola", "Nazwa");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "Id_uzytkownik,Imie,Nazwisko,Adres_zamieszkania,Data_urodzenia,Login,Haslo,Rola,Nr_prawa_jazdy,PESEL")] uzytkownicy uzytkownicy)
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

        public ActionResult Autherize(Car_rental.Models.uzytkownicy userModel)
        {
            using (CarRentalDBEntities db = new CarRentalDBEntities())
            {
                var userDetails = db.uzytkownicy.Where(x => x.Login == userModel.Login && x.Haslo == userModel.Haslo).FirstOrDefault();
                if (userDetails == null)
                {
                    return View("Index", userModel);
                }
                else
                {
                    Session["Login"] = userDetails.Login;
                    Session["Rola"] = userDetails.Rola;
                    return RedirectToAction("Konto", "Home");
                }
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Konto()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}