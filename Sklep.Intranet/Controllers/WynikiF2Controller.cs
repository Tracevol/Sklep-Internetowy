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
    public class WynikiF2Controller : Controller
    {
        private readonly SklepContext _context;

        public WynikiF2Controller(SklepContext context)
        {
            _context = context;
        }

        // GET: WynikiF2
        public async Task<IActionResult> Index()
        {
              return _context.WynikiF2 != null ? 
                          View(await _context.WynikiF2.ToListAsync()) :
                          Problem("Entity set 'SklepContext.WynikiF2'  is null.");
        }

        // GET: WynikiF2/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.WynikiF2 == null)
            {
                return NotFound();
            }

            var wynikiF2 = await _context.WynikiF2
                .FirstOrDefaultAsync(m => m.IdWyniku == id);
            if (wynikiF2 == null)
            {
                return NotFound();
            }

            return View(wynikiF2);
        }

        // GET: WynikiF2/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WynikiF2/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdWyniku,PozycjaKierowcy,ImieNazwisko,Zespol,Punkty")] WynikiF2 wynikiF2)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wynikiF2);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(wynikiF2);
        }

        // GET: WynikiF2/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.WynikiF2 == null)
            {
                return NotFound();
            }

            var wynikiF2 = await _context.WynikiF2.FindAsync(id);
            if (wynikiF2 == null)
            {
                return NotFound();
            }
            return View(wynikiF2);
        }

        // POST: WynikiF2/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdWyniku,PozycjaKierowcy,ImieNazwisko,Zespol,Punkty")] WynikiF2 wynikiF2)
        {
            if (id != wynikiF2.IdWyniku)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wynikiF2);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WynikiF2Exists(wynikiF2.IdWyniku))
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
            return View(wynikiF2);
        }

        // GET: WynikiF2/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.WynikiF2 == null)
            {
                return NotFound();
            }

            var wynikiF2 = await _context.WynikiF2
                .FirstOrDefaultAsync(m => m.IdWyniku == id);
            if (wynikiF2 == null)
            {
                return NotFound();
            }

            return View(wynikiF2);
        }

        // POST: WynikiF2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.WynikiF2 == null)
            {
                return Problem("Entity set 'SklepContext.WynikiF2'  is null.");
            }
            var wynikiF2 = await _context.WynikiF2.FindAsync(id);
            if (wynikiF2 != null)
            {
                _context.WynikiF2.Remove(wynikiF2);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WynikiF2Exists(int id)
        {
          return (_context.WynikiF2?.Any(e => e.IdWyniku == id)).GetValueOrDefault();
        }
    }
}
