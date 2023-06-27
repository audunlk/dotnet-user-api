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
            modelBuilder.Entity<User>(entity =>
            {

                entity.ToTable("users");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100); 

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100); 
            });
        }
    }
}
