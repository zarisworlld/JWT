
using JWT.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
 
namespace JWT.Domain.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base(options) 
        {
            
        }
        public DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users");
                entity.HasKey(u => u.Id);

                entity.Property(u => u.Name)
               .IsRequired()
               .HasMaxLength(100);

                entity.Property(u => u.Role)
                .IsRequired();

                entity.Property(u => u.Password)
                .IsRequired();

                entity.Property(u => u.CreateDate)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");
            });
        }
    }
}
