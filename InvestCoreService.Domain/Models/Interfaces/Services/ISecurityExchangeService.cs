using InvestCoreService.Domain.Models.SecurityExchangeModels;

namespace InvestCoreService.Domain.Models.Interfaces.Services
{
    public interface ISecurityExchangeService
    {
        public Task<List<Bond>> GetPotentialBondsAsync(int count);
    }
}
