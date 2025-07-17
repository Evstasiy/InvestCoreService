using System.Linq.Expressions;

namespace InvestCoreService.Domain.Models.Interfaces.Database
{
    public interface IRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<List<T>> GetByFilterAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
        Task AddAsync(T entity);
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
    }
}
