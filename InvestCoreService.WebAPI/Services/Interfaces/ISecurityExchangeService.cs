using InvestCoreService.Domain.Requests.GetPotentialBonds;

namespace InvestCoreService.API.Services.Interfaces
{
    public interface ISecurityExchangeService
    {
        public Task<GetPotentialBondsResponse> GetPotentialBondsAsync(int count);
    }
}
