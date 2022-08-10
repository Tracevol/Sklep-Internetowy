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
    public class WynikiEnduranceController : Controller
    {
        private readonly SklepContext _context;

        public WynikiEnduranceController(SklepContext context)
        {
            _context = context;
        }

        // GET: WynikiEndurance
        public async Task<IActionResult> Index()
        {
              return _context.Endurance != null ? 
                          View(await _context.Endurance.ToListAsync()) :
                          Problem("Entity set 'SklepContext.Endurance'  is null.");
        }

        // GET: WynikiEndurance/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Endurance == null)
            {
                return NotFound();
            }

            var wynikiEndurance = await _context.Endurance
                .FirstOrDefaultAsync(m => m.IdWyniku == id);
            if (wynikiEndurance == null)
            {
                return NotFound();
            }

            return View(wynikiEndurance);
        }

        // GET: WynikiEndurance/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WynikiEndurance/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdWyniku,PozycjaKierowcy,ImieNazwisko,Zespol,Punkty")] WynikiEndurance wynikiEndurance)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wynikiEndurance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(wynikiEndurance);
        }

        // GET: WynikiEndurance/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Endurance == null)
            {
                return NotFound();
            }

            var wynikiEndurance = await _context.Endurance.FindAsync(id);
            if (wynikiEndurance == null)
            {
                return NotFound();
            }
            return View(wynikiEndurance);
        }

        // POST: WynikiEndurance/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdWyniku,PozycjaKierowcy,ImieNazwisko,Zespol,Punkty")] WynikiEndurance wynikiEndurance)
        {
            if (id != wynikiEndurance.IdWyniku)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wynikiEndurance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WynikiEnduranceExists(wynikiEndurance.IdWyniku))
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
            return View(wynikiEndurance);
        }

        // GET: WynikiEndurance/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Endurance == null)
            {
                return NotFound();
            }

            var wynikiEndurance = await _context.Endurance
                .FirstOrDefaultAsync(m => m.IdWyniku == id);
            if (wynikiEndurance == null)
            {
                return NotFound();
            }

            return View(wynikiEndurance);
        }

        // POST: WynikiEndurance/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Endurance == null)
            {
                return Problem("Entity set 'SklepContext.Endurance'  is null.");
            }
            var wynikiEndurance = await _context.Endurance.FindAsync(id);
            if (wynikiEndurance != null)
            {
                _context.Endurance.Remove(wynikiEndurance);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WynikiEnduranceExists(int id)
        {
          return (_context.Endurance?.Any(e => e.IdWyniku == id)).GetValueOrDefault();
        }
    }
}
