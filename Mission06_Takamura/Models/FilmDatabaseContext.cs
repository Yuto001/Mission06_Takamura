using Microsoft.EntityFrameworkCore;

namespace Mission06_Takamura.Models
{
    public class FilmDatabaseContext : DbContext
    {
        public FilmDatabaseContext(DbContextOptions<FilmDatabaseContext> options) : base(options) { }

        public DbSet<FilmInfo> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FilmInfo>().ToTable("Movies"); // Explicitly map the table name
            modelBuilder.Entity<Category>().ToTable("Categories");
        }
    }
       
}
