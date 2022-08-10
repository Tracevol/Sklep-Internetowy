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
    public class StronaController : Controller
    {
        private readonly SklepContext _context;

        public StronaController(SklepContext context)
        {
            _context = context;
        }

        // GET: Strona
        public async Task<IActionResult> Index()
        {
            return View(await _context.Strona.ToListAsync());
        }

        // GET: Strona/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var strona = await _context.Strona
                .FirstOrDefaultAsync(m => m.IdStrona == id);
            if (strona == null)
            {
                return NotFound();
            }

            return View(strona);
        }

        // GET: Strona/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Strona/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdStrona,LinkTytul,Tytul,TablicaOgloszen,CiekawostkiMotoryzacja,InformacjeMotoryzacja,Pozycja")] Strona strona)
        {
            if (ModelState.IsValid)
            {
                _context.Add(strona);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(strona);
        }

        // GET: Strona/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var strona = await _context.Strona.FindAsync(id);
            if (strona == null)
            {
                return NotFound();
            }
            return View(strona);
        }

        // POST: Strona/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdStrona,LinkTytul,Tytul,TablicaOgloszen,CiekawostkiMotoryzacja,InformacjeMotoryzacja,Pozycja")] Strona strona)
        {
            if (id != strona.IdStrona)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(strona);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StronaExists(strona.IdStrona))
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
            return View(strona);
        }

        // GET: Strona/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var strona = await _context.Strona
                .FirstOrDefaultAsync(m => m.IdStrona == id);
            if (strona == null)
            {
                return NotFound();
            }

            return View(strona);
        }

        // POST: Strona/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var strona = await _context.Strona.FindAsync(id);
            _context.Strona.Remove(strona);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StronaExists(int id)
        {
            return _context.Strona.Any(e => e.IdStrona == id);
        }
    }
}
