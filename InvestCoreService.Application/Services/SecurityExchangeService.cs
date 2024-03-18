using InvestCoreService.Application.BrokerAPI;
using InvestCoreService.Application.Interfaces.Services;

namespace InvestCoreService.API.Services
{
    public class SecurityExchangeService : ISecurityExchangeService
    {
        //private List<IBaseBroker> brokers;

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
