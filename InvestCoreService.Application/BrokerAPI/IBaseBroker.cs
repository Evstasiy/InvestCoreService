using InvestCoreService.Application.Bonds;

namespace InvestCoreService.Application.BrokerAPI
{
    public interface IBaseBroker
    {
        public string BrokerName { get; }
        public IBondManager GetBondManager();
    }
}
