using Google.Protobuf.WellKnownTypes;
using Tinkoff.InvestApi;
using Tinkoff.InvestApi.V1;

namespace InvestBroker.TinkoffAPI
{
    //https://excalidraw.com/#json=PE59_VCpG4MA_rNlqWvl1,MXpg9j6hoQ4d3pqer3hQpw
    //https://app.diagrams.net/#L%D0%94%D0%B8%D0%B0%D0%B3%D1%80%D0%B0%D0%BC%D0%BC%D0%B0%20%D0%B1%D0%B5%D0%B7%20%D0%BD%D0%B0%D0%B7%D0%B2%D0%B0%D0%BD%D0%B8%D1%8F.drawio
    //ТОкен песочницы t.h3tmiaYYSA7utDOWL2SrFME0GfUSQVt7N4sxqt01bgpNwX9ieRAsWUdDjBFNvawzsaBaBcScCXV3ITrLVTP0JA
    //accountID 12d715aa-8ce7-4ac2-9a42-5acc9bc1fa6f
    public class OpenInvest
    {
        private InvestApiClient apiClient;
        private Account account;
        public OpenInvest()
        {
            string token = "t.2vT5oCez0oo0ayULaeBpUurbUHbMuChVeaUxb7dDTCHy_qAVwMJGJTuvRvgvGVY5B477tbHY73u878Oa4V59ZA";
            apiClient = InvestApiClientFactory.Create(token, true);

            var info = apiClient.Users.GetInfo();
            var request = new GetAccountsRequest();
            var accounts = apiClient.Sandbox.GetSandboxAccounts(request);
            account = accounts.Accounts.FirstOrDefault();
            if(account == null)
            {
                apiClient.Sandbox.OpenSandboxAccount(new OpenSandboxAccountRequest() { });
                accounts = apiClient.Sandbox.GetSandboxAccounts(request);
                account = accounts.Accounts.FirstOrDefault();
            }
            var l = GetBonds();
        }

        public IEnumerable<string> GetBonds() {
            var bonds = apiClient.Instruments.Bonds().Instruments.ToList();
            //var bond = bonds.FirstOrDefault(x => x.Ticker.Contains("RU000A105YQ9"));
            List<(Bond,int)> bondsVolumes = new List<(Bond, int)>();
            int baseNominal = 1000;
            bonds = bonds.Where(x=>x.InitialNominal.Units == baseNominal && !x.AmortizationFlag && !x.PerpetualFlag)
                .Take(100).ToList();
            foreach (var bond in bonds) {
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
            var vi = bondsVolumes.OrderBy(x => x.Item1.RiskLevel).ToList();
            var vi1 = bondsVolumes.OrderByDescending(x => x.Item2).ToList();
            return new List<string>();
            //bonds.FirstOrDefault(x=>x.)
            //var concretBond = apiClient.Instruments.BondBy(new InstrumentRequest() { ClassCode =  }).Instrument;
            //bonds.FirstOrDefault().

            /*var bond = bonds.SelectMany(x => x).Where(x => x.Ticker.Contains("RU000A105P64")).FirstOrDefault();
            var concretBond = apiClient.Instruments.BondBy(new InstrumentRequest() { ClassCode = bond.ClassCode,Id = bond.Uid, IdType = InstrumentIdType.Uid }).Instrument;
            var cot = apiClient.MarketData.GetCandles(new GetCandlesRequest() { Figi = concretBond.Figi,Interval = CandleInterval.Day, From = new Timestamp() {Nanos = 200 },To = new Timestamp() { Nanos = 300 } });
            return bonds.Select(x => x.Name);*/
        }
        public string GetBalance()
        {
            var portfolio = apiClient.Operations.GetPortfolio(new PortfolioRequest() { AccountId = account.Id });
            return $"{portfolio.TotalAmountPortfolio.Units},{portfolio.TotalAmountPortfolio.Nano} {portfolio.TotalAmountPortfolio.Currency}";
        }
    }
}
