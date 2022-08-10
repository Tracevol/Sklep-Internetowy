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
    public class ParametryController : Controller
    {
        private readonly SklepContext _context;

        public ParametryController(SklepContext context)
        {
            _context = context;
        }

        // GET: Parametry
        public async Task<IActionResult> Index()
        {
            return View(await _context.Parametry.ToListAsync());
        }

        // GET: Parametry/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parametry = await _context.Parametry
                .FirstOrDefaultAsync(m => m.IdParametru == id);
            if (parametry == null)
            {
                return NotFound();
            }

            return View(parametry);
        }

        // GET: Parametry/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Parametry/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdParametru,Kod,Nazwa,Wartosc,Opis")] Parametry parametry)
        {
            if (ModelState.IsValid)
            {
                _context.Add(parametry);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(parametry);
        }

        // GET: Parametry/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parametry = await _context.Parametry.FindAsync(id);
            if (parametry == null)
            {
                return NotFound();
            }
            return View(parametry);
        }

        // POST: Parametry/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdParametru,Kod,Nazwa,Wartosc,Opis")] Parametry parametry)
        {
            if (id != parametry.IdParametru)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parametry);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParametryExists(parametry.IdParametru))
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
            return View(parametry);
        }

        // GET: Parametry/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parametry = await _context.Parametry
                .FirstOrDefaultAsync(m => m.IdParametru == id);
            if (parametry == null)
            {
                return NotFound();
            }

            return View(parametry);
        }

        // POST: Parametry/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var parametry = await _context.Parametry.FindAsync(id);
            _context.Parametry.Remove(parametry);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParametryExists(int id)
        {
            return _context.Parametry.Any(e => e.IdParametru == id);
        }
    }
}
