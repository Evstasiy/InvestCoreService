using InvestCoreService.Domain.Models.Interfaces;
using InvestCoreService.Domain.Models.SecurityExchangeModels;
using InternalBond = InvestCoreService.Domain.Models.SecurityExchangeModels.Bond;

namespace InvestBroker.FinamAPI.Bonds
{
    public class BondManager //: IBondManager
    {
        public Task<IEnumerable<InternalBond>> GetAllSecurityExchangeBondsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<InternalBond>> GetAllUserBondsAsync()
        {
            var bonds = new List<Bond>()
            {
                new InternalBond()
                {
                    Name = "FinamBond",
                    Isin = "FinamISIN1",
                    Exchange = "Finam",
                    Ticker = "SU26222"
                }
            };
            return bonds;
        }

        public Task<IEnumerable<InternalBond>> GetAllUserBondsAsync(int userId, int count)
        {
            throw new NotImplementedException();
        }
    }
}
