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
    public class WynikiIndyCarController : Controller
    {
        private readonly SklepContext _context;

        public WynikiIndyCarController(SklepContext context)
        {
            _context = context;
        }

        // GET: WynikiIndyCar
        public async Task<IActionResult> Index()
        {
              return _context.IndyCar != null ? 
                          View(await _context.IndyCar.ToListAsync()) :
                          Problem("Entity set 'SklepContext.IndyCar'  is null.");
        }

        // GET: WynikiIndyCar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.IndyCar == null)
            {
                return NotFound();
            }

            var wynikiIndyCar = await _context.IndyCar
                .FirstOrDefaultAsync(m => m.IdWyniku == id);
            if (wynikiIndyCar == null)
            {
                return NotFound();
            }

            return View(wynikiIndyCar);
        }

        // GET: WynikiIndyCar/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WynikiIndyCar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdWyniku,PozycjaKierowcy,ImieNazwisko,Zespol,Punkty")] WynikiIndyCar wynikiIndyCar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wynikiIndyCar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(wynikiIndyCar);
        }

        // GET: WynikiIndyCar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.IndyCar == null)
            {
                return NotFound();
            }

            var wynikiIndyCar = await _context.IndyCar.FindAsync(id);
            if (wynikiIndyCar == null)
            {
                return NotFound();
            }
            return View(wynikiIndyCar);
        }

        // POST: WynikiIndyCar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdWyniku,PozycjaKierowcy,ImieNazwisko,Zespol,Punkty")] WynikiIndyCar wynikiIndyCar)
        {
            if (id != wynikiIndyCar.IdWyniku)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wynikiIndyCar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WynikiIndyCarExists(wynikiIndyCar.IdWyniku))
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
            return View(wynikiIndyCar);
        }

        // GET: WynikiIndyCar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.IndyCar == null)
            {
                return NotFound();
            }

            var wynikiIndyCar = await _context.IndyCar
                .FirstOrDefaultAsync(m => m.IdWyniku == id);
            if (wynikiIndyCar == null)
            {
                return NotFound();
            }

            return View(wynikiIndyCar);
        }

        // POST: WynikiIndyCar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.IndyCar == null)
            {
                return Problem("Entity set 'SklepContext.IndyCar'  is null.");
            }
            var wynikiIndyCar = await _context.IndyCar.FindAsync(id);
            if (wynikiIndyCar != null)
            {
                _context.IndyCar.Remove(wynikiIndyCar);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WynikiIndyCarExists(int id)
        {
          return (_context.IndyCar?.Any(e => e.IdWyniku == id)).GetValueOrDefault();
        }
    }
}
