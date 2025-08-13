using InvestCoreService.Domain.Models.Enums;
using InvestCoreService.Domain.Models.Interfaces.Security;

namespace InvestCoreService.Domain.Models.SecurityExchangeModels
{
    public class UserTransactionSecurity
    {
        public required ISecurity Security { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
