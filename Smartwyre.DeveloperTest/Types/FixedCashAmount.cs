using Smartwyre.DeveloperTest.Models;
using Smartwyre.DeveloperTest.Models.Rest;
using Smartwyre.DeveloperTest.Types.Enums;
using Smartwyre.DeveloperTest.Types.Interfaces;

namespace Smartwyre.DeveloperTest.Types
{
    public class FixedCashAmount : IRebateIncentiveCalculator
    {
        public bool CalculateRebate(Product product, Rebate rebate, CalculateRebateRequest request, out decimal rebateAmount)
        {
            rebateAmount = 0;
            if (!product.SupportedIncentives.HasFlag(SupportedIncentiveType.FixedCashAmount) || rebate.Amount == 0)
            {
                return false;
            }

            rebateAmount = rebate.Amount;
            return true;
        }
    }
}