using InvestCoreService.Application.BrokerAPI;
using InvestCoreService.Application.Interfaces.Services;

namespace InvestCoreService.API.Services
{
    public class UserInvestDateService : IUserInvestDateService
    {
        private List<IBaseBroker> brokers;

        public UserInvestDateService()
        {
        }
    }
}
