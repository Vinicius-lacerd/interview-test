﻿namespace Smartwyre.DeveloperTest.Models.Rest;

public class CalculateRebateRequest
{
    public string RebateIdentifier { get; set; }

    public string ProductIdentifier { get; set; }

    public decimal Volume { get; set; }
}
