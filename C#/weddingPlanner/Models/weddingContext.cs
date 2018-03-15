using Microsoft.EntityFrameworkCore;
 
namespace weddingPlanner.Models
{
    public class weddingContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public weddingContext(DbContextOptions<weddingContext> options) : base(options) { }
        public DbSet<Wedding> Weddings { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<RSVP> RSVPs { get; set; }
    }
}