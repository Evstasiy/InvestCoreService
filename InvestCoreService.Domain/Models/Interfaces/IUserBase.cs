
namespace InvestCoreService.Domain.Models.Interfaces
{
    public interface IUserBase
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
