using Microsoft.AspNetCore.Mvc;
using Sklep.Data.Data;
using Sklep.Data.Data.Tablica;
using Sklep.PortalWWW.Models.BusinessLogic;
using Sklep.PortalWWW.Models.Sklep;

namespace Sklep.PortalWWW.Controllers
{
    public class KoszykController : Controller
    {

        //operacje na bazie danych 
        private readonly SklepContext _context;

        public KoszykController(SklepContext context)
        {
            
            _context = context;
        }

        public async Task <IActionResult> Index()
        {
            KoszykB koszykB = new KoszykB(_context, this.HttpContext);
            DaneDoKoszyka daneDoKoszyka = new DaneDoKoszyka()
            {
                ElementyKoszyka = await koszykB.GetElementykoszykaKlienta(),
                Razem = await koszykB.GetRazem()
            };
            return View(daneDoKoszyka);
            //return View();
        }

        public async Task<IActionResult> DodajDoKoszyka(int id) // id towaru dodawanego
        {
            KoszykB koszykB = new KoszykB(_context, HttpContext);

            Ogloszenia ogloszenia = await _context.Ogloszenia.FindAsync(id);

            koszykB.DodajDoKoszyka(ogloszenia);

            return RedirectToAction("Index"); // po dodaniu przechodzimy do indeksu koszyka

        }

        public async Task<IActionResult> UsunKoszyk(int id) // id ogłoszenia usuwanego
        {
            KoszykB koszykB = new KoszykB(_context, HttpContext);


            koszykB.UsunKoszyk(id);

            return RedirectToAction("Index"); // po dodaniu przechodzimy do indeksu koszyka



        }
    }
}
