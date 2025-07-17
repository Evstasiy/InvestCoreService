using InvestCoreService.Domain.Models.BaseModels;

namespace InvestCoreService.Domain.Models.Interfaces.Database
{
    public interface IDbContext
    {
        IEnumerable<User> Users { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
