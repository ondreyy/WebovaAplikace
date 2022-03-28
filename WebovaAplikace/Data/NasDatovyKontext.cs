using Microsoft.EntityFrameworkCore;

namespace WebovaAplikace.Data
{
    public class NasDatovyKontext : DbContext
    {
        public DbSet<Models.Poznamka> Poznamky { get; set; }
        public DbSet<Models.Pristup> Pristup { get; set; }

        public NasDatovyKontext(DbContextOptions<NasDatovyKontext> options) : base(options) { }
    }
}
