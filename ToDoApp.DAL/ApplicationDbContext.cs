using Microsoft.EntityFrameworkCore;
using ToDoApp.Domain.Entity;

namespace ToDoApp.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<TaskEntity> Tasks { get; set; }
        public DbSet<User> Users { get; set; }

        public ApplicationDbContext()
        {
            Database.EnsureCreated();
        }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
            modelBuilder.Entity<User>().HasMany(u => u.Tasks).WithOne(t => t.User);
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=ToDoAppDb;Username=postgres;Password=123456");
        }
    }
}
