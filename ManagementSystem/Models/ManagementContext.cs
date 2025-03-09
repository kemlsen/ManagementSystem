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
                    PasswordSalt = Convert.FromBase64String("3ttkFQ6rqgOkFCyqEPr6h68TxHAT90I4ztzS5Pl2m10="),
                    PasswordHash = Convert.FromBase64String("uTjdK35Y3Ut9pTrDdI1gx6JgpJ0E0hx0tOupoc4z9J3TrHZxxusS8JHDWfF9Eu3qyd9pcUeZOhlRgdQ2n60OrQ=="),
                    UserType = UserType.Admin
                },
                new User
                {
                    Id = 2,
                    FirstName = "Ahmet",
                    LastName = "Hassan",
                    UserName = "ahassan",
                    PasswordSalt = Convert.FromBase64String("3ttkFQ6rqgOkFCyqEPr6h68TxHAT90I4ztzS5Pl2m10="),
                    PasswordHash = Convert.FromBase64String("uTjdK35Y3Ut9pTrDdI1gx6JgpJ0E0hx0tOupoc4z9J3TrHZxxusS8JHDWfF9Eu3qyd9pcUeZOhlRgdQ2n60OrQ=="),
                    UserType = UserType.User
                }
            );
        }
    }
}
