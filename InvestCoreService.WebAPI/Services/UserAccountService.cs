using InvestBroker.FinamAPI;
using InvestBroker.TinkoffAPI;
using InvestCoreService.Application.BrokerAPI;
using InvestCoreService.Domain.Models.SecurityExchangeModels;
using InvestCoreService.API.Services.Interfaces;

namespace InvestCoreService.API.Services
{
    public class UserAccountService : IUserAccountService
    {
        public UserAccountService()
        {
            
        }

        public async Task UploadAllUserBondsInBrokersAsync(int userId)
        {
            var brokers = GetAllConnectUserBrokers();
            List<Bond> userBonds = new List<Bond>();
            foreach (var broker in brokers)
            {
                var bondsInBroker = await broker.GetBondManager().GetAllSecurityExchangeBondsAsync();
                userBonds.AddRange(bondsInBroker);
            }
        }

        private List<IBaseBroker> GetAllConnectUserBrokers()
        {
            var brokers = new List<IBaseBroker>()
            {
                new TinkoffCore(""),
                new FinamCore("")
            };
            return brokers;
        }
    }
}
