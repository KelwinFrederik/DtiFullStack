using Microsoft.EntityFrameworkCore;
using FullStack.Entities;

namespace FullStack.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Provider> Providers{ get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<LogSystem> LogSystem { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Provider>()
                .HasMany(p => p.Orders)
                .WithOne(o => o.Provider)
                .HasForeignKey(o => o.IdProvider);

            modelBuilder.Entity<Order>()
                .Property(o => o.CurrentStatus)
                .HasDefaultValue(StatusOrderEnum.PENDENTE);

            modelBuilder.Entity<LogSystem>().HasKey(l => l.Id);
        }
    }
}
