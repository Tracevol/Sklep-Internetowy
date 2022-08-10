using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklep.Data.Data
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<SklepContext>
    {
        public SklepContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SklepContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SklepContextII;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new SklepContext(optionsBuilder.Options);
        }
    }
}
