using InvestCoreService.Domain.Models.BaseModels;
using InvestCoreService.Domain.Models.Interfaces.Database;
using System.Linq.Expressions;

namespace InvestCoreService.Infrastructure.Database.BufferDb
{
    public class UserTextRepository : IRepository<User>
    {
        private List<User> _users = new List<User>
            {
                new User
                {
                    UserId = 1,
                    Name = "Admin",
                    Email = "admin@example.com",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("SecurePassword123!"),
                    AccessLevel = 1
                },
                new User
                {
                    UserId = 2,
                    Name = "John Doe",
                    Email = "john.doe@example.com",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("JohnsPass123"),
                    AccessLevel = 1
                },
                new User
                {
                    UserId = 3,
                    Name = "Jane Smith",
                    Email = "jane.smith@example.com",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("JanePassword456!"),
                    AccessLevel = 1
                },
                new User
                {
                    UserId = 4,
                    Name = "Test User",
                    Email = null, 
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("TestPass789"),
                    AccessLevel = 1
                },
                new User
                {
                    UserId = 5,
                    Name = "No Role User",
                    Email = "no-role@example.com",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("NoRolePass"),
                    AccessLevel = 1
                }
            };

        public void Add(User entity)
        {
            
        }

        public Task AddAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return Task.FromResult(_users);
        }

        public Task<List<User>> GetByFilterAsync(Expression<Func<User, bool>> predicate, CancellationToken cancellationToken = default)
        {
            var usersFilter = _users.Where(predicate.Compile()).ToList();
            return Task.FromResult(usersFilter);
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
