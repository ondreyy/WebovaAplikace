using Microsoft.AspNetCore.Mvc;
using WebovaAplikace.Data;
using WebovaAplikace.Models;

namespace WebovaAplikace.Controllers
{
    public class PoznamkyController : Controller
    {
        NasDatovyKontext Databaze { get; }

        public PoznamkyController(NasDatovyKontext databaze)
        {
            Databaze = databaze;
        }

        [HttpGet]
        public IActionResult Pridat()
        {
            string? pristup = HttpContext.Session.GetString("PristupOveren");

            if (pristup == null || pristup != "Ano")
                return RedirectToAction("Zkontrolovat", "Pristup");

            return View();
        }

        [HttpPost]
        public IActionResult Pridat(string nadpis, string text)
        {
            if (nadpis == null || nadpis.Trim().Length == 0)
                return RedirectToAction("Pridat");
            if(text == null || text.Trim().Length == 0)
                return RedirectToAction("Pridat");

            Poznamka vznikajiciPoznamka = new Poznamka()
            {
                Nadpis = nadpis,
                Text = text,
                CasPridani = DateTime.Now,
            };

            Databaze.Add(vznikajiciPoznamka);
            Databaze.SaveChanges();

            return RedirectToAction("Podekovani");
        }

        [HttpGet]
        public IActionResult Podekovani()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Prehled()
        {
            List<Poznamka> poznamkyVDatabazi = Databaze.Poznamky.ToList();

            poznamkyVDatabazi.Reverse();

            return View(poznamkyVDatabazi);
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            Poznamka? vyzadanaPoznamka = Databaze.Poznamky
                .Where(n => n.Id == id)
                .FirstOrDefault();

            if(vyzadanaPoznamka == null)
            {
                return RedirectToAction("Error", "Vychozi");
            }

            return View(vyzadanaPoznamka);
        }

        [HttpPost]
        public IActionResult Smazat(int id)
        {
            Poznamka? mazanaPoznamka = Databaze.Poznamky
                .Where(n => n.Id == id)
                .FirstOrDefault();

            if (mazanaPoznamka != null)
            {
                Databaze.Remove(mazanaPoznamka);
                Databaze.SaveChanges();
            }

            return RedirectToAction("Prehled");
        }
    }
}
