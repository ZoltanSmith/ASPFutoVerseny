using ASPFutoVerseny.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASPFutoVerseny.Controllers
{
    public class HomeController(FutoDbContext db) : Controller
    {
        public IActionResult Index()
        {
            return View(db.Versenyzok.ToList());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
