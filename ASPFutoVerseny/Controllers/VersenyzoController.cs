using ASPFutoVerseny.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPFutoVerseny.Controllers
{
    public class VersenyzoController(FutoDbContext db) : Controller
    {
        [HttpGet]
        public IActionResult Uj()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Uj(Versenyzo v)
        {
            db.Versenyzok.Add(v);
            if (db.SaveChanges() == 1)
            {
                TempData["info"] = "sikeres mentés";
            } else
            {
                TempData["error"] = "nem sikerült menteni";
            }

            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).Replace("Controller", ""));
        }
    }
}
