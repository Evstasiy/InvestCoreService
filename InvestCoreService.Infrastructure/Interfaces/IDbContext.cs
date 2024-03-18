using InvestCoreService.Domain.Models.BaseModels;
using InvestCoreService.Infrastructure.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace InvestCoreService.Infrastructure.Interfaces
{
    public interface IDbContext
    {
        DbSet<UserDTO> Users { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
