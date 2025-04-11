using InvestCoreService.Application.Interfaces.Database;
using InvestCoreService.Application.Models.DTOs;
using InvestCoreService.Domain.Models.BaseModels;
using Microsoft.EntityFrameworkCore;

namespace InvestCoreService.Persistence.Postgres
{
    public class AppDbConext : DbContext, IDbContext
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
