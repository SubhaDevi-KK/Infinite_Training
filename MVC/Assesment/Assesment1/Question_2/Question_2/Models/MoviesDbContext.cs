using System.Data.Entity;

namespace Question2.Models
{
    public class MoviesDbContext : DbContext
    {
        public MoviesDbContext() : base("MoviesDB") { }
        public DbSet<Movie> Movies { get; set; }
    }
}
