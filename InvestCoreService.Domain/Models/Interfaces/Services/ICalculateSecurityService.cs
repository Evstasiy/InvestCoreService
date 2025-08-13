using InvestCoreService.Domain.Models.Enums;
using InvestCoreService.Domain.Models.SecurityExchangeModels;

namespace InvestCoreService.Domain.Models.Interfaces.Services
{
    public interface ICalculateSecurityService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseBonds">1 - Isin, 2 - average purchase</param>
        /// <returns></returns>
        IEnumerable<Tuple<string, decimal>> GetAveragePurchasePriceByType(IEnumerable<UserTransactionSecurity> purchaseBonds, SecurityType securityType);
    }
}
