using InvestCoreService.Domain.Models.SecurityExchangeModels;

namespace InvestCoreService.Domain.Models.Interfaces.Services
{
    public interface ISecurityExchangeService
    {
        public Task<List<Bond>> GetUserBondsAsync(int userId);
        public Task<List<Bond>> GetRecomendationBondsAsync(int userId, int count);
    }
}
