using Microsoft.AspNetCore.Mvc;
using Sklep.Data.Data;
using Sklep.PortalWWW.Models;
using System.Diagnostics;

namespace Sklep.PortalWWW.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SklepContext _context;

        public HomeController(SklepContext context)
        {
            _context = context;
        }

        public IActionResult Index(int? id) // id strony wyświetlanej
        {
            ViewBag.ModelStrony = 
                (
                  from strona in _context.Strona
                  orderby strona.Pozycja
                  select strona
                ).ToList();
            

            ViewBag.ModelAktualnosci =
                (
                from aktualnosc in _context.Aktualnosci
                orderby aktualnosc.Pozycja
                select aktualnosc
                ).ToList();

            
            if (id == null)
                id = _context.Strona.First().IdStrona;
            // Przy kolejnym kliknęciu strony ID będzie nadawane z linku
            var item = _context.Strona.Find(id);
            // do widoku przekazuje te znaleziona strone z bazy danych o danym ID
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Ogloszenia()
        {
            var result = (from item in _context.SprzedazSamochodu select item).ToList();
            return View(result);
        }
        public IActionResult Wyniki()
        {
            ViewBag.WynikiF1 =
               (
                 from wynikif1 in _context.Wyniki
                 orderby wynikif1.PozycjaKierowcy
                 select wynikif1
               ).ToList();
            return View();
        }

        public IActionResult WynikiF1()
        {
            ViewBag.WynikiF1 =
            (
              from wynikif1 in _context.Wyniki
              orderby wynikif1.PozycjaKierowcy
              select wynikif1
            ).ToList();
            return View();
        }

        public IActionResult Ciekawostki()
        {
            return View();
        }
        public IActionResult Motoryzacja()
        {
            return View();
        }
        public IActionResult Logowanie()
        {
            return View();
        }
        public IActionResult Rejestracja()
        {
            return View();
        }

        public IActionResult WynikiPoprawne()
        {
            var result = (from item in _context.Wyniki select item).ToList();
            return View(result);
        }

        public IActionResult WynikiF2()
        {
            var result = (from item in _context.WynikiF2 select item).ToList();
            return View(result);
        }
        public IActionResult WynikiDTM()
        {
            var result = (from item in _context.DTM select item).ToList();
            return View(result);
        }
        public IActionResult WynikiEnduracne()
        {
            var result = (from item in _context.Endurance select item).ToList();
            return View(result);
        }
        public IActionResult WynikiIndyCar()
        {
            var result = (from item in _context.IndyCar select item).ToList();
            return View(result);
        }
        public IActionResult WynikiFormulaE()
        {
            var result = (from item in _context.FormulaE select item).ToList();
            return View(result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}