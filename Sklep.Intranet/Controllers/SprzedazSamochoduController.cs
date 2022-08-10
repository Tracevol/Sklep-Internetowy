using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sklep.Data.Data;
using Sklep.Data.Data.CMS;

namespace Sklep.Intranet.Controllers
{
    public class SprzedazSamochoduController : Controller
    {
        private readonly SklepContext _context;

        public SprzedazSamochoduController(SklepContext context)
        {
            _context = context;
        }

        // GET: SprzedazSamochodu
        public async Task<IActionResult> Index()
        {
              return _context.SprzedazSamochodu != null ? 
                          View(await _context.SprzedazSamochodu.ToListAsync()) :
                          Problem("Entity set 'SklepContext.SprzedazSamochodu'  is null.");
        }

        // GET: SprzedazSamochodu/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SprzedazSamochodu == null)
            {
                return NotFound();
            }

            var sprzedazSamochodu = await _context.SprzedazSamochodu
                .FirstOrDefaultAsync(m => m.IdSprzedazy == id);
            if (sprzedazSamochodu == null)
            {
                return NotFound();
            }

            return View(sprzedazSamochodu);
        }

        // GET: SprzedazSamochodu/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SprzedazSamochodu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSprzedazy,Marka,Model,KrajPochodzenia,Przebieg,Cena,Lokalizacja,Telefon")] SprzedazSamochodu sprzedazSamochodu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sprzedazSamochodu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sprzedazSamochodu);
        }

        // GET: SprzedazSamochodu/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SprzedazSamochodu == null)
            {
                return NotFound();
            }

            var sprzedazSamochodu = await _context.SprzedazSamochodu.FindAsync(id);
            if (sprzedazSamochodu == null)
            {
                return NotFound();
            }
            return View(sprzedazSamochodu);
        }

        // POST: SprzedazSamochodu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSprzedazy,Marka,Model,KrajPochodzenia,Przebieg,Cena,Lokalizacja,Telefon")] SprzedazSamochodu sprzedazSamochodu)
        {
            if (id != sprzedazSamochodu.IdSprzedazy)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sprzedazSamochodu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SprzedazSamochoduExists(sprzedazSamochodu.IdSprzedazy))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(sprzedazSamochodu);
        }

        // GET: SprzedazSamochodu/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SprzedazSamochodu == null)
            {
                return NotFound();
            }

            var sprzedazSamochodu = await _context.SprzedazSamochodu
                .FirstOrDefaultAsync(m => m.IdSprzedazy == id);
            if (sprzedazSamochodu == null)
            {
                return NotFound();
            }

            return View(sprzedazSamochodu);
        }

        // POST: SprzedazSamochodu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SprzedazSamochodu == null)
            {
                return Problem("Entity set 'SklepContext.SprzedazSamochodu'  is null.");
            }
            var sprzedazSamochodu = await _context.SprzedazSamochodu.FindAsync(id);
            if (sprzedazSamochodu != null)
            {
                _context.SprzedazSamochodu.Remove(sprzedazSamochodu);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SprzedazSamochoduExists(int id)
        {
          return (_context.SprzedazSamochodu?.Any(e => e.IdSprzedazy == id)).GetValueOrDefault();
        }
    }
}
