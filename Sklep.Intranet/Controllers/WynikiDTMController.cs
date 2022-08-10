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
    public class WynikiDTMController : Controller
    {
        private readonly SklepContext _context;

        public WynikiDTMController(SklepContext context)
        {
            _context = context;
        }

        // GET: WynikiDTM
        public async Task<IActionResult> Index()
        {
              return _context.DTM != null ? 
                          View(await _context.DTM.ToListAsync()) :
                          Problem("Entity set 'SklepContext.DTM'  is null.");
        }

        // GET: WynikiDTM/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DTM == null)
            {
                return NotFound();
            }

            var wynikiDTM = await _context.DTM
                .FirstOrDefaultAsync(m => m.IdWyniku == id);
            if (wynikiDTM == null)
            {
                return NotFound();
            }

            return View(wynikiDTM);
        }

        // GET: WynikiDTM/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WynikiDTM/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdWyniku,PozycjaKierowcy,ImieNazwisko,Zespol,Punkty")] WynikiDTM wynikiDTM)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wynikiDTM);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(wynikiDTM);
        }

        // GET: WynikiDTM/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DTM == null)
            {
                return NotFound();
            }

            var wynikiDTM = await _context.DTM.FindAsync(id);
            if (wynikiDTM == null)
            {
                return NotFound();
            }
            return View(wynikiDTM);
        }

        // POST: WynikiDTM/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdWyniku,PozycjaKierowcy,ImieNazwisko,Zespol,Punkty")] WynikiDTM wynikiDTM)
        {
            if (id != wynikiDTM.IdWyniku)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wynikiDTM);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WynikiDTMExists(wynikiDTM.IdWyniku))
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
            return View(wynikiDTM);
        }

        // GET: WynikiDTM/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DTM == null)
            {
                return NotFound();
            }

            var wynikiDTM = await _context.DTM
                .FirstOrDefaultAsync(m => m.IdWyniku == id);
            if (wynikiDTM == null)
            {
                return NotFound();
            }

            return View(wynikiDTM);
        }

        // POST: WynikiDTM/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DTM == null)
            {
                return Problem("Entity set 'SklepContext.DTM'  is null.");
            }
            var wynikiDTM = await _context.DTM.FindAsync(id);
            if (wynikiDTM != null)
            {
                _context.DTM.Remove(wynikiDTM);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WynikiDTMExists(int id)
        {
          return (_context.DTM?.Any(e => e.IdWyniku == id)).GetValueOrDefault();
        }
    }
}
