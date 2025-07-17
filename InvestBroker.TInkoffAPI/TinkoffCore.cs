using InvestBroker.TinkoffAPI.Bonds;
using InvestCoreService.Domain.Models.Interfaces;
using Tinkoff.InvestApi;

namespace InvestBroker.TinkoffAPI
{
    public class TinkoffCore : IBaseBroker
    {
        public IBondManager BondManager { get; set; }

        public string BrokerName => "Tinkoff";

        private InvestApiClient apiClient;

        public TinkoffCore(string token)
        {
            apiClient = InvestApiClientFactory.Create(token, true);
            BondManager = new BondManager(apiClient);
        }

        public IBondManager GetBondManager() => BondManager;
    }
}
