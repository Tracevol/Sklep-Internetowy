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
    public class CiekawostkiController : Controller
    {
        private readonly SklepContext _context;

        public CiekawostkiController(SklepContext context)
        {
            _context = context;
        }

        // GET: Ciekawostki
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ciekawostki.ToListAsync());
        }

        // GET: Ciekawostki/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ciekawostki = await _context.Ciekawostki
                .FirstOrDefaultAsync(m => m.IdCiekawostki == id);
            if (ciekawostki == null)
            {
                return NotFound();
            }

            return View(ciekawostki);
        }

        // GET: Ciekawostki/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ciekawostki/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCiekawostki,LinkTytul,Tytul,Tresc,Zdjecie,Pozycja")] Ciekawostki ciekawostki)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ciekawostki);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ciekawostki);
        }

        // GET: Ciekawostki/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ciekawostki = await _context.Ciekawostki.FindAsync(id);
            if (ciekawostki == null)
            {
                return NotFound();
            }
            return View(ciekawostki);
        }

        // POST: Ciekawostki/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCiekawostki,LinkTytul,Tytul,Tresc,Zdjecie,Pozycja")] Ciekawostki ciekawostki)
        {
            if (id != ciekawostki.IdCiekawostki)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ciekawostki);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CiekawostkiExists(ciekawostki.IdCiekawostki))
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
            return View(ciekawostki);
        }

        // GET: Ciekawostki/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ciekawostki = await _context.Ciekawostki
                .FirstOrDefaultAsync(m => m.IdCiekawostki == id);
            if (ciekawostki == null)
            {
                return NotFound();
            }

            return View(ciekawostki);
        }

        // POST: Ciekawostki/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ciekawostki = await _context.Ciekawostki.FindAsync(id);
            _context.Ciekawostki.Remove(ciekawostki);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CiekawostkiExists(int id)
        {
            return _context.Ciekawostki.Any(e => e.IdCiekawostki == id);
        }
    }
}
