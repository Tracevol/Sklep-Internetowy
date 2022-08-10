using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sklep.Data.Data;

namespace Sklep.PortalWWW.Controllers
{
    public class RodzajeMenuComponent : ViewComponent
    {
        private readonly SklepContext _context;

        public RodzajeMenuComponent(SklepContext context)
        {
            this._context = context;
        }

        // To jest funckja która zwraca komponent i dostarcza dane dla komponentu
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("RodzajeMenuComponent", await _context.Rodzaj.ToListAsync());
        }
    }
}
