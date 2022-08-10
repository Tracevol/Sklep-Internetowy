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
    public class AktualnosciController : Controller
    {
        private readonly SklepContext _context;

        public AktualnosciController(SklepContext context)
        {
            _context = context;
        }

        // GET: Aktualnosci
        public async Task<IActionResult> Index()
        {
              return _context.Aktualnosci != null ? 
                          View(await _context.Aktualnosci.ToListAsync()) :
                          Problem("Entity set 'SklepContext.Aktualnosci'  is null.");
        }

        // GET: Aktualnosci/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Aktualnosci == null)
            {
                return NotFound();
            }

            var aktualnosci = await _context.Aktualnosci
                .FirstOrDefaultAsync(m => m.IdStrona == id);
            if (aktualnosci == null)
            {
                return NotFound();
            }

            return View(aktualnosci);
        }

        // GET: Aktualnosci/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Aktualnosci/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdStrona,LinkTytul,Tytul,TablicaOgloszen,Pozycja")] Aktualnosci aktualnosci)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aktualnosci);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aktualnosci);
        }

        // GET: Aktualnosci/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Aktualnosci == null)
            {
                return NotFound();
            }

            var aktualnosci = await _context.Aktualnosci.FindAsync(id);
            if (aktualnosci == null)
            {
                return NotFound();
            }
            return View(aktualnosci);
        }

        // POST: Aktualnosci/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdStrona,LinkTytul,Tytul,TablicaOgloszen,Pozycja")] Aktualnosci aktualnosci)
        {
            if (id != aktualnosci.IdStrona)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aktualnosci);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AktualnosciExists(aktualnosci.IdStrona))
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
            return View(aktualnosci);
        }

        // GET: Aktualnosci/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Aktualnosci == null)
            {
                return NotFound();
            }

            var aktualnosci = await _context.Aktualnosci
                .FirstOrDefaultAsync(m => m.IdStrona == id);
            if (aktualnosci == null)
            {
                return NotFound();
            }

            return View(aktualnosci);
        }

        // POST: Aktualnosci/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Aktualnosci == null)
            {
                return Problem("Entity set 'SklepContext.Aktualnosci'  is null.");
            }
            var aktualnosci = await _context.Aktualnosci.FindAsync(id);
            if (aktualnosci != null)
            {
                _context.Aktualnosci.Remove(aktualnosci);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AktualnosciExists(int id)
        {
          return (_context.Aktualnosci?.Any(e => e.IdStrona == id)).GetValueOrDefault();
        }
    }
}
