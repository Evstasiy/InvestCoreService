using Tinkoff.InvestApi.V1;
using TinkoffBond = Tinkoff.InvestApi.V1.Bond;

namespace InvestBroker.TinkoffAPI.Extensions
{
    public static class BondExtension
    {
        public static InvestCoreService.Domain.Models.SecurityExchangeModels.Bond ToInternalBond(this TinkoffBond bond)
        {
            return new InvestCoreService.Domain.Models.SecurityExchangeModels.Bond()
            {
                Isin = bond.Isin
            };
        }
    }
}
