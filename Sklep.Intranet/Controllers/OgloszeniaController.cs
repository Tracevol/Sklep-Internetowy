using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sklep.Data.Data;
using Sklep.Data.Data.Tablica;

namespace Sklep.Intranet.Controllers
{
    public class OgloszeniaController : Controller
    {
        private readonly SklepContext _context;

        public OgloszeniaController(SklepContext context)
        {
            _context = context;
        }

        // GET: Ogloszenia
        public async Task<IActionResult> Index()
        {
              return _context.Ogloszenia != null ? 
                          View(await _context.Ogloszenia.ToListAsync()) :
                          Problem("Entity set 'SklepContext.Ogloszenia'  is null.");
        }

        // GET: Ogloszenia/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Ogloszenia == null)
            {
                return NotFound();
            }

            var ogloszenia = await _context.Ogloszenia
                .FirstOrDefaultAsync(m => m.IdOgloszenia == id);
            if (ogloszenia == null)
            {
                return NotFound();
            }

            return View(ogloszenia);
        }

        // GET: Ogloszenia/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ogloszenia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdOgloszenia,Kod,Nazwa,Cena,Foto,Opis,IdRodzaju,Promocja")] Ogloszenia ogloszenia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ogloszenia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ogloszenia);
        }

        // GET: Ogloszenia/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Ogloszenia == null)
            {
                return NotFound();
            }

            var ogloszenia = await _context.Ogloszenia.FindAsync(id);
            if (ogloszenia == null)
            {
                return NotFound();
            }
            return View(ogloszenia);
        }

        // POST: Ogloszenia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdOgloszenia,Kod,Nazwa,Cena,Foto,Opis,IdRodzaju,Promocja")] Ogloszenia ogloszenia)
        {
            if (id != ogloszenia.IdOgloszenia)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ogloszenia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OgloszeniaExists(ogloszenia.IdOgloszenia))
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
            return View(ogloszenia);
        }

        // GET: Ogloszenia/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Ogloszenia == null)
            {
                return NotFound();
            }

            var ogloszenia = await _context.Ogloszenia
                .FirstOrDefaultAsync(m => m.IdOgloszenia == id);
            if (ogloszenia == null)
            {
                return NotFound();
            }

            return View(ogloszenia);
        }

        // POST: Ogloszenia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Ogloszenia == null)
            {
                return Problem("Entity set 'SklepContext.Ogloszenia'  is null.");
            }
            var ogloszenia = await _context.Ogloszenia.FindAsync(id);
            if (ogloszenia != null)
            {
                _context.Ogloszenia.Remove(ogloszenia);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OgloszeniaExists(int id)
        {
          return (_context.Ogloszenia?.Any(e => e.IdOgloszenia == id)).GetValueOrDefault();
        }
    }
}
