using Smartwyre.DeveloperTest.Types.Enums;
using Smartwyre.DeveloperTest.Types.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartwyre.DeveloperTest.Types.Factory
{
    public class RebateIncentiveFactory
    {
        public static IRebateIncentiveCalculator Create(IncentiveType incentiveType)
        {
            return incentiveType switch
            {
                IncentiveType.FixedCashAmount => new FixedCashAmount(),
                IncentiveType.FixedRateRebate => new FixedRateRebate(),
                IncentiveType.AmountPerUom => new AmountPerUom(),
                _ => null
            };
        }
    }
}
