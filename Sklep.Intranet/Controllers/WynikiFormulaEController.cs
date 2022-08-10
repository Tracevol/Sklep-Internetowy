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
    public class WynikiFormulaEController : Controller
    {
        private readonly SklepContext _context;

        public WynikiFormulaEController(SklepContext context)
        {
            _context = context;
        }

        // GET: WynikiFormulaE
        public async Task<IActionResult> Index()
        {
              return _context.FormulaE != null ? 
                          View(await _context.FormulaE.ToListAsync()) :
                          Problem("Entity set 'SklepContext.FormulaE'  is null.");
        }

        // GET: WynikiFormulaE/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FormulaE == null)
            {
                return NotFound();
            }

            var wynikiFormulaE = await _context.FormulaE
                .FirstOrDefaultAsync(m => m.IdWyniku == id);
            if (wynikiFormulaE == null)
            {
                return NotFound();
            }

            return View(wynikiFormulaE);
        }

        // GET: WynikiFormulaE/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WynikiFormulaE/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdWyniku,PozycjaKierowcy,ImieNazwisko,Zespol,Punkty")] WynikiFormulaE wynikiFormulaE)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wynikiFormulaE);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(wynikiFormulaE);
        }

        // GET: WynikiFormulaE/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FormulaE == null)
            {
                return NotFound();
            }

            var wynikiFormulaE = await _context.FormulaE.FindAsync(id);
            if (wynikiFormulaE == null)
            {
                return NotFound();
            }
            return View(wynikiFormulaE);
        }

        // POST: WynikiFormulaE/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdWyniku,PozycjaKierowcy,ImieNazwisko,Zespol,Punkty")] WynikiFormulaE wynikiFormulaE)
        {
            if (id != wynikiFormulaE.IdWyniku)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wynikiFormulaE);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WynikiFormulaEExists(wynikiFormulaE.IdWyniku))
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
            return View(wynikiFormulaE);
        }

        // GET: WynikiFormulaE/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FormulaE == null)
            {
                return NotFound();
            }

            var wynikiFormulaE = await _context.FormulaE
                .FirstOrDefaultAsync(m => m.IdWyniku == id);
            if (wynikiFormulaE == null)
            {
                return NotFound();
            }

            return View(wynikiFormulaE);
        }

        // POST: WynikiFormulaE/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FormulaE == null)
            {
                return Problem("Entity set 'SklepContext.FormulaE'  is null.");
            }
            var wynikiFormulaE = await _context.FormulaE.FindAsync(id);
            if (wynikiFormulaE != null)
            {
                _context.FormulaE.Remove(wynikiFormulaE);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WynikiFormulaEExists(int id)
        {
          return (_context.FormulaE?.Any(e => e.IdWyniku == id)).GetValueOrDefault();
        }
    }
}
