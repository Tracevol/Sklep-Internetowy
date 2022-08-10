#nullable disable
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
    public class WynikiController : Controller
    {
        private readonly SklepContext _context;

        public WynikiController(SklepContext context)
        {
            _context = context;
        }

        // GET: Wyniki
        public async Task<IActionResult> Index()
        {
            return View(await _context.Wyniki.ToListAsync());
        }

        // GET: Wyniki/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wyniki = await _context.Wyniki
                .FirstOrDefaultAsync(m => m.IdWyniku == id);
            if (wyniki == null)
            {
                return NotFound();
            }

            return View(wyniki);
        }

        // GET: Wyniki/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Wyniki/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdWyniku,PozycjaKierowcy,ImieNazwisko,Zespol,Punkty")] Wyniki wyniki)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wyniki);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(wyniki);
        }

        // GET: Wyniki/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wyniki = await _context.Wyniki.FindAsync(id);
            if (wyniki == null)
            {
                return NotFound();
            }
            return View(wyniki);
        }

        // POST: Wyniki/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdWyniku,PozycjaKierowcy,ImieNazwisko,Zespol,Punkty")] Wyniki wyniki)
        {
            if (id != wyniki.IdWyniku)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wyniki);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WynikiExists(wyniki.IdWyniku))
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
            return View(wyniki);
        }

        // GET: Wyniki/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wyniki = await _context.Wyniki
                .FirstOrDefaultAsync(m => m.IdWyniku == id);
            if (wyniki == null)
            {
                return NotFound();
            }

            return View(wyniki);
        }

        // POST: Wyniki/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var wyniki = await _context.Wyniki.FindAsync(id);
            _context.Wyniki.Remove(wyniki);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WynikiExists(int id)
        {
            return _context.Wyniki.Any(e => e.IdWyniku == id);
        }
    }
}
