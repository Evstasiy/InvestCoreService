using InvestCoreService.Application.BrokerAPI;
using InvestCoreService.Domain.Models.SecurityExchangeModels;
using InvestCoreService.Application.Interfaces.Services;
using InvestCoreService.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InvestCoreService.API.Services
{
    public class UserAccountService : IUserAccountService
    {
        private IDbContext dbContext {  get; set; }

        public UserAccountService(IDbContext dbContext)
        {
            this.dbContext = dbContext;
            var l = dbContext.Users.ToList();
        }

        public async Task UploadAllUserBondsInBrokersAsync(int userId)
        {
            var l = await dbContext.Users.ToListAsync();
            //DTO to entity autoMaper
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
            return null;
        }
    }
}
