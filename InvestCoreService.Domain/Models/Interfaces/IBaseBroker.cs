namespace InvestCoreService.Domain.Models.Interfaces
{
    public interface IBaseBroker
    {
        public string BrokerName { get; }
        public IBondManager GetBondManager();
    }
}
