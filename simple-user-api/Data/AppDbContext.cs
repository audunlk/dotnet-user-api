using Microsoft.EntityFrameworkCore;
using simple_user_api.Models;

namespace simple_user_api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the User entity and its properties
            modelBuilder.Entity<User>(entity =>
            {

                entity.ToTable("users");

                entity.HasKey(e => e.Id); // Set the primary key

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100); // Set the max length for the Name property

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100); // Set the max length for the Email property
            });
        }
    }
}
