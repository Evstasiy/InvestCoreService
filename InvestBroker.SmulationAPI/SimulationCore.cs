using InvestBroker.SmulationAPI.Bonds;
using InvestCoreService.Domain.Models.Interfaces;

namespace InvestBroker.SmulationAPI
{
    public class SimulationCore : IBaseBroker
    {
        public string BrokerName => "Simulation";

        private IBondManager BondManager { get; }
        public SimulationCore(string token)
        {
            BondManager = new BondManager();
        }

        public IBondManager GetBondManager() => BondManager;
    }
}
