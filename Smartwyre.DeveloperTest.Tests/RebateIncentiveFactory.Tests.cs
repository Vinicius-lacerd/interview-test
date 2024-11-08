using Smartwyre.DeveloperTest.Types.Enums;
using Smartwyre.DeveloperTest.Types.Factory;
using Smartwyre.DeveloperTest.Types;
using System;
using Xunit;

namespace Smartwyre.DeveloperTest.Tests
{
    public class RebateIncentiveFactoryTests
    {
        [Fact]
        public void Create_FixedCashAmount()
        {

            var calculator = RebateIncentiveFactory.Create(IncentiveType.FixedCashAmount);

            // Assert
            Assert.IsType<FixedCashAmount>(calculator);
        }

        [Fact]
        public void Create_FixedRateRebate()
        {

            var calculator = RebateIncentiveFactory.Create(IncentiveType.FixedRateRebate);

            // Assert
            Assert.IsType<FixedRateRebate>(calculator);
        }

        [Fact]
        public void Create_AmountPerUom()
        {

            var calculator = RebateIncentiveFactory.Create(IncentiveType.AmountPerUom);

            Assert.IsType<AmountPerUom>(calculator);
        }
    }
}
