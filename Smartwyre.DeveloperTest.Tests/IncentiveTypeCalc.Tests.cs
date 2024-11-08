using Smartwyre.DeveloperTest.Models.Rest;
using Smartwyre.DeveloperTest.Models;
using Smartwyre.DeveloperTest.Types.Enums;
using Xunit;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Tests
{
    public class IncentiveTypeCalc
    {
        [Fact]
        public void CalculateFixedCash_CorrectAmount()
        {
            var calculator = new FixedCashAmount();
            var product = new Product { SupportedIncentives = SupportedIncentiveType.FixedCashAmount };
            var rebate = new Rebate { Amount = 100 };
            var request = new CalculateRebateRequest();

            var success = calculator.CalculateRebate(product, rebate, request, out var rebateAmount);

            Assert.True(success);
            Assert.Equal(100, rebateAmount);
        }

        [Fact]
        public void CalculateFixedRate_CorrectAmount()
        {
            var calculator = new FixedRateRebate();
            var product = new Product { SupportedIncentives = SupportedIncentiveType.FixedRateRebate, Price = 10  };
            var rebate = new Rebate { Amount = 100, Percentage= 1 };
            var request = new CalculateRebateRequest() { Volume = 10};

            var success = calculator.CalculateRebate(product, rebate, request, out var rebateAmount);


            Assert.True(success);
            Assert.Equal(100, rebateAmount);
        }

        [Fact]
        public void CalculateAmountPerUom_CorrectAmount()
        {
            var calculator = new AmountPerUom();
            var product = new Product { SupportedIncentives = SupportedIncentiveType.AmountPerUom };
            var rebate = new Rebate { Amount = 10 };
            var request = new CalculateRebateRequest() { Volume= 10} ;

            var success = calculator.CalculateRebate(product, rebate, request, out var rebateAmount);

            Assert.True(success);
            Assert.Equal(100, rebateAmount);
        }
    }
}
