using Smartwyre.DeveloperTest.Models.Rest;

namespace Smartwyre.DeveloperTest.Services.Interfaces;

public interface IRebateService
{
    CalculateRebateResult Calculate(CalculateRebateRequest request);
}
