using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sklep.Data.Data;

namespace Sklep.PortalWWW.Controllers
{
    public class SklepController : Controller
    {
        private readonly SklepContext _context;
        public SklepController(SklepContext context)
        {
            this._context = context;
        }
        public async Task<IActionResult> Index(int? id)
        {
            // pobieramy do ViewBaga wszystkie rodzaje z bazy danych aby wyświetlić je w menu
            //ViewBag.ModelRodzaj = await _context.Rodzaj.ToListAsync();

            // Bez promocji
            // przy pierwszym wejsci jak nie ma klikniętej kategorii to domyślnie ustawia się pierwsza z bazy danych
            //if(id == null)
            //{
            //    var pierwszy = await _context.Rodzaj.FirstAsync();
            //    id = pierwszy.IdRodzaju;
            //}

            // return View(await _context.Ogloszenia.Where(o => o.IdRodzaju == id).ToListAsync());

            if (id == null)
            {
                return View(await _context.Ogloszenia.Where(o => o.Promocja == true).ToListAsync());
            }
            else
            {
                // przekazuję listę ogłoszeń danego rodzaju do widoku
                return View(await _context.Ogloszenia.Where(o => o.IdRodzaju == id).ToListAsync());
            }        
        }

        public async Task<IActionResult> Szczegoly(int id) // wyswietla szczeguly ogloszenia
        {
            ViewBag.ModelRodzaj = await _context.Rodzaj.ToListAsync();
            // Do widoku przekazuje ogłoszenie które kliknięto
            return View(await _context.Ogloszenia.Where(o => o.IdOgloszenia == id).FirstOrDefaultAsync());
        }

        public async Task<IActionResult> Promocje()
        {
            return View(await _context.Ogloszenia.Where(o => o.Promocja == true).ToArrayAsync());
        }
    }
}
