using InvestCoreService.Domain.Models.Enums;
using InvestCoreService.Domain.Models.Interfaces.Services;
using InvestCoreService.Domain.Models.SecurityExchangeModels;

namespace InvestCoreService.Application.Services.Securities
{
    public class CalculateSecurityService : ICalculateSecurityService
    {
        public IEnumerable<Tuple<string, decimal>> GetAveragePurchasePriceByType(IEnumerable<UserTransactionSecurity> purchaseBonds, SecurityType securityType)
        {
            var allGroups = purchaseBonds
                .Where(x => x.Security.SecurityType == securityType)
                .GroupBy(x => x.Security.Isin)
                .Select(x =>
                {
                    int totalQuantity = x.Sum(y => y.Quantity);
                    if (totalQuantity == 0)
                    {
                        return new Tuple<string, decimal>(x.Key, 0);
                    }
                    decimal totalCost = x.Sum(y => y.Price * y.Quantity);
                    return new Tuple<string, decimal>(x.Key, totalCost / totalQuantity);
                });
            return allGroups;
        }
    }
}
