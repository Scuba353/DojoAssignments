using Microsoft.EntityFrameworkCore;
 
namespace RESTauranter.Models
{
    public class ReviewContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public ReviewContext(DbContextOptions<ReviewContext> options) : base(options) { }
        
        // This DbSet contains "Review" objects from the Review model and reviews refers to the table name
        public DbSet<Review> reviews { get; set; }
    }
}