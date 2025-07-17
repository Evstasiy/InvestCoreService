using InvestBroker.FinamAPI.Bonds;
using InvestCoreService.Domain.Models.Interfaces;

namespace InvestBroker.FinamAPI
{
    public class FinamCore : IBaseBroker
    {
        public string BrokerName => "Finam";

        private IBondManager BondManager { get; }
        public FinamCore(string token)
        {
            BondManager = new BondManager(token);
        }

        public IBondManager GetBondManager() => BondManager;
    }
}
