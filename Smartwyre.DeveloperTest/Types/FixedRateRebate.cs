using Smartwyre.DeveloperTest.Models;
using Smartwyre.DeveloperTest.Models.Rest;
using Smartwyre.DeveloperTest.Types.Enums;
using Smartwyre.DeveloperTest.Types.Interfaces;

namespace Smartwyre.DeveloperTest.Types
{
    public class FixedRateRebate : IRebateIncentiveCalculator
    {
        public bool CalculateRebate(Product product, Rebate rebate, CalculateRebateRequest request, out decimal rebateAmount)
        {
            rebateAmount = 0;
            if (product == null || !product.SupportedIncentives.HasFlag(SupportedIncentiveType.FixedRateRebate) ||
                rebate.Percentage == 0 || product.Price == 0 || request.Volume == 0)
            {
                return false;
            }

            rebateAmount = product.Price * rebate.Percentage * request.Volume;
            return true;
        }
    }
}