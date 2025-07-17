using InvestCoreService.Domain.Models.BaseModels;
using InvestCoreService.Domain.Models.Interfaces.Database;
using InvestCoreService.Persistence.Postgres;
using System.Linq.Expressions;

namespace InvestCoreService.Infrastructure.Database
{
    public class UserRepository : IRepository<User>
    {
        private readonly AppDbConext _context;
        public void Add(User entity)
        {
            throw new NotImplementedException();
        }

        public async Task AddAsync(User entity)
        {
            await _context.SaveChangesAsync();
        }

        public Task<List<User>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetByFilterAsync(Expression<Func<User, bool>> predicate, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public void Remove(User entity)
        {
            throw new NotImplementedException();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
