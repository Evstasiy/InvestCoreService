using InvestBroker.FinamAPI;
using InvestBroker.TinkoffAPI;
using InvestCoreService.Application.BrokerAPI;
using InvestCoreService.API.Services.Interfaces;

namespace InvestCoreService.API.Services
{
    public class UserInvestDateService : IUserInvestDateService
    {
        private List<IBaseBroker> brokers;

        public UserInvestDateService()
        {
            this.brokers = new List<IBaseBroker>()
            {
                new TinkoffCore(""),
                new FinamCore("")
            };
        }
    }
}
