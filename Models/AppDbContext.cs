using Microsoft.EntityFrameworkCore;
namespace Beautiful.API.Models

{
    public class AppDbContext: DbContext
    {
           
        // Constructor that takes DbContextOptions
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<Students> Studentss { get; set; }
    }
}
