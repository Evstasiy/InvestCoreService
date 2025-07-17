using Google.Protobuf.WellKnownTypes;
using InvestBroker.TinkoffAPI.Extensions;
using InvestCoreService.Domain.Models.Interfaces;
using Tinkoff.InvestApi;
using Tinkoff.InvestApi.V1;
using InternalBond = InvestCoreService.Domain.Models.SecurityExchangeModels.Bond;

namespace InvestBroker.TinkoffAPI.Bonds
{
    public class BondManager : IBondManager
    {
        private InvestApiClient apiClient;

        public BondManager(InvestApiClient apiClient) 
        { 
            this.apiClient = apiClient;
        }

        public async Task<IEnumerable<InternalBond>> GetAllSecurityExchangeBondsAsync()
        {
            var bonds = apiClient.Instruments.Bonds().Instruments.ToList();
            List<(Bond, int)> bondsVolumes = new List<(Bond, int)>();
            int baseNominal = 1000;
            bonds = bonds.Where(x => x.InitialNominal.Units == baseNominal && !x.AmortizationFlag && !x.PerpetualFlag)
                .Take(100).ToList();
            foreach (var bond in bonds)
            {
                var c = apiClient.MarketData.GetCandles(new GetCandlesRequest()
                {
                    InstrumentId = bond.Figi,
                    From = DateTime.UtcNow.AddDays(-30).ToTimestamp(),
                    To = DateTime.UtcNow.ToTimestamp(),
                    Interval = CandleInterval.Day
                });

                if (c.Candles.Count == 0)
                    continue;
                var vol = c.Candles.Sum(x => x.Volume) / c.Candles.Count;
                bondsVolumes.Add((bond, int.Parse(vol.ToString())));
            }
            return bondsVolumes.Select(x=> x.Item1.ToInternalBond()).Take(10);
        }
    }
}
