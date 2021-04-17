using Lifekeys.Models.User;
using Microsoft.EntityFrameworkCore;

namespace Lifekeys.Contexts
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> context) : base(context)
        { }

        public UserContext() { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
        }
    }
}
