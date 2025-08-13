using InvestCoreService.Application.Interfaces.Services;
using InvestCoreService.Domain.Models.Interfaces;
using InvestCoreService.Domain.Models.Interfaces.Services;
using InvestCoreService.Domain.Models.SecurityExchangeModels;

namespace InvestCoreService.API.Services
{
    public class SecurityExchangeService : ISecurityExchangeService
    {
        private IEnumerable<IBaseBroker> _brokers;

        public SecurityExchangeService(IEnumerable<IBaseBroker> baseBrokers) 
        {
            _brokers = baseBrokers;
        }

        public async Task<List<Bond>> GetUserBondsAsync(int userId)
        {
            var userBonds = new List<Bond>();

            foreach (var broker in _brokers)
            {
                var bonds = await broker.GetBondManager().GetAllUserBondsAsync(userId);
                userBonds.AddRange(bonds);
            }
            return userBonds;
        }

        public async Task<List<Bond>> GetRecomendationBondsAsync(int userId, int count)
        {
            var userBonds = new List<Bond>();

            /*foreach (var broker in _brokers)
            {
                /*
                 IBrokerTokenStore внутри брокеров GPT ответ
                 */
                /*var bonds = await broker.GetBondManager().GetAllUserBondsAsync(userId);
                userBonds.AddRange(bonds);
            }*/
            /*
             Тут нужно рассчитать бумаги для 
             */

            return userBonds;
        }
    }
}
