using Microsoft.AspNetCore.Mvc;
using WebovaAplikace.Data;
using WebovaAplikace.Models;

namespace WebovaAplikace.Controllers
{
    public class PristupController : Controller
    {
        private NasDatovyKontext Databaze { get; set; }

        public PristupController(NasDatovyKontext databaze)
        {
            Databaze = databaze;
        }

        [HttpGet]
        public IActionResult Zkontrolovat()
        {
            Pristup? existujiciPristup = Databaze.Pristup.FirstOrDefault();

            if (existujiciPristup == null)
            {
                return RedirectToAction("Vytvorit");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Zkontrolovat(string uzivatel, string heslo)
        {
            Pristup? uzivatel = Databaze.Pristup
                .Where(pristup => pristup.Uzivatel == uzivatel)
                .FirstOrDefault();

            if (!BCrypt.Net.BCrypt.Verify(heslo, uzivatel.Heslo))
            {
                return RedirectToAction("Overit");
            }

            HttpContext.Session.SetString("PristupOveren", "Ano");

            return RedirectToAction("Pridat", "Poznamky");
        }

        [HttpGet]
        public IActionResult Vytvorit()
        {
            Pristup? existujiciPristup = Databaze.Pristup.FirstOrDefault();

            if (existujiciPristup != null)
            {
                return RedirectToAction("Zkontrolovat");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Vytvorit(string heslo, string znovu)
        {
            if (heslo == null || heslo.Trim().Length == 0)
                return RedirectToAction("Vytvorit");
            if(heslo != znovu)
                return RedirectToAction("Vytvorit");

            heslo = BCrypt.Net.BCrypt.HashPassword(heslo);

            Databaze.Pristup.Add(new Pristup() { Heslo = heslo });
            Databaze.SaveChanges();

            return RedirectToAction("Zkontrolovat");
        }

        [HttpGet]
        public IActionResult Zrusit()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Home");
        }
    }
}
