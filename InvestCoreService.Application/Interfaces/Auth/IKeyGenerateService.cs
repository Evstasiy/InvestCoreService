using InvestCoreService.Domain.Models.BaseModels;

namespace InvestCoreService.Application.Interfaces.Auth
{
    public interface IKeyGenerateService
    {
        public string GenerateToken(User user);
    }
}
