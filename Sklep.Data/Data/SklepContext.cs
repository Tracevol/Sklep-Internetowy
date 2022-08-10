using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sklep.Data.Data.CMS;
using Sklep.Data.Data.Tablica;

namespace Sklep.Data.Data
{
    public class SklepContext : DbContext
    {
        public SklepContext(DbContextOptions<SklepContext> options)
            : base(options)
        {
        }

        public DbSet<Aktualnosci> Aktualnosci { get; set; }
        public DbSet<Ciekawostki> Ciekawostki { get; set; }

        public DbSet<Parametry> Parametry { get; set; }

        public DbSet<SprzedazSamochodu> SprzedazSamochodu { get; set; }

        public DbSet<Strona> Strona { get; set; }
        public DbSet<Rodzaj> Rodzaj { get; set; }
        public DbSet<Ogloszenia> Ogloszenia { get; set; }
        public DbSet<Wyniki> Wyniki { get; set; }
        public DbSet<WynikiDTM> DTM { get; set; }
        public DbSet<WynikiEndurance> Endurance { get; set; }
        public DbSet<WynikiF2> WynikiF2 { get; set; }
        public DbSet<WynikiFormulaE> FormulaE { get; set; }
        public DbSet<WynikiIndyCar> IndyCar { get; set; }
        public DbSet<ElementKoszyka> ElementKoszyka { get; set; }
    }
}


