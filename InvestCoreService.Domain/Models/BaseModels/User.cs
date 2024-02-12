using InvestCoreService.Domain.Models.Interfaces;

namespace InvestCoreService.Domain.Models.BaseModels
{
    public class User : IUserBase
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
