
namespace InvestCoreService.Domain.Models.Interfaces
{
    public interface IUserBase
    {
        public int UserId { get;}
        public string? Name { get; }
        public string? Email { get; }
        public string? Password { get; }
    }
}
