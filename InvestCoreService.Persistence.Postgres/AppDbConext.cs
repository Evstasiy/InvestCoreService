using InvestCoreService.Domain.Models.BaseModels;
using InvestCoreService.Infrastructure.Interfaces;
using InvestCoreService.Infrastructure.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace InvestCoreService.Persistence.Postgres
{
    public class AppDbConext : DbContext, IDbContext
    {
        public AppDbConext(DbContextOptions options) : base(options) { }
        public DbSet<UserDTO> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserDTO>()
                .ToTable("users");
        }
    }
}
