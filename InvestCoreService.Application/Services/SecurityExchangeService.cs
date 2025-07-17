using InvestCoreService.Application.Interfaces.Services;
using InvestCoreService.Domain.Models.Interfaces;
using InvestCoreService.Domain.Models.Interfaces.Services;
using InvestCoreService.Domain.Models.SecurityExchangeModels;

namespace InvestCoreService.API.Services
{
    public class SecurityExchangeService : ISecurityExchangeService
    {
        private List<IBaseBroker> brokers;

        public Task<List<Bond>> GetPotentialBondsAsync(int count)
        {
            throw new NotImplementedException();
        }

        /*public SecurityExchangeService() 
        {
            this.brokers = new List<IBaseBroker>()
            {
                new TinkoffCore(""),
                new FinamCore("")
            };
        }

        public async Task<GetPotentialBondsResponse> GetPotentialBondsAsync(int count)
        {
            List<Bond> bonds = new List<Bond>();
            foreach (var broker in brokers)
            {
                var bondsInBroker = await broker.GetBondManager().GetAllSecurityExchangeBondsAsync();
                bonds.AddRange(bondsInBroker);
            }
            var response = new GetPotentialBondsResponse()
            {
                PotentialBonds = bonds.ToList()
            };

            return response;
        }*/
    }
}
