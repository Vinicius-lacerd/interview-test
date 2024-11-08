using Smartwyre.DeveloperTest.Models;
using Smartwyre.DeveloperTest.Models.Rest;

namespace Smartwyre.DeveloperTest.Types.Interfaces
{
    public interface IRebateIncentiveCalculator
    {
        bool CalculateRebate(Product product, Rebate rebate, CalculateRebateRequest request, out decimal rebateAmount);

    }
}
