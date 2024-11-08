using Smartwyre.DeveloperTest.Data.Interfaces;
using Smartwyre.DeveloperTest.Models;
using Smartwyre.DeveloperTest.Models.Rest;
using Smartwyre.DeveloperTest.Services.Interfaces;
using Smartwyre.DeveloperTest.Types.Factory;
using Smartwyre.DeveloperTest.Types.Interfaces;

namespace Smartwyre.DeveloperTest.Types;

public class RebateService : IRebateService
{
    private readonly IRebateDataStore _dataStore;
    private readonly IProductDataStore _productDataStore;

    public RebateService(IProductDataStore productDataStore, IRebateDataStore dataStore)
    {
        _productDataStore = productDataStore;
        _dataStore = dataStore;
    }
    public CalculateRebateResult Calculate(CalculateRebateRequest request)
    {
        //validate request ?  -> result to false
        var result = new CalculateRebateResult();

        if (request == null) return result;

        Rebate rebate = _dataStore.GetRebate(request.RebateIdentifier);
        Product product = _productDataStore.GetProduct(request.ProductIdentifier);


        decimal rebateAmount = 0;

        if (rebate == null)
            result.Success = false;
        else
        {
            IRebateIncentiveCalculator calculator = RebateIncentiveFactory.Create(rebate.Incentive);

            if (calculator is not null)
                result.Success = calculator.CalculateRebate(product, rebate, request, out rebateAmount);
        }

        if (result.Success)
            _dataStore.StoreCalculationResult(rebate, rebateAmount);

        return result;
    }
}
