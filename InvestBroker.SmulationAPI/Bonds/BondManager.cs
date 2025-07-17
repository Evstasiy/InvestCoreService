
using InvestCoreService.Domain.Models.Interfaces;
using InvestCoreService.Domain.Models.SecurityExchangeModels;

namespace InvestBroker.SmulationAPI.Bonds
{
    public class BondManager : IBondManager
    {
        public BondManager()
        {
        }

        public async Task<IEnumerable<Bond>> GetAllSecurityExchangeBondsAsync()
        {
            var bonds = new List<Bond>()
            {
                new Bond
                {
                    Isin = "RU000A123456",
                    Ticker = "OBIG1",
                    Name = "Облигация гос 2024-1",
                    Exchange = "MOEX",
                    CouponQuantityPerYear = 2,
                    Nominal = 1000m,
                    PriceNow = 1025.50m,
                    AciValue = 15.75m,
                    Sector = "Государственные",
                    IssueSize = 1000000000,
                    FloatingCouponFlag = false,
                    PerpetualFlag = false
                },
                new Bond
                {
                    Isin = "RU000B789012",
                    Ticker = "CORP2",
                    Name = "Облигация корп 2025",
                    Exchange = "SPBX",
                    CouponQuantityPerYear = 4,
                    Nominal = 5000m,
                    PriceNow = 4950.25m,
                    AciValue = 20.00m,
                    Sector = "Корпоративные",
                    IssueSize = 500000000,
                    FloatingCouponFlag = true,
                    PerpetualFlag = false
                },
                new Bond
                {
                    Isin = "US000A111222",
                    Ticker = "PERP1",
                    Name = "Бессрочная облигация",
                    Exchange = "NASDAQ",
                    CouponQuantityPerYear = 1,
                    Nominal = 1000m,
                    PriceNow = 980.00m,
                    AciValue = 10.50m,
                    Sector = "Финансовые",
                    IssueSize = 200000000,
                    FloatingCouponFlag = true,
                    PerpetualFlag = true
                }
            };
            return bonds;
        }
    }
}
