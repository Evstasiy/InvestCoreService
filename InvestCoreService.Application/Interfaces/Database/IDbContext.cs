using InvestCoreService.Domain.Models.BaseModels;
using Microsoft.EntityFrameworkCore;

namespace InvestCoreService.Application.Interfaces.Database
{
    public interface IDbContext
    {
        DbSet<User> Users { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
