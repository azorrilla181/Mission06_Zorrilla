using Microsoft.EntityFrameworkCore;

namespace Mission06_Zorrilla.Models
{
    public class AddMovieContext : DbContext
    {
        public AddMovieContext(DbContextOptions<AddMovieContext> options) : base (options) 
        {
        }
        public DbSet<Application> AddedMovies { get; set; }
    }
}
