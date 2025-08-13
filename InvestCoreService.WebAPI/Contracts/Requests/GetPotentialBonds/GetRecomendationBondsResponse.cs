using InvestCoreService.Domain.Models.SecurityExchangeModels;

namespace InvestCoreService.API.Contracts.Requests.GetPotentialBonds
{
    public class GetRecomendationBondsResponse
    {
        public List<Bond>? PotentialBonds { get; set; }
    }
}
