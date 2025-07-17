using InvestCoreService.Domain.Models.BaseModels;
using Microsoft.EntityFrameworkCore;

namespace InvestCoreService.Persistence.Postgres
{
    public class AppDbConext : DbContext
    {
        public AppDbConext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .ToTable("users");
        }
    }
}
