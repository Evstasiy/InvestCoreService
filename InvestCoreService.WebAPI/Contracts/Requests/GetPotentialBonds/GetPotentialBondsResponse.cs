using InvestCoreService.Domain.Models.SecurityExchangeModels;

namespace InvestCoreService.API.Contracts.Requests.GetPotentialBonds
{
    public class GetPotentialBondsResponse
    {
        public List<Bond>? PotentialBonds { get; set; }
    }
}
