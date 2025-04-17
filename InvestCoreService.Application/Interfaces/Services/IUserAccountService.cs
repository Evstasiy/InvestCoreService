using InvestCoreService.Application.Models.DTOs;
using InvestCoreService.Domain.Models.BaseModels;
using System.Linq.Expressions;

namespace InvestCoreService.Application.Interfaces.Services
{
    public interface IUserAccountService
    {
        public Task Register(string userName, string email, string password);
        public Task<string> Login(string email, string password);
        public Task<List<UserDTO>> GetList(Expression<Func<User, bool>> predicate);
    }
}
