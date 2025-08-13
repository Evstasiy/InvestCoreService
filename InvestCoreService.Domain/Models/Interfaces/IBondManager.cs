using InvestCoreService.Domain.Models.SecurityExchangeModels;

namespace InvestCoreService.Domain.Models.Interfaces
{
    public interface IBondManager
    {
        public Task<IEnumerable<Bond>> GetAllSecurityExchangeBondsAsync();

        public Task<IEnumerable<Bond>> GetAllUserBondsAsync(int userId);
    }
}
