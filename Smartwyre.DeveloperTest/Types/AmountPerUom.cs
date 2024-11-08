using Smartwyre.DeveloperTest.Models;
using Smartwyre.DeveloperTest.Models.Rest;
using Smartwyre.DeveloperTest.Types.Enums;
using Smartwyre.DeveloperTest.Types.Interfaces;

namespace Smartwyre.DeveloperTest.Types
{
    public class AmountPerUom : IRebateIncentiveCalculator
    {
        public bool CalculateRebate(Product product, Rebate rebate, CalculateRebateRequest request, out decimal rebateAmount)
        {
            rebateAmount = 0;

            if (product == null || !product.SupportedIncentives.HasFlag(SupportedIncentiveType.AmountPerUom)
                || rebate.Amount == 0 || request.Volume == 0)
                return false;

            rebateAmount = rebate.Amount * request.Volume;
            return true;
        }
    }
}