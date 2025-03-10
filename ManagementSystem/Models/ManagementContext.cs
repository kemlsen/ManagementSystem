using ManagementSystem.Models.Entities;
using ManagementSystem.Models.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace ManagementSystem.Models
{
    public class ManagementContext : DbContext
    {
        public ManagementContext(DbContextOptions<ManagementContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Service> Services { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    FirstName = "Dincer",
                    LastName = "Teknoloji",
                    UserName = "admindincer",
                    PasswordSalt = new byte[] { 132, 225, 102, 92, 223, 144, 89, 34, 201, 70, 254, 48, 247, 32, 115, 109, 186, 132, 232, 94, 124, 40, 202, 53, 197, 146, 231, 211, 126, 72, 179, 96, 30, 85, 82, 7, 42, 213, 204, 142, 121, 132, 24, 42, 127, 152, 131, 128, 53, 168, 88, 153, 13, 116, 182, 8, 69, 249, 181, 197, 197, 223, 187, 194, 189, 122, 178, 12, 124, 250, 166, 210, 204, 54, 100, 124, 39, 59, 145, 189, 119, 233, 8, 93, 113, 189, 161, 67, 185, 203, 57, 29, 136, 91, 197, 234, 14, 199, 17, 192, 243, 157, 71, 186, 238, 174, 237, 63, 85, 78, 62, 67, 177, 249, 107, 12, 121, 186, 56, 203, 177, 166, 230, 1, 163, 75, 223, 80 }, 
                    PasswordHash = new byte[] { 11, 54, 62, 240, 159, 165, 184, 150, 168, 114, 83, 20, 142, 97, 71, 182, 100, 171, 169, 16, 205, 16, 7, 251, 84, 237, 243, 76, 117, 235, 46, 226, 17, 88, 82, 212, 112, 64, 155, 240, 63, 69, 146, 217, 32, 194, 35, 2, 119, 182, 34, 135, 143, 33, 10, 184, 24, 62, 131, 182, 235, 177, 81, 99 },
                    UserType = UserType.Admin
                },
                new User
                {
                    Id = 2,
                    FirstName = "Kemal",
                    LastName = "Sen",
                    UserName = "userkemal",
                    PasswordSalt = new byte[] { 132, 225, 102, 92, 223, 144, 89, 34, 201, 70, 254, 48, 247, 32, 115, 109, 186, 132, 232, 94, 124, 40, 202, 53, 197, 146, 231, 211, 126, 72, 179, 96, 30, 85, 82, 7, 42, 213, 204, 142, 121, 132, 24, 42, 127, 152, 131, 128, 53, 168, 88, 153, 13, 116, 182, 8, 69, 249, 181, 197, 197, 223, 187, 194, 189, 122, 178, 12, 124, 250, 166, 210, 204, 54, 100, 124, 39, 59, 145, 189, 119, 233, 8, 93, 113, 189, 161, 67, 185, 203, 57, 29, 136, 91, 197, 234, 14, 199, 17, 192, 243, 157, 71, 186, 238, 174, 237, 63, 85, 78, 62, 67, 177, 249, 107, 12, 121, 186, 56, 203, 177, 166, 230, 1, 163, 75, 223, 80 }, 
                    PasswordHash = new byte[] { 11, 54, 62, 240, 159, 165, 184, 150, 168, 114, 83, 20, 142, 97, 71, 182, 100, 171, 169, 16, 205, 16, 7, 251, 84, 237, 243, 76, 117, 235, 46, 226, 17, 88, 82, 212, 112, 64, 155, 240, 63, 69, 146, 217, 32, 194, 35, 2, 119, 182, 34, 135, 143, 33, 10, 184, 24, 62, 131, 182, 235, 177, 81, 99 },
                    UserType = UserType.User
                }
            );
        }
    }
}
