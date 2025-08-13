using InvestCoreService.Domain.Models.Enums;

namespace InvestCoreService.Domain.Models.Interfaces.Security
{
    public interface ISecurity
    {
        SecurityType SecurityType { get; }
        string Isin { get; }
        string Ticker { get; }
        string Name { get; }
        string Exchange { get; }
        decimal PriceNow { get; }
    }
}
