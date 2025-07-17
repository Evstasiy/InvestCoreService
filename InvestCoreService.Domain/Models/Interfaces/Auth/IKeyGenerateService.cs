using InvestCoreService.Domain.Models.BaseModels;

namespace InvestCoreService.Domain.Models.Interfaces.Auth
{
    public interface IKeyGenerateService
    {
        public string GenerateToken(User user);
    }
}
