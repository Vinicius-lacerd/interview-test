using Xunit;
using Moq;
using Smartwyre.DeveloperTest.Models;
using Smartwyre.DeveloperTest.Types;
using Smartwyre.DeveloperTest.Models.Rest;
using Smartwyre.DeveloperTest.Types.Enums;
using Smartwyre.DeveloperTest.Data.Interfaces;

namespace Smartwyre.DeveloperTest.Tests
{
    public class RebateServiceTests
    {
        private readonly Mock<IRebateDataStore> _mockDataStore;
        private readonly Mock<IProductDataStore> _mockProductDataStore;
        private readonly RebateService _rebateService;

        public RebateServiceTests()
        {
            _mockDataStore = new Mock<IRebateDataStore>();
            _mockProductDataStore = new Mock<IProductDataStore>();
            _rebateService = new RebateService(_mockProductDataStore.Object, _mockDataStore.Object);
        }

        [Fact]
        public void Calculate_ValidFixedCashAmount_Success()
        {
            var rebate = new Rebate { Incentive = IncentiveType.FixedCashAmount, Amount = 100 };
            var product = new Product { SupportedIncentives = SupportedIncentiveType.FixedCashAmount };
            var request = new CalculateRebateRequest { RebateIdentifier = "123", ProductIdentifier = "456", Volume= 10 };

            _mockDataStore.Setup(ds => ds.GetRebate(It.IsAny<string>())).Returns(rebate);
            _mockProductDataStore.Setup(pds => pds.GetProduct(It.IsAny<string>())).Returns(product);
            
            var result = _rebateService.Calculate(request);
            
            Assert.True(result.Success);
            _mockDataStore.Verify(ds => ds.StoreCalculationResult(rebate, 100), Times.Once);
        }

        [Fact]
        public void Calculate_ValidFixedRate_Success()
        {
            var rebate = new Rebate { Incentive = IncentiveType.FixedRateRebate, Amount = 100, Percentage = 1 };
            var product = new Product { SupportedIncentives = SupportedIncentiveType.FixedRateRebate, Price = 10 };
            var request = new CalculateRebateRequest { RebateIdentifier = "123", ProductIdentifier = "456", Volume =10 };

            _mockDataStore.Setup(ds => ds.GetRebate(It.IsAny<string>())).Returns(rebate);
            _mockProductDataStore.Setup(pds => pds.GetProduct(It.IsAny<string>())).Returns(product);

            
            var result = _rebateService.Calculate(request);

            Assert.True(result.Success);
            _mockDataStore.Verify(ds => ds.StoreCalculationResult(rebate, 100), Times.Once);
        }

        [Fact]
        public void Calculate_ValidAmountPerUom_Success()
        {
            var rebate = new Rebate { Incentive = IncentiveType.AmountPerUom, Amount = 10 };
            var product = new Product { SupportedIncentives = SupportedIncentiveType.AmountPerUom };
            var request = new CalculateRebateRequest { RebateIdentifier = "123", ProductIdentifier = "456", Volume =10 };

            _mockDataStore.Setup(ds => ds.GetRebate(It.IsAny<string>())).Returns(rebate);
            _mockProductDataStore.Setup(pds => pds.GetProduct(It.IsAny<string>())).Returns(product);

            
            var result = _rebateService.Calculate(request);

            Assert.True(result.Success);
            _mockDataStore.Verify(ds => ds.StoreCalculationResult(rebate, 100), Times.Once);
        }

        [Fact]
        public void Calculate_NullRebate_Failure()
        {
            var rebate = new Rebate();
            var request = new CalculateRebateRequest { RebateIdentifier = "123", ProductIdentifier = "456" };

            _mockDataStore.Setup(ds => ds.GetRebate("Rebate")).Returns(rebate = null);
            
            
            var result = _rebateService.Calculate(request);            
            Assert.False(result.Success);
        }
    }

}
