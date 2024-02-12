namespace InvestCoreService.Domain.Models.SecurityExchangeModels
{

    /// <summary>
    /// Облигация
    /// </summary>
    public class Bond
    {
        /// <summary>
        /// Международный код облигации
        /// </summary>
        public string Isin { get; set; }

        public string Ticker { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// Торговая площадка
        /// </summary>
        public string Exchange { get; set; }

        /// <summary>
        /// Количество выплат по купонам в год
        /// </summary>
        public int CouponQuantityPerYear { get; set; }

        /// <summary>
        /// Номинал облигации
        /// </summary>
        public decimal Nominal { get; set; }

        /// <summary>
        /// Текущая цена
        /// </summary>
        public decimal PriceNow { get; set; }

        /// <summary>
        /// Значение НКД
        /// </summary>
        public decimal AciValue { get; set; }

        /// <summary>
        /// Сектор экономики
        /// </summary>
        public string Sector { get; set; }

        /// <summary>
        /// Размер выпуска
        /// </summary>
        public long IssueSize { get; set; }

        /// <summary>
        /// Признак плаавающго купона
        /// </summary>
        public bool FloatingCouponFlag { get; set; }

        /// <summary>
        /// Бессрочная облигация
        /// </summary>
        public bool PerpetualFlag { get; set; }
    }
}
