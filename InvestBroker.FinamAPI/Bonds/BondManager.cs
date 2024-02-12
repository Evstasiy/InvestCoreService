using InvestCoreService.Application.Bonds;
using InvestCoreService.Domain.Models.SecurityExchangeModels;
using InternalBond = InvestCoreService.Domain.Models.SecurityExchangeModels.Bond;

namespace InvestBroker.FinamAPI.Bonds
{
    public class BondManager : IBondManager
    {
        Bond b;
        public BondManager(string token) 
        {
            b = new Bond() { Isin = token };
        }

        public async Task<IEnumerable<InternalBond>> GetAllSecurityExchangeBondsAsync()
        {
            var bonds = new List<Bond>()
            {
                new InternalBond()
                {
                    Name = "FinamBond",
                    Isin = "FinamISIN1"
                },
                b
            };
            return bonds;
        }
    }
}
