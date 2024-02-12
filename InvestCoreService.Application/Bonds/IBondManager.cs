using InvestCoreService.Domain.Models.SecurityExchangeModels;

namespace InvestCoreService.Application.Bonds
{
    public interface IBondManager
    {
        public Task<IEnumerable<Bond>> GetAllSecurityExchangeBondsAsync();
    }
}
