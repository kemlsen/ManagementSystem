using Microsoft.EntityFrameworkCore;

namespace ManagementSystem.Models
{
    public class ManagementContext : DbContext
    {
        public ManagementContext(DbContextOptions<ManagementContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    FirstName = "Kemal",
                    LastName = "Sen",
                    UserName = "kemlsen",
                    Password = "123",
                    UserType = UserType.Admin
                },
                new User
                {
                    Id = 2,
                    FirstName = "Ahmet",
                    LastName = "Hassan",
                    UserName = "ahassan",
                    Password = "123",
                    UserType = UserType.User
                }
            );
        }
    }
}
