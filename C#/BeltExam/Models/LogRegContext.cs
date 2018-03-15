using Microsoft.EntityFrameworkCore;
 
namespace BeltExam.Models
{
    public class BeltExamContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public BeltExamContext(DbContextOptions<BeltExamContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Playit> Activities { get; set; }

        public DbSet<UserActivities> User_Activity_Join { get; set; }
    }
}