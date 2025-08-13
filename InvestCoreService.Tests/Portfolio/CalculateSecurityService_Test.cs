using InvestCoreService.Application.Services.Securities;
using InvestCoreService.Domain.Models.Enums;
using InvestCoreService.Domain.Models.SecurityExchangeModels;
using NUnit.Framework;

namespace InvestCoreService.Tests.Portfolio
{
    [TestFixture]
    public class CalculateSecurityService_Test
    {
        private CalculateSecurityService _service;

        [SetUp]
        public void Setup()
        {
            // Этот метод выполняется перед каждым тестом
            _service = new CalculateSecurityService();
        }

        [Test]
        public void GetAveragePurchasePriceByType_ForBonds_ReturnsCorrectWeightedAveragePrice()
        {
            var bond1 = new Bond { Isin = "RU000A0JXQ23", Name = "ОФЗ-1", Ticker = "SU26222", Exchange = "MOEX" };
            var bond2 = new Bond { Isin = "RU000A1009T5", Name = "ВТБ-1", Ticker = "VTBR1", Exchange = "MOEX" };
            //var stock1 = new Stock { Isin = "US0378331005", Name = "Apple", Ticker = "AAPL", Exchange = "NASDAQ" };

            var transactions = new List<UserTransactionSecurity>
            {
                // Несколько покупок первой облигации для проверки взвешенного среднего
                new UserTransactionSecurity { Security = bond1, Price = 980m, Quantity = 10 },
                new UserTransactionSecurity { Security = bond1, Price = 1000m, Quantity = 5 },

                // Одна покупка второй облигации
                new UserTransactionSecurity { Security = bond2, Price = 1010m, Quantity = 20 },

                // Покупка акции (должна быть отфильтрована)
                //new UserTransactionSecurity { Security = stock1, Price = 200m, Quantity = 50 }
            };

            // Ручной расчет ожидаемых значений:
            // Bond1: (980*10 + 1000*5) / (10+5) = (9800 + 5000) / 15 = 14800 / 15 = 986.666...m
            decimal expectedAverageForBond1 = 14800m / 15m;
            // Bond2: (1010*20) / 20 = 1010m
            decimal expectedAverageForBond2 = 1010m;

            var result = _service.GetAveragePurchasePriceByType(transactions, SecurityType.Bond).ToList();

            // --- Assert (Проверка) ---
            // 1. Убедимся, что результат содержит 2 элемента (только облигации)
            Assert.That(result.Count, Is.EqualTo(2), "Должно быть найдено 2 уникальные облигации.");

            // 2. Найдем результаты для каждой облигации
            var resultBond1 = result.FirstOrDefault(r => r.Item1 == bond1.Isin);
            var resultBond2 = result.FirstOrDefault(r => r.Item1 == bond2.Isin);

            // 3. Проверим, что они существуют
            Assert.IsNotNull(resultBond1, "Результат для первой облигации не найден.");
            Assert.IsNotNull(resultBond2, "Результат для второй облигации не найден.");

            // 4. Главная проверка: сравним вычисленную среднюю цену с ожидаемой
            Assert.That(resultBond1.Item2, Is.EqualTo(expectedAverageForBond1).Within(0.0001), "Средняя цена для первой облигации рассчитана неверно.");
            Assert.That(resultBond2.Item2, Is.EqualTo(expectedAverageForBond2), "Средняя цена для второй облигации рассчитана неверно.");
        }

        /*[Test]
        public void GetAveragePurchasePriceByType_WhenNoMatchingSecurities_ReturnsEmptyCollection()
        {
            // --- Arrange ---
            var stock1 = new Stock { Isin = "US0378331005", Name = "Apple", Ticker = "AAPL", Exchange = "NASDAQ" };
            var transactions = new List<UserTransactionSecurity>
            {
                new UserTransactionSecurity { Security = stock1, Price = 200m, Quantity = 50 }
            };

            // --- Act ---
            // Ищем облигации (Bond), но в списке только акции (Stock)
            var result = _service.GetAveragePurchasePriceByType(transactions, SecurityType.Bond);

            // --- Assert ---
            Assert.IsEmpty(result, "Коллекция должна быть пустой, если нет активов нужного типа.");
        }*/

        [Test]
        public void GetAveragePurchasePriceByType_WhenInputIsEmpty_ReturnsEmptyCollection()
        {
            var emptyTransactions = new List<UserTransactionSecurity>();

            var result = _service.GetAveragePurchasePriceByType(emptyTransactions, SecurityType.Bond);

            Assert.IsEmpty(result, "Коллекция должна быть пустой, если на вход подан пустой список.");
        }

        [Test]
        public void GetAveragePurchasePriceByType_WhenTotalQuantityIsZero_ReturnsZeroAveragePrice()
        {
            // --- Arrange ---
            // Случай, когда есть транзакции, но их количество равно 0. 
            // Это предотвратит DivideByZeroException в доработанном методе.
            var bond1 = new Bond { Isin = "RU000A0JXQ23", Name = "ОФЗ-1", Ticker = "SU26222", Exchange = "MOEX" };
            var transactions = new List<UserTransactionSecurity>
            {
                new UserTransactionSecurity { Security = bond1, Price = 1000m, Quantity = 0 }
            };

            // --- Act ---
            var result = _service.GetAveragePurchasePriceByType(transactions, SecurityType.Bond).ToList();

            // --- Assert ---
            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result[0].Item2, Is.EqualTo(0), "Средняя цена должна быть 0, если общее количество равно 0.");
        }
    }
}
