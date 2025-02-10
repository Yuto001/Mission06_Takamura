using Microsoft.EntityFrameworkCore;

namespace Mission06_Takamura.Models
{
    public class FilmDatabaseContext : DbContext
    {
        public FilmDatabaseContext(DbContextOptions<FilmDatabaseContext> options) : base(options) { }

        public DbSet<FilmInfo> FilmInfos {get; set;}
    }
}
